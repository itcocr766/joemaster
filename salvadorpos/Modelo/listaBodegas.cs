using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Modelo
{
    public class listaBodegas
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString[] list;

        public async Task listabodegas(DataGridView d,string item)
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaBodegasItem(item).Length];
                    list = soap.ListaBodegasItem(item);

                    d.Invoke(new MethodInvoker(delegate {

                        foreach (var s in list)
                        {
                            d.Rows.Add(s[1], s[2], s[3]);
                        }

                    }));
                }
                catch (Exception j)
                {

                    MessageBox.Show(j.ToString());
                }


            });



        }



        public void busquedarapida(string valor,DataGridView d)
        {
            try
            {
                if (d.Rows.Count>0)
                {
                  
                    foreach (DataGridViewRow item in d.Rows)
                    {
                        foreach (DataGridViewCell i in item.Cells)
                        {
                            if (i.Value.ToString().ToLowerInvariant().Contains(valor.ToLowerInvariant()))
                            {
                                d.DefaultCellStyle.BackColor = Color.White;
                                item.DefaultCellStyle.BackColor = Color.BlueViolet;
                            }
                        }
                    }


                }
            }
            catch (Exception g)
            {

                MessageBox.Show(g.ToString());
            }
        }




    }
}
