using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Facturacion
{
    public partial class FacturaExport : Form
    {
        public FacturaExport()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.UtcNow;

            textBox1.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Utc.Id, "Central Standard Time").ToString();
        }

        private void FacturaExport_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
