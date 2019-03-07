using salvadorpos.cotizaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Compartidas
{
    public class Operaciones
    {
        public totalesClass calcularTotales(List<prctsCtizcn> data) {
            double subtotal = 0;
            double totalDesc = 0;
            double impuestos = 0;
            double totalTotal = 0;
            decimal cantidadTot = 0;
            totalesClass returnLista = new totalesClass();
            List<string> listaDesc = new List<string>();
            List<string> listaSub = new List<string>();
            List<double> listaImp = new List<double>();
            listaSub = data.Select(x => x.TOTAL).ToList();
            listaDesc = data.Select(x => x.DESCT).ToList();
            foreach (var i in listaSub)
            {
                subtotal = subtotal + Convert.ToDouble(i);
            }
            foreach (var i in listaDesc)
            {
                totalDesc = totalDesc + Convert.ToDouble(i);
            }
            foreach (var i in data)
            {
                if (i.TAX.Equals("13%"))
                {
                    impuestos = Convert.ToDouble(Convert.ToDouble(i.TOTAL) - totalDesc) * 0.13;
                    listaImp.Add(impuestos);
                }
            }
            impuestos = listaImp.Sum();
            totalTotal = (subtotal + impuestos) - totalDesc;
            returnLista = new Compartidas.totalesClass
            {
                cantidad = Math.Round(cantidadTot, 2),
                descuento = Math.Round(totalDesc, 2),
                subtotal = Math.Round(subtotal, 2),
                impuestos = Math.Round(impuestos, 2),
                total = Math.Round(totalTotal, 2),
                descuentoEspecial = 0
            };

            return returnLista;
        }
    }
}
