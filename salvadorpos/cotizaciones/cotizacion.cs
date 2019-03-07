using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interop.QBFC13;
using salvadorpos.Modelo;
using salvadorpos.ServiceReference1;

namespace salvadorpos.cotizaciones
{
    public partial class cotizacion : Form
    {
        List<prctsCtizcn> listaDGV = new List<prctsCtizcn>();
        Compartidas.Operaciones operac = new Compartidas.Operaciones();
        Compartidas.PriceLevels pricesLevel = new Compartidas.PriceLevels();
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        string tipoCliente = "";
        public cotizacion()
        {
            InitializeComponent();
        }

        #region load
        private void cotizacion_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewButtonColumn btnclm = new DataGridViewButtonColumn();
                btnclm.Name = "Eliminar";
                dgvCotz.Columns.Add(btnclm);
                ListandoProducto();
                cargaClientes();
            }
            catch (Exception)
            {
                MessageBox.Show("Parece que hubo un error de carga de datos. Favor intenta de nuevo", "UPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        #endregion

        #region cargar cliente
        private void cargaClientes()
        {
            try
            {
                List<clientes.claseClientes> lista = new List<clientes.claseClientes>();
                foreach (var x in soap.ListaClientes())
                {
                    lista.Add(new clientes.claseClientes { RazonSocial = x[3].ToString(), TipoCliente = x[35].ToString() });
                }

                cmbClientes.DisplayMember = "RazonSocial";
                cmbClientes.ValueMember = "TipoCliente";
                cmbClientes.DataSource = lista;
                cmbClientes.DropDownStyle = ComboBoxStyle.DropDown;
                cmbClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbClientes.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception e)
            {
                MessageBox.Show("Parece que hubo un error de carga de datos. Favor intenta de nuevo", "Ups!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region listar productos
        private void ListandoProducto() {
            try
            {
                prctsCtizcn myProd = new prctsCtizcn();
                string price = "0";
                string tax = "";
                myProd = new prctsCtizcn { PROD = "-- Elige un producto", CANT = "0" };
                List<prctsCtizcn> lista = new List<prctsCtizcn>();
                foreach (var x in soap.ListaArticulos())
                {
                    lista.Add(new prctsCtizcn { PROD = x[1].ToString(), PUNID = x[6].ToString() + "~" + x[5].ToString() });
                    price = x[6].ToString();
                    tax = x[5].ToString();
                }
                string selected = price + "~" + tax;
                cmbProd.DisplayMember = "PROD";
                cmbProd.ValueMember = "PUNID";
                lista.Add(myProd);
                lista = lista.OrderBy(x => x.PROD).ToList();
                cmbProd.DataSource = lista;
                //cmbProd.SelectedIndex = -1;
                cmbProd.DropDownStyle = ComboBoxStyle.DropDown;
                cmbProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProd.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception)
            {
            }
            
        }
        #endregion

        #region cambio de clientes
        private void cmbClnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            prctsCtizcn newProd = new prctsCtizcn();

            double priceLevelVar = 0;
            double precioReal = 0;
            try
            {
                tipoCliente = cmbClientes.SelectedValue.ToString();

                prctsCtizcn newPrdt = new prctsCtizcn();
                List<prctsCtizcn> prdct = new List<prctsCtizcn>();

                //guardo en una lista lo que tengo en el data grid view
                foreach (DataGridViewRow dr in dgvCotz.Rows)
                {
                    string prodName = dr.Cells[0].Value.ToString();
                    foreach (var o in soap.ListaArticulos())
                    {
                        if (o[1].ToString() == prodName)
                        {
                            priceLevelVar = Convert.ToDouble(o[6]);
                        }
                    }
                    precioReal = pricesLevel.PriceLevelsCalc(priceLevelVar, tipoCliente);
                    prdct.Add(new prctsCtizcn
                    {
                        PROD = dr.Cells[0].Value.ToString(),
                        PUNID = precioReal.ToString(),
                        CANT = dr.Cells[2].Value.ToString(),
                        DESCT = dr.Cells[3].Value.ToString(),
                        TOTAL = (precioReal * Convert.ToDouble(dr.Cells[2].Value)).ToString(),
                        TAX = dr.Cells[5].Value.ToString()
                    });


                }

                //Cargar productos
                dgvCotz.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                dgvCotz.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

                dgvCotz.Columns[0].ReadOnly = true;
                dgvCotz.Columns[1].ReadOnly = true;
                dgvCotz.Columns[4].ReadOnly = true;
                int cant = 1;
                string splitCombo = cmbProd.SelectedValue.ToString();
                char[] charSeparators = new char[] { '~' };
                string[] result;
                result = splitCombo.Split(charSeparators, StringSplitOptions.None);
                string unidPr = result[0].ToString();
                string impst = "";
                impst = result[1].ToString();
                double total = Convert.ToDouble(cant) * Convert.ToDouble(unidPr);
                listaDGV = prdct;
                dgvCotz.Rows.Clear();
                foreach (var x in listaDGV)
                {
                    string[] row0 = { x.PROD, x.PUNID, x.CANT, x.DESCT, x.TOTAL, x.TAX };
                    dgvCotz.Rows.Add(row0);
                    dgvCotz.Columns[0].DisplayIndex = 0;
                    dgvCotz.Columns[1].DisplayIndex = 1;
                    dgvCotz.Columns[2].DisplayIndex = 2;
                    dgvCotz.Columns[3].DisplayIndex = 3;
                    dgvCotz.Columns[4].DisplayIndex = 4;
                    dgvCotz.Columns[5].DisplayIndex = 5;
                }

                try
                {
                    Compartidas.totalesClass totales = new Compartidas.totalesClass();
                    totales = operaciones();
                    double descTodos = totales.descuentoEspecial + totales.descuento;
                    lbDescnt.Text = totales.descuento.ToString();
                    lbIV.Text = totales.impuestos.ToString();
                    lbSubtotal.Text = totales.subtotal.ToString();
                    lbTotal.Text = totales.total.ToString();
                }
                catch (Exception) { }

            }
            catch (Exception)
            {
            }


        }
        #endregion

        #region Cargo productos en data grid view cuando son seleccionados
        private void cmbProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            prctsCtizcn newProd = new prctsCtizcn();
            string tipoCliente = "";
            double priceLevelVar = 0;
            double precioReal = 0;
            try
            {
                tipoCliente = cmbClientes.SelectedValue.ToString();

                prctsCtizcn newPrdt = new prctsCtizcn();
                List<prctsCtizcn> prdct = new List<prctsCtizcn>();

                //guardo en una lista lo que tengo en el data grid view
                foreach (DataGridViewRow dr in dgvCotz.Rows)
                {
                    priceLevelVar = Convert.ToDouble(dr.Cells[1].Value);
                    precioReal = pricesLevel.PriceLevelsCalc(priceLevelVar, tipoCliente);
                    prdct.Add(new prctsCtizcn {
                        PROD = dr.Cells[0].Value.ToString(),
                        PUNID = precioReal.ToString(),
                        CANT = dr.Cells[2].Value.ToString(),
                        DESCT = dr.Cells[3].Value.ToString(),
                        TOTAL = dr.Cells[4].Value.ToString(),
                        TAX = dr.Cells[5].Value.ToString()
                    });


                }
                
                //Cargar productos
                dgvCotz.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                dgvCotz.CurrentCellDirtyStateChanged += new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

                dgvCotz.Columns[0].ReadOnly = true;
                dgvCotz.Columns[1].ReadOnly = true;
                dgvCotz.Columns[4].ReadOnly = true;
                int cant = 1;
                string splitCombo = cmbProd.SelectedValue.ToString();
                char[] charSeparators = new char[] { '~' };
                string[] result;
                result = splitCombo.Split(charSeparators, StringSplitOptions.None);
                string unidPr = result[0].ToString();
                precioReal = pricesLevel.PriceLevelsCalc(Convert.ToDouble(unidPr), tipoCliente);
                unidPr = precioReal.ToString();
                string impst = "";
                impst = result[1].ToString();
                if (impst.Equals("Tax"))
                {
                    impst = "13%";
                }
                else
                {
                    impst = "0%";
                }
                double total = Convert.ToDouble(cant) * Convert.ToDouble(unidPr);
                //listaDGV.Add(new prctsCtizcn { PROD = cmbProd.Text, PUNID = cmbProd.SelectedValue.ToString(), CANT = cant.ToString(), DESCT = "0", TOTAL = total.ToString() });
                newPrdt = new prctsCtizcn { PROD = cmbProd.Text, PUNID = unidPr, CANT = cant.ToString(), DESCT = "0", TOTAL = total.ToString(), TAX = impst };
                prdct.Add(newPrdt);
                listaDGV = prdct;
                dgvCotz.Rows.Clear();
                foreach (var x in listaDGV)
                {
                    string[] row0 = { x.PROD, x.PUNID, x.CANT, x.DESCT, x.TOTAL, x.TAX };
                    dgvCotz.Rows.Add(row0);
                    dgvCotz.Columns[0].DisplayIndex = 0;
                    dgvCotz.Columns[1].DisplayIndex = 1;
                    dgvCotz.Columns[2].DisplayIndex = 2;
                    dgvCotz.Columns[3].DisplayIndex = 3;
                    dgvCotz.Columns[4].DisplayIndex = 4;
                    dgvCotz.Columns[5].DisplayIndex = 5;
                }

                try
                {
                    Compartidas.totalesClass totales = new Compartidas.totalesClass();
                    totales = operaciones();
                    double descTodos = totales.descuentoEspecial + totales.descuento;
                    lbDescnt.Text = totales.descuento.ToString();
                    lbIV.Text = totales.impuestos.ToString();
                    lbSubtotal.Text = totales.subtotal.ToString();
                    lbTotal.Text = totales.total.ToString();
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
            
            
        }
        #endregion
        
        #region método para saber cuando hay un cambio en una columna del DGV
        void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvCotz.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgvCotz.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = 0;
            try
            {
                int column = e.ColumnIndex;
                row = e.RowIndex;
                string ch = dgvCotz.EditingControl.Text;
                if (column == 2)
                {
                    string price = "";
                    
                    foreach (DataGridViewRow dr in dgvCotz.Rows)
                    {
                        price = dr.Cells[1].Value.ToString();
                    }
                    double priceCnvrt = Convert.ToDouble(price);
                    
                    double change = Convert.ToInt32(ch);
                    double total = Convert.ToDouble(priceCnvrt * change);

                    //Use when column names know
                    dgvCotz.Rows[row].Cells[2].Value = ch;
                    dgvCotz.Rows[row].Cells[4].Value = total;

                    try
                    {
                        Compartidas.totalesClass totales = new Compartidas.totalesClass();
                        totales = operaciones();
                        double descTodos = 0;
                        try
                        {
                            descTodos = totales.descuentoEspecial + totales.descuento;
                            descTodos = descTodos * 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (descTodos > totales.total)
                        {
                            MessageBox.Show("El descuento aplicado supera el monto total", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvCotz.Rows[row].Cells[3].Value = "0";
                        }
                        lbDescnt.Text = totales.descuento.ToString();
                        lbIV.Text = totales.impuestos.ToString();
                        lbSubtotal.Text = totales.subtotal.ToString();
                        lbTotal.Text = totales.total.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCotz.Rows[row].Cells[3].Value = "0";
                    }
                }
                if (column == 3)
                {
                    string price = "";

                    foreach (DataGridViewRow dr in dgvCotz.Rows)
                    {
                        price = dr.Cells[1].Value.ToString();
                    }
                    double priceCnvrt = Convert.ToDouble(price);
                    double priceLevel = pricesLevel.PriceLevelsCalc(priceCnvrt, tipoCliente);
                    double descuento = Convert.ToInt32(ch);
                    double total = Convert.ToDouble(priceCnvrt - descuento);

                    //Use when column names know
                    dgvCotz.Rows[row].Cells[3].Value = ch;
                    dgvCotz.Rows[row].Cells[4].Value = total;

                    try
                    {
                        Compartidas.totalesClass totales = new Compartidas.totalesClass();
                        totales = operaciones();
                        double descTodos = 0;
                        try
                        {
                            descTodos = totales.descuentoEspecial + totales.descuento;
                            descTodos = descTodos * 1;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (descTodos > totales.total)
                        {
                            MessageBox.Show("El descuento aplicado supera el monto total", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvCotz.Rows[row].Cells[3].Value = "0";
                        }
                        lbDescnt.Text = totales.descuento.ToString();
                        lbIV.Text = totales.impuestos.ToString();
                        lbSubtotal.Text = totales.subtotal.ToString();
                        lbTotal.Text = totales.total.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvCotz.Rows[row].Cells[3].Value = "0";
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }
        #endregion

        
        // ************************************************************//


        #region operaciones de totales
        public Compartidas.totalesClass operaciones() {
            Compartidas.totalesClass returnLista = new Compartidas.totalesClass();
            
            List<prctsCtizcn> subtotales  = new List<prctsCtizcn>();
           
            if (dgvCotz.Rows.Count != 0 && dgvCotz.Rows != null)
            {
               
                for (int rows = 0; rows < dgvCotz.Rows.Count; rows++)
                {
                    subtotales.Add(new prctsCtizcn {
                        PROD = dgvCotz.Rows[rows].Cells[0].Value.ToString(),
                        PUNID = dgvCotz.Rows[rows].Cells[1].Value.ToString(),
                        CANT = dgvCotz.Rows[rows].Cells[2].Value.ToString(),
                        DESCT = dgvCotz.Rows[rows].Cells[3].Value.ToString(),
                        TAX = dgvCotz.Rows[rows].Cells[5].Value.ToString(),
                        TOTAL = dgvCotz.Rows[rows].Cells[4].Value.ToString()
                    });
                }
            }

            returnLista = operac.calcularTotales(subtotales);

            return returnLista;
        }

        #endregion
        
        #region eliminar de data grid
        private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvCotz.Columns[e.ColumnIndex].Name == "Eliminar" && e.RowIndex >= 0)
            {
                //e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = dgvCotz.Rows[e.RowIndex].Cells["Eliminar"] as DataGridViewButtonCell;

                celBoton.FlatStyle = FlatStyle.Flat;
                celBoton.Style.BackColor = Color.Red;

                e.Handled = true;
            }
        }
        private void dgvCotz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCotz.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado = MessageBox.Show("Deseas eliminar este producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {
                    dgvCotz.Rows.Remove(dgvCotz.CurrentRow);
                    try
                    {

                        List<prctsCtizcn> prdct = new List<prctsCtizcn>();

                        //guardo en una lista lo que tengo en el data grid view
                        foreach (DataGridViewRow dr in dgvCotz.Rows)
                        {
                            prdct.Add(new prctsCtizcn
                            {
                                PROD = dr.Cells[0].Value.ToString(),
                                PUNID = dr.Cells[1].Value.ToString(),
                                CANT = dr.Cells[2].Value.ToString(),
                                DESCT = dr.Cells[3].Value.ToString(),
                                TOTAL = dr.Cells[4].Value.ToString(),
                                TAX = dr.Cells[5].Value.ToString()
                            });
                        }

                        dgvCotz.Rows.Clear();
                        foreach (var x in prdct)
                        {
                            string[] row0 = { x.PROD, x.PUNID, x.CANT, x.DESCT, x.TOTAL, x.TAX };
                            dgvCotz.Rows.Add(row0);
                            dgvCotz.Columns[0].DisplayIndex = 0;
                            dgvCotz.Columns[1].DisplayIndex = 1;
                            dgvCotz.Columns[2].DisplayIndex = 2;
                            dgvCotz.Columns[3].DisplayIndex = 3;
                            dgvCotz.Columns[4].DisplayIndex = 4;
                            dgvCotz.Columns[5].DisplayIndex = 5;
                        }

                        Compartidas.totalesClass totales = new Compartidas.totalesClass();
                        totales = operaciones();
                        double descTodos = totales.descuentoEspecial + totales.descuento;
                        lbDescnt.Text = totales.descuento.ToString();
                        lbIV.Text = totales.impuestos.ToString();
                        lbSubtotal.Text = totales.subtotal.ToString();
                        lbTotal.Text = totales.total.ToString();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }
        #endregion

        #region crear cotizaciones

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                List<prctsCtizcn> prdct = new List<prctsCtizcn>();
                Compartidas.totalesClass summary = new Compartidas.totalesClass();
                envioClass envio = new envioClass();
                string subtotal = "";
                string descuentos = "";
                string impuestos = "";
                string total = "";
                //guardo en una lista lo que tengo en el data grid view
                foreach (DataGridViewRow dr in dgvCotz.Rows)
                {
                    prdct.Add(new prctsCtizcn
                    {
                        PROD = dr.Cells[0].Value.ToString(),
                        PUNID = dr.Cells[1].Value.ToString(),
                        CANT = dr.Cells[2].Value.ToString(),
                        DESCT = dr.Cells[3].Value.ToString(),
                        TOTAL = dr.Cells[4].Value.ToString(),
                        TAX = dr.Cells[5].Value.ToString()
                    });
                }
                subtotal = lbSubtotal.Text;
                descuentos = lbDescnt.Text;
                impuestos = lbIV.Text;
                total = lbTotal.Text;
                summary = new Compartidas.totalesClass
                {
                    impuestos = Convert.ToDouble(impuestos),
                    descuento = Convert.ToDouble(descuentos),
                    subtotal = Convert.ToDouble(subtotal),
                    total = Convert.ToDouble(total)
                };
                string cliente = cmbClientes.SelectedText;
                envio = new envioClass { Cliente = cliente, detalles = prdct, sumas = summary };

                dgvCotz.Rows.Clear();
            }
            catch (Exception)
            { }

        }
        #endregion

        #region limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            List<prctsCtizcn> prdct = new List<prctsCtizcn>();
            try
            {
                foreach (DataGridViewRow dr in dgvCotz.Rows)
                {
                    prdct.Add(new prctsCtizcn
                    {
                        PROD = dr.Cells[0].Value.ToString(),
                        PUNID = dr.Cells[1].Value.ToString(),
                        CANT = dr.Cells[2].Value.ToString(),
                        DESCT = dr.Cells[3].Value.ToString(),
                        TOTAL = dr.Cells[4].Value.ToString(),
                        TAX = dr.Cells[5].Value.ToString()
                    });
                }
            }
            catch (Exception)
            {

            }
            if (prdct.Count != 0)
            {
                DialogResult resultado = MessageBox.Show("¿Deseas limpiar toda la lista de productos?", "Limpiar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (resultado == DialogResult.Yes)
                {
                    dgvCotz.Rows.Clear();
                }
            }
        }
        #endregion
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        

        //public void crear()
        //{
        //    try
        //    {
        //        using (var quickbooks=new Quickbooks())
        //        {
        //            quickbooks.conectar();
                    
        //            IEstimateAdd EstimateAddRq = quickbooks.request.AppendEstimateAddRq();
        //            EstimateAddRq.CustomerRef.FullName.SetValue(comboBox1.Text);
                    
        //            //EstimateAddRq.TxnDate.SetValue(dateTimePicker1.Value);
        //            //EstimateAddRq.RefNumber.SetValue("0");
        //            EstimateAddRq.DueDate.SetValue(dateTimePicker2.Value);
        //            //EstimateAddRq.CustomerMsgRef.FullName.SetValue(richTextBox2.Text);
        //            //EstimateAddRq.SalesRepRef.FullName.SetValue(comboBox4.Text);

        //            for (int i=0;i<dgvCotz.Rows.Count;i++)
        //            {
        //                IOREstimateLineAdd OREstimateLineAddListElement15 = EstimateAddRq.OREstimateLineAddList.Append();
                        
        //                OREstimateLineAddListElement15.EstimateLineAdd.Quantity.SetValue(double.Parse(dgvCotz.Rows[i].Cells[3].Value.ToString()));
        //            }

        //            IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);

        //            quickbooks.Dispose();
        //            mensajes.inf();
        //        }
                    
        //    }
        //    catch (Exception eer)
        //    {
        //        mensajes.err(eer);

        //    }

        //}
      
        
    }
}
