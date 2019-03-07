using salvadorpos.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salvadorpos.Compartidas
{
    public class PriceLevels
    {
        QuickBooksWebRestSoapClient soap = new QuickBooksWebRestSoapClient();
        public double PriceLevelsCalc(double paramPrice, string tipoCliente)
        {
            double priceDesc = 0;
            double price = 0;
            try
            {
                var levels = soap.ListaPriceLevels();
                string descuento = "";
                foreach (var x in levels)
                {
                    if (x[0].Equals(tipoCliente))
                    {
                        descuento = x[2].ToString();
                    }
                }
                descuento = descuento.Replace("-", String.Empty);
                descuento = descuento.Replace("%", String.Empty);
                try
                {
                    decimal desct = Convert.ToDecimal(descuento);
                    priceDesc = paramPrice * Convert.ToDouble(desct / 100);
                    price = Math.Round(paramPrice - priceDesc, 2);
                }
                catch (Exception)
                {
                    price = paramPrice;
                }

            }
            catch (Exception e)
            {

            }

            return price;
        }
    }
}
