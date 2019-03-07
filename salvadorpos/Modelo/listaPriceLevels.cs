using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Modelo
{
    public class listaPriceLevels
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString[] list;

        public async Task listadepricelevels()
        {
            await Task.Run(() => {


                try
                {


                    list = new ArrayOfString[soap.ListaPriceLevels().Length];
                    list = soap.ListaPriceLevels();

                    foreach (var item in list)
                    {
                        switch (item[0].ToString().ToUpperInvariant())
                        {
                            case "CLIENTE CONTRATISTA":
                                Properties.Settings.Default.ClienteContratista = item[2].Replace("-","");
                                break;
                            case "CLIENTE FINAL":
                                Properties.Settings.Default.ClienteFinal = item[2].Replace("-", "");
                                break;
                            case "CLIENTE MECANICO":
                                Properties.Settings.Default.ClienteMecanico = item[2].Replace("-", "");
                                break;
                        }
                    }


                    Properties.Settings.Default.Save();


                }
                catch (Exception j)
                {
                    mensajes.err(j);
                   
                }


            });



        }


    }
}
