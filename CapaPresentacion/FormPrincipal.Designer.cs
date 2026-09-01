namespace CapaPresentacion
{
    partial class FormPrincipal
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
            this.PCabecera = new System.Windows.Forms.Panel();
            this.LFechaHora = new System.Windows.Forms.Label();
            this.BCerrarSesion = new System.Windows.Forms.Button();
            this.LUsuarioInfo = new System.Windows.Forms.Label();
            this.LTitulo = new System.Windows.Forms.Label();
            this.PMenu = new System.Windows.Forms.Panel();
            this.BMenuReportes = new System.Windows.Forms.Button();
            this.BMenuUsuarios = new System.Windows.Forms.Button();
            this.BMenuCaja = new System.Windows.Forms.Button();
            this.BMenuProductos = new System.Windows.Forms.Button();
            this.BMenuClientes = new System.Windows.Forms.Button();
            this.BMenuVentas = new System.Windows.Forms.Button();
            this.PContenedor = new System.Windows.Forms.Panel();
            this.PCabecera.SuspendLayout();
            this.PMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCabecera
            // 
            this.PCabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.PCabecera.Controls.Add(this.LFechaHora);
            this.PCabecera.Controls.Add(this.BCerrarSesion);
            this.PCabecera.Controls.Add(this.LUsuarioInfo);
            this.PCabecera.Controls.Add(this.LTitulo);
            this.PCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCabecera.Location = new System.Drawing.Point(0, 0);
            this.PCabecera.Name = "PCabecera";
            this.PCabecera.Size = new System.Drawing.Size(1330, 60);
            this.PCabecera.TabIndex = 0;
            // 
            // LFechaHora
            // 
            this.LFechaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LFechaHora.AutoSize = true;
            this.LFechaHora.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(175)))), ((int)(((byte)(180)))));
            this.LFechaHora.Location = new System.Drawing.Point(671, 20);
            this.LFechaHora.Name = "LFechaHora";
            this.LFechaHora.Size = new System.Drawing.Size(225, 23);
            this.LFechaHora.TabIndex = 3;
            this.LFechaHora.Text = "21:00 | 27 de agosto, 2026";
            // 
            // BCerrarSesion
            // 
            this.BCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BCerrarSesion.BackColor = System.Drawing.Color.IndianRed;
            this.BCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarSesion.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BCerrarSesion.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.BCerrarSesion.Location = new System.Drawing.Point(1158, 5);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(140, 50);
            this.BCerrarSesion.TabIndex = 2;
            this.BCerrarSesion.Text = "Cerrar Sesión";
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // LUsuarioInfo
            // 
            this.LUsuarioInfo.AutoSize = true;
            this.LUsuarioInfo.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuarioInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(166)))), ((int)(((byte)(35)))));
            this.LUsuarioInfo.Location = new System.Drawing.Point(316, 22);
            this.LUsuarioInfo.Name = "LUsuarioInfo";
            this.LUsuarioInfo.Size = new System.Drawing.Size(131, 25);
            this.LUsuarioInfo.TabIndex = 1;
            this.LUsuarioInfo.Text = "Nombre | Rol";
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.Color.White;
            this.LTitulo.Location = new System.Drawing.Point(31, 12);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(197, 38);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Hierro y Forja";
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.PMenu.Controls.Add(this.BMenuReportes);
            this.PMenu.Controls.Add(this.BMenuUsuarios);
            this.PMenu.Controls.Add(this.BMenuCaja);
            this.PMenu.Controls.Add(this.BMenuProductos);
            this.PMenu.Controls.Add(this.BMenuClientes);
            this.PMenu.Controls.Add(this.BMenuVentas);
            this.PMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMenu.Location = new System.Drawing.Point(0, 60);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(1330, 90);
            this.PMenu.TabIndex = 1;
            // 
            // BMenuReportes
            // 
            this.BMenuReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuReportes.ForeColor = System.Drawing.Color.White;
            this.BMenuReportes.Location = new System.Drawing.Point(739, 11);
            this.BMenuReportes.Name = "BMenuReportes";
            this.BMenuReportes.Size = new System.Drawing.Size(140, 70);
            this.BMenuReportes.TabIndex = 5;
            this.BMenuReportes.Text = "Informes";
            this.BMenuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuReportes.UseVisualStyleBackColor = true;
            // 
            // BMenuUsuarios
            // 
            this.BMenuUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuUsuarios.ForeColor = System.Drawing.Color.White;
            this.BMenuUsuarios.Location = new System.Drawing.Point(593, 11);
            this.BMenuUsuarios.Name = "BMenuUsuarios";
            this.BMenuUsuarios.Size = new System.Drawing.Size(140, 70);
            this.BMenuUsuarios.TabIndex = 4;
            this.BMenuUsuarios.Text = "Personal y Perfiles";
            this.BMenuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuUsuarios.UseVisualStyleBackColor = true;
            // 
            // BMenuCaja
            // 
            this.BMenuCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuCaja.ForeColor = System.Drawing.Color.White;
            this.BMenuCaja.Location = new System.Drawing.Point(447, 11);
            this.BMenuCaja.Name = "BMenuCaja";
            this.BMenuCaja.Size = new System.Drawing.Size(140, 70);
            this.BMenuCaja.TabIndex = 3;
            this.BMenuCaja.Text = "Caja";
            this.BMenuCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuCaja.UseVisualStyleBackColor = true;
            // 
            // BMenuProductos
            // 
            this.BMenuProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuProductos.ForeColor = System.Drawing.Color.White;
            this.BMenuProductos.Location = new System.Drawing.Point(301, 11);
            this.BMenuProductos.Name = "BMenuProductos";
            this.BMenuProductos.Size = new System.Drawing.Size(140, 70);
            this.BMenuProductos.TabIndex = 2;
            this.BMenuProductos.Text = "Catálogo";
            this.BMenuProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuProductos.UseVisualStyleBackColor = true;
            this.BMenuProductos.Click += new System.EventHandler(this.BMenuProductos_Click);
            // 
            // BMenuClientes
            // 
            this.BMenuClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuClientes.ForeColor = System.Drawing.Color.White;
            this.BMenuClientes.Location = new System.Drawing.Point(155, 11);
            this.BMenuClientes.Name = "BMenuClientes";
            this.BMenuClientes.Size = new System.Drawing.Size(140, 70);
            this.BMenuClientes.TabIndex = 1;
            this.BMenuClientes.Text = "Clientes";
            this.BMenuClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuClientes.UseVisualStyleBackColor = true;
            // 
            // BMenuVentas
            // 
            this.BMenuVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuVentas.ForeColor = System.Drawing.Color.White;
            this.BMenuVentas.Location = new System.Drawing.Point(9, 11);
            this.BMenuVentas.Name = "BMenuVentas";
            this.BMenuVentas.Size = new System.Drawing.Size(140, 70);
            this.BMenuVentas.TabIndex = 0;
            this.BMenuVentas.Text = "Ventas";
            this.BMenuVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BMenuVentas.UseVisualStyleBackColor = true;
            // 
            // PContenedor
            // 
            this.PContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedor.ForeColor = System.Drawing.Color.White;
            this.PContenedor.Location = new System.Drawing.Point(0, 150);
            this.PContenedor.Name = "PContenedor";
            this.PContenedor.Size = new System.Drawing.Size(1330, 440);
            this.PContenedor.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(1330, 590);
            this.Controls.Add(this.PContenedor);
            this.Controls.Add(this.PMenu);
            this.Controls.Add(this.PCabecera);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema POS ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.PCabecera.ResumeLayout(false);
            this.PCabecera.PerformLayout();
            this.PMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PCabecera;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Label LUsuarioInfo;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PContenedor;
        private System.Windows.Forms.Button BMenuReportes;
        private System.Windows.Forms.Button BMenuUsuarios;
        private System.Windows.Forms.Button BMenuCaja;
        private System.Windows.Forms.Button BMenuProductos;
        private System.Windows.Forms.Button BMenuClientes;
        private System.Windows.Forms.Button BMenuVentas;
        private System.Windows.Forms.Label LFechaHora;
    }
}