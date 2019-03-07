using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using salvadorpos.Modelo;
namespace salvadorpos.Bodegas
{
    public partial class bod : Form
    {
        public bod()
        {
            InitializeComponent();
        }

        private void bod_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception r)
            {
                mensajes.err(r);
            }
         
        }
    }
}
