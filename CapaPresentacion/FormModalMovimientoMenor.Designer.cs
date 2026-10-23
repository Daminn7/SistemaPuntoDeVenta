namespace CapaPresentacion
{
    partial class FormModalMovimientoMenor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.PFranjaColor = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LSubtitulo = new System.Windows.Forms.Label();
            this.LTipo = new System.Windows.Forms.Label();
            this.TBTipo = new System.Windows.Forms.TextBox();
            this.LMonto = new System.Windows.Forms.Label();
            this.TBMonto = new System.Windows.Forms.TextBox();
            this.LMotivo = new System.Windows.Forms.Label();
            this.TBMotivo = new System.Windows.Forms.TextBox();
            this.BRegistrar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PFranjaColor
            // 
            this.PFranjaColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PFranjaColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.PFranjaColor.Location = new System.Drawing.Point(0, 0);
            this.PFranjaColor.Name = "PFranjaColor";
            this.PFranjaColor.Size = new System.Drawing.Size(6, 300);
            this.PFranjaColor.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTitulo.Location = new System.Drawing.Point(22, 16);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(280, 25);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "REGISTRAR MOVIMIENTO";
            // 
            // LSubtitulo
            // 
            this.LSubtitulo.AutoSize = true;
            this.LSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.LSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.LSubtitulo.Location = new System.Drawing.Point(23, 42);
            this.LSubtitulo.Name = "LSubtitulo";
            this.LSubtitulo.Size = new System.Drawing.Size(300, 17);
            this.LSubtitulo.TabIndex = 2;
            this.LSubtitulo.Text = "Movimiento de efectivo en gaveta";
            // 
            // LTipo
            // 
            this.LTipo.AutoSize = true;
            this.LTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTipo.ForeColor = System.Drawing.Color.White;
            this.LTipo.Location = new System.Drawing.Point(22, 75);
            this.LTipo.Name = "LTipo";
            this.LTipo.Size = new System.Drawing.Size(44, 20);
            this.LTipo.TabIndex = 3;
            this.LTipo.Text = "Tipo:";
            // 
            // TBTipo
            // 
            this.TBTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.TBTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.TBTipo.ForeColor = System.Drawing.Color.White;
            this.TBTipo.Location = new System.Drawing.Point(25, 98);
            this.TBTipo.Name = "TBTipo";
            this.TBTipo.ReadOnly = true;
            this.TBTipo.Size = new System.Drawing.Size(340, 30);
            this.TBTipo.TabIndex = 4;
            this.TBTipo.TabStop = false;
            // 
            // LMonto
            // 
            this.LMonto.AutoSize = true;
            this.LMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LMonto.ForeColor = System.Drawing.Color.White;
            this.LMonto.Location = new System.Drawing.Point(22, 140);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(180, 20);
            this.LMonto.TabIndex = 5;
            this.LMonto.Text = "Importe ($): *";
            // 
            // TBMonto
            // 
            this.TBMonto.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBMonto.Location = new System.Drawing.Point(25, 163);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.Size = new System.Drawing.Size(340, 32);
            this.TBMonto.TabIndex = 6;
            this.TBMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBMonto_KeyPress);
            // 
            // LMotivo
            // 
            this.LMotivo.AutoSize = true;
            this.LMotivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LMotivo.ForeColor = System.Drawing.Color.White;
            this.LMotivo.Location = new System.Drawing.Point(22, 205);
            this.LMotivo.Name = "LMotivo";
            this.LMotivo.Size = new System.Drawing.Size(230, 20);
            this.LMotivo.TabIndex = 7;
            this.LMotivo.Text = "Concepto / Justificación: *";
            // 
            // TBMotivo
            // 
            this.TBMotivo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBMotivo.Location = new System.Drawing.Point(25, 228);
            this.TBMotivo.Name = "TBMotivo";
            this.TBMotivo.Size = new System.Drawing.Size(340, 29);
            this.TBMotivo.TabIndex = 8;
            // 
            // BRegistrar
            // 
            this.BRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRegistrar.FlatAppearance.BorderSize = 0;
            this.BRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BRegistrar.ForeColor = System.Drawing.Color.White;
            this.BRegistrar.Location = new System.Drawing.Point(150, 275);
            this.BRegistrar.Name = "BRegistrar";
            this.BRegistrar.Size = new System.Drawing.Size(105, 34);
            this.BRegistrar.TabIndex = 9;
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
            this.BCancelar.Location = new System.Drawing.Point(265, 275);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(100, 34);
            this.BCancelar.TabIndex = 10;
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
            this.ClientSize = new System.Drawing.Size(390, 330);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BRegistrar);
            this.Controls.Add(this.TBMotivo);
            this.Controls.Add(this.LMotivo);
            this.Controls.Add(this.TBMonto);
            this.Controls.Add(this.LMonto);
            this.Controls.Add(this.TBTipo);
            this.Controls.Add(this.LTipo);
            this.Controls.Add(this.LSubtitulo);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.PFranjaColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModalMovimientoMenor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimiento de Caja";
            this.Load += new System.EventHandler(this.FormModalMovimientoMenor_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormModalMovimientoMenor_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PFranjaColor;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LSubtitulo;
        private System.Windows.Forms.Label LTipo;
        private System.Windows.Forms.TextBox TBTipo;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.TextBox TBMonto;
        private System.Windows.Forms.Label LMotivo;
        private System.Windows.Forms.TextBox TBMotivo;
        private System.Windows.Forms.Button BRegistrar;
        private System.Windows.Forms.Button BCancelar;
    }
}