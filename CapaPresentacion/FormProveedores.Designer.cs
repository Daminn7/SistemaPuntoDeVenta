namespace CapaPresentacion
{
    partial class FormProveedores
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.PFondo = new System.Windows.Forms.Panel();
            this.TLPContenido = new System.Windows.Forms.TableLayoutPanel();
            this.DGVProveedores = new System.Windows.Forms.DataGridView();
            this.ColIdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLocalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.TLPFormularioEdicion = new System.Windows.Forms.TableLayoutPanel();

            this.PGrupoCuit = new System.Windows.Forms.Panel();
            this.TBCuit = new System.Windows.Forms.TextBox();
            this.LCuit = new System.Windows.Forms.Label();

            this.PGrupoRazonSocial = new System.Windows.Forms.Panel();
            this.TBRazonSocial = new System.Windows.Forms.TextBox();
            this.LRazonSocial = new System.Windows.Forms.Label();

            this.PGrupoContacto = new System.Windows.Forms.Panel();
            this.TBContacto = new System.Windows.Forms.TextBox();
            this.LContacto = new System.Windows.Forms.Label();

            this.PGrupoTelefono = new System.Windows.Forms.Panel();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();

            this.PGrupoEmail = new System.Windows.Forms.Panel();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();

            this.LSubtituloDomicilio = new System.Windows.Forms.Label();

            this.PGrupoCalle = new System.Windows.Forms.Panel();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.LCalle = new System.Windows.Forms.Label();

            this.PGrupoNro = new System.Windows.Forms.Panel();
            this.TBNro = new System.Windows.Forms.TextBox();
            this.LNroAltura = new System.Windows.Forms.Label();

            this.PGrupoProvincia = new System.Windows.Forms.Panel();
            this.CBProvincia = new System.Windows.Forms.ComboBox();
            this.LProvincia = new System.Windows.Forms.Label();

            this.PGrupoLocalidad = new System.Windows.Forms.Panel();
            this.CBLocalidad = new System.Windows.Forms.ComboBox();
            this.LLocalidad = new System.Windows.Forms.Label();

            this.PHabilitado = new System.Windows.Forms.Panel();
            this.ChBProveedorHabilitado = new System.Windows.Forms.CheckBox();

            this.PBotonesAccion = new System.Windows.Forms.Panel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.TLPBotonesMed = new System.Windows.Forms.TableLayoutPanel();
            this.BEditar = new System.Windows.Forms.Button();
            this.BDesactivar = new System.Windows.Forms.Button();
            this.TPLBotonesSup = new System.Windows.Forms.TableLayoutPanel();
            this.BNuevo = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();

            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();

            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LBuscar = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LFiltroLocalidad = new System.Windows.Forms.Label();
            this.CBFiltroLocalidad = new System.Windows.Forms.ComboBox();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();

            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();

            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProveedores)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.TLPFormularioEdicion.SuspendLayout();
            this.PGrupoCuit.SuspendLayout();
            this.PGrupoRazonSocial.SuspendLayout();
            this.PGrupoContacto.SuspendLayout();
            this.PGrupoTelefono.SuspendLayout();
            this.PGrupoEmail.SuspendLayout();
            this.PGrupoCalle.SuspendLayout();
            this.PGrupoNro.SuspendLayout();
            this.PGrupoProvincia.SuspendLayout();
            this.PGrupoLocalidad.SuspendLayout();
            this.PHabilitado.SuspendLayout();
            this.PBotonesAccion.SuspendLayout();
            this.TLPBotonesMed.SuspendLayout();
            this.TPLBotonesSup.SuspendLayout();
            this.PBarraFiltros.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();

            // 
            // PFondo
            // 
            this.PFondo.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.PFondo.Controls.Add(this.TLPContenido);
            this.PFondo.Controls.Add(this.PBarraFiltros);
            this.PFondo.Controls.Add(this.PEncabezado);
            this.PFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFondo.Location = new System.Drawing.Point(0, 0);
            this.PFondo.Name = "PFondo";
            this.PFondo.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PFondo.Size = new System.Drawing.Size(1534, 822);
            this.PFondo.TabIndex = 0;

            // 
            // PEncabezado
            // 
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(21, 15);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1492, 38);
            this.PEncabezado.TabIndex = 2;

            // 
            // PBIconoTitulo
            // 
            this.PBIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.PBIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.PBIconoTitulo.Name = "PBIconoTitulo";
            this.PBIconoTitulo.Size = new System.Drawing.Size(37, 34);
            this.PBIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoTitulo.TabIndex = 1;
            this.PBIconoTitulo.TabStop = false;

            // 
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.LTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(260, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "GESTIÓN DE PROVEEDORES";

            // 
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.LBuscar);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LFiltroLocalidad);
            this.PBarraFiltros.Controls.Add(this.CBFiltroLocalidad);
            this.PBarraFiltros.Controls.Add(this.BLimpiarFiltros);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(21, 53);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1492, 47);
            this.PBarraFiltros.TabIndex = 1;

            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LBuscar.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LBuscar.Location = new System.Drawing.Point(3, 16);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(210, 20);
            this.LBuscar.TabIndex = 0;
            this.LBuscar.Text = "Buscar por CUIT / Proveedor:";

            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBBuscar.Location = new System.Drawing.Point(220, 11);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(290, 27);
            this.TBBuscar.TabIndex = 1;

            // 
            // LFiltroLocalidad
            // 
            this.LFiltroLocalidad.AutoSize = true;
            this.LFiltroLocalidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroLocalidad.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFiltroLocalidad.Location = new System.Drawing.Point(540, 15);
            this.LFiltroLocalidad.Name = "LFiltroLocalidad";
            this.LFiltroLocalidad.Size = new System.Drawing.Size(79, 20);
            this.LFiltroLocalidad.TabIndex = 2;
            this.LFiltroLocalidad.Text = "Localidad:";

            // 
            // CBFiltroLocalidad
            // 
            this.CBFiltroLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltroLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFiltroLocalidad.Location = new System.Drawing.Point(625, 10);
            this.CBFiltroLocalidad.Name = "CBFiltroLocalidad";
            this.CBFiltroLocalidad.Size = new System.Drawing.Size(190, 28);
            this.CBFiltroLocalidad.TabIndex = 3;

            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.BLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(835, 9);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(86, 29);
            this.BLimpiarFiltros.TabIndex = 4;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;

            // 
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.DGVProveedores, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 100);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 707);
            this.TLPContenido.TabIndex = 0;

            // 
            // DGVProveedores
            // 
            this.DGVProveedores.AllowUserToAddRows = false;
            this.DGVProveedores.AllowUserToDeleteRows = false;
            this.DGVProveedores.AllowUserToResizeColumns = false;
            this.DGVProveedores.AllowUserToResizeRows = false;
            this.DGVProveedores.BackgroundColor = System.Drawing.Color.White;
            this.DGVProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVProveedores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVProveedores.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVProveedores.ColumnHeadersHeight = 32;
            this.DGVProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProveedores.EnableHeadersVisualStyles = false;
            this.DGVProveedores.GridColor = System.Drawing.Color.FromArgb(230, 233, 238);
            this.DGVProveedores.MultiSelect = false;
            this.DGVProveedores.ReadOnly = true;
            this.DGVProveedores.RowHeadersVisible = false;
            this.DGVProveedores.RowHeadersWidth = 51;
            this.DGVProveedores.RowTemplate.Height = 28;
            this.DGVProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.DGVProveedores.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;

            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVProveedores.DefaultCellStyle = dgvRowStyle;

            dgvAltRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvAltRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvAltRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvAltRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvAltRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVProveedores.AlternatingRowsDefaultCellStyle = dgvAltRowStyle;

            this.DGVProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColIdProveedor,
                this.ColCuit,
                this.ColRazonSocial,
                this.ColContacto,
                this.ColTelefono,
                this.ColEmail,
                this.ColLocalidad,
                this.ColDireccion,
                this.ColEstado
            });
            this.DGVProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVProveedores.Location = new System.Drawing.Point(0, 6);
            this.DGVProveedores.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.DGVProveedores.Name = "DGVProveedores";
            this.DGVProveedores.Size = new System.Drawing.Size(1060, 701);
            this.DGVProveedores.TabIndex = 0;
            this.DGVProveedores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVProveedores_CellClick);

            // Columnas
            this.ColIdProveedor.HeaderText = "ID";
            this.ColIdProveedor.Name = "ColIdProveedor";
            this.ColIdProveedor.ReadOnly = true;
            this.ColIdProveedor.Visible = false;

            this.ColCuit.HeaderText = "CUIT";
            this.ColCuit.Width = 110;
            this.ColCuit.Name = "ColCuit";
            this.ColCuit.ReadOnly = true;

            this.ColRazonSocial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColRazonSocial.HeaderText = "Proveedor / Razón Social";
            this.ColRazonSocial.Name = "ColRazonSocial";
            this.ColRazonSocial.ReadOnly = true;

            this.ColContacto.HeaderText = "Contacto";
            this.ColContacto.Width = 130;
            this.ColContacto.Name = "ColContacto";
            this.ColContacto.ReadOnly = true;

            this.ColTelefono.HeaderText = "Teléfono";
            this.ColTelefono.Width = 120;
            this.ColTelefono.Name = "ColTelefono";
            this.ColTelefono.ReadOnly = true;

            this.ColEmail.HeaderText = "Correo Electrónico";
            this.ColEmail.Width = 160;
            this.ColEmail.Name = "ColEmail";
            this.ColEmail.ReadOnly = true;

            this.ColLocalidad.HeaderText = "Localidad";
            this.ColLocalidad.Width = 110;
            this.ColLocalidad.Name = "ColLocalidad";
            this.ColLocalidad.ReadOnly = true;

            this.ColDireccion.HeaderText = "Dirección";
            this.ColDireccion.Width = 140;
            this.ColDireccion.Name = "ColDireccion";
            this.ColDireccion.ReadOnly = true;

            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Width = 90;
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;

            // 
            // PTarjetaLateral
            // 
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.TLPFormularioEdicion);
            this.PTarjetaLateral.Controls.Add(this.PBotonesAccion);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1074, 6);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.PTarjetaLateral.Size = new System.Drawing.Size(418, 701);
            this.PTarjetaLateral.TabIndex = 1;

            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 11);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(388, 23);
            this.LTituloTarjeta.TabIndex = 3;
            this.LTituloTarjeta.Text = "DETALLE DEL PROVEEDOR";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // LSubtituloTarjeta
            // 
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 34);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(388, 21);
            this.LSubtituloTarjeta.TabIndex = 2;
            this.LSubtituloTarjeta.Text = "Carga y actualización de proveedores";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // TLPFormularioEdicion
            // 
            this.TLPFormularioEdicion.ColumnCount = 2;
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoCuit, 0, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoRazonSocial, 1, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoContacto, 0, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoTelefono, 1, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoEmail, 0, 2);
            this.TLPFormularioEdicion.Controls.Add(this.LSubtituloDomicilio, 0, 3);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoCalle, 0, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoNro, 1, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoProvincia, 0, 5);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoLocalidad, 1, 5);
            this.TLPFormularioEdicion.Controls.Add(this.PHabilitado, 0, 6);
            this.TLPFormularioEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFormularioEdicion.Location = new System.Drawing.Point(14, 55);
            this.TLPFormularioEdicion.Name = "TLPFormularioEdicion";
            this.TLPFormularioEdicion.RowCount = 7;
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFormularioEdicion.Size = new System.Drawing.Size(388, 457);
            this.TLPFormularioEdicion.TabIndex = 0;

            // CUIT
            this.PGrupoCuit.Controls.Add(this.TBCuit);
            this.PGrupoCuit.Controls.Add(this.LCuit);
            this.PGrupoCuit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCuit.Location = new System.Drawing.Point(0, 0);
            this.PGrupoCuit.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoCuit.Name = "PGrupoCuit";
            this.PGrupoCuit.Size = new System.Drawing.Size(191, 49);
            this.PGrupoCuit.TabIndex = 0;

            this.LCuit.Dock = System.Windows.Forms.DockStyle.Top;
            this.LCuit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LCuit.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LCuit.Location = new System.Drawing.Point(0, 0);
            this.LCuit.Name = "LCuit";
            this.LCuit.Size = new System.Drawing.Size(191, 22);
            this.LCuit.Text = "CUIT:";

            this.TBCuit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCuit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBCuit.Location = new System.Drawing.Point(0, 22);
            this.TBCuit.Name = "TBCuit";
            this.TBCuit.Size = new System.Drawing.Size(191, 27);

            // Razón Social
            this.PGrupoRazonSocial.Controls.Add(this.TBRazonSocial);
            this.PGrupoRazonSocial.Controls.Add(this.LRazonSocial);
            this.PGrupoRazonSocial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoRazonSocial.Location = new System.Drawing.Point(197, 0);
            this.PGrupoRazonSocial.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoRazonSocial.Name = "PGrupoRazonSocial";
            this.PGrupoRazonSocial.Size = new System.Drawing.Size(191, 49);
            this.PGrupoRazonSocial.TabIndex = 1;

            this.LRazonSocial.Dock = System.Windows.Forms.DockStyle.Top;
            this.LRazonSocial.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LRazonSocial.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LRazonSocial.Location = new System.Drawing.Point(0, 0);
            this.LRazonSocial.Name = "LRazonSocial";
            this.LRazonSocial.Size = new System.Drawing.Size(191, 22);
            this.LRazonSocial.Text = "Razón Social / Empresa:";

            this.TBRazonSocial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBRazonSocial.Location = new System.Drawing.Point(0, 22);
            this.TBRazonSocial.Name = "TBRazonSocial";
            this.TBRazonSocial.Size = new System.Drawing.Size(191, 27);

            // Contacto / Vendedor
            this.PGrupoContacto.Controls.Add(this.TBContacto);
            this.PGrupoContacto.Controls.Add(this.LContacto);
            this.PGrupoContacto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoContacto.Location = new System.Drawing.Point(0, 51);
            this.PGrupoContacto.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoContacto.Name = "PGrupoContacto";
            this.PGrupoContacto.Size = new System.Drawing.Size(191, 49);
            this.PGrupoContacto.TabIndex = 2;

            this.LContacto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LContacto.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LContacto.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LContacto.Location = new System.Drawing.Point(0, 0);
            this.LContacto.Name = "LContacto";
            this.LContacto.Size = new System.Drawing.Size(191, 22);
            this.LContacto.Text = "Contacto / Vendedor:";

            this.TBContacto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBContacto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBContacto.Location = new System.Drawing.Point(0, 22);
            this.TBContacto.Name = "TBContacto";
            this.TBContacto.Size = new System.Drawing.Size(191, 27);

            // Teléfono
            this.PGrupoTelefono.Controls.Add(this.TBTelefono);
            this.PGrupoTelefono.Controls.Add(this.LTelefono);
            this.PGrupoTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTelefono.Location = new System.Drawing.Point(197, 51);
            this.PGrupoTelefono.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoTelefono.Name = "PGrupoTelefono";
            this.PGrupoTelefono.Size = new System.Drawing.Size(191, 49);
            this.PGrupoTelefono.TabIndex = 3;

            this.LTelefono.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTelefono.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTelefono.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LTelefono.Location = new System.Drawing.Point(0, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(191, 22);
            this.LTelefono.Text = "Teléfono:";

            this.TBTelefono.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBTelefono.Location = new System.Drawing.Point(0, 22);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(191, 27);

            // Correo Electrónico (Span 2)
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoEmail, 2);
            this.PGrupoEmail.Controls.Add(this.TBEmail);
            this.PGrupoEmail.Controls.Add(this.LEmail);
            this.PGrupoEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoEmail.Location = new System.Drawing.Point(0, 102);
            this.PGrupoEmail.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.PGrupoEmail.Name = "PGrupoEmail";
            this.PGrupoEmail.Size = new System.Drawing.Size(388, 49);
            this.PGrupoEmail.TabIndex = 4;

            this.LEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.LEmail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LEmail.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LEmail.Location = new System.Drawing.Point(0, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(388, 22);
            this.LEmail.Text = "Correo Electrónico:";

            this.TBEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBEmail.Location = new System.Drawing.Point(0, 22);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(388, 27);

            // Subtítulo Domicilio
            this.TLPFormularioEdicion.SetColumnSpan(this.LSubtituloDomicilio, 2);
            this.LSubtituloDomicilio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LSubtituloDomicilio.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LSubtituloDomicilio.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LSubtituloDomicilio.Location = new System.Drawing.Point(3, 153);
            this.LSubtituloDomicilio.Name = "LSubtituloDomicilio";
            this.LSubtituloDomicilio.Size = new System.Drawing.Size(382, 28);
            this.LSubtituloDomicilio.TabIndex = 5;
            this.LSubtituloDomicilio.Text = "DOMICILIO FISCAL";
            this.LSubtituloDomicilio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Calle
            this.PGrupoCalle.Controls.Add(this.TBCalle);
            this.PGrupoCalle.Controls.Add(this.LCalle);
            this.PGrupoCalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCalle.Location = new System.Drawing.Point(0, 181);
            this.PGrupoCalle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoCalle.Name = "PGrupoCalle";
            this.PGrupoCalle.Size = new System.Drawing.Size(191, 49);
            this.PGrupoCalle.TabIndex = 6;

            this.LCalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LCalle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LCalle.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LCalle.Location = new System.Drawing.Point(0, 0);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(191, 22);
            this.LCalle.Text = "Calle:";

            this.TBCalle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBCalle.Location = new System.Drawing.Point(0, 22);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(191, 27);

            // Nro / Altura
            this.PGrupoNro.Controls.Add(this.TBNro);
            this.PGrupoNro.Controls.Add(this.LNroAltura);
            this.PGrupoNro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoNro.Location = new System.Drawing.Point(197, 181);
            this.PGrupoNro.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoNro.Name = "PGrupoNro";
            this.PGrupoNro.Size = new System.Drawing.Size(191, 49);
            this.PGrupoNro.TabIndex = 7;

            this.LNroAltura.Dock = System.Windows.Forms.DockStyle.Top;
            this.LNroAltura.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LNroAltura.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LNroAltura.Location = new System.Drawing.Point(0, 0);
            this.LNroAltura.Name = "LNroAltura";
            this.LNroAltura.Size = new System.Drawing.Size(191, 22);
            this.LNroAltura.Text = "N° / Altura:";

            this.TBNro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBNro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBNro.Location = new System.Drawing.Point(0, 22);
            this.TBNro.Name = "TBNro";
            this.TBNro.Size = new System.Drawing.Size(191, 27);

            // Provincia
            this.PGrupoProvincia.Controls.Add(this.CBProvincia);
            this.PGrupoProvincia.Controls.Add(this.LProvincia);
            this.PGrupoProvincia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoProvincia.Location = new System.Drawing.Point(0, 232);
            this.PGrupoProvincia.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoProvincia.Name = "PGrupoProvincia";
            this.PGrupoProvincia.Size = new System.Drawing.Size(191, 49);
            this.PGrupoProvincia.TabIndex = 8;

            this.LProvincia.Dock = System.Windows.Forms.DockStyle.Top;
            this.LProvincia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LProvincia.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LProvincia.Location = new System.Drawing.Point(0, 0);
            this.LProvincia.Name = "LProvincia";
            this.LProvincia.Size = new System.Drawing.Size(191, 22);
            this.LProvincia.Text = "Provincia:";

            this.CBProvincia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProvincia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBProvincia.Location = new System.Drawing.Point(0, 21);
            this.CBProvincia.Name = "CBProvincia";
            this.CBProvincia.Size = new System.Drawing.Size(191, 28);

            // Localidad
            this.PGrupoLocalidad.Controls.Add(this.CBLocalidad);
            this.PGrupoLocalidad.Controls.Add(this.LLocalidad);
            this.PGrupoLocalidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoLocalidad.Location = new System.Drawing.Point(197, 232);
            this.PGrupoLocalidad.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoLocalidad.Name = "PGrupoLocalidad";
            this.PGrupoLocalidad.Size = new System.Drawing.Size(191, 49);
            this.PGrupoLocalidad.TabIndex = 9;

            this.LLocalidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.LLocalidad.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LLocalidad.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LLocalidad.Location = new System.Drawing.Point(0, 0);
            this.LLocalidad.Name = "LLocalidad";
            this.LLocalidad.Size = new System.Drawing.Size(191, 22);
            this.LLocalidad.Text = "Localidad:";

            this.CBLocalidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBLocalidad.Location = new System.Drawing.Point(0, 21);
            this.CBLocalidad.Name = "CBLocalidad";
            this.CBLocalidad.Size = new System.Drawing.Size(191, 28);

            // CheckBox Proveedor Habilitado
            this.TLPFormularioEdicion.SetColumnSpan(this.PHabilitado, 2);
            this.PHabilitado.Controls.Add(this.ChBProveedorHabilitado);
            this.PHabilitado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHabilitado.Location = new System.Drawing.Point(3, 285);
            this.PHabilitado.Name = "PHabilitado";
            this.PHabilitado.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.PHabilitado.Size = new System.Drawing.Size(382, 169);
            this.PHabilitado.TabIndex = 10;

            this.ChBProveedorHabilitado.Checked = true;
            this.ChBProveedorHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChBProveedorHabilitado.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChBProveedorHabilitado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.ChBProveedorHabilitado.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.ChBProveedorHabilitado.Location = new System.Drawing.Point(0, 8);
            this.ChBProveedorHabilitado.Name = "ChBProveedorHabilitado";
            this.ChBProveedorHabilitado.Size = new System.Drawing.Size(382, 26);
            this.ChBProveedorHabilitado.TabIndex = 0;
            this.ChBProveedorHabilitado.Text = "Proveedor Habilitado";

            // 
            // PBotonesAccion (Botonera unificada idéntica a Clientes)
            // 
            this.PBotonesAccion.Controls.Add(this.BLimpiar);
            this.PBotonesAccion.Controls.Add(this.TLPBotonesMed);
            this.PBotonesAccion.Controls.Add(this.TPLBotonesSup);
            this.PBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesAccion.Location = new System.Drawing.Point(14, 512);
            this.PBotonesAccion.Name = "PBotonesAccion";
            this.PBotonesAccion.Size = new System.Drawing.Size(388, 176);
            this.PBotonesAccion.TabIndex = 1;

            // Fila Superior Botones
            this.TPLBotonesSup.ColumnCount = 2;
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.Controls.Add(this.BNuevo, 0, 0);
            this.TPLBotonesSup.Controls.Add(this.BGuardar, 1, 0);
            this.TPLBotonesSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TPLBotonesSup.Location = new System.Drawing.Point(0, 0);
            this.TPLBotonesSup.Name = "TPLBotonesSup";
            this.TPLBotonesSup.Size = new System.Drawing.Size(388, 55);
            this.TPLBotonesSup.TabIndex = 2;

            // BNuevo
            this.BNuevo.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.BNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BNuevo.FlatAppearance.BorderSize = 0;
            this.BNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BNuevo.ForeColor = System.Drawing.Color.White;
            this.BNuevo.Location = new System.Drawing.Point(0, 0);
            this.BNuevo.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Padding = new System.Windows.Forms.Padding(34, 0, 0, 0);
            this.BNuevo.Size = new System.Drawing.Size(191, 52);
            this.BNuevo.TabIndex = 0;
            this.BNuevo.Text = "Nuevo";
            this.BNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BNuevo.UseVisualStyleBackColor = false;
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);

            // BGuardar
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.BGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BGuardar.FlatAppearance.BorderSize = 0;
            this.BGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BGuardar.ForeColor = System.Drawing.Color.White;
            this.BGuardar.Location = new System.Drawing.Point(197, 0);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.BGuardar.Size = new System.Drawing.Size(191, 52);
            this.BGuardar.TabIndex = 1;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);

            // Fila Media Botones
            this.TLPBotonesMed.ColumnCount = 2;
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.Controls.Add(this.BEditar, 0, 0);
            this.TLPBotonesMed.Controls.Add(this.BDesactivar, 1, 0);
            this.TLPBotonesMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPBotonesMed.Location = new System.Drawing.Point(0, 55);
            this.TLPBotonesMed.Name = "TLPBotonesMed";
            this.TLPBotonesMed.Size = new System.Drawing.Size(388, 55);
            this.TLPBotonesMed.TabIndex = 1;

            // BEditar
            this.BEditar.BackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.BEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BEditar.FlatAppearance.BorderSize = 0;
            this.BEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BEditar.ForeColor = System.Drawing.Color.White;
            this.BEditar.Location = new System.Drawing.Point(0, 0);
            this.BEditar.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.BEditar.Name = "BEditar";
            this.BEditar.Padding = new System.Windows.Forms.Padding(36, 0, 0, 0);
            this.BEditar.Size = new System.Drawing.Size(191, 52);
            this.BEditar.TabIndex = 0;
            this.BEditar.Text = "Editar";
            this.BEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditar.UseVisualStyleBackColor = false;
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);

            // BDesactivar
            this.BDesactivar.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.BDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BDesactivar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BDesactivar.FlatAppearance.BorderSize = 0;
            this.BDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BDesactivar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BDesactivar.ForeColor = System.Drawing.Color.White;
            this.BDesactivar.Location = new System.Drawing.Point(197, 0);
            this.BDesactivar.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.BDesactivar.Name = "BDesactivar";
            this.BDesactivar.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.BDesactivar.Size = new System.Drawing.Size(191, 52);
            this.BDesactivar.TabIndex = 1;
            this.BDesactivar.Text = "Dar de Baja";
            this.BDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BDesactivar.UseVisualStyleBackColor = false;
            this.BDesactivar.Click += new System.EventHandler(this.BDesactivar_Click);

            // BLimpiar
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.BLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BLimpiar.FlatAppearance.BorderSize = 0;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.Location = new System.Drawing.Point(0, 110);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.BLimpiar.Size = new System.Drawing.Size(388, 52);
            this.BLimpiar.TabIndex = 0;
            this.BLimpiar.Text = "Limpiar Campos";
            this.BLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);

            // 
            // FormProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProveedores";
            this.Text = "Gestión de Proveedores";
            this.Load += new System.EventHandler(this.FormProveedores_Load);

            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProveedores)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.TLPFormularioEdicion.ResumeLayout(false);
            this.PGrupoCuit.ResumeLayout(false);
            this.PGrupoCuit.PerformLayout();
            this.PGrupoRazonSocial.ResumeLayout(false);
            this.PGrupoRazonSocial.PerformLayout();
            this.PGrupoContacto.ResumeLayout(false);
            this.PGrupoContacto.PerformLayout();
            this.PGrupoTelefono.ResumeLayout(false);
            this.PGrupoTelefono.PerformLayout();
            this.PGrupoEmail.ResumeLayout(false);
            this.PGrupoEmail.PerformLayout();
            this.PGrupoCalle.ResumeLayout(false);
            this.PGrupoCalle.PerformLayout();
            this.PGrupoNro.ResumeLayout(false);
            this.PGrupoNro.PerformLayout();
            this.PGrupoProvincia.ResumeLayout(false);
            this.PGrupoLocalidad.ResumeLayout(false);
            this.PHabilitado.ResumeLayout(false);
            this.PBotonesAccion.ResumeLayout(false);
            this.TLPBotonesMed.ResumeLayout(false);
            this.TPLBotonesSup.ResumeLayout(false);
            this.PBarraFiltros.ResumeLayout(false);
            this.PBarraFiltros.PerformLayout();
            this.PEncabezado.ResumeLayout(false);
            this.PEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel PFondo;
        private System.Windows.Forms.Panel PEncabezado;
        private System.Windows.Forms.PictureBox PBIconoTitulo;
        private System.Windows.Forms.Label LTituloPrincipal;
        private System.Windows.Forms.Panel PBarraFiltros;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label LFiltroLocalidad;
        private System.Windows.Forms.ComboBox CBFiltroLocalidad;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLocalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.TableLayoutPanel TLPFormularioEdicion;
        private System.Windows.Forms.Panel PGrupoCuit;
        private System.Windows.Forms.Label LCuit;
        private System.Windows.Forms.TextBox TBCuit;
        private System.Windows.Forms.Panel PGrupoRazonSocial;
        private System.Windows.Forms.Label LRazonSocial;
        private System.Windows.Forms.TextBox TBRazonSocial;
        private System.Windows.Forms.Panel PGrupoContacto;
        private System.Windows.Forms.Label LContacto;
        private System.Windows.Forms.TextBox TBContacto;
        private System.Windows.Forms.Panel PGrupoTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Panel PGrupoEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LSubtituloDomicilio;
        private System.Windows.Forms.Panel PGrupoCalle;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.TextBox TBCalle;
        private System.Windows.Forms.Panel PGrupoNro;
        private System.Windows.Forms.Label LNroAltura;
        private System.Windows.Forms.TextBox TBNro;
        private System.Windows.Forms.Panel PGrupoProvincia;
        private System.Windows.Forms.Label LProvincia;
        private System.Windows.Forms.ComboBox CBProvincia;
        private System.Windows.Forms.Panel PGrupoLocalidad;
        private System.Windows.Forms.Label LLocalidad;
        private System.Windows.Forms.ComboBox CBLocalidad;
        private System.Windows.Forms.Panel PHabilitado;
        private System.Windows.Forms.CheckBox ChBProveedorHabilitado;
        private System.Windows.Forms.Panel PBotonesAccion;
        private System.Windows.Forms.TableLayoutPanel TPLBotonesSup;
        private System.Windows.Forms.Button BNuevo;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.TableLayoutPanel TLPBotonesMed;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BDesactivar;
        private System.Windows.Forms.Button BLimpiar;
    }
}