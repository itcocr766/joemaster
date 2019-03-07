using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace salvadorpos.Modelo
{
    public static class mensajes
    {
        public static void err(Exception e)
        {
            MessageBox.Show(e.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }
        public static void inf()
        {
            MessageBox.Show("Solicitud procesada correctmente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



    }
}
