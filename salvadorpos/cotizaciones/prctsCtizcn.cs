using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.cotizaciones
{
    public class prctsCtizcn
    {
        public string PROD { get; set; }
        public string PUNID { get; set; }
        public string CANT { get; set; }
        public string DESCT { get; set; }
        public string TOTAL { get; set; }
        public string TAX { get; set; }

        //nuevos objetos para facturaciones
        public string CODIGO { get; set; }
        public string BODEGA { get; set; }
        public string PRECIOORIGN { get; set; }
    }
}
