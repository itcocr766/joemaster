using salvadorpos.Compartidas;
using salvadorpos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.impresion
{
    public class objetoimpresion
    {
        string cliente;
        string direccion;
        string nit;
        string giro;
        string ncr;
        string consecutivo;
        string vendedor;
        string condiciondepago;
        List<ListaProductos> productos;
        totalesClass totales;

        public string Cliente { get => cliente; set => cliente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Giro { get => giro; set => giro = value; }
        public string Ncr { get => ncr; set => ncr = value; }
        public string Consecutivo { get => consecutivo; set => consecutivo = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public string Condiciondepago { get => condiciondepago; set => condiciondepago = value; }
        public totalesClass Totales { get => totales; set => totales = value; }
        internal List<ListaProductos> Productos { get => productos; set => productos = value; }
    }
}
