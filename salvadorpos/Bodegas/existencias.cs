using salvadorpos.Facturacion;
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
    public partial class existencias : Form
    {
       
       
        public existencias()
        {
            InitializeComponent();
            
        }

        private void existencias_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
