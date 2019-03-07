using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Modelo
{
    class listaTerminos
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString list;
        public async Task listaterminos(ComboBox c)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString();
                    list = soap.ListaTerminos();

                    c.Invoke(new MethodInvoker(delegate {

                        for (int i = 0; i < list.Count; i++)
                        {
                            c.Items.Add(list[i]);
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
    }

}
