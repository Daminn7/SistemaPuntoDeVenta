namespace CapaPresentacion
{
    partial class FormModalMovimientoMenor
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
            this.PFranjaRoja = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LMonto = new System.Windows.Forms.Label();
            this.TBMonto = new System.Windows.Forms.TextBox();
            this.LMotivo = new System.Windows.Forms.Label();
            this.TBMotivo = new System.Windows.Forms.TextBox();
            this.BRegistrar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PFranjaRoja
            // 
            this.PFranjaRoja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PFranjaRoja.Dock = System.Windows.Forms.DockStyle.Left;
            this.PFranjaRoja.Location = new System.Drawing.Point(0, 0);
            this.PFranjaRoja.Name = "PFranjaRoja";
            this.PFranjaRoja.Size = new System.Drawing.Size(6, 255);
            this.PFranjaRoja.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTitulo.Location = new System.Drawing.Point(22, 16);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(262, 25);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "RETIRO / GASTO DE CAJA";
            // 
            // LMonto
            // 
            this.LMonto.AutoSize = true;
            this.LMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LMonto.ForeColor = System.Drawing.Color.White;
            this.LMonto.Location = new System.Drawing.Point(22, 50);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(176, 20);
            this.LMonto.TabIndex = 2;
            this.LMonto.Text = "Importe a Retirar ($): *";
            // 
            // TBMonto
            // 
            this.TBMonto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBMonto.Location = new System.Drawing.Point(25, 74);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.Size = new System.Drawing.Size(340, 32);
            this.TBMonto.TabIndex = 3;
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBMonto_KeyPress);
            // 
            // LMotivo
            // 
            this.LMotivo.AutoSize = true;
            this.LMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LMotivo.ForeColor = System.Drawing.Color.White;
            this.LMotivo.Location = new System.Drawing.Point(22, 116);
            this.LMotivo.Name = "LMotivo";
            this.LMotivo.Size = new System.Drawing.Size(227, 20);
            this.LMotivo.TabIndex = 4;
            this.LMotivo.Text = "Motivo / Justificación Legal: *";
            // 
            // TBMotivo
            // 
            this.TBMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBMotivo.Location = new System.Drawing.Point(25, 138);
            this.TBMotivo.Multiline = true;
            this.TBMotivo.Name = "TBMotivo";
            this.TBMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBMotivo.Size = new System.Drawing.Size(340, 48);
            this.TBMotivo.TabIndex = 5;
            // 
            // BRegistrar
            // 
            this.BRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRegistrar.FlatAppearance.BorderSize = 0;
            this.BRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BRegistrar.ForeColor = System.Drawing.Color.White;
            this.BRegistrar.Location = new System.Drawing.Point(150, 202);
            this.BRegistrar.Name = "BRegistrar";
            this.BRegistrar.Size = new System.Drawing.Size(105, 34);
            this.BRegistrar.TabIndex = 6;
            this.BRegistrar.Text = "Registrar";
            this.BRegistrar.UseVisualStyleBackColor = false;
            this.BRegistrar.Click += new System.EventHandler(this.BRegistrar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Location = new System.Drawing.Point(265, 202);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(100, 34);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // FormModalMovimientoMenor
            // 
            this.AcceptButton = this.BRegistrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(390, 255);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BRegistrar);
            this.Controls.Add(this.TBMotivo);
            this.Controls.Add(this.LMotivo);
            this.Controls.Add(this.TBMonto);
            this.Controls.Add(this.LMonto);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.PFranjaRoja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModalMovimientoMenor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimiento Menor";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormModalMovimientoMenor_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PFranjaRoja;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.TextBox TBMonto;
        private System.Windows.Forms.Label LMotivo;
        private System.Windows.Forms.TextBox TBMotivo;
        private System.Windows.Forms.Button BRegistrar;
        private System.Windows.Forms.Button BCancelar;
    }
}