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

namespace salvadorpos.Pedidos
{
    public partial class pedidos : Form
    {
        ListaProductos lista = new ListaProductos();
        listaClientes listac = new listaClientes();
        listaTerminos listat = new listaTerminos();
        public pedidos()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private async void pedidos_Load(object sender, EventArgs e)
        {
            await lista.listaProductos(comboBox6);
            await listac.listaclientes(comboBox1);
            await listat.listaterminos(comboBox3);
        }
    }
}
