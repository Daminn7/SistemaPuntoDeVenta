namespace CapaPresentacion
{
    partial class FormCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PFondo = new System.Windows.Forms.Panel();
            this.TLPContenido = new System.Windows.Forms.TableLayoutPanel();
            this.DGVDetalleCompra = new System.Windows.Forms.DataGridView();
            this.ColIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccionEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.TLPFormularioEdicion = new System.Windows.Forms.TableLayoutPanel();
            this.PGrupoProveedor = new System.Windows.Forms.Panel();
            this.CBProveedor = new System.Windows.Forms.ComboBox();
            this.LProveedor = new System.Windows.Forms.Label();
            this.PGrupoTipoDoc = new System.Windows.Forms.Panel();
            this.CBTipoComprobante = new System.Windows.Forms.ComboBox();
            this.LTipoComprobante = new System.Windows.Forms.Label();
            this.PGrupoNroFactura = new System.Windows.Forms.Panel();
            this.TBNroComprobante = new System.Windows.Forms.TextBox();
            this.LNroComprobante = new System.Windows.Forms.Label();
            this.PGrupoFecha = new System.Windows.Forms.Panel();
            this.DTPFechaEmision = new System.Windows.Forms.DateTimePicker();
            this.LFechaEmision = new System.Windows.Forms.Label();
            this.PGrupoFormaPago = new System.Windows.Forms.Panel();
            this.CBFormaPago = new System.Windows.Forms.ComboBox();
            this.LFormaPago = new System.Windows.Forms.Label();
            this.LSubtituloArticulos = new System.Windows.Forms.Label();
            this.PGrupoProducto = new System.Windows.Forms.Panel();
            this.CBProducto = new System.Windows.Forms.ComboBox();
            this.LProducto = new System.Windows.Forms.Label();
            this.PGrupoCosto = new System.Windows.Forms.Panel();
            this.TBCostoUnitario = new System.Windows.Forms.TextBox();
            this.LCostoUnitario = new System.Windows.Forms.Label();
            this.PGrupoCantidad = new System.Windows.Forms.Panel();
            this.NUDCantidad = new System.Windows.Forms.NumericUpDown();
            this.LCantidad = new System.Windows.Forms.Label();
            this.PGrupoBotonAgregar = new System.Windows.Forms.Panel();
            this.BAgregarItem = new System.Windows.Forms.Button();
            this.LSubtituloTotales = new System.Windows.Forms.Label();
            this.PGrupoSubtotal = new System.Windows.Forms.Panel();
            this.TBSubtotal = new System.Windows.Forms.TextBox();
            this.LSubtotal = new System.Windows.Forms.Label();
            this.PGrupoIva = new System.Windows.Forms.Panel();
            this.TBIva = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.PGrupoTotal = new System.Windows.Forms.Panel();
            this.TBTotalCompra = new System.Windows.Forms.TextBox();
            this.LTotalCompra = new System.Windows.Forms.Label();
            this.PBotonesAccion = new System.Windows.Forms.Panel();
            this.BGuardarCompra = new System.Windows.Forms.Button();
            this.BCancelar = new System.Windows.Forms.Button();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LBuscarArticulo = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalleCompra)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.TLPFormularioEdicion.SuspendLayout();
            this.PGrupoProveedor.SuspendLayout();
            this.PGrupoTipoDoc.SuspendLayout();
            this.PGrupoNroFactura.SuspendLayout();
            this.PGrupoFecha.SuspendLayout();
            this.PGrupoFormaPago.SuspendLayout();
            this.PGrupoProducto.SuspendLayout();
            this.PGrupoCosto.SuspendLayout();
            this.PGrupoCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).BeginInit();
            this.PGrupoBotonAgregar.SuspendLayout();
            this.PGrupoSubtotal.SuspendLayout();
            this.PGrupoIva.SuspendLayout();
            this.PGrupoTotal.SuspendLayout();
            this.PBotonesAccion.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // PFondo
            // 
            this.PFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
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
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.btnBuscar);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LBuscarArticulo);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(21, 53);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1492, 47);
            this.PBarraFiltros.TabIndex = 1;
            // 
            // LBuscarArticulo
            // 
            this.LBuscarArticulo.AutoSize = true;
            this.LBuscarArticulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LBuscarArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LBuscarArticulo.Location = new System.Drawing.Point(3, 14);
            this.LBuscarArticulo.Name = "LBuscarArticulo";
            this.LBuscarArticulo.Size = new System.Drawing.Size(188, 20);
            this.LBuscarArticulo.TabIndex = 0;
            this.LBuscarArticulo.Text = "Filtrar en Lista de Compra:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBBuscar.Location = new System.Drawing.Point(200, 10);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(320, 27);
            this.TBBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(535, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 29);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TLPContenido.Controls.Add(this.DGVDetalleCompra, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 100);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 707);
            this.TLPContenido.TabIndex = 1;
            // 
            // DGVDetalleCompra
            // 
            this.DGVDetalleCompra.AllowUserToAddRows = false;
            this.DGVDetalleCompra.AllowUserToDeleteRows = false;
            this.DGVDetalleCompra.AllowUserToResizeColumns = false;
            this.DGVDetalleCompra.AllowUserToResizeRows = false;
            this.DGVDetalleCompra.BackgroundColor = System.Drawing.Color.White;
            this.DGVDetalleCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVDetalleCompra.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVDetalleCompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.DGVDetalleCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDetalleCompra.ColumnHeadersHeight = 32;
            this.DGVDetalleCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVDetalleCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdProducto,
            this.ColCodigo,
            this.ColDescripcion,
            this.ColCantidad,
            this.ColCostoUnitario,
            this.ColSubtotal,
            this.ColAccionEliminar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            // Fila alternada
            System.Windows.Forms.DataGridViewCellStyle dgvAlt = new System.Windows.Forms.DataGridViewCellStyle();
            dgvAlt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dgvAlt.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvAlt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dgvAlt.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dgvAlt.SelectionForeColor = System.Drawing.Color.White;
            this.DGVDetalleCompra.AlternatingRowsDefaultCellStyle = dgvAlt;
            this.DGVDetalleCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetalleCompra.EnableHeadersVisualStyles = false;
            this.DGVDetalleCompra.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.DGVDetalleCompra.MultiSelect = false;
            this.DGVDetalleCompra.Name = "DGVDetalleCompra";
            this.DGVDetalleCompra.ReadOnly = true;
            this.DGVDetalleCompra.RowHeadersVisible = false;
            this.DGVDetalleCompra.RowTemplate.Height = 28;
            this.DGVDetalleCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDetalleCompra.Size = new System.Drawing.Size(1030, 748);
            this.DGVDetalleCompra.TabIndex = 0;
            this.DGVDetalleCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetalleCompra_CellContentClick);
            // 
            // ColIdProducto
            // 
            this.ColIdProducto.HeaderText = "ID";
            this.ColIdProducto.MinimumWidth = 6;
            this.ColIdProducto.Name = "ColIdProducto";
            this.ColIdProducto.ReadOnly = true;
            this.ColIdProducto.Visible = false;
            this.ColIdProducto.Width = 125;
            // 
            // ColCodigo
            // 
            this.ColCodigo.HeaderText = "Código";
            this.ColCodigo.MinimumWidth = 6;
            this.ColCodigo.Name = "ColCodigo";
            this.ColCodigo.ReadOnly = true;
            this.ColCodigo.Width = 120;
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescripcion.HeaderText = "Descripción del Insumo / Producto";
            this.ColDescripcion.MinimumWidth = 6;
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.ReadOnly = true;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "Cantidad";
            this.ColCantidad.MinimumWidth = 6;
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            this.ColCantidad.Width = 95;
            // 
            // ColCostoUnitario
            // 
            this.ColCostoUnitario.HeaderText = "Costo Unit. ($)";
            this.ColCostoUnitario.MinimumWidth = 6;
            this.ColCostoUnitario.Name = "ColCostoUnitario";
            this.ColCostoUnitario.ReadOnly = true;
            this.ColCostoUnitario.Width = 135;
            // 
            // ColSubtotal
            // 
            this.ColSubtotal.HeaderText = "Subtotal ($)";
            this.ColSubtotal.MinimumWidth = 6;
            this.ColSubtotal.Name = "ColSubtotal";
            this.ColSubtotal.ReadOnly = true;
            this.ColSubtotal.Width = 135;
            // 
            // ColAccionEliminar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.ColAccionEliminar.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColAccionEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColAccionEliminar.HeaderText = "Quitar";
            this.ColAccionEliminar.MinimumWidth = 6;
            this.ColAccionEliminar.Name = "ColAccionEliminar";
            this.ColAccionEliminar.ReadOnly = true;
            this.ColAccionEliminar.Text = "X";
            this.ColAccionEliminar.UseColumnTextForButtonValue = true;
            this.ColAccionEliminar.Width = 70;
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
            this.PTarjetaLateral.Location = new System.Drawing.Point(1044, 6);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.PTarjetaLateral.Size = new System.Drawing.Size(448, 748);
            this.PTarjetaLateral.TabIndex = 1;
            // 
            // TLPFormularioEdicion
            // 
            this.TLPFormularioEdicion.ColumnCount = 2;
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoProveedor, 0, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoTipoDoc, 1, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoNroFactura, 0, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoFecha, 1, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoFormaPago, 0, 2);
            this.TLPFormularioEdicion.Controls.Add(this.LSubtituloArticulos, 0, 3);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoProducto, 0, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoCosto, 0, 5);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoCantidad, 1, 5);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoBotonAgregar, 0, 6);
            this.TLPFormularioEdicion.Controls.Add(this.LSubtituloTotales, 0, 7);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoSubtotal, 0, 8);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoIva, 1, 8);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoTotal, 0, 9);
            this.TLPFormularioEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFormularioEdicion.Location = new System.Drawing.Point(14, 55);
            this.TLPFormularioEdicion.Name = "TLPFormularioEdicion";
            this.TLPFormularioEdicion.RowCount = 10;
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // Proveedor / TipoDoc
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // NroFactura / Fecha
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // FormaPago
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F)); // Subtitulo Artículos
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // Producto
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // Costo / Cantidad
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F)); // Botón Agregar (Achicado)
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F)); // Subtitulo Totales
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F)); // Subtotal / IVA
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Total (Ocupa el resto sin desbordar)
            this.TLPFormularioEdicion.Size = new System.Drawing.Size(418, 590);
            this.TLPFormularioEdicion.TabIndex = 0;
            // 
            // PGrupoProveedor
            // 
            this.PGrupoProveedor.Controls.Add(this.CBProveedor);
            this.PGrupoProveedor.Controls.Add(this.LProveedor);
            this.PGrupoProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoProveedor.Location = new System.Drawing.Point(0, 0);
            this.PGrupoProveedor.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoProveedor.Name = "PGrupoProveedor";
            this.PGrupoProveedor.Size = new System.Drawing.Size(206, 49);
            this.PGrupoProveedor.TabIndex = 0;
            // 
            // CBProveedor
            // 
            this.CBProveedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBProveedor.Location = new System.Drawing.Point(0, 21);
            this.CBProveedor.Name = "CBProveedor";
            this.CBProveedor.Size = new System.Drawing.Size(206, 28);
            this.CBProveedor.TabIndex = 0;
            this.CBProveedor.SelectedIndexChanged += new System.EventHandler(this.CBProveedor_SelectedIndexChanged);
            // 
            // LProveedor
            // 
            this.LProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LProveedor.Location = new System.Drawing.Point(0, 0);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(206, 22);
            this.LProveedor.TabIndex = 1;
            this.LProveedor.Text = "Proveedor:";
            // 
            // PGrupoTipoDoc
            // 
            this.PGrupoTipoDoc.Controls.Add(this.CBTipoComprobante);
            this.PGrupoTipoDoc.Controls.Add(this.LTipoComprobante);
            this.PGrupoTipoDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTipoDoc.Location = new System.Drawing.Point(212, 0);
            this.PGrupoTipoDoc.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoTipoDoc.Name = "PGrupoTipoDoc";
            this.PGrupoTipoDoc.Size = new System.Drawing.Size(206, 49);
            this.PGrupoTipoDoc.TabIndex = 1;
            // 
            // CBTipoComprobante
            // 
            this.CBTipoComprobante.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBTipoComprobante.Location = new System.Drawing.Point(0, 21);
            this.CBTipoComprobante.Name = "CBTipoComprobante";
            this.CBTipoComprobante.Size = new System.Drawing.Size(206, 28);
            this.CBTipoComprobante.TabIndex = 0;
            // 
            // LTipoComprobante
            // 
            this.LTipoComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LTipoComprobante.Location = new System.Drawing.Point(0, 0);
            this.LTipoComprobante.Name = "LTipoComprobante";
            this.LTipoComprobante.Size = new System.Drawing.Size(206, 22);
            this.LTipoComprobante.TabIndex = 1;
            this.LTipoComprobante.Text = "Tipo Comprobante:";
            // 
            // PGrupoNroFactura
            // 
            this.PGrupoNroFactura.Controls.Add(this.TBNroComprobante);
            this.PGrupoNroFactura.Controls.Add(this.LNroComprobante);
            this.PGrupoNroFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoNroFactura.Location = new System.Drawing.Point(0, 51);
            this.PGrupoNroFactura.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoNroFactura.Name = "PGrupoNroFactura";
            this.PGrupoNroFactura.Size = new System.Drawing.Size(206, 49);
            this.PGrupoNroFactura.TabIndex = 2;
            // 
            // TBNroComprobante
            // 
            this.TBNroComprobante.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBNroComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBNroComprobante.Location = new System.Drawing.Point(0, 22);
            this.TBNroComprobante.Name = "TBNroComprobante";
            this.TBNroComprobante.Size = new System.Drawing.Size(206, 27);
            this.TBNroComprobante.TabIndex = 0;
            // 
            // LNroComprobante
            // 
            this.LNroComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LNroComprobante.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LNroComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LNroComprobante.Location = new System.Drawing.Point(0, 0);
            this.LNroComprobante.Name = "LNroComprobante";
            this.LNroComprobante.Size = new System.Drawing.Size(206, 22);
            this.LNroComprobante.TabIndex = 1;
            this.LNroComprobante.Text = "N° Factura / Remito:";
            // 
            // PGrupoFecha
            // 
            this.PGrupoFecha.Controls.Add(this.DTPFechaEmision);
            this.PGrupoFecha.Controls.Add(this.LFechaEmision);
            this.PGrupoFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFecha.Location = new System.Drawing.Point(212, 51);
            this.PGrupoFecha.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoFecha.Name = "PGrupoFecha";
            this.PGrupoFecha.Size = new System.Drawing.Size(206, 49);
            this.PGrupoFecha.TabIndex = 3;
            // 
            // DTPFechaEmision
            // 
            this.DTPFechaEmision.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DTPFechaEmision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaEmision.Location = new System.Drawing.Point(0, 22);
            this.DTPFechaEmision.Name = "DTPFechaEmision";
            this.DTPFechaEmision.Size = new System.Drawing.Size(206, 27);
            this.DTPFechaEmision.TabIndex = 0;
            // 
            // LFechaEmision
            // 
            this.LFechaEmision.Dock = System.Windows.Forms.DockStyle.Top;
            this.LFechaEmision.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LFechaEmision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LFechaEmision.Location = new System.Drawing.Point(0, 0);
            this.LFechaEmision.Name = "LFechaEmision";
            this.LFechaEmision.Size = new System.Drawing.Size(206, 22);
            this.LFechaEmision.TabIndex = 1;
            this.LFechaEmision.Text = "Fecha de Emisión:";
            // 
            // PGrupoFormaPago
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoFormaPago, 2);
            this.PGrupoFormaPago.Controls.Add(this.CBFormaPago);
            this.PGrupoFormaPago.Controls.Add(this.LFormaPago);
            this.PGrupoFormaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFormaPago.Location = new System.Drawing.Point(0, 102);
            this.PGrupoFormaPago.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.PGrupoFormaPago.Name = "PGrupoFormaPago";
            this.PGrupoFormaPago.Size = new System.Drawing.Size(418, 49);
            this.PGrupoFormaPago.TabIndex = 4;
            // 
            // CBFormaPago
            // 
            this.CBFormaPago.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFormaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFormaPago.Location = new System.Drawing.Point(0, 21);
            this.CBFormaPago.Name = "CBFormaPago";
            this.CBFormaPago.Size = new System.Drawing.Size(418, 28);
            this.CBFormaPago.TabIndex = 0;
            // 
            // LFormaPago
            // 
            this.LFormaPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.LFormaPago.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LFormaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LFormaPago.Location = new System.Drawing.Point(0, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(418, 22);
            this.LFormaPago.TabIndex = 1;
            this.LFormaPago.Text = "Condición / Medio de Pago:";
            // 
            // LSubtituloArticulos
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.LSubtituloArticulos, 2);
            this.LSubtituloArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LSubtituloArticulos.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LSubtituloArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LSubtituloArticulos.Location = new System.Drawing.Point(3, 153);
            this.LSubtituloArticulos.Name = "LSubtituloArticulos";
            this.LSubtituloArticulos.Size = new System.Drawing.Size(412, 28);
            this.LSubtituloArticulos.TabIndex = 5;
            this.LSubtituloArticulos.Text = "CARGA DE ARTÍCULOS E INSUMOS";
            this.LSubtituloArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PGrupoProducto
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoProducto, 2);
            this.PGrupoProducto.Controls.Add(this.CBProducto);
            this.PGrupoProducto.Controls.Add(this.LProducto);
            this.PGrupoProducto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoProducto.Location = new System.Drawing.Point(0, 181);
            this.PGrupoProducto.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.PGrupoProducto.Name = "PGrupoProducto";
            this.PGrupoProducto.Size = new System.Drawing.Size(418, 49);
            this.PGrupoProducto.TabIndex = 6;
            // 
            // CBProducto
            // 
            this.CBProducto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBProducto.Location = new System.Drawing.Point(0, 21);
            this.CBProducto.Name = "CBProducto";
            this.CBProducto.Size = new System.Drawing.Size(418, 28);
            this.CBProducto.TabIndex = 0;
            this.CBProducto.SelectedIndexChanged += new System.EventHandler(this.CBProducto_SelectedIndexChanged);
            // 
            // LProducto
            // 
            this.LProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LProducto.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LProducto.Location = new System.Drawing.Point(0, 0);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(418, 22);
            this.LProducto.TabIndex = 1;
            this.LProducto.Text = "Seleccionar Producto / Insumo:";
            // 
            // PGrupoCosto
            // 
            this.PGrupoCosto.Controls.Add(this.TBCostoUnitario);
            this.PGrupoCosto.Controls.Add(this.LCostoUnitario);
            this.PGrupoCosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCosto.Location = new System.Drawing.Point(0, 232);
            this.PGrupoCosto.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoCosto.Name = "PGrupoCosto";
            this.PGrupoCosto.Size = new System.Drawing.Size(206, 49);
            this.PGrupoCosto.TabIndex = 7;
            // 
            // TBCostoUnitario
            // 
            this.TBCostoUnitario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBCostoUnitario.Location = new System.Drawing.Point(0, 22);
            this.TBCostoUnitario.Name = "TBCostoUnitario";
            this.TBCostoUnitario.Size = new System.Drawing.Size(206, 27);
            this.TBCostoUnitario.TabIndex = 0;
            // 
            // LCostoUnitario
            // 
            this.LCostoUnitario.Dock = System.Windows.Forms.DockStyle.Top;
            this.LCostoUnitario.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LCostoUnitario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LCostoUnitario.Location = new System.Drawing.Point(0, 0);
            this.LCostoUnitario.Name = "LCostoUnitario";
            this.LCostoUnitario.Size = new System.Drawing.Size(206, 22);
            this.LCostoUnitario.TabIndex = 1;
            this.LCostoUnitario.Text = "Costo Unitario ($):";
            // 
            // PGrupoCantidad
            // 
            this.PGrupoCantidad.Controls.Add(this.NUDCantidad);
            this.PGrupoCantidad.Controls.Add(this.LCantidad);
            this.PGrupoCantidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCantidad.Location = new System.Drawing.Point(212, 232);
            this.PGrupoCantidad.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoCantidad.Name = "PGrupoCantidad";
            this.PGrupoCantidad.Size = new System.Drawing.Size(206, 49);
            this.PGrupoCantidad.TabIndex = 8;
            // 
            // NUDCantidad
            // 
            this.NUDCantidad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NUDCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.NUDCantidad.Location = new System.Drawing.Point(0, 22);
            this.NUDCantidad.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.NUDCantidad.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.NUDCantidad.Name = "NUDCantidad";
            this.NUDCantidad.Size = new System.Drawing.Size(206, 27);
            this.NUDCantidad.TabIndex = 0;
            this.NUDCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDCantidad.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // LCantidad
            // 
            this.LCantidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.LCantidad.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LCantidad.Location = new System.Drawing.Point(0, 0);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(206, 22);
            this.LCantidad.TabIndex = 1;
            this.LCantidad.Text = "Cantidad a Ingresar:";
            // 
            // PGrupoBotonAgregar
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoBotonAgregar, 2);
            this.PGrupoBotonAgregar.Controls.Add(this.BAgregarItem);
            this.PGrupoBotonAgregar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoBotonAgregar.Location = new System.Drawing.Point(0, 264);
            this.PGrupoBotonAgregar.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.PGrupoBotonAgregar.Name = "PGrupoBotonAgregar";
            this.PGrupoBotonAgregar.Size = new System.Drawing.Size(418, 34);
            this.PGrupoBotonAgregar.TabIndex = 9;
            // 
            // BAgregarItem
            // 
            this.BAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.BAgregarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BAgregarItem.FlatAppearance.BorderSize = 0;
            this.BAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BAgregarItem.ForeColor = System.Drawing.Color.White;
            this.BAgregarItem.Location = new System.Drawing.Point(0, 0);
            this.BAgregarItem.Name = "BAgregarItem";
            this.BAgregarItem.Size = new System.Drawing.Size(418, 34);
            this.BAgregarItem.TabIndex = 0;
            this.BAgregarItem.Text = "+ Agregar Ítem a la Lista";
            this.BAgregarItem.UseVisualStyleBackColor = false;
            this.BAgregarItem.Click += new System.EventHandler(this.BAgregarItem_Click);
            // 
            // LSubtituloTotales
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.LSubtituloTotales, 2);
            this.LSubtituloTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LSubtituloTotales.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LSubtituloTotales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LSubtituloTotales.Location = new System.Drawing.Point(3, 328);
            this.LSubtituloTotales.Name = "LSubtituloTotales";
            this.LSubtituloTotales.Size = new System.Drawing.Size(412, 28);
            this.LSubtituloTotales.TabIndex = 10;
            this.LSubtituloTotales.Text = "LIQUIDACIÓN DE FACTURA";
            this.LSubtituloTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PGrupoSubtotal
            // 
            this.PGrupoSubtotal.Controls.Add(this.TBSubtotal);
            this.PGrupoSubtotal.Controls.Add(this.LSubtotal);
            this.PGrupoSubtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoSubtotal.Location = new System.Drawing.Point(0, 356);
            this.PGrupoSubtotal.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoSubtotal.Name = "PGrupoSubtotal";
            this.PGrupoSubtotal.Size = new System.Drawing.Size(206, 49);
            this.PGrupoSubtotal.TabIndex = 11;
            // 
            // TBSubtotal
            // 
            this.TBSubtotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBSubtotal.Location = new System.Drawing.Point(0, 22);
            this.TBSubtotal.Name = "TBSubtotal";
            this.TBSubtotal.ReadOnly = true;
            this.TBSubtotal.Size = new System.Drawing.Size(206, 27);
            this.TBSubtotal.TabIndex = 0;
            // 
            // LSubtotal
            // 
            this.LSubtotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtotal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LSubtotal.Location = new System.Drawing.Point(0, 0);
            this.LSubtotal.Name = "LSubtotal";
            this.LSubtotal.Size = new System.Drawing.Size(206, 22);
            this.LSubtotal.TabIndex = 1;
            this.LSubtotal.Text = "Subtotal Neto ($):";
            // 
            // PGrupoIva
            // 
            this.PGrupoIva.Controls.Add(this.TBIva);
            this.PGrupoIva.Controls.Add(this.LIva);
            this.PGrupoIva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoIva.Location = new System.Drawing.Point(212, 356);
            this.PGrupoIva.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoIva.Name = "PGrupoIva";
            this.PGrupoIva.Size = new System.Drawing.Size(206, 49);
            this.PGrupoIva.TabIndex = 12;
            // 
            // TBIva
            // 
            this.TBIva.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBIva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBIva.Location = new System.Drawing.Point(0, 22);
            this.TBIva.Name = "TBIva";
            this.TBIva.ReadOnly = true;
            this.TBIva.Size = new System.Drawing.Size(206, 27);
            this.TBIva.TabIndex = 0;
            // 
            // LIva
            // 
            this.LIva.Dock = System.Windows.Forms.DockStyle.Top;
            this.LIva.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LIva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LIva.Location = new System.Drawing.Point(0, 0);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(206, 22);
            this.LIva.TabIndex = 1;
            this.LIva.Text = "IVA (21%) ($):";
            // 
            // PGrupoTotal
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoTotal, 2);
            this.PGrupoTotal.Controls.Add(this.TBTotalCompra);
            this.PGrupoTotal.Controls.Add(this.LTotalCompra);
            this.PGrupoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTotal.Location = new System.Drawing.Point(0, 407);
            this.PGrupoTotal.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.PGrupoTotal.Name = "PGrupoTotal";
            this.PGrupoTotal.Size = new System.Drawing.Size(418, 157);
            this.PGrupoTotal.TabIndex = 13;
            // 
            // TBTotalCompra
            // 
            this.TBTotalCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TBTotalCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.TBTotalCompra.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.TBTotalCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.TBTotalCompra.Location = new System.Drawing.Point(0, 22);
            this.TBTotalCompra.Name = "TBTotalCompra";
            this.TBTotalCompra.ReadOnly = true;
            this.TBTotalCompra.Size = new System.Drawing.Size(418, 34);
            this.TBTotalCompra.TabIndex = 0;
            this.TBTotalCompra.Text = "0,00";
            this.TBTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LTotalCompra
            // 
            this.LTotalCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTotalCompra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LTotalCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LTotalCompra.Location = new System.Drawing.Point(0, 0);
            this.LTotalCompra.Name = "LTotalCompra";
            this.LTotalCompra.Size = new System.Drawing.Size(418, 22);
            this.LTotalCompra.TabIndex = 1;
            this.LTotalCompra.Text = "TOTAL DE LA COMPRA ($):";
            // 
            // PBotonesAccion
            // 
            this.PBotonesAccion.Controls.Add(this.BGuardarCompra);
            this.PBotonesAccion.Controls.Add(this.BCancelar);
            this.PBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesAccion.Location = new System.Drawing.Point(14, 647);
            this.PBotonesAccion.Name = "PBotonesAccion";
            this.PBotonesAccion.Size = new System.Drawing.Size(418, 88);
            this.PBotonesAccion.TabIndex = 1;
            // 
            // BGuardarCompra
            // 
            this.BGuardarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BGuardarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardarCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.BGuardarCompra.FlatAppearance.BorderSize = 0;
            this.BGuardarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BGuardarCompra.ForeColor = System.Drawing.Color.White;
            this.BGuardarCompra.Location = new System.Drawing.Point(0, 0);
            this.BGuardarCompra.Name = "BGuardarCompra";
            this.BGuardarCompra.Padding = new System.Windows.Forms.Padding(65, 0, 0, 0);
            this.BGuardarCompra.Size = new System.Drawing.Size(418, 40);
            this.BGuardarCompra.TabIndex = 0;
            this.BGuardarCompra.Text = "Registrar e Ingresar Stock";
            this.BGuardarCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BGuardarCompra.UseVisualStyleBackColor = false;
            this.BGuardarCompra.Click += new System.EventHandler(this.BGuardarCompra_Click);
            // 
            // BCancelar
            // 
            this.BCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCancelar.FlatAppearance.BorderSize = 0;
            this.BCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BCancelar.ForeColor = System.Drawing.Color.White;
            this.BCancelar.Location = new System.Drawing.Point(0, 48);
            this.BCancelar.Name = "BCancelar";
            this.BCancelar.Padding = new System.Windows.Forms.Padding(85, 0, 0, 0);
            this.BCancelar.Size = new System.Drawing.Size(418, 40);
            this.BCancelar.TabIndex = 1;
            this.BCancelar.Text = "Descartar Compra";
            this.BCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BCancelar.UseVisualStyleBackColor = false;
            this.BCancelar.Click += new System.EventHandler(this.BCancelar_Click);
            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 11);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(418, 23);
            this.LTituloTarjeta.TabIndex = 3;
            this.LTituloTarjeta.Text = "INGRESO DE COMPROBANTE";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LSubtituloTarjeta
            // 
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 34);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(418, 21);
            this.LSubtituloTarjeta.TabIndex = 2;
            this.LSubtituloTarjeta.Text = "Carga de factura y recepción de insumos";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PEncabezado
            // 
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(21, 15);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1492, 38);
            this.PEncabezado.TabIndex = 0;
            // 
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(395, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "GESTIÓN DE COMPRAS Y RECEPCIÓN";
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
            // FormCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCompras";
            this.Text = "Gestión de Compras";
            this.Load += new System.EventHandler(this.FormCompras_Load);
            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalleCompra)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.TLPFormularioEdicion.ResumeLayout(false);
            this.PGrupoProveedor.ResumeLayout(false);
            this.PGrupoTipoDoc.ResumeLayout(false);
            this.PGrupoNroFactura.ResumeLayout(false);
            this.PGrupoNroFactura.PerformLayout();
            this.PGrupoFecha.ResumeLayout(false);
            this.PGrupoFormaPago.ResumeLayout(false);
            this.PGrupoProducto.ResumeLayout(false);
            this.PGrupoCosto.ResumeLayout(false);
            this.PGrupoCosto.PerformLayout();
            this.PGrupoCantidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).EndInit();
            this.PGrupoBotonAgregar.ResumeLayout(false);
            this.PGrupoSubtotal.ResumeLayout(false);
            this.PGrupoSubtotal.PerformLayout();
            this.PGrupoIva.ResumeLayout(false);
            this.PGrupoIva.PerformLayout();
            this.PGrupoTotal.ResumeLayout(false);
            this.PGrupoTotal.PerformLayout();
            this.PBotonesAccion.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVDetalleCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubtotal;
        private System.Windows.Forms.DataGridViewButtonColumn ColAccionEliminar;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.TableLayoutPanel TLPFormularioEdicion;
        private System.Windows.Forms.Panel PGrupoProveedor;
        private System.Windows.Forms.Label LProveedor;
        private System.Windows.Forms.ComboBox CBProveedor;
        private System.Windows.Forms.Panel PGrupoTipoDoc;
        private System.Windows.Forms.Label LTipoComprobante;
        private System.Windows.Forms.ComboBox CBTipoComprobante;
        private System.Windows.Forms.Panel PGrupoNroFactura;
        private System.Windows.Forms.Label LNroComprobante;
        private System.Windows.Forms.TextBox TBNroComprobante;
        private System.Windows.Forms.Panel PGrupoFecha;
        private System.Windows.Forms.Label LFechaEmision;
        private System.Windows.Forms.DateTimePicker DTPFechaEmision;
        private System.Windows.Forms.Panel PGrupoFormaPago;
        private System.Windows.Forms.Label LFormaPago;
        private System.Windows.Forms.ComboBox CBFormaPago;
        private System.Windows.Forms.Label LSubtituloArticulos;
        private System.Windows.Forms.Panel PGrupoProducto;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.ComboBox CBProducto;
        private System.Windows.Forms.Panel PGrupoCosto;
        private System.Windows.Forms.Label LCostoUnitario;
        private System.Windows.Forms.TextBox TBCostoUnitario;
        private System.Windows.Forms.Panel PGrupoCantidad;
        private System.Windows.Forms.Label LCantidad;
        private System.Windows.Forms.NumericUpDown NUDCantidad;
        private System.Windows.Forms.Panel PGrupoBotonAgregar;
        private System.Windows.Forms.Button BAgregarItem;
        private System.Windows.Forms.Label LSubtituloTotales;
        private System.Windows.Forms.Panel PGrupoSubtotal;
        private System.Windows.Forms.Label LSubtotal;
        private System.Windows.Forms.TextBox TBSubtotal;
        private System.Windows.Forms.Panel PGrupoIva;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.TextBox TBIva;
        private System.Windows.Forms.Panel PGrupoTotal;
        private System.Windows.Forms.Label LTotalCompra;
        private System.Windows.Forms.TextBox TBTotalCompra;
        private System.Windows.Forms.Panel PBotonesAccion;
        private System.Windows.Forms.Button BGuardarCompra;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.Panel PBarraFiltros;
        private System.Windows.Forms.Label LBuscarArticulo;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}