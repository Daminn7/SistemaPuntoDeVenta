namespace CapaPresentacion
{
    partial class FormModalArqueoCaja
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
            this.PFranjaOcre = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LSubtitulo = new System.Windows.Forms.Label();
            this.LEsperado = new System.Windows.Forms.Label();
            this.TBEfectivoEsperado = new System.Windows.Forms.TextBox();
            this.LReal = new System.Windows.Forms.Label();
            this.TBEfectivoReal = new System.Windows.Forms.TextBox();
            this.LDiferencia = new System.Windows.Forms.Label();
            this.TBDiferencia = new System.Windows.Forms.TextBox();
            this.LObservaciones = new System.Windows.Forms.Label();
            this.TBObservaciones = new System.Windows.Forms.TextBox();
            this.BConfirmarCierre = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PFranjaOcre
            // 
            this.PFranjaOcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PFranjaOcre.Dock = System.Windows.Forms.DockStyle.Left;
            this.PFranjaOcre.Location = new System.Drawing.Point(0, 0);
            this.PFranjaOcre.Name = "PFranjaOcre";
            this.PFranjaOcre.Size = new System.Drawing.Size(6, 430);
            this.PFranjaOcre.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTitulo.Location = new System.Drawing.Point(24, 18);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(264, 21);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "ARQUEO Y CIERRE DE TURNO";
            // 
            // LSubtitulo
            // 
            this.LSubtitulo.AutoSize = true;
            this.LSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.LSubtitulo.Location = new System.Drawing.Point(25, 42);
            this.LSubtitulo.Name = "LSubtitulo";
            this.LSubtitulo.Size = new System.Drawing.Size(296, 15);
            this.LSubtitulo.TabIndex = 2;
            this.LSubtitulo.Text = "Verificación de dinero físico en gaveta contra sistema";
            // 
            // LEsperado
            // 
            this.LEsperado.AutoSize = true;
            this.LEsperado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LEsperado.ForeColor = System.Drawing.Color.White;
            this.LEsperado.Location = new System.Drawing.Point(25, 78);
            this.LEsperado.Name = "LEsperado";
            this.LEsperado.Size = new System.Drawing.Size(182, 15);
            this.LEsperado.TabIndex = 3;
            this.LEsperado.Text = "Efectivo Teórico Esperado ($):";
            // 
            // TBEfectivoEsperado
            // 
            this.TBEfectivoEsperado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.TBEfectivoEsperado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBEfectivoEsperado.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBEfectivoEsperado.ForeColor = System.Drawing.Color.White;
            this.TBEfectivoEsperado.Location = new System.Drawing.Point(28, 98);
            this.TBEfectivoEsperado.Name = "TBEfectivoEsperado";
            this.TBEfectivoEsperado.ReadOnly = true;
            this.TBEfectivoEsperado.Size = new System.Drawing.Size(360, 27);
            this.TBEfectivoEsperado.TabIndex = 4;
            this.TBEfectivoEsperado.Text = "0,00";
            this.TBEfectivoEsperado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LReal
            // 
            this.LReal.AutoSize = true;
            this.LReal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LReal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LReal.Location = new System.Drawing.Point(25, 140);
            this.LReal.Name = "LReal";
            this.LReal.Size = new System.Drawing.Size(206, 15);
            this.LReal.TabIndex = 5;
            this.LReal.Text = "Efectivo Real en Mano (Contado): *";
            // 
            // TBEfectivoReal
            // 
            this.TBEfectivoReal.BackColor = System.Drawing.Color.White;
            this.TBEfectivoReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBEfectivoReal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TBEfectivoReal.ForeColor = System.Drawing.Color.Black;
            this.TBEfectivoReal.Location = new System.Drawing.Point(28, 160);
            this.TBEfectivoReal.Name = "TBEfectivoReal";
            this.TBEfectivoReal.Size = new System.Drawing.Size(360, 29);
            this.TBEfectivoReal.TabIndex = 6;
            this.TBEfectivoReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBEfectivoReal.TextChanged += new System.EventHandler(this.TBEfectivoReal_TextChanged);
            this.TBEfectivoReal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBEfectivoReal_KeyPress);
            // 
            // LDiferencia
            // 
            this.LDiferencia.AutoSize = true;
            this.LDiferencia.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LDiferencia.ForeColor = System.Drawing.Color.White;
            this.LDiferencia.Location = new System.Drawing.Point(25, 204);
            this.LDiferencia.Name = "LDiferencia";
            this.LDiferencia.Size = new System.Drawing.Size(183, 15);
            this.LDiferencia.TabIndex = 7;
            this.LDiferencia.Text = "Diferencia (Sobrante / Faltante):";
            // 
            // TBDiferencia
            // 
            this.TBDiferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.TBDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBDiferencia.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBDiferencia.ForeColor = System.Drawing.Color.White;
            this.TBDiferencia.Location = new System.Drawing.Point(28, 224);
            this.TBDiferencia.Name = "TBDiferencia";
            this.TBDiferencia.ReadOnly = true;
            this.TBDiferencia.Size = new System.Drawing.Size(360, 27);
            this.TBDiferencia.TabIndex = 8;
            this.TBDiferencia.Text = "0,00";
            this.TBDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LObservaciones
            // 
            this.LObservaciones.AutoSize = true;
            this.LObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LObservaciones.ForeColor = System.Drawing.Color.White;
            this.LObservaciones.Location = new System.Drawing.Point(25, 266);
            this.LObservaciones.Name = "LObservaciones";
            this.LObservaciones.Size = new System.Drawing.Size(163, 15);
            this.LObservaciones.TabIndex = 9;
            this.LObservaciones.Text = "Observaciones de Cierre:";
            // 
            // TBObservaciones
            // 
            this.TBObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBObservaciones.Location = new System.Drawing.Point(28, 286);
            this.TBObservaciones.Multiline = true;
            this.TBObservaciones.Name = "TBObservaciones";
            this.TBObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBObservaciones.Size = new System.Drawing.Size(360, 68);
            this.TBObservaciones.TabIndex = 10;
            // 
            // BConfirmarCierre
            // 
            this.BConfirmarCierre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BConfirmarCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BConfirmarCierre.FlatAppearance.BorderSize = 0;
            this.BConfirmarCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConfirmarCierre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BConfirmarCierre.ForeColor = System.Drawing.Color.White;
            this.BConfirmarCierre.Location = new System.Drawing.Point(120, 372);
            this.BConfirmarCierre.Name = "BConfirmarCierre";
            this.BConfirmarCierre.Size = new System.Drawing.Size(150, 38);
            this.BConfirmarCierre.TabIndex = 11;
            this.BConfirmarCierre.Text = "Cerrar Turno";
            this.BConfirmarCierre.UseVisualStyleBackColor = false;
            this.BConfirmarCierre.Click += new System.EventHandler(this.BConfirmarCierre_Click);
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
            this.BCancelar.Location = new System.Drawing.Point(280, 372);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(108, 38);
            this.BCancelar.TabIndex = 12;
            this.BCancelar.Text = "Volver";
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // FormModalArqueoCaja
            // 
            this.AcceptButton = this.BConfirmarCierre;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(416, 430);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BConfirmarCierre);
            this.Controls.Add(this.TBObservaciones);
            this.Controls.Add(this.LObservaciones);
            this.Controls.Add(this.TBDiferencia);
            this.Controls.Add(this.LDiferencia);
            this.Controls.Add(this.TBEfectivoReal);
            this.Controls.Add(this.LReal);
            this.Controls.Add(this.TBEfectivoEsperado);
            this.Controls.Add(this.LEsperado);
            this.Controls.Add(this.LSubtitulo);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.PFranjaOcre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModalArqueoCaja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Arqueo de Caja";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormModalArqueoCaja_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PFranjaOcre;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LSubtitulo;
        private System.Windows.Forms.Label LEsperado;
        private System.Windows.Forms.TextBox TBEfectivoEsperado;
        private System.Windows.Forms.Label LReal;
        private System.Windows.Forms.TextBox TBEfectivoReal;
        private System.Windows.Forms.Label LDiferencia;
        private System.Windows.Forms.TextBox TBDiferencia;
        private System.Windows.Forms.Label LObservaciones;
        private System.Windows.Forms.TextBox TBObservaciones;
        private System.Windows.Forms.Button BConfirmarCierre;
        private System.Windows.Forms.Button BCancelar;
    }
}