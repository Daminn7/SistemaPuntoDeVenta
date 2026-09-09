namespace CapaPresentacion
{
    partial class FormCobroVenta
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
            this.SCIzquierda = new System.Windows.Forms.SplitContainer();
            this.LSubtituloPendientes = new System.Windows.Forms.Label();
            this.DGVPendientes = new System.Windows.Forms.DataGridView();
            this.ColIdPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.LSubtituloDetalle = new System.Windows.Forms.Label();
            this.DGVDetalle = new System.Windows.Forms.DataGridView();
            this.ColDetCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDetDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDetCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDetPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDetSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.PBotonesCobro = new System.Windows.Forms.Panel();
            this.BAnularPedido = new System.Windows.Forms.Button();
            this.BConfirmarCobro = new System.Windows.Forms.Button();

            this.PCalculoPago = new System.Windows.Forms.Panel();
            this.LValorVuelto = new System.Windows.Forms.Label();
            this.LTituloVuelto = new System.Windows.Forms.Label();
            this.TBPagaCon = new System.Windows.Forms.TextBox();
            this.LTituloPagaCon = new System.Windows.Forms.Label();

            this.PFormaPago = new System.Windows.Forms.Panel();
            this.CBComprobante = new System.Windows.Forms.ComboBox();
            this.LTipoComprobante = new System.Windows.Forms.Label();
            this.CBMedioPago = new System.Windows.Forms.ComboBox();
            this.LTituloMedioPago = new System.Windows.Forms.Label();

            this.PContenedorTotal = new System.Windows.Forms.Panel();
            this.LTotalMonto = new System.Windows.Forms.Label();
            this.LTituloTotal = new System.Windows.Forms.Label();

            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();

            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();

            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SCIzquierda)).BeginInit();
            this.SCIzquierda.Panel1.SuspendLayout();
            this.SCIzquierda.Panel2.SuspendLayout();
            this.SCIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.PBotonesCobro.SuspendLayout();
            this.PCalculoPago.SuspendLayout();
            this.PFormaPago.SuspendLayout();
            this.PContenedorTotal.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();

            // PFondo
            this.PFondo.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.PFondo.Controls.Add(this.TLPContenido);
            this.PFondo.Controls.Add(this.PEncabezado);
            this.PFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFondo.Location = new System.Drawing.Point(0, 0);
            this.PFondo.Name = "PFondo";
            this.PFondo.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PFondo.Size = new System.Drawing.Size(1534, 822);
            this.PFondo.TabIndex = 0;

            // PEncabezado
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(21, 15);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1492, 38);
            this.PEncabezado.TabIndex = 2;

            this.PBIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.PBIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.PBIconoTitulo.Name = "PBIconoTitulo";
            this.PBIconoTitulo.Size = new System.Drawing.Size(37, 34);
            this.PBIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoTitulo.TabIndex = 1;
            this.PBIconoTitulo.TabStop = false;

            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.LTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(340, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "COBRO DE PEDIDOS Y CAJA";

            // TLPContenido
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.SCIzquierda, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 53);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 754);
            this.TLPContenido.TabIndex = 0;

            // SCIzquierda (Parte superior: Pendientes, Parte inferior: Detalle de ítems)
            this.SCIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SCIzquierda.Location = new System.Drawing.Point(0, 0);
            this.SCIzquierda.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.SCIzquierda.Name = "SCIzquierda";
            this.SCIzquierda.Orientation = System.Windows.Forms.Orientation.Horizontal;

            // Panel1: Pendientes
            this.SCIzquierda.Panel1.Controls.Add(this.DGVPendientes);
            this.SCIzquierda.Panel1.Controls.Add(this.LSubtituloPendientes);
            // Panel2: Detalle de pedido
            this.SCIzquierda.Panel2.Controls.Add(this.DGVDetalle);
            this.SCIzquierda.Panel2.Controls.Add(this.LSubtituloDetalle);
            this.SCIzquierda.Size = new System.Drawing.Size(1060, 754);
            this.SCIzquierda.SplitterDistance = 370;
            this.SCIzquierda.TabIndex = 0;

            // LSubtituloPendientes
            this.LSubtituloPendientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloPendientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LSubtituloPendientes.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LSubtituloPendientes.Location = new System.Drawing.Point(0, 0);
            this.LSubtituloPendientes.Name = "LSubtituloPendientes";
            this.LSubtituloPendientes.Size = new System.Drawing.Size(1060, 24);
            this.LSubtituloPendientes.TabIndex = 0;
            this.LSubtituloPendientes.Text = "PEDIDOS EMITIDOS EN PREVENTA (PENDIENTES DE COBRO):";

            // DGVPendientes
            this.DGVPendientes.AllowUserToAddRows = false;
            this.DGVPendientes.AllowUserToDeleteRows = false;
            this.DGVPendientes.BackgroundColor = System.Drawing.Color.White;
            this.DGVPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVPendientes.ColumnHeadersHeight = 32;
            this.DGVPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPendientes.EnableHeadersVisualStyles = false;
            this.DGVPendientes.GridColor = System.Drawing.Color.FromArgb(230, 233, 238);
            this.DGVPendientes.MultiSelect = false;
            this.DGVPendientes.ReadOnly = true;
            this.DGVPendientes.RowHeadersVisible = false;
            this.DGVPendientes.RowTemplate.Height = 28;
            this.DGVPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.DGVPendientes.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;

            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVPendientes.DefaultCellStyle = dgvRowStyle;

            this.DGVPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColIdPedido,
                this.ColNroPedido,
                this.ColHora,
                this.ColVendedor,
                this.ColCliente,
                this.ColTotalPedido
            });
            this.DGVPendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPendientes.Location = new System.Drawing.Point(0, 24);
            this.DGVPendientes.Name = "DGVPendientes";
            this.DGVPendientes.Size = new System.Drawing.Size(1060, 346);
            this.DGVPendientes.TabIndex = 1;
            this.DGVPendientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPendientes_CellClick);

            this.ColIdPedido.HeaderText = "ID";
            this.ColIdPedido.Name = "ColIdPedido";
            this.ColIdPedido.ReadOnly = true;
            this.ColIdPedido.Visible = false;

            this.ColNroPedido.HeaderText = "N° Pedido";
            this.ColNroPedido.Width = 140;
            this.ColNroPedido.Name = "ColNroPedido";
            this.ColNroPedido.ReadOnly = true;

            this.ColHora.HeaderText = "Hora Emisión";
            this.ColHora.Width = 110;
            this.ColHora.Name = "ColHora";
            this.ColHora.ReadOnly = true;

            this.ColVendedor.HeaderText = "Vendedor";
            this.ColVendedor.Width = 140;
            this.ColVendedor.Name = "ColVendedor";
            this.ColVendedor.ReadOnly = true;

            this.ColCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCliente.HeaderText = "Cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;

            this.ColTotalPedido.HeaderText = "Total Pedido ($)";
            this.ColTotalPedido.Width = 140;
            this.ColTotalPedido.Name = "ColTotalPedido";
            this.ColTotalPedido.ReadOnly = true;

            // LSubtituloDetalle
            this.LSubtituloDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LSubtituloDetalle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LSubtituloDetalle.Location = new System.Drawing.Point(0, 0);
            this.LSubtituloDetalle.Name = "LSubtituloDetalle";
            this.LSubtituloDetalle.Size = new System.Drawing.Size(1060, 24);
            this.LSubtituloDetalle.TabIndex = 0;
            this.LSubtituloDetalle.Text = "DETALLE DE ARTÍCULOS DEL PEDIDO SELECCIONADO:";

            // DGVDetalle
            this.DGVDetalle.AllowUserToAddRows = false;
            this.DGVDetalle.AllowUserToDeleteRows = false;
            this.DGVDetalle.BackgroundColor = System.Drawing.Color.White;
            this.DGVDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVDetalle.ColumnHeadersHeight = 30;
            this.DGVDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVDetalle.EnableHeadersVisualStyles = false;
            this.DGVDetalle.GridColor = System.Drawing.Color.FromArgb(230, 233, 238);
            this.DGVDetalle.MultiSelect = false;
            this.DGVDetalle.ReadOnly = true;
            this.DGVDetalle.RowHeadersVisible = false;
            this.DGVDetalle.RowTemplate.Height = 26;
            this.DGVDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.DGVDetalle.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.DGVDetalle.DefaultCellStyle = dgvRowStyle;

            this.DGVDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColDetCodigo,
                this.ColDetDesc,
                this.ColDetCant,
                this.ColDetPrecio,
                this.ColDetSubtotal
            });
            this.DGVDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetalle.Location = new System.Drawing.Point(0, 24);
            this.DGVDetalle.Name = "DGVDetalle";
            this.DGVDetalle.Size = new System.Drawing.Size(1060, 356);
            this.DGVDetalle.TabIndex = 1;

            this.ColDetCodigo.HeaderText = "Código";
            this.ColDetCodigo.Width = 110;
            this.ColDetCodigo.Name = "ColDetCodigo";
            this.ColDetCodigo.ReadOnly = true;

            this.ColDetDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDetDesc.HeaderText = "Insumo / Descripción";
            this.ColDetDesc.Name = "ColDetDesc";
            this.ColDetDesc.ReadOnly = true;

            this.ColDetCant.HeaderText = "Cantidad";
            this.ColDetCant.Width = 90;
            this.ColDetCant.Name = "ColDetCant";
            this.ColDetCant.ReadOnly = true;

            this.ColDetPrecio.HeaderText = "Precio Unit. ($)";
            this.ColDetPrecio.Width = 130;
            this.ColDetPrecio.Name = "ColDetPrecio";
            this.ColDetPrecio.ReadOnly = true;

            this.ColDetSubtotal.HeaderText = "Subtotal ($)";
            this.ColDetSubtotal.Width = 130;
            this.ColDetSubtotal.Name = "ColDetSubtotal";
            this.ColDetSubtotal.ReadOnly = true;

            // PTarjetaLateral
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.PBotonesCobro);
            this.PTarjetaLateral.Controls.Add(this.PCalculoPago);
            this.PTarjetaLateral.Controls.Add(this.PFormaPago);
            this.PTarjetaLateral.Controls.Add(this.PContenedorTotal);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1074, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14);
            this.PTarjetaLateral.Size = new System.Drawing.Size(418, 754);
            this.PTarjetaLateral.TabIndex = 1;

            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 14);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(388, 24);
            this.LTituloTarjeta.TabIndex = 0;
            this.LTituloTarjeta.Text = "TERMINAL DE COBRO";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 38);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(388, 20);
            this.LSubtituloTarjeta.TabIndex = 1;
            this.LSubtituloTarjeta.Text = "Facturación y registro de caja";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // PContenedorTotal
            this.PContenedorTotal.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PContenedorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorTotal.Controls.Add(this.LTotalMonto);
            this.PContenedorTotal.Controls.Add(this.LTituloTotal);
            this.PContenedorTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.PContenedorTotal.Location = new System.Drawing.Point(14, 58);
            this.PContenedorTotal.Name = "PContenedorTotal";
            this.PContenedorTotal.Padding = new System.Windows.Forms.Padding(10);
            this.PContenedorTotal.Size = new System.Drawing.Size(388, 85);
            this.PContenedorTotal.TabIndex = 2;

            this.LTituloTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTotal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTituloTotal.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.LTituloTotal.Location = new System.Drawing.Point(10, 10);
            this.LTituloTotal.Name = "LTituloTotal";
            this.LTituloTotal.Size = new System.Drawing.Size(366, 20);
            this.LTituloTotal.Text = "TOTAL A COBRAR:";

            this.LTotalMonto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LTotalMonto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.LTotalMonto.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LTotalMonto.Location = new System.Drawing.Point(10, 33);
            this.LTotalMonto.Name = "LTotalMonto";
            this.LTotalMonto.Size = new System.Drawing.Size(366, 40);
            this.LTotalMonto.TabIndex = 1;
            this.LTotalMonto.Text = "$ 0,00";

            // PFormaPago
            this.PFormaPago.Controls.Add(this.CBComprobante);
            this.PFormaPago.Controls.Add(this.LTipoComprobante);
            this.PFormaPago.Controls.Add(this.CBMedioPago);
            this.PFormaPago.Controls.Add(this.LTituloMedioPago);
            this.PFormaPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.PFormaPago.Location = new System.Drawing.Point(14, 143);
            this.PFormaPago.Name = "PFormaPago";
            this.PFormaPago.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PFormaPago.Size = new System.Drawing.Size(388, 140);
            this.PFormaPago.TabIndex = 3;

            this.LTituloMedioPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloMedioPago.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTituloMedioPago.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LTituloMedioPago.Location = new System.Drawing.Point(0, 10);
            this.LTituloMedioPago.Name = "LTituloMedioPago";
            this.LTituloMedioPago.Size = new System.Drawing.Size(388, 22);
            this.LTituloMedioPago.Text = "Medio de Cobro:";

            this.CBMedioPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.CBMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBMedioPago.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.CBMedioPago.Location = new System.Drawing.Point(0, 32);
            this.CBMedioPago.Name = "CBMedioPago";
            this.CBMedioPago.Size = new System.Drawing.Size(388, 29);
            this.CBMedioPago.TabIndex = 0;

            this.LTipoComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTipoComprobante.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LTipoComprobante.Location = new System.Drawing.Point(0, 61);
            this.LTipoComprobante.Name = "LTipoComprobante";
            this.LTipoComprobante.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.LTipoComprobante.Size = new System.Drawing.Size(388, 30);
            this.LTipoComprobante.TabIndex = 1;
            this.LTipoComprobante.Text = "Tipo de Comprobante:";

            this.CBComprobante.Dock = System.Windows.Forms.DockStyle.Top;
            this.CBComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBComprobante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.CBComprobante.Location = new System.Drawing.Point(0, 91);
            this.CBComprobante.Name = "CBComprobante";
            this.CBComprobante.Size = new System.Drawing.Size(388, 29);
            this.CBComprobante.TabIndex = 2;

            // PCalculoPago
            this.PCalculoPago.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PCalculoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCalculoPago.Controls.Add(this.LValorVuelto);
            this.PCalculoPago.Controls.Add(this.LTituloVuelto);
            this.PCalculoPago.Controls.Add(this.TBPagaCon);
            this.PCalculoPago.Controls.Add(this.LTituloPagaCon);
            this.PCalculoPago.Dock = System.Windows.Forms.DockStyle.Top;
            this.PCalculoPago.Location = new System.Drawing.Point(14, 283);
            this.PCalculoPago.Name = "PCalculoPago";
            this.PCalculoPago.Padding = new System.Windows.Forms.Padding(10);
            this.PCalculoPago.Size = new System.Drawing.Size(388, 125);
            this.PCalculoPago.TabIndex = 4;

            this.LTituloPagaCon.AutoSize = true;
            this.LTituloPagaCon.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTituloPagaCon.ForeColor = System.Drawing.Color.FromArgb(70, 70, 70);
            this.LTituloPagaCon.Location = new System.Drawing.Point(10, 12);
            this.LTituloPagaCon.Name = "LTituloPagaCon";
            this.LTituloPagaCon.Size = new System.Drawing.Size(95, 20);
            this.LTituloPagaCon.TabIndex = 0;
            this.LTituloPagaCon.Text = "Abona con ($):";

            this.TBPagaCon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBPagaCon.Location = new System.Drawing.Point(120, 8);
            this.TBPagaCon.Name = "TBPagaCon";
            this.TBPagaCon.Size = new System.Drawing.Size(180, 32);
            this.TBPagaCon.TabIndex = 1;

            this.LTituloVuelto.AutoSize = true;
            this.LTituloVuelto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.LTituloVuelto.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.LTituloVuelto.Location = new System.Drawing.Point(10, 68);
            this.LTituloVuelto.Name = "LTituloVuelto";
            this.LTituloVuelto.Size = new System.Drawing.Size(107, 21);
            this.LTituloVuelto.TabIndex = 2;
            this.LTituloVuelto.Text = "Vuelto / Cambio:";

            this.LValorVuelto.AutoSize = true;
            this.LValorVuelto.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorVuelto.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.LValorVuelto.Location = new System.Drawing.Point(135, 62);
            this.LValorVuelto.Name = "LValorVuelto";
            this.LValorVuelto.Size = new System.Drawing.Size(76, 31);
            this.LValorVuelto.TabIndex = 3;
            this.LValorVuelto.Text = "$ 0,00";

            // PBotonesCobro
            this.PBotonesCobro.Controls.Add(this.BAnularPedido);
            this.PBotonesCobro.Controls.Add(this.BConfirmarCobro);
            this.PBotonesCobro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesCobro.Location = new System.Drawing.Point(14, 616);
            this.PBotonesCobro.Name = "PBotonesCobro";
            this.PBotonesCobro.Size = new System.Drawing.Size(388, 122);
            this.PBotonesCobro.TabIndex = 5;
            // 
            // BConfirmarCobro
            // 
            this.BConfirmarCobro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BConfirmarCobro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BConfirmarCobro.Dock = System.Windows.Forms.DockStyle.Top;
            this.BConfirmarCobro.FlatAppearance.BorderSize = 0;
            this.BConfirmarCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConfirmarCobro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BConfirmarCobro.ForeColor = System.Drawing.Color.White;
            this.BConfirmarCobro.Location = new System.Drawing.Point(0, 0);
            this.BConfirmarCobro.Name = "BConfirmarCobro";
            this.BConfirmarCobro.Padding = new System.Windows.Forms.Padding(54, 0, 0, 0);
            this.BConfirmarCobro.Size = new System.Drawing.Size(388, 54);
            this.BConfirmarCobro.TabIndex = 0;
            this.BConfirmarCobro.Text = "Cobrar y Emitir Factura";
            this.BConfirmarCobro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BConfirmarCobro.UseVisualStyleBackColor = false;
            this.BConfirmarCobro.Click += new System.EventHandler(this.BConfirmarCobro_Click);

            // 
            // BAnularPedido
            // 
            this.BAnularPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BAnularPedido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAnularPedido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BAnularPedido.FlatAppearance.BorderSize = 0;
            this.BAnularPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAnularPedido.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BAnularPedido.ForeColor = System.Drawing.Color.White;
            this.BAnularPedido.Location = new System.Drawing.Point(0, 68);
            this.BAnularPedido.Name = "BAnularPedido";
            this.BAnularPedido.Padding = new System.Windows.Forms.Padding(48, 0, 0, 0);
            this.BAnularPedido.Size = new System.Drawing.Size(388, 54);
            this.BAnularPedido.TabIndex = 1;
            this.BAnularPedido.Text = "Descartar / Anular Pedido";
            this.BAnularPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BAnularPedido.UseVisualStyleBackColor = false;
            this.BAnularPedido.Click += new System.EventHandler(this.BAnularPedido_Click);

            // FormCobroVenta
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCobroVenta";
            this.Text = "Cobro de Ventas";
            this.Load += new System.EventHandler(this.FormCobroVenta_Load);

            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            this.SCIzquierda.Panel1.ResumeLayout(false);
            this.SCIzquierda.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SCIzquierda)).EndInit();
            this.SCIzquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.PBotonesCobro.ResumeLayout(false);
            this.PCalculoPago.ResumeLayout(false);
            this.PCalculoPago.PerformLayout();
            this.PFormaPago.ResumeLayout(false);
            this.PContenedorTotal.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer SCIzquierda;
        private System.Windows.Forms.Label LSubtituloPendientes;
        private System.Windows.Forms.DataGridView DGVPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPedido;
        private System.Windows.Forms.Label LSubtituloDetalle;
        private System.Windows.Forms.DataGridView DGVDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDetSubtotal;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.Panel PContenedorTotal;
        private System.Windows.Forms.Label LTituloTotal;
        private System.Windows.Forms.Label LTotalMonto;
        private System.Windows.Forms.Panel PFormaPago;
        private System.Windows.Forms.Label LTituloMedioPago;
        private System.Windows.Forms.ComboBox CBMedioPago;
        private System.Windows.Forms.Label LTipoComprobante;
        private System.Windows.Forms.ComboBox CBComprobante;
        private System.Windows.Forms.Panel PCalculoPago;
        private System.Windows.Forms.Label LTituloPagaCon;
        private System.Windows.Forms.TextBox TBPagaCon;
        private System.Windows.Forms.Label LTituloVuelto;
        private System.Windows.Forms.Label LValorVuelto;
        private System.Windows.Forms.Panel PBotonesCobro;
        private System.Windows.Forms.Button BConfirmarCobro;
        private System.Windows.Forms.Button BAnularPedido;
    }
}