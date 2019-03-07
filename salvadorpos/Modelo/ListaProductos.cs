using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Modelo
{
    class ListaProductos
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString[] list;

        public async Task listaProductos(DataGridView d)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaArticulos().Length];
                    list = soap.ListaArticulos();

                    d.Invoke(new MethodInvoker(delegate {

                        foreach (var s in list)
                        {
                            d.Rows.Add(s[0], s[1], s[3],s[6],s[5]);
                        }

                    }));
                }
                catch (Exception j)
                {

                    
                }


            });



        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>

        public async Task listaProductos(ComboBox c)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaArticulos().Length];
                    list = soap.ListaArticulos();

                    c.Invoke(new MethodInvoker(delegate {

                        foreach (var s in list)
                        {
                            c.Items.Add(s[1]);
                        }


                        if (c.Items.Count > 0)
                        {
                            c.SelectedIndex = 0;
                        }

                    }));



                }
                catch (Exception j)
                {

                   
                }


            });



        }


        public string listaProductos(string fullname)
        {

            string st = "";

                try
                {


                    list = new ArrayOfString[soap.ListaArticulos().Length];
                    list = soap.ListaArticulos();
                foreach (var s in list)
                {
                    if (s[1].ToUpperInvariant()==fullname)
                    {
                        st= s[0];
                    }
                }


                }
                catch (Exception j)
                {


                }



            return st;

        }



    }

}
