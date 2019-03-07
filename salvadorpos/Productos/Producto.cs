using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Productos
{
    public class Producto : IDisposable
    {
        public string id;
        public string precio;
        public string descripcion;


        public Producto(string i,string p,string d)
        {
            id = i;
            precio = p;
            descripcion = d;
        }

        public void Dispose()
        {
            id = null;
            precio = null;
            descripcion = null;
        }
    }
}
