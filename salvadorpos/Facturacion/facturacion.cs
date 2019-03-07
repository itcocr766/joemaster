using Interop.QBFC13;
using RestSharp;
using salvadorpos.Bodegas;
using salvadorpos.clientes;
using salvadorpos.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using salvadorpos.ServiceReference1;
using salvadorpos.Productos;
using salvadorpos.cotizaciones;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace salvadorpos.Facturacion
{
    public partial class facturacion : Form
    {
        ListaProductos lista = new ListaProductos();
        listaClientes listac = new listaClientes();
        listaTerminos listat = new listaTerminos();
        
        List<prctsCtizcn> listaDGV = new List<prctsCtizcn>();
        Compartidas.PriceLevels compartir = new Compartidas.PriceLevels();
        Compartidas.PriceLevels pricesLevel = new Compartidas.PriceLevels();
        Compartidas.logicaVaria logicaVariad = new Compartidas.logicaVaria();
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        Compartidas.Operaciones operacionesInst = new Compartidas.Operaciones();
        Compartidas.retornaCambios retornoCmbs = new Compartidas.retornaCambios();

        public double monto = 0;
        string tipoCliente = "";
        public string bodega = "";
        public string impuesto = "";
        public string idarticulo = "";
        public string tipoClientePL = "";
        public string precioarticulo = "";
        public string precioOriginal = "";
        public string descripcionproducto = "";
        
        public facturacion()
        {
            InitializeComponent();
            modificaCasillas();
        }

        private async void facturacion_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Today.ToString();
            Select();
            comboBox2.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            await lista.listaProductos(comboBox6);
            await listac.listaclientes(comboBox1);
            await listat.listaterminos(comboBox3);

        }

        

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvfacturacion.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        
        //Metodos para realizar cálculos de montos totales
        #region operaciones de totales

        #region retorna una lista con los calculos, recibe una lista del data grid view
        public Compartidas.totalesClass operaciones(List<prctsCtizcn> listaDataGrid)
        {
            Compartidas.totalesClass returnLista = new Compartidas.totalesClass();

            List<prctsCtizcn> subtotales = new List<prctsCtizcn>();

            if (listaDataGrid.Count != 0)
            {
                foreach (var i in listaDataGrid)
                {
                    subtotales.Add(new prctsCtizcn
                    {
                        PROD = i.PROD,
                        PUNID = i.PUNID,
                        CANT = i.CANT,
                        DESCT = i.DESCT,
                        TAX = i.TAX,
                        TOTAL = i.TOTAL
                    });
                }
            }

            returnLista = operacionesInst.calcularTotales(subtotales);

            return returnLista;
            //dataGridView1.Rows.Add(returnLista);
        }
        #endregion

        #region muestra los valores en los diferentes labels
        public void mostrarTotales(Compartidas.totalesClass totalParam)
        {

            double descTodos = totalParam.descuentoEspecial + totalParam.descuento;
            lbDesct.Text = totalParam.descuento.ToString();
            lbIva.Text = totalParam.impuestos.ToString();
            lbSubtotal.Text = totalParam.subtotal.ToString();
            lbTotal.Text = totalParam.total.ToString();
        }
        #endregion

        #endregion

        #region metodo para recorrer DGV y guardarlo en una lista
        public List<prctsCtizcn> listaDataGV()
        {
            string value = comboBox1.DisplayMember.ToString();
            return logicaVariad.listaDataGV(dgvfacturacion, value);
        }
        #endregion

        #region metodo para reccorer DGV cuando se cambia cantidad o descuento
        public List<prctsCtizcn> listaDgvCambio()
        {
            List<prctsCtizcn> prdct = new List<prctsCtizcn>();
            double priceLevelVar = 0;
            double precioReal = 0;
            string value = comboBox1.DisplayMember.ToString();
            //guardo en una lista lo que tengo en el data grid view
            foreach (DataGridViewRow dr in dgvfacturacion.Rows)
            {
                string prodName = dr.Cells[1].Value.ToString();
                foreach (var o in soap.ListaArticulos())
                {
                    if (o[1].ToString() == prodName)
                    {
                        priceLevelVar = Convert.ToDouble(o[6]);
                        break;
                    }
                }
                precioReal = pricesLevel.PriceLevelsCalc(priceLevelVar, value);
                //guarda los porductos que ya existen en una nueva lista
                prdct.Add(new prctsCtizcn
                {
                    PROD = dr.Cells[1].Value.ToString(),
                    PUNID = precioReal.ToString(),
                    CANT = dr.Cells[3].Value.ToString(),
                    DESCT = dr.Cells[7].Value.ToString(),
                    TOTAL = (precioReal * Convert.ToDouble(dr.Cells[3].Value)).ToString(),
                    TAX = dr.Cells[6].Value.ToString(),
                    CODIGO = dr.Cells[0].Value.ToString(),
                    BODEGA = dr.Cells[2].Value.ToString(),
                    PRECIOORIGN = dr.Cells["OriginalPrice"].Value.ToString()
                });

            }
            return prdct;
        }
        #endregion

        #region cambio de clientes
        private void cmbClnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            prctsCtizcn newProd = new prctsCtizcn();
            
            try
            {
                tipoCliente = comboBox1.DisplayMember.ToString();
                
                prctsCtizcn newPrdt = new prctsCtizcn();

                //Cargar productos

                List<prctsCtizcn> prdct = new List<prctsCtizcn>();
                string value = comboBox1.DisplayMember.ToString();
                prdct = logicaVariad.listaDataGV(dgvfacturacion, value);

                //dgvfacturacion.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                dgvfacturacion.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

                dgvfacturacion.Columns[0].ReadOnly = true;
                dgvfacturacion.Columns[1].ReadOnly = true;
                dgvfacturacion.Columns[4].ReadOnly = true;
                dgvfacturacion.Rows.Clear();
                double precioNormal = 0;
                foreach (var i in prdct)
                {
                    precioNormal = Convert.ToDouble(i.PRECIOORIGN);
                }
                double nuevoPrecio = pricesLevel.PriceLevelsCalc(precioNormal, tipoCliente);

                foreach (var x in prdct)
                {
                    string[] row0 = { x.CODIGO, x.PROD, x.BODEGA, x.CANT, nuevoPrecio.ToString(), x.TOTAL, x.TAX, x.DESCT, x.PRECIOORIGN };
                    dgvfacturacion.Rows.Add(row0);
                    dgvfacturacion.Columns[0].DisplayIndex = 0;
                    dgvfacturacion.Columns[1].DisplayIndex = 1;
                    dgvfacturacion.Columns[2].DisplayIndex = 2;
                    dgvfacturacion.Columns[3].DisplayIndex = 3;
                    dgvfacturacion.Columns[4].DisplayIndex = 4;
                    dgvfacturacion.Columns[5].DisplayIndex = 5;
                    dgvfacturacion.Columns[6].DisplayIndex = 6;
                    dgvfacturacion.Columns[7].DisplayIndex = 7;
                    dgvfacturacion.Columns[8].DisplayIndex = 8;
                }

                try
                {
                    Compartidas.totalesClass totales = new Compartidas.totalesClass();
                    totales = operacionesInst.calcularTotales(prdct);
                    double descTodos = totales.descuentoEspecial + totales.descuento;
                    lbDesct.Text = totales.descuento.ToString();
                    lbIva.Text = totales.impuestos.ToString();
                    lbSubtotal.Text = totales.subtotal.ToString();
                    lbTotal.Text = totales.total.ToString();
                }
                catch (Exception b) { MessageBox.Show(b.ToString()); }

            }
            catch (Exception v)
            {
                MessageBox.Show(v.ToString());
            }


        }
        #endregion
        
        #region casillas con read only
        public void modificaCasillas() {
            try
            {
                dgvfacturacion.Columns[3].ReadOnly = false;
                dgvfacturacion.Columns[7].ReadOnly = false;
                dgvfacturacion.Columns[0].ReadOnly = true;
                dgvfacturacion.Columns[1].ReadOnly = true;
                dgvfacturacion.Columns[2].ReadOnly = true;
                dgvfacturacion.Columns[4].ReadOnly = true;
                dgvfacturacion.Columns[5].ReadOnly = true;
                dgvfacturacion.Columns[6].ReadOnly = true;
            }
            catch (Exception)
            {
            }
            
        }
        #endregion

        private void dgvfacturacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvfacturacion.Rows.Count > 0)
            {
                Compartidas.retornaCambios retorno = new Compartidas.retornaCambios();
                int row = 0;
                try
                {
                    int column = e.ColumnIndex;
                    row = e.RowIndex;
                    string ch = dgvfacturacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    string cliente = comboBox1.DisplayMember;
                    try
                    {
                        retorno = logicaVariad.cambioDGV(dgvfacturacion, column, row, ch, cliente, lbDesct, lbIva, lbSubtotal, lbTotal);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        #region metodo que detecta un cambio en la cantidad o descuento
        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        #endregion

        #region enviar factura a Quickbooks
        private void btnCrear_Click(object sender, EventArgs e)
        {
            List<prctsCtizcn> prdct = new List<prctsCtizcn>();
            string value = comboBox1.DisplayMember.ToString();
            List<envioQckbks> listaJson = new List<envioQckbks>();
            prdct = logicaVariad.listaDataGV(dgvfacturacion, value);
            string priceLevel = comboBox1.DisplayMember;
            foreach (var i in prdct)
            {
                string tieneImp = "";
                if (i.TAX.Equals("13%"))
                {
                    tieneImp = "Tax";
                }
                listaJson.Add(new envioQckbks
                {
                    fullName =i.PROD,
                    desc = "",
                    quantity = i.CANT,
                    rate = i.TOTAL,
                    ratePorcent = i.TAX.Replace("%", String.Empty),
                    salesTax = tieneImp,
                    priceLevels = priceLevel
                });
            }
            string JsonOutput = JsonConvert.SerializeObject(new { products = listaJson });
            string cliente = comboBox1.Text.ToString();
            string plantilla = comboBox2.Text.ToString();
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string dueDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            string termino = comboBox3.Text.ToString();
            string mensaje = soap.InsertaFactura("AGRO INDUSTRIALES SAN JOSE, S.A DE C.V.", plantilla, today, dueDate, dueDate, termino, "Memo", "CCF", "Mensaje", JsonOutput);
        }
        #endregion

        





        #region otras funciones

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{


        //}
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectionChangeCommitted(object sender, EventArgs e)
        {



        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox6_KeyDown(object sender, KeyEventArgs e)
        {

        }

        #region calclar de Richie
        //public void calcular()
        //{
        //    double sub = 0;
        //    double totalt = 0;
        //    double pric = 0;
        //    double descuen = 0;
        //    double can = 0;
        //    double impi = 0;
        //    double unita = 0;
        //    double totalsub = 0;
        //    double totalimp = 0;
        //    double totalvou = 0;
        //    double totaldescuen = 0;

        //    try
        //    {

        //        for (int restadescuento = 0; restadescuento < dataGridView1.Rows.Count; restadescuento++)
        //        {
        //            can = 0;
        //            pric = 0;
        //            descuen = 0;
        //            if (dataGridView1.Rows[restadescuento].Cells[9].Value.ToString() == "Tax")
        //            {
        //                can = double.Parse(dataGridView1.Rows[restadescuento].Cells[3].Value.ToString());
        //                pric = double.Parse(dataGridView1.Rows[restadescuento].Cells[4].Value.ToString());
        //                descuen = double.Parse(dataGridView1.Rows[restadescuento].Cells[11].Value.ToString());


        //                unita = Math.Round((pric + (((pric) * 13) / 100)), 2);
        //                impi = Math.Round((((pric * can) - descuen) * 13) / 100, 2);

        //                sub = Math.Round(((pric * can) - descuen), 2);
        //                totalt = Math.Round((sub + impi), 2);



        //                dataGridView1.Rows[restadescuento].Cells[6].Value = Math.Round((unita - descuen), 2);
        //                dataGridView1.Rows[restadescuento].Cells[7].Value = Math.Round(pric * can, 2);
        //                dataGridView1.Rows[restadescuento].Cells[8].Value = Math.Round(totalt, 2);


        //            }
        //            else
        //            {
        //                can = double.Parse(dataGridView1.Rows[restadescuento].Cells[3].Value.ToString());
        //                pric = double.Parse(dataGridView1.Rows[restadescuento].Cells[4].Value.ToString());
        //                descuen = double.Parse(dataGridView1.Rows[restadescuento].Cells[11].Value.ToString());


        //                unita = Math.Round((pric), 2);
        //                impi = 0;

        //                sub = Math.Round(((pric * can) - descuen), 2);
        //                totalt = Math.Round((sub + impi), 2);



        //                dataGridView1.Rows[restadescuento].Cells[6].Value = Math.Round((unita - descuen), 2);
        //                dataGridView1.Rows[restadescuento].Cells[7].Value = Math.Round(pric * can, 2);
        //                dataGridView1.Rows[restadescuento].Cells[8].Value = Math.Round(totalt, 2);

        //            }



        //        }

        //        for (int g = 0; g < dataGridView1.Rows.Count; g++)
        //        {

        //            if (dataGridView1.Rows[g].Cells[9].Value.ToString() == "Tax")
        //            {
        //                totalsub += Math.Round(((double.Parse(dataGridView1.Rows[g].Cells[8].Value.ToString())) / 1.13), 2);
        //                //totalimp += Math.Round(imp, 2);
        //                totalvou += Math.Round(double.Parse(dataGridView1.Rows[g].Cells[8].Value.ToString()), 2);
        //                totaldescuen += Math.Round(double.Parse(dataGridView1.Rows[g].Cells[11].Value.ToString()), 2);
        //                totalimp += Math.Round((((pric * can) - descuen) * 13) / 100, 2);
        //            }
        //            else
        //            {
        //                totalsub += Math.Round((double.Parse(dataGridView1.Rows[g].Cells[8].Value.ToString())), 2);
        //                //totalimp += Math.Round(imp, 2);
        //                totalvou += Math.Round(double.Parse(dataGridView1.Rows[g].Cells[8].Value.ToString()), 2);
        //                totaldescuen += Math.Round(double.Parse(dataGridView1.Rows[g].Cells[11].Value.ToString()), 2);
        //                totalimp += 0;
        //            }
        //        }

        //        txtDesct.Text = string.Format("{0:N2}", totaldescuen);
        //        txtSubtotal.Text = string.Format("{0:N2}", totalsub);
        //        txtTotal.Text = string.Format("{0:N2}", totalvou);

        //        txtIva.Text = string.Format("{0:N2}", totalimp);


        //    }
        //    catch (Exception err_0010)
        //    {
        //        mensajes.err(err_0010);

        //        if (dataGridView1.Rows.Count > 0)
        //        {
        //            txtTotal.Text = string.Format("{0:N2}", (totalt - totaldescuen));
        //            txtIva.Text = string.Format("{0:N2}", (totalimp - (totalimp / 1.13)));
        //        }
        //        else
        //        {
        //            txtTotal.Text = "0";
        //            txtIva.Text = "0";
        //        }


        //    }
        //}

        #endregion

        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void comboBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void z(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void facturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                Busqueda b = new Busqueda(this);
                b.Show();
            }
            else if (e.KeyCode == Keys.F3)
            {
                busqueda_prod bp = new busqueda_prod(this);
                bp.Show();
            }
            else if (e.KeyCode == Keys.F4)
            {
                mostrarbodegas mb = new mostrarbodegas(this);
                mb.elitem = comboBox6.Text;
                mb.Show();
            }

        }
        private void label20_Click(object sender, EventArgs e)
        {

        }


        #endregion

        
    }
}