using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handler.QuickService;

namespace Process.Clientes
{
    public class clienteProcess
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();

        public void listaClientes()
        {
            List<Handler.Clases.clienteClass> clientesLista = new List<Handler.Clases.clienteClass>();
            soap.ListaClientes();
        }
    }
}
