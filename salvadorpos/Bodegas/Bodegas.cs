﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salvadorpos.Bodegas
{
    public partial class Bodegas : Form
    {
        private bod createWarehouseForm;
        public Bodegas()
        {
            InitializeComponent();
            createWarehouseForm = new bod();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            createWarehouseForm.ShowDialog();
        }
    }
}
