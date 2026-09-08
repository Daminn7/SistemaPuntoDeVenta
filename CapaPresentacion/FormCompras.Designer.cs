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
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PFondo = new System.Windows.Forms.Panel();
            this.TLPContenido = new System.Windows.Forms.TableLayoutPanel();
            this.DGVCompras = new System.Windows.Forms.DataGridView();
            this.ColIdCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.PGrupoSubtotal = new System.Windows.Forms.Panel();
            this.TBSubtotal = new System.Windows.Forms.TextBox();
            this.LSubtotal = new System.Windows.Forms.Label();
            this.LSubtituloTotales = new System.Windows.Forms.Label();
            this.PGrupoIva = new System.Windows.Forms.Panel();
            this.TBIva = new System.Windows.Forms.TextBox();
            this.LIva = new System.Windows.Forms.Label();
            this.PGrupoTotal = new System.Windows.Forms.Panel();
            this.TBTotalCompra = new System.Windows.Forms.TextBox();
            this.LTotalCompra = new System.Windows.Forms.Label();
            this.PHabilitado = new System.Windows.Forms.Panel();
            this.ChBCompraRegistrada = new System.Windows.Forms.CheckBox();
            this.PBotonesAccion = new System.Windows.Forms.Panel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.TLPBotonesMed = new System.Windows.Forms.TableLayoutPanel();
            this.BVerDetalle = new System.Windows.Forms.Button();
            this.BAnular = new System.Windows.Forms.Button();
            this.TPLBotonesSup = new System.Windows.Forms.TableLayoutPanel();
            this.BNuevaCompra = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LBuscar = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LFiltroProveedor = new System.Windows.Forms.Label();
            this.CBFiltroProveedor = new System.Windows.Forms.ComboBox();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCompras)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.TLPFormularioEdicion.SuspendLayout();
            this.PGrupoProveedor.SuspendLayout();
            this.PGrupoTipoDoc.SuspendLayout();
            this.PGrupoNroFactura.SuspendLayout();
            this.PGrupoFecha.SuspendLayout();
            this.PGrupoFormaPago.SuspendLayout();
            this.PGrupoSubtotal.SuspendLayout();
            this.PGrupoIva.SuspendLayout();
            this.PGrupoTotal.SuspendLayout();
            this.PHabilitado.SuspendLayout();
            this.PBotonesAccion.SuspendLayout();
            this.TLPBotonesMed.SuspendLayout();
            this.TPLBotonesSup.SuspendLayout();
            this.PBarraFiltros.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            this.SuspendLayout();
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
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.DGVCompras, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 100);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 707);
            this.TLPContenido.TabIndex = 0;
            // 
            // DGVCompras
            // 
            this.DGVCompras.AllowUserToAddRows = false;
            this.DGVCompras.AllowUserToDeleteRows = false;
            this.DGVCompras.AllowUserToResizeColumns = false;
            this.DGVCompras.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DGVCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCompras.BackgroundColor = System.Drawing.Color.White;
            this.DGVCompras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DGVCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCompras.ColumnHeadersHeight = 32;
            this.DGVCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdCompra,
            this.ColFecha,
            this.ColTipoComprobante,
            this.ColNroComprobante,
            this.ColProveedor,
            this.ColFormaPago,
            this.ColTotal,
            this.ColEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCompras.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCompras.EnableHeadersVisualStyles = false;
            this.DGVCompras.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.DGVCompras.Location = new System.Drawing.Point(0, 6);
            this.DGVCompras.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.DGVCompras.MultiSelect = false;
            this.DGVCompras.Name = "DGVCompras";
            this.DGVCompras.ReadOnly = true;
            this.DGVCompras.RowHeadersVisible = false;
            this.DGVCompras.RowHeadersWidth = 51;
            this.DGVCompras.RowTemplate.Height = 28;
            this.DGVCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCompras.Size = new System.Drawing.Size(1060, 701);
            this.DGVCompras.TabIndex = 0;
            this.DGVCompras.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCompras_CellClick);
            // 
            // ColIdCompra
            // 
            this.ColIdCompra.HeaderText = "ID";
            this.ColIdCompra.MinimumWidth = 6;
            this.ColIdCompra.Name = "ColIdCompra";
            this.ColIdCompra.ReadOnly = true;
            this.ColIdCompra.Visible = false;
            this.ColIdCompra.Width = 125;
            // 
            // ColFecha
            // 
            this.ColFecha.HeaderText = "Fecha";
            this.ColFecha.MinimumWidth = 6;
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;
            this.ColFecha.Width = 95;
            // 
            // ColTipoComprobante
            // 
            this.ColTipoComprobante.HeaderText = "Tipo";
            this.ColTipoComprobante.MinimumWidth = 6;
            this.ColTipoComprobante.Name = "ColTipoComprobante";
            this.ColTipoComprobante.ReadOnly = true;
            this.ColTipoComprobante.Width = 80;
            // 
            // ColNroComprobante
            // 
            this.ColNroComprobante.HeaderText = "N° Comprobante";
            this.ColNroComprobante.MinimumWidth = 6;
            this.ColNroComprobante.Name = "ColNroComprobante";
            this.ColNroComprobante.ReadOnly = true;
            this.ColNroComprobante.Width = 140;
            // 
            // ColProveedor
            // 
            this.ColProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColProveedor.HeaderText = "Proveedor / Razón Social";
            this.ColProveedor.MinimumWidth = 6;
            this.ColProveedor.Name = "ColProveedor";
            this.ColProveedor.ReadOnly = true;
            // 
            // ColFormaPago
            // 
            this.ColFormaPago.HeaderText = "Condición Pago";
            this.ColFormaPago.MinimumWidth = 6;
            this.ColFormaPago.Name = "ColFormaPago";
            this.ColFormaPago.ReadOnly = true;
            this.ColFormaPago.Width = 130;
            // 
            // ColTotal
            // 
            this.ColTotal.HeaderText = "Total ($)";
            this.ColTotal.MinimumWidth = 6;
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;
            this.ColTotal.Width = 120;
            // 
            // ColEstado
            // 
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.MinimumWidth = 6;
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
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoSubtotal, 1, 2);
            this.TLPFormularioEdicion.Controls.Add(this.LSubtituloTotales, 0, 3);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoIva, 0, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoTotal, 1, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PHabilitado, 0, 5);
            this.TLPFormularioEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFormularioEdicion.Location = new System.Drawing.Point(14, 55);
            this.TLPFormularioEdicion.Name = "TLPFormularioEdicion";
            this.TLPFormularioEdicion.RowCount = 6;
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFormularioEdicion.Size = new System.Drawing.Size(388, 457);
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
            this.PGrupoProveedor.Size = new System.Drawing.Size(191, 49);
            this.PGrupoProveedor.TabIndex = 0;
            // 
            // CBProveedor
            // 
            this.CBProveedor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBProveedor.Location = new System.Drawing.Point(0, 21);
            this.CBProveedor.Name = "CBProveedor";
            this.CBProveedor.Size = new System.Drawing.Size(191, 28);
            this.CBProveedor.TabIndex = 0;
            // 
            // LProveedor
            // 
            this.LProveedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.LProveedor.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LProveedor.Location = new System.Drawing.Point(0, 0);
            this.LProveedor.Name = "LProveedor";
            this.LProveedor.Size = new System.Drawing.Size(191, 22);
            this.LProveedor.TabIndex = 1;
            this.LProveedor.Text = "Proveedor:";
            // 
            // PGrupoTipoDoc
            // 
            this.PGrupoTipoDoc.Controls.Add(this.CBTipoComprobante);
            this.PGrupoTipoDoc.Controls.Add(this.LTipoComprobante);
            this.PGrupoTipoDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTipoDoc.Location = new System.Drawing.Point(197, 0);
            this.PGrupoTipoDoc.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoTipoDoc.Name = "PGrupoTipoDoc";
            this.PGrupoTipoDoc.Size = new System.Drawing.Size(191, 49);
            this.PGrupoTipoDoc.TabIndex = 1;
            // 
            // CBTipoComprobante
            // 
            this.CBTipoComprobante.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBTipoComprobante.Location = new System.Drawing.Point(0, 21);
            this.CBTipoComprobante.Name = "CBTipoComprobante";
            this.CBTipoComprobante.Size = new System.Drawing.Size(191, 28);
            this.CBTipoComprobante.TabIndex = 0;
            // 
            // LTipoComprobante
            // 
            this.LTipoComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LTipoComprobante.Location = new System.Drawing.Point(0, 0);
            this.LTipoComprobante.Name = "LTipoComprobante";
            this.LTipoComprobante.Size = new System.Drawing.Size(191, 22);
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
            this.PGrupoNroFactura.Size = new System.Drawing.Size(191, 49);
            this.PGrupoNroFactura.TabIndex = 2;
            // 
            // TBNroComprobante
            // 
            this.TBNroComprobante.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBNroComprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBNroComprobante.Location = new System.Drawing.Point(0, 22);
            this.TBNroComprobante.Name = "TBNroComprobante";
            this.TBNroComprobante.Size = new System.Drawing.Size(191, 27);
            this.TBNroComprobante.TabIndex = 0;
            // 
            // LNroComprobante
            // 
            this.LNroComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LNroComprobante.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LNroComprobante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LNroComprobante.Location = new System.Drawing.Point(0, 0);
            this.LNroComprobante.Name = "LNroComprobante";
            this.LNroComprobante.Size = new System.Drawing.Size(191, 22);
            this.LNroComprobante.TabIndex = 1;
            this.LNroComprobante.Text = "N° Factura / Comp:";
            // 
            // PGrupoFecha
            // 
            this.PGrupoFecha.Controls.Add(this.DTPFechaEmision);
            this.PGrupoFecha.Controls.Add(this.LFechaEmision);
            this.PGrupoFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFecha.Location = new System.Drawing.Point(197, 51);
            this.PGrupoFecha.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoFecha.Name = "PGrupoFecha";
            this.PGrupoFecha.Size = new System.Drawing.Size(191, 49);
            this.PGrupoFecha.TabIndex = 3;
            // 
            // DTPFechaEmision
            // 
            this.DTPFechaEmision.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DTPFechaEmision.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaEmision.Location = new System.Drawing.Point(0, 22);
            this.DTPFechaEmision.Name = "DTPFechaEmision";
            this.DTPFechaEmision.Size = new System.Drawing.Size(191, 27);
            this.DTPFechaEmision.TabIndex = 0;
            // 
            // LFechaEmision
            // 
            this.LFechaEmision.Dock = System.Windows.Forms.DockStyle.Top;
            this.LFechaEmision.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LFechaEmision.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LFechaEmision.Location = new System.Drawing.Point(0, 0);
            this.LFechaEmision.Name = "LFechaEmision";
            this.LFechaEmision.Size = new System.Drawing.Size(191, 22);
            this.LFechaEmision.TabIndex = 1;
            this.LFechaEmision.Text = "Fecha de Emisión:";
            // 
            // PGrupoFormaPago
            // 
            this.PGrupoFormaPago.Controls.Add(this.CBFormaPago);
            this.PGrupoFormaPago.Controls.Add(this.LFormaPago);
            this.PGrupoFormaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFormaPago.Location = new System.Drawing.Point(0, 102);
            this.PGrupoFormaPago.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoFormaPago.Name = "PGrupoFormaPago";
            this.PGrupoFormaPago.Size = new System.Drawing.Size(191, 49);
            this.PGrupoFormaPago.TabIndex = 4;
            // 
            // CBFormaPago
            // 
            this.CBFormaPago.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFormaPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFormaPago.Location = new System.Drawing.Point(0, 21);
            this.CBFormaPago.Name = "CBFormaPago";
            this.CBFormaPago.Size = new System.Drawing.Size(191, 28);
            this.CBFormaPago.TabIndex = 0;
            // 
            // LFormaPago
            // 
            this.LFormaPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.LFormaPago.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LFormaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LFormaPago.Location = new System.Drawing.Point(0, 0);
            this.LFormaPago.Name = "LFormaPago";
            this.LFormaPago.Size = new System.Drawing.Size(191, 22);
            this.LFormaPago.TabIndex = 1;
            this.LFormaPago.Text = "Condición de Pago:";
            // 
            // PGrupoSubtotal
            // 
            this.PGrupoSubtotal.Controls.Add(this.TBSubtotal);
            this.PGrupoSubtotal.Controls.Add(this.LSubtotal);
            this.PGrupoSubtotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoSubtotal.Location = new System.Drawing.Point(197, 102);
            this.PGrupoSubtotal.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoSubtotal.Name = "PGrupoSubtotal";
            this.PGrupoSubtotal.Size = new System.Drawing.Size(191, 49);
            this.PGrupoSubtotal.TabIndex = 5;
            // 
            // TBSubtotal
            // 
            this.TBSubtotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBSubtotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBSubtotal.Location = new System.Drawing.Point(0, 22);
            this.TBSubtotal.Name = "TBSubtotal";
            this.TBSubtotal.Size = new System.Drawing.Size(191, 27);
            this.TBSubtotal.TabIndex = 0;
            // 
            // LSubtotal
            // 
            this.LSubtotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtotal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LSubtotal.Location = new System.Drawing.Point(0, 0);
            this.LSubtotal.Name = "LSubtotal";
            this.LSubtotal.Size = new System.Drawing.Size(191, 22);
            this.LSubtotal.TabIndex = 1;
            this.LSubtotal.Text = "Subtotal Gravado ($):";
            // 
            // LSubtituloTotales
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.LSubtituloTotales, 2);
            this.LSubtituloTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LSubtituloTotales.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LSubtituloTotales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LSubtituloTotales.Location = new System.Drawing.Point(3, 153);
            this.LSubtituloTotales.Name = "LSubtituloTotales";
            this.LSubtituloTotales.Size = new System.Drawing.Size(382, 28);
            this.LSubtituloTotales.TabIndex = 6;
            this.LSubtituloTotales.Text = "TOTALES Y CIERRE";
            this.LSubtituloTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PGrupoIva
            // 
            this.PGrupoIva.Controls.Add(this.TBIva);
            this.PGrupoIva.Controls.Add(this.LIva);
            this.PGrupoIva.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoIva.Location = new System.Drawing.Point(0, 181);
            this.PGrupoIva.Margin = new System.Windows.Forms.Padding(0, 0, 3, 2);
            this.PGrupoIva.Name = "PGrupoIva";
            this.PGrupoIva.Size = new System.Drawing.Size(191, 49);
            this.PGrupoIva.TabIndex = 7;
            // 
            // TBIva
            // 
            this.TBIva.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBIva.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBIva.Location = new System.Drawing.Point(0, 22);
            this.TBIva.Name = "TBIva";
            this.TBIva.Size = new System.Drawing.Size(191, 27);
            this.TBIva.TabIndex = 0;
            // 
            // LIva
            // 
            this.LIva.Dock = System.Windows.Forms.DockStyle.Top;
            this.LIva.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LIva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LIva.Location = new System.Drawing.Point(0, 0);
            this.LIva.Name = "LIva";
            this.LIva.Size = new System.Drawing.Size(191, 22);
            this.LIva.TabIndex = 1;
            this.LIva.Text = "IVA / Percepciones ($):";
            // 
            // PGrupoTotal
            // 
            this.PGrupoTotal.Controls.Add(this.TBTotalCompra);
            this.PGrupoTotal.Controls.Add(this.LTotalCompra);
            this.PGrupoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTotal.Location = new System.Drawing.Point(197, 181);
            this.PGrupoTotal.Margin = new System.Windows.Forms.Padding(3, 0, 0, 2);
            this.PGrupoTotal.Name = "PGrupoTotal";
            this.PGrupoTotal.Size = new System.Drawing.Size(191, 49);
            this.PGrupoTotal.TabIndex = 8;
            // 
            // TBTotalCompra
            // 
            this.TBTotalCompra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBTotalCompra.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.TBTotalCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.TBTotalCompra.Location = new System.Drawing.Point(0, 20);
            this.TBTotalCompra.Name = "TBTotalCompra";
            this.TBTotalCompra.Size = new System.Drawing.Size(191, 29);
            this.TBTotalCompra.TabIndex = 0;
            // 
            // LTotalCompra
            // 
            this.LTotalCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTotalCompra.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTotalCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LTotalCompra.Location = new System.Drawing.Point(0, 0);
            this.LTotalCompra.Name = "LTotalCompra";
            this.LTotalCompra.Size = new System.Drawing.Size(191, 22);
            this.LTotalCompra.TabIndex = 1;
            this.LTotalCompra.Text = "Total Factura ($):";
            // 
            // PHabilitado
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PHabilitado, 2);
            this.PHabilitado.Controls.Add(this.ChBCompraRegistrada);
            this.PHabilitado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHabilitado.Location = new System.Drawing.Point(3, 235);
            this.PHabilitado.Name = "PHabilitado";
            this.PHabilitado.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.PHabilitado.Size = new System.Drawing.Size(382, 219);
            this.PHabilitado.TabIndex = 9;
            // 
            // ChBCompraRegistrada
            // 
            this.ChBCompraRegistrada.Checked = true;
            this.ChBCompraRegistrada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChBCompraRegistrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChBCompraRegistrada.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.ChBCompraRegistrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.ChBCompraRegistrada.Location = new System.Drawing.Point(0, 8);
            this.ChBCompraRegistrada.Name = "ChBCompraRegistrada";
            this.ChBCompraRegistrada.Size = new System.Drawing.Size(382, 26);
            this.ChBCompraRegistrada.TabIndex = 0;
            this.ChBCompraRegistrada.Text = "Impactar inmediatamente en el Stock";
            // 
            // PBotonesAccion
            // 
            this.PBotonesAccion.Controls.Add(this.BLimpiar);
            this.PBotonesAccion.Controls.Add(this.TLPBotonesMed);
            this.PBotonesAccion.Controls.Add(this.TPLBotonesSup);
            this.PBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesAccion.Location = new System.Drawing.Point(14, 512);
            this.PBotonesAccion.Name = "PBotonesAccion";
            this.PBotonesAccion.Size = new System.Drawing.Size(388, 176);
            this.PBotonesAccion.TabIndex = 1;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
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
            // 
            // TLPBotonesMed
            // 
            this.TLPBotonesMed.ColumnCount = 2;
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.Controls.Add(this.BVerDetalle, 0, 0);
            this.TLPBotonesMed.Controls.Add(this.BAnular, 1, 0);
            this.TLPBotonesMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPBotonesMed.Location = new System.Drawing.Point(0, 55);
            this.TLPBotonesMed.Name = "TLPBotonesMed";
            this.TLPBotonesMed.Size = new System.Drawing.Size(388, 55);
            this.TLPBotonesMed.TabIndex = 1;
            // 
            // BVerDetalle
            // 
            this.BVerDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVerDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BVerDetalle.FlatAppearance.BorderSize = 0;
            this.BVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVerDetalle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BVerDetalle.ForeColor = System.Drawing.Color.White;
            this.BVerDetalle.Location = new System.Drawing.Point(0, 0);
            this.BVerDetalle.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.BVerDetalle.Name = "BVerDetalle";
            this.BVerDetalle.Padding = new System.Windows.Forms.Padding(36, 0, 0, 0);
            this.BVerDetalle.Size = new System.Drawing.Size(191, 52);
            this.BVerDetalle.TabIndex = 0;
            this.BVerDetalle.Text = "Editar";
            this.BVerDetalle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BVerDetalle.UseVisualStyleBackColor = false;
            // 
            // BAnular
            // 
            this.BAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAnular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BAnular.FlatAppearance.BorderSize = 0;
            this.BAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAnular.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BAnular.ForeColor = System.Drawing.Color.White;
            this.BAnular.Location = new System.Drawing.Point(197, 0);
            this.BAnular.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.BAnular.Name = "BAnular";
            this.BAnular.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.BAnular.Size = new System.Drawing.Size(191, 52);
            this.BAnular.TabIndex = 1;
            this.BAnular.Text = "Dar de Baja";
            this.BAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAnular.UseVisualStyleBackColor = false;
            // 
            // TPLBotonesSup
            // 
            this.TPLBotonesSup.ColumnCount = 2;
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.Controls.Add(this.BNuevaCompra, 0, 0);
            this.TPLBotonesSup.Controls.Add(this.BGuardar, 1, 0);
            this.TPLBotonesSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TPLBotonesSup.Location = new System.Drawing.Point(0, 0);
            this.TPLBotonesSup.Name = "TPLBotonesSup";
            this.TPLBotonesSup.Size = new System.Drawing.Size(388, 55);
            this.TPLBotonesSup.TabIndex = 2;
            // 
            // BNuevaCompra
            // 
            this.BNuevaCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BNuevaCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevaCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BNuevaCompra.FlatAppearance.BorderSize = 0;
            this.BNuevaCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevaCompra.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BNuevaCompra.ForeColor = System.Drawing.Color.White;
            this.BNuevaCompra.Location = new System.Drawing.Point(0, 0);
            this.BNuevaCompra.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.BNuevaCompra.Name = "BNuevaCompra";
            this.BNuevaCompra.Padding = new System.Windows.Forms.Padding(34, 0, 0, 0);
            this.BNuevaCompra.Size = new System.Drawing.Size(191, 52);
            this.BNuevaCompra.TabIndex = 0;
            this.BNuevaCompra.Text = "Nueva";
            this.BNuevaCompra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BNuevaCompra.UseVisualStyleBackColor = false;
            // 
            // BGuardar
            // 
            this.BGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
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
            this.LSubtituloTarjeta.Text = "Comprobantes y recepción de insumos";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 11);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(388, 23);
            this.LTituloTarjeta.TabIndex = 3;
            this.LTituloTarjeta.Text = "REGISTRO DE COMPRA";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.LBuscar);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LFiltroProveedor);
            this.PBarraFiltros.Controls.Add(this.CBFiltroProveedor);
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
            this.LBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LBuscar.Location = new System.Drawing.Point(3, 16);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(227, 20);
            this.LBuscar.TabIndex = 0;
            this.LBuscar.Text = "Buscar por N° Comp. / Insumo:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBBuscar.Location = new System.Drawing.Point(230, 11);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(290, 27);
            this.TBBuscar.TabIndex = 1;
            // 
            // LFiltroProveedor
            // 
            this.LFiltroProveedor.AutoSize = true;
            this.LFiltroProveedor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroProveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LFiltroProveedor.Location = new System.Drawing.Point(550, 15);
            this.LFiltroProveedor.Name = "LFiltroProveedor";
            this.LFiltroProveedor.Size = new System.Drawing.Size(86, 20);
            this.LFiltroProveedor.TabIndex = 2;
            this.LFiltroProveedor.Text = "Proveedor:";
            // 
            // CBFiltroProveedor
            // 
            this.CBFiltroProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltroProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFiltroProveedor.Location = new System.Drawing.Point(645, 10);
            this.CBFiltroProveedor.Name = "CBFiltroProveedor";
            this.CBFiltroProveedor.Size = new System.Drawing.Size(200, 28);
            this.CBFiltroProveedor.TabIndex = 3;
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.BLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(860, 9);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(86, 29);
            this.BLimpiarFiltros.TabIndex = 4;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
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
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(231, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "GESTIÓN DE COMPRAS";
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
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).EndInit();
            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCompras)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.TLPFormularioEdicion.ResumeLayout(false);
            this.PGrupoProveedor.ResumeLayout(false);
            this.PGrupoTipoDoc.ResumeLayout(false);
            this.PGrupoNroFactura.ResumeLayout(false);
            this.PGrupoNroFactura.PerformLayout();
            this.PGrupoFecha.ResumeLayout(false);
            this.PGrupoFormaPago.ResumeLayout(false);
            this.PGrupoSubtotal.ResumeLayout(false);
            this.PGrupoSubtotal.PerformLayout();
            this.PGrupoIva.ResumeLayout(false);
            this.PGrupoIva.PerformLayout();
            this.PGrupoTotal.ResumeLayout(false);
            this.PGrupoTotal.PerformLayout();
            this.PHabilitado.ResumeLayout(false);
            this.PBotonesAccion.ResumeLayout(false);
            this.TLPBotonesMed.ResumeLayout(false);
            this.TPLBotonesSup.ResumeLayout(false);
            this.PBarraFiltros.ResumeLayout(false);
            this.PBarraFiltros.PerformLayout();
            this.PEncabezado.ResumeLayout(false);
            this.PEncabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PFondo;
        private System.Windows.Forms.Panel PEncabezado;
        private System.Windows.Forms.Label LTituloPrincipal;
        private System.Windows.Forms.Panel PBarraFiltros;
        private System.Windows.Forms.Label LBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label LFiltroProveedor;
        private System.Windows.Forms.ComboBox CBFiltroProveedor;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
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
        private System.Windows.Forms.Panel PGrupoSubtotal;
        private System.Windows.Forms.Label LSubtotal;
        private System.Windows.Forms.TextBox TBSubtotal;
        private System.Windows.Forms.Label LSubtituloTotales;
        private System.Windows.Forms.Panel PGrupoIva;
        private System.Windows.Forms.Label LIva;
        private System.Windows.Forms.TextBox TBIva;
        private System.Windows.Forms.Panel PGrupoTotal;
        private System.Windows.Forms.Label LTotalCompra;
        private System.Windows.Forms.TextBox TBTotalCompra;
        private System.Windows.Forms.Panel PHabilitado;
        private System.Windows.Forms.CheckBox ChBCompraRegistrada;
        private System.Windows.Forms.Panel PBotonesAccion;
        private System.Windows.Forms.TableLayoutPanel TPLBotonesSup;
        private System.Windows.Forms.Button BNuevaCompra;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.TableLayoutPanel TLPBotonesMed;
        private System.Windows.Forms.Button BVerDetalle;
        private System.Windows.Forms.Button BAnular;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.PictureBox PBIconoTitulo;
    }
}