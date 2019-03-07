using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Modelo
{
   public  class calculos
    {
        tipoCliente tc = new tipoCliente();
        public  double  calcularpricelevel(string tipcli,string precio)
        {
           
            try
            {
                switch (tipcli.ToUpperInvariant())
                {
                    case "CLIENTE CONTRATISTA":
                        break;
                    case "CLIENTE MECANICO":
                        break;
                    case "CLIENTE FINAL":
                        break;

                }


            }
            catch (Exception t)
            {

                mensajes.err(t);
            }


            return 0;
        }
    }
}
