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
            this.FLPModulos = new System.Windows.Forms.FlowLayoutPanel();
            this.BMenuVentas = new System.Windows.Forms.Button();
            this.BMenuClientes = new System.Windows.Forms.Button();
            this.BMenuProductos = new System.Windows.Forms.Button();
            this.BMenuCaja = new System.Windows.Forms.Button();
            this.BMenuCompras = new System.Windows.Forms.Button();
            this.BMenuProveedores = new System.Windows.Forms.Button();
            this.BMenuUsuarios = new System.Windows.Forms.Button();
            this.BMenuReportes = new System.Windows.Forms.Button();
            this.BMenuMisVentas = new System.Windows.Forms.Button();
            this.PContenedor = new System.Windows.Forms.Panel();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PCabecera.SuspendLayout();
            this.PMenu.SuspendLayout();
            this.FLPModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCabecera
            // 
            this.PCabecera.BackColor = System.Drawing.Color.FromArgb(26, 29, 32);
            this.PCabecera.Controls.Add(this.LFechaHora);
            this.PCabecera.Controls.Add(this.BCerrarSesion);
            this.PCabecera.Controls.Add(this.LUsuarioInfo);
            this.PCabecera.Controls.Add(this.LTitulo);
            this.PCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCabecera.Location = new System.Drawing.Point(0, 0);
            this.PCabecera.Name = "PCabecera";
            this.PCabecera.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.PCabecera.Size = new System.Drawing.Size(1330, 60);
            this.PCabecera.TabIndex = 0;
            // 
            // LTitulo (Funciona como Botón de Inicio / Dashboard)
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LTitulo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53); // Ocre institucional
            this.LTitulo.Location = new System.Drawing.Point(18, 14);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(200, 35);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "HIERRO Y FORJA";
            this.LTitulo.Click += new System.EventHandler(this.BMenuDashboard_Click);
            // 
            // LUsuarioInfo
            // 
            this.LUsuarioInfo.AutoSize = true;
            this.LUsuarioInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuarioInfo.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.LUsuarioInfo.Location = new System.Drawing.Point(235, 20);
            this.LUsuarioInfo.Name = "LUsuarioInfo";
            this.LUsuarioInfo.Size = new System.Drawing.Size(140, 21);
            this.LUsuarioInfo.TabIndex = 1;
            this.LUsuarioInfo.Text = "Usuario | Rol";
            // 
            // LFechaHora
            // 
            this.LFechaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LFechaHora.AutoSize = true;
            this.LFechaHora.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFechaHora.ForeColor = System.Drawing.Color.FromArgb(170, 175, 180);
            this.LFechaHora.Location = new System.Drawing.Point(920, 20);
            this.LFechaHora.Name = "LFechaHora";
            this.LFechaHora.Size = new System.Drawing.Size(180, 21);
            this.LFechaHora.TabIndex = 3;
            this.LFechaHora.Text = "🕒 00:00:00  •  00/00/0000";
            // 
            // BCerrarSesion (Botón estilizado)
            // 
            this.BCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BCerrarSesion.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 57, 43); // Borde sutil rojo
            this.BCerrarSesion.FlatAppearance.BorderSize = 1;
            this.BCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.BCerrarSesion.Location = new System.Drawing.Point(1175, 12);
            this.BCerrarSesion.Name = "BCerrarSesion";
            this.BCerrarSesion.Size = new System.Drawing.Size(130, 36);
            this.BCerrarSesion.TabIndex = 2;
            this.BCerrarSesion.Text = "⏻ Cerrar Sesión";
            this.BCerrarSesion.UseVisualStyleBackColor = false;
            this.BCerrarSesion.Click += new System.EventHandler(this.BCerrarSesion_Click);
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.PMenu.Controls.Add(this.FLPModulos);
            this.PMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PMenu.Location = new System.Drawing.Point(0, 60);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(1330, 78);
            this.PMenu.TabIndex = 1;
            // 
            // FLPModulos (Flujo horizontal uniforme para todos los botones)
            // 
            this.FLPModulos.BackColor = System.Drawing.Color.Transparent;
            this.FLPModulos.Controls.Add(this.BMenuVentas);
            this.FLPModulos.Controls.Add(this.BMenuClientes);
            this.FLPModulos.Controls.Add(this.BMenuProductos);
            this.FLPModulos.Controls.Add(this.BMenuCaja);
            this.FLPModulos.Controls.Add(this.BMenuCompras);
            this.FLPModulos.Controls.Add(this.BMenuProveedores);
            this.FLPModulos.Controls.Add(this.BMenuUsuarios);
            this.FLPModulos.Controls.Add(this.BMenuReportes);
            this.FLPModulos.Controls.Add(this.BMenuMisVentas);
            this.FLPModulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPModulos.Location = new System.Drawing.Point(0, 0);
            this.FLPModulos.Name = "FLPModulos";
            this.FLPModulos.Padding = new System.Windows.Forms.Padding(12, 10, 12, 0);
            this.FLPModulos.Size = new System.Drawing.Size(1330, 78);
            this.FLPModulos.TabIndex = 0;
            this.FLPModulos.WrapContents = false;
            // 
            // BMenuVentas
            // 
            this.BMenuVentas.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuVentas.FlatAppearance.BorderSize = 0;
            this.BMenuVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuVentas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuVentas.ForeColor = System.Drawing.Color.White;
            this.BMenuVentas.Location = new System.Drawing.Point(15, 10);
            this.BMenuVentas.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuVentas.Name = "BMenuVentas";
            this.BMenuVentas.Size = new System.Drawing.Size(136, 56);
            this.BMenuVentas.TabIndex = 0;
            this.BMenuVentas.Text = "Ventas";
            this.BMenuVentas.UseVisualStyleBackColor = false;
            this.BMenuVentas.Click += new System.EventHandler(this.BMenuVentas_Click);
            // 
            // BMenuClientes
            // 
            this.BMenuClientes.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuClientes.FlatAppearance.BorderSize = 0;
            this.BMenuClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuClientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuClientes.ForeColor = System.Drawing.Color.White;
            this.BMenuClientes.Location = new System.Drawing.Point(160, 10);
            this.BMenuClientes.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuClientes.Name = "BMenuClientes";
            this.BMenuClientes.Size = new System.Drawing.Size(136, 56);
            this.BMenuClientes.TabIndex = 1;
            this.BMenuClientes.Text = "Clientes";
            this.BMenuClientes.UseVisualStyleBackColor = false;
            this.BMenuClientes.Click += new System.EventHandler(this.BMenuClientes_Click);
            // 
            // BMenuProductos
            // 
            this.BMenuProductos.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuProductos.FlatAppearance.BorderSize = 0;
            this.BMenuProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuProductos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuProductos.ForeColor = System.Drawing.Color.White;
            this.BMenuProductos.Location = new System.Drawing.Point(305, 10);
            this.BMenuProductos.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuProductos.Name = "BMenuProductos";
            this.BMenuProductos.Size = new System.Drawing.Size(136, 56);
            this.BMenuProductos.TabIndex = 2;
            this.BMenuProductos.Text = "Catálogo";
            this.BMenuProductos.UseVisualStyleBackColor = false;
            this.BMenuProductos.Click += new System.EventHandler(this.BMenuProductos_Click);
            // 
            // BMenuCaja
            // 
            this.BMenuCaja.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuCaja.FlatAppearance.BorderSize = 0;
            this.BMenuCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuCaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuCaja.ForeColor = System.Drawing.Color.White;
            this.BMenuCaja.Location = new System.Drawing.Point(450, 10);
            this.BMenuCaja.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuCaja.Name = "BMenuCaja";
            this.BMenuCaja.Size = new System.Drawing.Size(136, 56);
            this.BMenuCaja.TabIndex = 3;
            this.BMenuCaja.Text = "Caja";
            this.BMenuCaja.UseVisualStyleBackColor = false;
            this.BMenuCaja.Click += new System.EventHandler(this.BMenuCaja_Click);
            // 
            // BMenuCompras
            // 
            this.BMenuCompras.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuCompras.FlatAppearance.BorderSize = 0;
            this.BMenuCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuCompras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuCompras.ForeColor = System.Drawing.Color.White;
            this.BMenuCompras.Location = new System.Drawing.Point(595, 10);
            this.BMenuCompras.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuCompras.Name = "BMenuCompras";
            this.BMenuCompras.Size = new System.Drawing.Size(136, 56);
            this.BMenuCompras.TabIndex = 4;
            this.BMenuCompras.Text = "Compras";
            this.BMenuCompras.UseVisualStyleBackColor = false;
            this.BMenuCompras.Click += new System.EventHandler(this.BMenuCompras_Click);
            // 
            // BMenuProveedores
            // 
            this.BMenuProveedores.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuProveedores.FlatAppearance.BorderSize = 0;
            this.BMenuProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuProveedores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuProveedores.ForeColor = System.Drawing.Color.White;
            this.BMenuProveedores.Location = new System.Drawing.Point(740, 10);
            this.BMenuProveedores.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuProveedores.Name = "BMenuProveedores";
            this.BMenuProveedores.Size = new System.Drawing.Size(146, 56);
            this.BMenuProveedores.TabIndex = 5;
            this.BMenuProveedores.Text = "Proveedores";
            this.BMenuProveedores.UseVisualStyleBackColor = false;
            this.BMenuProveedores.Click += new System.EventHandler(this.BMenuProveedores_Click);
            // 
            // BMenuUsuarios
            // 
            this.BMenuUsuarios.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuUsuarios.FlatAppearance.BorderSize = 0;
            this.BMenuUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuUsuarios.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuUsuarios.ForeColor = System.Drawing.Color.White;
            this.BMenuUsuarios.Location = new System.Drawing.Point(895, 10);
            this.BMenuUsuarios.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuUsuarios.Name = "BMenuUsuarios";
            this.BMenuUsuarios.Size = new System.Drawing.Size(136, 56);
            this.BMenuUsuarios.TabIndex = 6;
            this.BMenuUsuarios.Text = "Personal";
            this.BMenuUsuarios.UseVisualStyleBackColor = false;
            this.BMenuUsuarios.Click += new System.EventHandler(this.BMenuUsuarios_Click);
            // 
            // BMenuReportes
            // 
            this.BMenuReportes.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.BMenuReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuReportes.FlatAppearance.BorderSize = 0;
            this.BMenuReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMenuReportes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMenuReportes.ForeColor = System.Drawing.Color.White;
            this.BMenuReportes.Location = new System.Drawing.Point(1040, 10);
            this.BMenuReportes.Margin = new System.Windows.Forms.Padding(3, 0, 6, 0);
            this.BMenuReportes.Name = "BMenuReportes";
            this.BMenuReportes.Size = new System.Drawing.Size(136, 56);
            this.BMenuReportes.TabIndex = 7;
            this.BMenuReportes.Text = "Informes";
            this.BMenuReportes.UseVisualStyleBackColor = false;
            this.BMenuReportes.Click += new System.EventHandler(this.BMenuReportes_Click);
            // 
            // BMenuMisVentas
            // 
            this.BMenuMisVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.BMenuMisVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMenuMisVentas.FlatAppearance.BorderSize = 0;
            this.BMenuMisVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BMenuMisVentas.ForeColor = System.Drawing.Color.White;
            this.BMenuMisVentas.Location = new System.Drawing.Point(0, 0);
            this.BMenuMisVentas.Margin = new System.Windows.Forms.Padding(0);
            this.BMenuMisVentas.Name = "BMenuMisVentas";
            this.BMenuMisVentas.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.BMenuMisVentas.Size = new System.Drawing.Size(130, 48);
            this.BMenuMisVentas.TabIndex = 8;
            this.BMenuMisVentas.Text = "Mis Ventas";
            this.BMenuMisVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BMenuMisVentas.UseVisualStyleBackColor = false;
            this.BMenuMisVentas.Click += new System.EventHandler(this.BMenuMisVentas_Click);
            // 
            // PContenedor
            // 
            this.PContenedor.BackColor = System.Drawing.Color.FromArgb(242, 237, 230); // Fondo crema cálido
            this.PContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedor.Location = new System.Drawing.Point(0, 138);
            this.PContenedor.Name = "PContenedor";
            this.PContenedor.Size = new System.Drawing.Size(1330, 452);
            this.PContenedor.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1330, 590);
            this.Controls.Add(this.PContenedor);
            this.Controls.Add(this.PMenu);
            this.Controls.Add(this.PCabecera);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hierro y Forja - Sistema de Gestión Comercial";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.PCabecera.ResumeLayout(false);
            this.PCabecera.PerformLayout();
            this.PMenu.ResumeLayout(false);
            this.FLPModulos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PCabecera;
        private System.Windows.Forms.Button BCerrarSesion;
        private System.Windows.Forms.Label LUsuarioInfo;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LFechaHora;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.FlowLayoutPanel FLPModulos;
        private System.Windows.Forms.Button BMenuVentas;
        private System.Windows.Forms.Button BMenuClientes;
        private System.Windows.Forms.Button BMenuProductos;
        private System.Windows.Forms.Button BMenuCaja;
        private System.Windows.Forms.Button BMenuCompras;
        private System.Windows.Forms.Button BMenuProveedores;
        private System.Windows.Forms.Button BMenuUsuarios;
        private System.Windows.Forms.Button BMenuReportes;
        private System.Windows.Forms.Panel PContenedor;
        private System.Windows.Forms.Button BMenuMisVentas;
    }
}