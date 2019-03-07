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

namespace salvadorpos.clientes
{
    public partial class Busqueda : Form
    {
        facturacion fac;
        listaClientes listac = new listaClientes();
       
        public Busqueda(facturacion f)
        {
            InitializeComponent();
            fac = f;
        }

        private async void Busqueda_Load(object sender, EventArgs e)
        {
           
            await listac.listaclientes(dataGridView1);
            dataGridView1.Select();
            
        }

        private void Busqueda_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private  void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                if (dataGridView1.Rows.Count>0)
                {
                    fac.comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    Visible = false;
                }
            }
            
            else if (e.KeyCode==Keys.Escape)
            {
                Visible = false;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
}
