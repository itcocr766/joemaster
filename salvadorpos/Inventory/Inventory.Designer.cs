namespace salvadorpos.Bodegas
{
    partial class Inventory
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
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.lblItemId = new System.Windows.Forms.Label();
            this.cboBodegas = new System.Windows.Forms.ComboBox();
            this.lblBodegas = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(82, 42);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 0;
            // 
            // lblItemId
            // 
            this.lblItemId.AutoSize = true;
            this.lblItemId.Location = new System.Drawing.Point(25, 49);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(41, 13);
            this.lblItemId.TabIndex = 1;
            this.lblItemId.Text = "Item ID";
            // 
            // cboBodegas
            // 
            this.cboBodegas.FormattingEnabled = true;
            this.cboBodegas.Location = new System.Drawing.Point(82, 83);
            this.cboBodegas.Name = "cboBodegas";
            this.cboBodegas.Size = new System.Drawing.Size(121, 21);
            this.cboBodegas.TabIndex = 2;
            // 
            // lblBodegas
            // 
            this.lblBodegas.AutoSize = true;
            this.lblBodegas.Location = new System.Drawing.Point(28, 86);
            this.lblBodegas.Name = "lblBodegas";
            this.lblBodegas.Size = new System.Drawing.Size(49, 13);
            this.lblBodegas.TabIndex = 3;
            this.lblBodegas.Text = "Bodegas";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(286, 83);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(234, 86);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 5;
            this.lblCantidad.Text = "Cantidad";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblBodegas);
            this.Controls.Add(this.cboBodegas);
            this.Controls.Add(this.lblItemId);
            this.Controls.Add(this.txtItemId);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.ComboBox cboBodegas;
        private System.Windows.Forms.Label lblBodegas;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
    }
}