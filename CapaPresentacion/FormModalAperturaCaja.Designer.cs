namespace CapaPresentacion
{
    partial class FormModalAperturaCaja
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
            this.PFranjaVerde = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.LMonto = new System.Windows.Forms.Label();
            this.TBMontoApertura = new System.Windows.Forms.TextBox();
            this.BAbrir = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PFranjaVerde
            // 
            this.PFranjaVerde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.PFranjaVerde.Dock = System.Windows.Forms.DockStyle.Left;
            this.PFranjaVerde.Location = new System.Drawing.Point(0, 0);
            this.PFranjaVerde.Name = "PFranjaVerde";
            this.PFranjaVerde.Size = new System.Drawing.Size(6, 175);
            this.PFranjaVerde.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.LTitulo.Location = new System.Drawing.Point(22, 16);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(225, 25);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "APERTURA DE TURNO";
            // 
            // LMonto
            // 
            this.LMonto.AutoSize = true;
            this.LMonto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LMonto.ForeColor = System.Drawing.Color.White;
            this.LMonto.Location = new System.Drawing.Point(22, 50);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(242, 20);
            this.LMonto.TabIndex = 2;
            this.LMonto.Text = "Fondo Inicial / Cambio en Caja ($):";
            // 
            // TBMontoApertura
            // 
            this.TBMontoApertura.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBMontoApertura.Location = new System.Drawing.Point(25, 75);
            this.TBMontoApertura.Name = "TBMontoApertura";
            this.TBMontoApertura.Size = new System.Drawing.Size(330, 32);
            this.TBMontoApertura.TabIndex = 3;
            this.TBMontoApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TBMontoApertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBMontoApertura_KeyPress);
            // 
            // BAbrir
            // 
            this.BAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAbrir.FlatAppearance.BorderSize = 0;
            this.BAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAbrir.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BAbrir.ForeColor = System.Drawing.Color.White;
            this.BAbrir.Location = new System.Drawing.Point(145, 122);
            this.BAbrir.Name = "BAbrir";
            this.BAbrir.Size = new System.Drawing.Size(105, 34);
            this.BAbrir.TabIndex = 4;
            this.BAbrir.Text = "Iniciar Turno";
            this.BAbrir.UseVisualStyleBackColor = false;
            this.BAbrir.Click += new System.EventHandler(this.BAbrir_Click);
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
            this.BCancelar.Location = new System.Drawing.Point(260, 122);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(95, 34);
            this.BCancelar.TabIndex = 5;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // FormModalAperturaCaja
            // 
            this.AcceptButton = this.BAbrir;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(380, 175);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BAbrir);
            this.Controls.Add(this.TBMontoApertura);
            this.Controls.Add(this.LMonto);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.PFranjaVerde);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModalAperturaCaja";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Apertura de Turno";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormModalAperturaCaja_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PFranjaVerde;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.TextBox TBMontoApertura;
        private System.Windows.Forms.Button BAbrir;
        private System.Windows.Forms.Button BCancelar;
    }
}