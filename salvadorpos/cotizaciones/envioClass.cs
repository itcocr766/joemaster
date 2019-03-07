using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.cotizaciones
{
    public class envioClass
    {
        public string Cliente { get; set; }
        public List<prctsCtizcn> detalles { get; set; }
        public Compartidas.totalesClass sumas { get; set; }
        
    }
}
