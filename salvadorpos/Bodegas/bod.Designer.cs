namespace salvadorpos.Bodegas
{
    partial class bod
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
            this.lblName = new System.Windows.Forms.TextBox();
            this.btnCrearBodega = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(33, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(180, 20);
            this.lblName.TabIndex = 0;
            // 
            // btnCrearBodega
            // 
            this.btnCrearBodega.Location = new System.Drawing.Point(268, 26);
            this.btnCrearBodega.Name = "btnCrearBodega";
            this.btnCrearBodega.Size = new System.Drawing.Size(92, 35);
            this.btnCrearBodega.TabIndex = 1;
            this.btnCrearBodega.Text = "Crear Bodega";
            this.btnCrearBodega.UseVisualStyleBackColor = true;
            this.btnCrearBodega.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre de la bodega";
            // 
            // bod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 93);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearBodega);
            this.Controls.Add(this.lblName);
            this.Name = "bod";
            this.Text = "bod";
            this.Load += new System.EventHandler(this.bod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblName;
        private System.Windows.Forms.Button btnCrearBodega;
        private System.Windows.Forms.Label label1;
    }
}