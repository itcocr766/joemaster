namespace salvadorpos.cotizaciones
{
    partial class cotizacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cotizacion));
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.dgvCotz = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbIV = new System.Windows.Forms.Label();
            this.lbDescnt = new System.Windows.Forms.Label();
            this.lbSubtotal = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProd = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotz)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClientes
            // 
            this.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(21, 21);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(279, 21);
            this.cmbClientes.TabIndex = 0;
            this.cmbClientes.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            this.cmbClientes.SelectedValueChanged += new System.EventHandler(this.cmbClnt_SelectedIndexChanged);
            // 
            // dgvCotz
            // 
            this.dgvCotz.AllowUserToAddRows = false;
            this.dgvCotz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCotz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCotz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCotz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.Precio,
            this.Cantidad,
            this.Descuento,
            this.Total,
            this.TAX});
            this.dgvCotz.Location = new System.Drawing.Point(12, 98);
            this.dgvCotz.Name = "dgvCotz";
            this.dgvCotz.Size = new System.Drawing.Size(1069, 382);
            this.dgvCotz.TabIndex = 13;
            this.dgvCotz.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCotz_CellContentClick);
            // 
            // Producto
            // 
            this.Producto.FillWeight = 42.63958F;
            this.Producto.HeaderText = "PROD";
            this.Producto.Name = "Producto";
            // 
            // Precio
            // 
            this.Precio.FillWeight = 42.63958F;
            this.Precio.HeaderText = "PUNID";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.FillWeight = 42.63958F;
            this.Cantidad.HeaderText = "CANT";
            this.Cantidad.Name = "Cantidad";
            // 
            // Descuento
            // 
            this.Descuento.FillWeight = 42.63958F;
            this.Descuento.HeaderText = "DESC $";
            this.Descuento.Name = "Descuento";
            // 
            // Total
            // 
            this.Total.FillWeight = 42.63958F;
            this.Total.HeaderText = "TOTAL";
            this.Total.Name = "Total";
            // 
            // TAX
            // 
            this.TAX.FillWeight = 42.63958F;
            this.TAX.HeaderText = "IMPUESTO";
            this.TAX.Name = "TAX";
            this.TAX.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Cliente";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbTotal);
            this.panel1.Controls.Add(this.lbIV);
            this.panel1.Controls.Add(this.lbDescnt);
            this.panel1.Controls.Add(this.lbSubtotal);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 486);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 100);
            this.panel1.TabIndex = 135;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbTotal.AutoSize = true;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.Color.White;
            this.lbTotal.Location = new System.Drawing.Point(139, 76);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(16, 16);
            this.lbTotal.TabIndex = 146;
            this.lbTotal.Text = "0";
            // 
            // lbIV
            // 
            this.lbIV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbIV.AutoSize = true;
            this.lbIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIV.ForeColor = System.Drawing.Color.White;
            this.lbIV.Location = new System.Drawing.Point(139, 56);
            this.lbIV.Name = "lbIV";
            this.lbIV.Size = new System.Drawing.Size(16, 16);
            this.lbIV.TabIndex = 145;
            this.lbIV.Text = "0";
            // 
            // lbDescnt
            // 
            this.lbDescnt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbDescnt.AutoSize = true;
            this.lbDescnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDescnt.ForeColor = System.Drawing.Color.White;
            this.lbDescnt.Location = new System.Drawing.Point(139, 34);
            this.lbDescnt.Name = "lbDescnt";
            this.lbDescnt.Size = new System.Drawing.Size(16, 16);
            this.lbDescnt.TabIndex = 144;
            this.lbDescnt.Text = "0";
            // 
            // lbSubtotal
            // 
            this.lbSubtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSubtotal.AutoSize = true;
            this.lbSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubtotal.ForeColor = System.Drawing.Color.White;
            this.lbSubtotal.Location = new System.Drawing.Point(139, 12);
            this.lbSubtotal.Name = "lbSubtotal";
            this.lbSubtotal.Size = new System.Drawing.Size(16, 16);
            this.lbSubtotal.TabIndex = 143;
            this.lbSubtotal.Text = "0";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(103, 34);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(16, 16);
            this.label24.TabIndex = 142;
            this.label24.Text = "$";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(15, 34);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 16);
            this.label25.TabIndex = 141;
            this.label25.Text = "Descuento";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(103, 77);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(16, 16);
            this.label23.TabIndex = 140;
            this.label23.Text = "$";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(103, 55);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 16);
            this.label22.TabIndex = 139;
            this.label22.Text = "$";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(103, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(16, 16);
            this.label21.TabIndex = 138;
            this.label21.Text = "$";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 137;
            this.label3.Text = "Total";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(65, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 136;
            this.label2.Text = "IVA";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 135;
            this.label1.Text = "Subtotal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(562, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 137;
            this.label4.Text = "Productos";
            // 
            // cmbProd
            // 
            this.cmbProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbProd.FormattingEnabled = true;
            this.cmbProd.Location = new System.Drawing.Point(383, 21);
            this.cmbProd.Name = "cmbProd";
            this.cmbProd.Size = new System.Drawing.Size(475, 21);
            this.cmbProd.TabIndex = 136;
            this.cmbProd.SelectedIndexChanged += new System.EventHandler(this.cmbProd_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.btnCrear);
            this.panel2.Controls.Add(this.btnLimpiar);
            this.panel2.Location = new System.Drawing.Point(782, 486);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 100);
            this.panel2.TabIndex = 140;
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCrear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrear.Location = new System.Drawing.Point(5, 35);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(140, 35);
            this.btnCrear.TabIndex = 141;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(151, 35);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 35);
            this.btnLimpiar.TabIndex = 142;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1113, 598);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbProd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvCotz);
            this.Controls.Add(this.cmbClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "cotizacion";
            this.Text = "?:|";
            this.Load += new System.EventHandler(this.cotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCotz)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.DataGridView dgvCotz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbIV;
        private System.Windows.Forms.Label lbDescnt;
        private System.Windows.Forms.Label lbSubtotal;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnLimpiar;
    }
}