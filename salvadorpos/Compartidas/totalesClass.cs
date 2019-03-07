using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Compartidas
{
    public class totalesClass
    {
        public decimal cantidad { get; set; }
        public double descuento { get; set; }
        public double descuentoEspecial { get; set; }
        public double subtotal { get; set; }
        public double impuestos { get; set; }
        public double total { get; set; }
    }
}
