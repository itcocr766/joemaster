using salvadorpos.cotizaciones;
using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Compartidas
{
    public class logicaVaria
    {
        //Facturacion.facturacion facturaciones = new Facturacion.facturacion();
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        Operaciones operacionesInst = new Operaciones();
        PriceLevels pricesLevel = new PriceLevels();
        PriceLevels compartir = new PriceLevels();

        

        #region recorrer data grid
        public List<prctsCtizcn> listaDataGV(DataGridView dataGridView1, string value)
        {
            List<prctsCtizcn> prdct = new List<prctsCtizcn>();
            double priceLevelVar = 0;
            double precioReal = 0;
            //string value = comboBox1.DisplayMember.ToString();
            //guardo en una lista lo que tengo en el data grid view
            foreach (DataGridViewRow dr in dataGridView1.Rows)
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
            dataGridView1.Rows.Clear();
            return prdct;
        }
        #endregion

        #region recorrer data grid espcial
        public List<prctsCtizcn> listaDgvCambio(DataGridView dataGridView1, string value)
        {
            List<prctsCtizcn> prdct = new List<prctsCtizcn>();
            string impst = "";
            string unidPr = "";
            double priceLevelVar = 0;
            double precioReal = 0;
            //guardo en una lista lo que tengo en el data grid view
            foreach (DataGridViewRow dr in dataGridView1.Rows)
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

        #region cambio en data grid
        public retornaCambios cambioDGV(DataGridView dataGridView1, int column, int row, string ch, string cliente, Label lbDesct, Label lbIva, Label lbSubtotal, Label lbTotal) {

            retornaCambios listaReturn = new retornaCambios();

            if (column == 3)
            {
                string price = "";

                
                price = dataGridView1.Rows[row].Cells[4].Value.ToString();

                double priceCnvrt = Convert.ToDouble(price);

                double change = Convert.ToInt32(ch);
                double total = Convert.ToDouble(priceCnvrt * change);
                try
                {
                    totalesClass totales = new totalesClass();
                    List<prctsCtizcn> prdct = new List<prctsCtizcn>();
                    prdct = listaDgvCambio(dataGridView1, cliente);
                    totales = operacionesInst.calcularTotales(prdct);
                    double descTodos = 0;
                    try
                    {
                        descTodos = totales.descuentoEspecial + totales.descuento;
                        descTodos = descTodos * 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (descTodos > totales.total)
                    {
                        MessageBox.Show("El descuento aplicado supera el monto total", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Rows[row].Cells[7].Value = "0";
                        total = Convert.ToDouble(price) * Convert.ToDouble(ch);
                    }
                    totales = operacionesInst.calcularTotales(prdct);
                    mostrarTotales(totales, lbDesct, lbIva, lbSubtotal, lbTotal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[row].Cells[3].Value = "0";
                }
                //Use when column names know
                //dataGridView1.Rows[row].Cells["Cantidad"].Value = ch;
                //dataGridView1.Rows[row].Cells["Total"].Value = total;
                dataGridView1.Rows[row].Cells[3].Value = ch;
                dataGridView1.Rows[row].Cells[5].Value = total;
                listaReturn = new retornaCambios { total = total.ToString(), cantidad = ch, descuento = "0" };
            }
            //si el descuento fue modificado
            if (column == 7)
            {
                string totalDg = dataGridView1.Rows[row].Cells[8].Value.ToString();
                double cantidad = Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value);

                double realPrice = pricesLevel.PriceLevelsCalc(Convert.ToDouble(totalDg), cliente);
                double totalAhora = cantidad * realPrice;
                //double priceLevel = compartir.PriceLevelsCalc(priceCnvrt, cliente);
                double descuento = Convert.ToInt32(ch);
                double total = Convert.ToDouble(totalAhora - descuento);


                try
                {
                    totalesClass totales = new totalesClass();
                    List<prctsCtizcn> prdct = new List<prctsCtizcn>();
                    prdct = listaDgvCambio(dataGridView1, cliente);
                    totales = operacionesInst.calcularTotales(prdct);
                    double descTodos = 0;
                    try
                    {
                        descTodos = totales.descuentoEspecial + totales.descuento;
                        descTodos = descTodos * 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (descTodos > totalAhora)
                    {
                        MessageBox.Show("El descuento aplicado supera el monto total", "Descuento inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        descuento = 0;
                        total = totalAhora;
                    }
                    totales = operacionesInst.calcularTotales(prdct);
                    mostrarTotales(totales, lbDesct, lbIva, lbSubtotal, lbTotal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se permiten letras en las cantidades", "Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[row].Cells[3].Value = "0";
                }
                //Use when column names know
                //dataGridView1.Rows[row].Cells[3].Value = ch;
                //dataGridView1.Rows[row].Cells[4].Value = total;
                dataGridView1.Rows[row].Cells[5].Value = total;
                dataGridView1.Rows[row].Cells[7].Value = descuento;
                listaReturn = new retornaCambios { total = total.ToString(), cantidad = ch, descuento = descuento.ToString() };
                

            }
            return listaReturn;
        }
        #endregion

        #region muestra los valores en los diferentes labels
        public void mostrarTotales(totalesClass totalParam, Label lbDesct, Label lbIva, Label lbSubtotal, Label lbTotal)
        {

            double descTodos = totalParam.descuentoEspecial + totalParam.descuento;
            lbDesct.Text = totalParam.descuento.ToString();
            lbIva.Text = totalParam.impuestos.ToString();
            lbSubtotal.Text = totalParam.subtotal.ToString();
            lbTotal.Text = totalParam.total.ToString();
        }
        #endregion
    }
}
