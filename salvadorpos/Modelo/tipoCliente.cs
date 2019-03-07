using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Modelo
{
    public class tipoCliente
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        ArrayOfString[] list;

        public  string obtenertipodecliente(string cliente)
        {
            string resultado = "";
          
                try
                {


                    list = new ArrayOfString[soap.ListaClientes().Length];
                    list = soap.ListaClientes();


                foreach (var item in list)
                {
                    if (item[3].ToString().ToUpperInvariant()==cliente.ToUpperInvariant())
                    {
                        resultado = item[17].ToString().ToUpperInvariant();
                    }
                }


                }
                catch (Exception j)
                {
                mensajes.err(j);
                    
                }

            return resultado;
        }
    }
}
