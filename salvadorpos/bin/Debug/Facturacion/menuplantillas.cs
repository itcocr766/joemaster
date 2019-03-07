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
    public partial class menuplantillas : Form
    {
        Form1 ventana;
        public menuplantillas(Form1 f)
        {
            InitializeComponent();
            ventana = f;
        }

        private void menuplantillas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ventanaamostrar(new FacturaClienteFinal(),"a");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ventanaamostrar(new FacturaExport(), "b");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ventanaamostrar(new facturacion(), "c");
        }

        public void ventanaamostrar(object sender,string window)
        {

            try
            {

                switch (window)
                {
                    case "a":
                        if (ventana.panel3.Controls.Count > 0)
                        {



                            ventana.panel3.Controls.RemoveAt(0);
                            FacturaClienteFinal c = sender as FacturaClienteFinal;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();






                        }
                        else
                        {
                            FacturaClienteFinal c = sender as FacturaClienteFinal;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();



                        }
                        break;
                    case "b":
                        if (ventana.panel3.Controls.Count > 0)
                        {



                            ventana.panel3.Controls.RemoveAt(0);
                            FacturaExport c = sender as FacturaExport;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();






                        }
                        else
                        {
                            FacturaExport c = sender as FacturaExport;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();



                        }
                        break;
                    case "c":
                        if (ventana.panel3.Controls.Count > 0)
                        {



                            ventana.panel3.Controls.RemoveAt(0);
                            facturacion c = sender as facturacion;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();






                        }
                        else
                        {
                            facturacion c = sender as facturacion;

                            c.TopLevel = false;
                            c.Dock = DockStyle.Fill;
                            ventana.panel3.Controls.Add(c);
                            ventana.panel3.Tag = c;
                            c.Show();



                        }
                        break;
                }
                

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }



    }
}
