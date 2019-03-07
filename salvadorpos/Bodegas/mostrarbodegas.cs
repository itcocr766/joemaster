
using salvadorpos.cotizaciones;
using salvadorpos.Facturacion;
using salvadorpos.Modelo;
using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Bodegas
{
    public partial class mostrarbodegas : Form
    {
        double tax = 0;
        facturacion pr;
        string precioOrig = "";
        public string elitem = "";
        listaBodegas lb = new listaBodegas();
        ListaProductos lp = new ListaProductos();
        facturacion facturaciones = new facturacion();
        Compartidas.logicaVaria logicaVariad = new Compartidas.logicaVaria();
        Compartidas.PriceLevels pricesLevels = new Compartidas.PriceLevels();
        Compartidas.Operaciones operacionesInst = new Compartidas.Operaciones();
        public mostrarbodegas(facturacion h)
        {
            InitializeComponent();
            pr = h;
        }

        private async void mostrarbodegas_Load(object sender, EventArgs e)
        {
           await lb.listabodegas(dataGridView1,lp.listaProductos(elitem)); 
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
            
           
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //operaciones para mostrar en el dataGridView
            try
            {
                prctsCtizcn nuevoProd = new prctsCtizcn();
                if (e.KeyCode==Keys.Enter)
                {
                    precioOrig = pr.precioarticulo;
                    tax = 0;
                    precioOrig = "";

                    if (pr.impuesto.Equals("Tax"))
                    {
                        tax = 13;
                    }
                    //se toman los valores de productos y bodegas para llenarlos en el data grid view
                    //pr.dataGridView1.Rows.Add(
                    //pr.idarticulo,
                    //pr.descripcionproducto,
                    //dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                    //"1",
                    //pr.precioarticulo,
                    //(Convert.ToDouble(pr.precioarticulo) * 1),
                    //tax.ToString() + "%",
                    //"0",
                    //precioOrig);
                    double precioNormal = (Convert.ToDouble(pr.precioarticulo));
                    string tipoCl = pr.comboBox1.ValueMember.ToString();
                    double nuevoPrecio = pricesLevels.PriceLevelsCalc(precioNormal , tipoCl);
                    nuevoProd = new prctsCtizcn{
                        CODIGO = pr.idarticulo,
                        PROD = pr.descripcionproducto,
                        BODEGA = dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                        CANT = "1",
                        PUNID = nuevoPrecio.ToString(),
                        TOTAL = (Convert.ToDouble(nuevoPrecio) * 1).ToString(),
                        TAX = tax.ToString() + "%",
                        DESCT = "0",
                        PRECIOORIGN = precioNormal.ToString() };

                    //tomo los valores de inmediato del DGV y realizo los nuevos cálculos dependiendo del price level
                    List<prctsCtizcn> prdct = new List<prctsCtizcn>();
                    prdct = pr.listaDataGV();
                    prdct.Add(nuevoProd);
                    //lleno de nuevo el data grid view con los nuevos valores
                    foreach (var i in prdct)
                    {
                        pr.dgvfacturacion.Rows.Add(
                        i.CODIGO,
                        i.PROD,
                        i.BODEGA,
                        i.CANT,
                        i.PUNID,
                        i.TOTAL,
                        i.TAX,
                        i.DESCT,
                        i.PRECIOORIGN);
                    }
                    
                    Compartidas.totalesClass totales = new Compartidas.totalesClass();
                    totales = operacionesInst.calcularTotales(prdct);

                    facturaciones.mostrarTotales(totales);
                }
              
               
                   
               

            }
            catch (Exception)
            {

            }

            Visible = false;
       
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            lb.busquedarapida(e.KeyChar.ToString(),dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
