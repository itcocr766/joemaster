using salvadorpos.Facturacion;
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

namespace salvadorpos.Productos
{
    public partial class busqueda_prod : Form
    {
        facturacion fac;
        ListaProductos lista = new ListaProductos();
        public busqueda_prod(facturacion f)
        {
            InitializeComponent();
            fac = f;
        }

        private async void busqueda_prod_Load(object sender, EventArgs e)
        {
            await lista.listaProductos(dataGridView1);
            dataGridView1.Select();
        }

        private  void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    fac.comboBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    fac.idarticulo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    fac.descripcionproducto = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    fac.precioarticulo=dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    fac.impuesto = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    fac.precioOriginal = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    Visible = false;
                }
            }
            
            else if (e.KeyCode == Keys.Escape)
            {
                Visible = false;
            }
        }
    }
}
