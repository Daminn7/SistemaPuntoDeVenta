namespace CapaPresentacion
{
    partial class FormModalCategoria
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
            this.LNombre = new System.Windows.Forms.Label();
            this.TBNombreCategoria = new System.Windows.Forms.TextBox();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.TBDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.BGuardar = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PFranjaOcre
            // 
            this.PFranjaOcre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PFranjaOcre.Dock = System.Windows.Forms.DockStyle.Left;
            this.PFranjaOcre.Location = new System.Drawing.Point(0, 0);
            this.PFranjaOcre.Name = "PFranjaOcre";
            this.PFranjaOcre.Size = new System.Drawing.Size(5, 230);
            this.PFranjaOcre.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTitulo.Location = new System.Drawing.Point(22, 16);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(263, 19);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "NUEVA CATEGORÍA DE PRODUCTOS";
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LNombre.ForeColor = System.Drawing.Color.White;
            this.LNombre.Location = new System.Drawing.Point(22, 48);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(130, 15);
            this.LNombre.TabIndex = 2;
            this.LNombre.Text = "Nombre de Categoría:";
            // 
            // TBNombreCategoria
            // 
            this.TBNombreCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBNombreCategoria.Location = new System.Drawing.Point(25, 68);
            this.TBNombreCategoria.Name = "TBNombreCategoria";
            this.TBNombreCategoria.Size = new System.Drawing.Size(335, 24);
            this.TBNombreCategoria.TabIndex = 3;
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LDescripcion.ForeColor = System.Drawing.Color.White;
            this.LDescripcion.Location = new System.Drawing.Point(22, 104);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(137, 15);
            this.LDescripcion.TabIndex = 4;
            this.LDescripcion.Text = "Descripción / Detalle:";
            // 
            // TBDescripcionCategoria
            // 
            this.TBDescripcionCategoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBDescripcionCategoria.Location = new System.Drawing.Point(25, 124);
            this.TBDescripcionCategoria.Multiline = true;
            this.TBDescripcionCategoria.Name = "TBDescripcionCategoria";
            this.TBDescripcionCategoria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBDescripcionCategoria.Size = new System.Drawing.Size(335, 42);
            this.TBDescripcionCategoria.TabIndex = 5;
            // 
            // BGuardar
            // 
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BGuardar.ForeColor = System.Drawing.Color.White;
            this.BGuardar.Location = new System.Drawing.Point(160, 182);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Size = new System.Drawing.Size(95, 32);
            this.BGuardar.TabIndex = 6;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Location = new System.Drawing.Point(265, 182);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Size = new System.Drawing.Size(95, 32);
            this.BCancelar.TabIndex = 7;
            this.BCancelar.Text = "Cancelar";
            this.BCancelar.UseVisualStyleBackColor = false;
            // 
            // FormModalCategoria
            // 
            this.AcceptButton = this.BGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.CancelButton = this.BCancelar;
            this.ClientSize = new System.Drawing.Size(380, 230);
            this.Controls.Add(this.BCancelar);
            this.Controls.Add(this.BGuardar);
            this.Controls.Add(this.TBDescripcionCategoria);
            this.Controls.Add(this.LDescripcion);
            this.Controls.Add(this.TBNombreCategoria);
            this.Controls.Add(this.LNombre);
            this.Controls.Add(this.LTitulo);
            this.Controls.Add(this.PFranjaOcre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModalCategoria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Categoría";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormModalCategoria_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel PFranjaOcre;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombreCategoria;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.TextBox TBDescripcionCategoria;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.Button BCancelar;
    }
}