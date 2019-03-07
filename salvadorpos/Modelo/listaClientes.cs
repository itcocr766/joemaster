using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Modelo
{
    class listaClientes
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString[] list;


        public async Task listaclientes(ComboBox c)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaClientes().Length];
                    list = soap.ListaClientes();

                    c.Invoke(new MethodInvoker(delegate {

                        foreach (var s in list)
                        {
                            c.Items.Add(s[3]);
                            c.ValueMember = s[35];
                        }


                        if (c.Items.Count > 0)
                        {
                            c.SelectedIndex = 0;
                        }

                    }));



                }
                catch (Exception j)
                {

                    MessageBox.Show(j.ToString());
                }


            });



        }



        public async Task listaclientes(DataGridView d)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaClientes().Length];
                    
                    list = soap.ListaClientes();

                    d.Invoke(new MethodInvoker(delegate {

                        foreach (var s in list)
                        {
                            d.Rows.Add(s[0],s[3],s[35]);
                        }

                    }));



                }
                catch (Exception j)
                {
                    MessageBox.Show(j.ToString());

                }


            });



        }



    }

}
