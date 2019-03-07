
using salvadorpos.Compartidas;
using salvadorpos.impresion;
using salvadorpos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Facturacion
{
    public partial class FacturaClienteFinal : Form
    {
        impresiones impresion;
        ListaProductos lista = new ListaProductos();
        listaClientes listac = new listaClientes();
        listaTerminos listat = new listaTerminos();
        public FacturaClienteFinal()
        {
            InitializeComponent();
            impresion = new impresiones();

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
           
            DateTime currentTime = DateTime.UtcNow;

            textBox1.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Utc.Id, "Central Standard Time").ToString();
        }

        private async void FacturaClienteFinal_Load(object sender, EventArgs e)
        {
            timer1.Start();
            await lista.listaProductos(comboBox6);
            await listac.listaclientes(comboBox1);
            await listat.listaterminos(comboBox3);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            objetoimpresion ob = new objetoimpresion
            {
                Cliente = comboBox1.Text,
                Direccion = "",
                Nit = "",
                Giro = "",
                Ncr = "",
                Consecutivo = "",
                Vendedor = "",
                Totales = new totalesClass(),
                Condiciondepago = comboBox3.Text,
                Productos = new List<ListaProductos>()
            };

            
            impresion.crearhtml(ob);
            impresion.convertirhtmlapdf();
            impresion.imprimirpdf("mipdf.pdf");
        }
    }
}
