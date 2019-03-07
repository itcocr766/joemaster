namespace salvadorpos.Inventory
{
    partial class Item
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
            this.lblitemId = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtSubItem = new System.Windows.Forms.TextBox();
            this.lblSubItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(110, 45);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 0;
            // 
            // lblitemId
            // 
            this.lblitemId.AutoSize = true;
            this.lblitemId.Location = new System.Drawing.Point(49, 51);
            this.lblitemId.Name = "lblitemId";
            this.lblitemId.Size = new System.Drawing.Size(41, 13);
            this.lblitemId.TabIndex = 1;
            this.lblitemId.Text = "Item ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(49, 78);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nombre";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(618, 415);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(713, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtSubItem
            // 
            this.txtSubItem.Location = new System.Drawing.Point(110, 104);
            this.txtSubItem.Name = "txtSubItem";
            this.txtSubItem.Size = new System.Drawing.Size(100, 20);
            this.txtSubItem.TabIndex = 6;
            // 
            // lblSubItem
            // 
            this.lblSubItem.AutoSize = true;
            this.lblSubItem.Location = new System.Drawing.Point(49, 107);
            this.lblSubItem.Name = "lblSubItem";
            this.lblSubItem.Size = new System.Drawing.Size(49, 13);
            this.lblSubItem.TabIndex = 7;
            this.lblSubItem.Text = "Sub-Item";
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSubItem);
            this.Controls.Add(this.txtSubItem);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblitemId);
            this.Controls.Add(this.txtItemId);
            this.Name = "Item";
            this.Text = "Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.Label lblitemId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtSubItem;
        private System.Windows.Forms.Label lblSubItem;
    }
}