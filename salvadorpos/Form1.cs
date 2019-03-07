using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Interop.QBFC13;
using salvadorpos.Modelo;
using salvadorpos.cotizaciones;
using System.Runtime.InteropServices;
using salvadorpos.Productos;
using salvadorpos.Facturacion;
using salvadorpos.Bodegas;
using System.Configuration;

namespace salvadorpos
{
    public partial class Form1 : Form
    {
        //listaPriceLevels lpl = new listaPriceLevels();


        public Form1()
        {
            InitializeComponent();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            clientesform(new Clientes());
        }

        public void clientesform(object sender)
        {

            try
            {
                if (panel3.Controls.Count > 0)
                {
                    panel3.Controls.RemoveAt(0);
                    Clientes c = sender as Clientes;
                    
                        c.TopLevel = false;
                        c.Dock = DockStyle.Fill;
                        panel3.Controls.Add(c);
                        panel3.Tag = c;
                        c.Show();

                    

                       
                  

                }
                else
                {
                    Clientes c = sender as Clientes;
                    
                        c.TopLevel = false;
                        c.Dock = DockStyle.Fill;
                        panel3.Controls.Add(c);
                        panel3.Tag = c;
                        c.Show();

                    

                }

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }


        public void cotizacionesform(object sender)
        {

            try
            {
                if (panel3.Controls.Count > 0)
                {
                    panel3.Controls.RemoveAt(0);
                    cotizacion c = sender as cotizacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();






                }
                else
                {
                    cotizacion c = sender as cotizacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();



                }

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private  void Form1_Load(object sender, EventArgs e)
        {

            
            button1.Select();
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }


        public void cargarclientes()
        {
            try
            {
                //using (var quickbooks = new Quickbooks())
                //{
                //    //quickbooks.conectar();
                    //ICustomerQuery CustomerQueryRq = quickbooks.request.AppendCustomerQueryRq();
                    //CustomerQueryRq.IncludeRetElementList.Add("Name");
                    //CustomerQueryRq.IncludeRetElementList.Add("CompanyName");
                    //CustomerQueryRq.IncludeRetElementList.Add("BillAddress");
                    //CustomerQueryRq.IncludeRetElementList.Add("Email");
                    //CustomerQueryRq.IncludeRetElementList.Add("DataExtRet");
                    //CustomerQueryRq.OwnerIDList.Add("0");p




                    //IMsgSetResponse respuesta = quickbooks.sesionmanager.DoRequests(quickbooks.request);

                    //response = respuesta.ResponseList.GetAt(0);



                    //ICustomerRetList lista = response.Detail as ICustomerRetList;

                    //ICustomerRet ret;


                    //using (var context = new salvadorEntities2())
                    //{
                    //    var entities = (from p in context.Clientes
                                        
                    //                    select p).Single();


                    
                    //}


                //if (response.StatusMessage == "Status OK")
                //    {

                //        for (int i131 = 0; i131 < lista.Count; i131++)
                //        {
                //            if (lista.GetAt(i131) != null)
                //            {
                //                ret = lista.GetAt(i131);


                //                using (var sco = new TransactionScope(TransactionScopeOption.Required))
                //                {


                //                    using (var cliente = new salvadorEntities1())
                //                    {





                //                        Cliente c = new Cliente()
                //                        {

                //                            Direccion = ret.BillAddress.Addr1.GetValue(),
                //                            Razon = ret.CompanyName.GetValue(),
                //                            Email = ret.Email.GetValue(),
                //                            NIT = "n/a",
                //                            GIRO = "n/a",
                //                            NCR = "n/a",
                //                            DUI = "n/a"


                //                        };

                //                        cliente.Clientes.Add(c);
                //                        cliente.SaveChanges();



                //                    }


                //                    sco.Complete();



                //                }






                //            }//fin if


                //}





           
            

        
            }
            catch (ArgumentNullException age)
            {

                mensajes.err(age);
            }

        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            facturacionform(new facturacion());
            //ser

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg,int wParam,int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cotizacionesform(new cotizacion());
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //prodform(new productos());
        }

        public void prodform(object sender)
        {

            try
            {
                //if (panel3.Controls.Count > 0)
                //{
                //    panel3.Controls.RemoveAt(0);
                //    productos c = sender as productos;

                //    c.TopLevel = false;
                //    c.Dock = DockStyle.Fill;
                //    panel3.Controls.Add(c);
                //    panel3.Tag = c;
                //    c.Show();






                //}
                //else
                //{
                //    productos c = sender as productos;

                //    c.TopLevel = false;
                //    c.Dock = DockStyle.Fill;
                //    panel3.Controls.Add(c);
                //    panel3.Tag = c;
                //    c.Show();



                //}

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }


        public void facturacionform(object sender)
        {

            try
            {
                if (panel3.Controls.Count > 0)
                {
                    panel3.Controls.RemoveAt(0);
                    facturacion c = sender as facturacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();






                }
                else
                {
                    facturacion c = sender as facturacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();



                }

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }



        public void bodegasform(object sender)
        {

            try
            {
                if (panel3.Controls.Count > 0)
                {
                    panel3.Controls.RemoveAt(0);
                    facturacion c = sender as facturacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();






                }
                else
                {
                    facturacion c = sender as facturacion;

                    c.TopLevel = false;
                    c.Dock = DockStyle.Fill;
                    panel3.Controls.Add(c);
                    panel3.Tag = c;
                    c.Show();



                }

            }
            catch (Exception eb)
            {
                MessageBox.Show(eb.ToString());

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
     
        }

        public void creaproductoform(object sender)
        {

            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBodegas_Click(object sender, EventArgs e)
        {
           
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            //await lpl.listadepricelevels();
        }
    }
}
