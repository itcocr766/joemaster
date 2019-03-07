using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler.Clases
{
    public class clienteClass
    {
        #region propiedades
        public string NIT { get; set; }
        public string NCR { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string RazonSocial { get; set; }
        public string Correo { get; set; }
        #endregion

        #region constructor
        public clienteClass(string nit, string ncr, string dui, string tel, string rz, string corr) {
            NIT = nit;
            NCR = ncr;
            DUI = dui;
            Telefono = tel;
            RazonSocial = rz;
            Correo = corr;
        }
        #endregion
    }
}
