namespace CapaPresentacion
{
    partial class FormHistorialVentas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PFondo = new System.Windows.Forms.Panel();
            this.TLPContenido = new System.Windows.Forms.TableLayoutPanel();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.colIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNroTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.DGVDetalle = new System.Windows.Forms.DataGridView();
            this.colCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAccionesTarjeta = new System.Windows.Forms.Panel();
            this.TLPBotonesAccion = new System.Windows.Forms.TableLayoutPanel();
            this.BReimprimir = new System.Windows.Forms.Button();
            this.BAnular = new System.Windows.Forms.Button();
            this.LTotalMonto = new System.Windows.Forms.Label();
            this.LTotalTexto = new System.Windows.Forms.Label();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LFiltroTexto = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LFiltroFecha = new System.Windows.Forms.Label();
            this.DTPDesde = new System.Windows.Forms.DateTimePicker();
            this.DTPHasta = new System.Windows.Forms.DateTimePicker();
            this.LFiltroEstado = new System.Windows.Forms.Label();
            this.CBOEstado = new System.Windows.Forms.ComboBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).BeginInit();
            this.PAccionesTarjeta.SuspendLayout();
            this.TLPBotonesAccion.SuspendLayout();
            this.PBarraFiltros.SuspendLayout();
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
            this.PFondo.Size = new System.Drawing.Size(1683, 716);
            this.PFondo.TabIndex = 0;
            // 
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.DGVVentas, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 101);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1641, 600);
            this.TLPContenido.TabIndex = 0;
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.BackgroundColor = System.Drawing.Color.White;
            this.DGVVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DGVVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVVentas.ColumnHeadersHeight = 32;
            this.DGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdVenta,
            this.colNroTicket,
            this.colFecha,
            this.colCliente,
            this.colVendedor,
            this.colFormaPago,
            this.colTotal,
            this.colEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVentas.EnableHeadersVisualStyles = false;
            this.DGVVentas.Location = new System.Drawing.Point(0, 6);
            this.DGVVentas.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.DGVVentas.MultiSelect = false;
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.RowHeadersVisible = false;
            this.DGVVentas.RowHeadersWidth = 51;
            this.DGVVentas.RowTemplate.Height = 28;
            this.DGVVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVVentas.Size = new System.Drawing.Size(1167, 594);
            this.DGVVentas.TabIndex = 0;
            // 
            // colIdVenta
            // 
            this.colIdVenta.HeaderText = "ID";
            this.colIdVenta.MinimumWidth = 6;
            this.colIdVenta.Name = "colIdVenta";
            this.colIdVenta.ReadOnly = true;
            this.colIdVenta.Visible = false;
            this.colIdVenta.Width = 125;
            // 
            // colNroTicket
            // 
            this.colNroTicket.HeaderText = "N° Ticket";
            this.colNroTicket.MinimumWidth = 6;
            this.colNroTicket.Name = "colNroTicket";
            this.colNroTicket.ReadOnly = true;
            this.colNroTicket.Width = 85;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha / Hora";
            this.colFecha.MinimumWidth = 6;
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 120;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente / Razón Social";
            this.colCliente.MinimumWidth = 6;
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colVendedor
            // 
            this.colVendedor.HeaderText = "Vendedor";
            this.colVendedor.MinimumWidth = 6;
            this.colVendedor.Name = "colVendedor";
            this.colVendedor.ReadOnly = true;
            this.colVendedor.Width = 125;
            // 
            // colFormaPago
            // 
            this.colFormaPago.HeaderText = "Pago";
            this.colFormaPago.MinimumWidth = 6;
            this.colFormaPago.Name = "colFormaPago";
            this.colFormaPago.ReadOnly = true;
            this.colFormaPago.Width = 85;
            // 
            // colTotal
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTotal.HeaderText = "Total ($)";
            this.colTotal.MinimumWidth = 6;
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 90;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.MinimumWidth = 6;
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            this.colEstado.Width = 85;
            // 
            // PTarjetaLateral
            // 
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.DGVDetalle);
            this.PTarjetaLateral.Controls.Add(this.PAccionesTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1181, 6);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.PTarjetaLateral.Size = new System.Drawing.Size(460, 594);
            this.PTarjetaLateral.TabIndex = 1;
            // 
            // DGVDetalle
            // 
            this.DGVDetalle.AllowUserToAddRows = false;
            this.DGVDetalle.AllowUserToDeleteRows = false;
            this.DGVDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.DGVDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DGVDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVDetalle.ColumnHeadersHeight = 26;
            this.DGVDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCant,
            this.colProducto,
            this.colPrecioUnit,
            this.colSubtotal});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDetalle.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGVDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetalle.EnableHeadersVisualStyles = false;
            this.DGVDetalle.Location = new System.Drawing.Point(16, 64);
            this.DGVDetalle.MultiSelect = false;
            this.DGVDetalle.Name = "DGVDetalle";
            this.DGVDetalle.ReadOnly = true;
            this.DGVDetalle.RowHeadersVisible = false;
            this.DGVDetalle.RowHeadersWidth = 51;
            this.DGVDetalle.RowTemplate.Height = 24;
            this.DGVDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDetalle.Size = new System.Drawing.Size(426, 408);
            this.DGVDetalle.TabIndex = 0;
            // 
            // colCant
            // 
            this.colCant.HeaderText = "Cant";
            this.colCant.MinimumWidth = 6;
            this.colCant.Name = "colCant";
            this.colCant.ReadOnly = true;
            this.colCant.Width = 42;
            // 
            // colProducto
            // 
            this.colProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colProducto.HeaderText = "Producto";
            this.colProducto.MinimumWidth = 6;
            this.colProducto.Name = "colProducto";
            this.colProducto.ReadOnly = true;
            // 
            // colPrecioUnit
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrecioUnit.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPrecioUnit.HeaderText = "P.Unit";
            this.colPrecioUnit.MinimumWidth = 6;
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.ReadOnly = true;
            this.colPrecioUnit.Width = 60;
            // 
            // colSubtotal
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colSubtotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.MinimumWidth = 6;
            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.ReadOnly = true;
            this.colSubtotal.Width = 65;
            // 
            // PAccionesTarjeta
            // 
            this.PAccionesTarjeta.Controls.Add(this.TLPBotonesAccion);
            this.PAccionesTarjeta.Controls.Add(this.LTotalMonto);
            this.PAccionesTarjeta.Controls.Add(this.LTotalTexto);
            this.PAccionesTarjeta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PAccionesTarjeta.Location = new System.Drawing.Point(16, 472);
            this.PAccionesTarjeta.Name = "PAccionesTarjeta";
            this.PAccionesTarjeta.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.PAccionesTarjeta.Size = new System.Drawing.Size(426, 105);
            this.PAccionesTarjeta.TabIndex = 1;
            // 
            // TLPBotonesAccion
            // 
            this.TLPBotonesAccion.ColumnCount = 2;
            this.TLPBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesAccion.Controls.Add(this.BReimprimir, 0, 0);
            this.TLPBotonesAccion.Controls.Add(this.BAnular, 1, 0);
            this.TLPBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLPBotonesAccion.Location = new System.Drawing.Point(0, 61);
            this.TLPBotonesAccion.Margin = new System.Windows.Forms.Padding(0);
            this.TLPBotonesAccion.Name = "TLPBotonesAccion";
            this.TLPBotonesAccion.RowCount = 1;
            this.TLPBotonesAccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPBotonesAccion.Size = new System.Drawing.Size(426, 44);
            this.TLPBotonesAccion.TabIndex = 0;
            // 
            // BReimprimir
            // 
            this.BReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BReimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BReimprimir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BReimprimir.FlatAppearance.BorderSize = 0;
            this.BReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BReimprimir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BReimprimir.ForeColor = System.Drawing.Color.White;
            this.BReimprimir.Location = new System.Drawing.Point(0, 0);
            this.BReimprimir.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.BReimprimir.Name = "BReimprimir";
            this.BReimprimir.Size = new System.Drawing.Size(211, 44);
            this.BReimprimir.TabIndex = 0;
            this.BReimprimir.Text = "Reimprimir";
            this.BReimprimir.UseVisualStyleBackColor = false;
            // 
            // BAnular
            // 
            this.BAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAnular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BAnular.FlatAppearance.BorderSize = 0;
            this.BAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAnular.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BAnular.ForeColor = System.Drawing.Color.White;
            this.BAnular.Location = new System.Drawing.Point(215, 0);
            this.BAnular.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.BAnular.Name = "BAnular";
            this.BAnular.Size = new System.Drawing.Size(211, 44);
            this.BAnular.TabIndex = 1;
            this.BAnular.Text = "Anular Venta";
            this.BAnular.UseVisualStyleBackColor = false;
            // 
            // LTotalMonto
            // 
            this.LTotalMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTotalMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.LTotalMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTotalMonto.Location = new System.Drawing.Point(0, 26);
            this.LTotalMonto.Name = "LTotalMonto";
            this.LTotalMonto.Size = new System.Drawing.Size(426, 35);
            this.LTotalMonto.TabIndex = 2;
            this.LTotalMonto.Text = "$ 0,00";
            // 
            // LTotalTexto
            // 
            this.LTotalTexto.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTotalTexto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LTotalTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LTotalTexto.Location = new System.Drawing.Point(0, 8);
            this.LTotalTexto.Name = "LTotalTexto";
            this.LTotalTexto.Size = new System.Drawing.Size(426, 18);
            this.LTotalTexto.TabIndex = 3;
            this.LTotalTexto.Text = "TOTAL DE LA VENTA:";
            // 
            // LSubtituloTarjeta
            // 
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(16, 41);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(426, 23);
            this.LSubtituloTarjeta.TabIndex = 2;
            this.LSubtituloTarjeta.Text = "Seleccione una venta para ver sus artículos";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloTarjeta.Location = new System.Drawing.Point(16, 15);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(426, 26);
            this.LTituloTarjeta.TabIndex = 3;
            this.LTituloTarjeta.Text = "DETALLE DEL COMPROBANTE";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.LFiltroTexto);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LFiltroFecha);
            this.PBarraFiltros.Controls.Add(this.DTPDesde);
            this.PBarraFiltros.Controls.Add(this.DTPHasta);
            this.PBarraFiltros.Controls.Add(this.LFiltroEstado);
            this.PBarraFiltros.Controls.Add(this.CBOEstado);
            this.PBarraFiltros.Controls.Add(this.BBuscar);
            this.PBarraFiltros.Controls.Add(this.BLimpiar);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(21, 51);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1641, 50);
            this.PBarraFiltros.TabIndex = 1;
            // 
            // LFiltroTexto
            // 
            this.LFiltroTexto.AutoSize = true;
            this.LFiltroTexto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LFiltroTexto.Location = new System.Drawing.Point(1, 15);
            this.LFiltroTexto.Name = "LFiltroTexto";
            this.LFiltroTexto.Size = new System.Drawing.Size(169, 20);
            this.LFiltroTexto.TabIndex = 0;
            this.LFiltroTexto.Text = "Buscar Ticket / Cliente:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBBuscar.Location = new System.Drawing.Point(190, 11);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(195, 29);
            this.TBBuscar.TabIndex = 1;
            // 
            // LFiltroFecha
            // 
            this.LFiltroFecha.AutoSize = true;
            this.LFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LFiltroFecha.Location = new System.Drawing.Point(400, 15);
            this.LFiltroFecha.Name = "LFiltroFecha";
            this.LFiltroFecha.Size = new System.Drawing.Size(60, 20);
            this.LFiltroFecha.TabIndex = 2;
            this.LFiltroFecha.Text = "Fechas:";
            // 
            // DTPDesde
            // 
            this.DTPDesde.CustomFormat = "dd/MM/yyyy";
            this.DTPDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPDesde.Location = new System.Drawing.Point(463, 11);
            this.DTPDesde.Name = "DTPDesde";
            this.DTPDesde.Size = new System.Drawing.Size(131, 27);
            this.DTPDesde.TabIndex = 3;
            // 
            // DTPHasta
            // 
            this.DTPHasta.CustomFormat = "dd/MM/yyyy";
            this.DTPHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPHasta.Location = new System.Drawing.Point(603, 11);
            this.DTPHasta.Name = "DTPHasta";
            this.DTPHasta.Size = new System.Drawing.Size(131, 27);
            this.DTPHasta.TabIndex = 4;
            // 
            // LFiltroEstado
            // 
            this.LFiltroEstado.AutoSize = true;
            this.LFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LFiltroEstado.Location = new System.Drawing.Point(750, 14);
            this.LFiltroEstado.Name = "LFiltroEstado";
            this.LFiltroEstado.Size = new System.Drawing.Size(60, 20);
            this.LFiltroEstado.TabIndex = 5;
            this.LFiltroEstado.Text = "Estado:";
            // 
            // CBOEstado
            // 
            this.CBOEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBOEstado.Items.AddRange(new object[] {
            "Todos",
            "Cobrado",
            "Pendiente",
            "Anulado"});
            this.CBOEstado.Location = new System.Drawing.Point(826, 10);
            this.CBOEstado.Name = "CBOEstado";
            this.CBOEstado.Size = new System.Drawing.Size(114, 28);
            this.CBOEstado.TabIndex = 6;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBuscar.FlatAppearance.BorderSize = 0;
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BBuscar.ForeColor = System.Drawing.Color.White;
            this.BBuscar.Location = new System.Drawing.Point(972, 8);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(80, 29);
            this.BBuscar.TabIndex = 7;
            this.BBuscar.Text = "Filtrar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiar.FlatAppearance.BorderSize = 0;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.Location = new System.Drawing.Point(1076, 8);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(80, 29);
            this.BLimpiar.TabIndex = 8;
            this.BLimpiar.Text = "Limpiar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // PEncabezado
            // 
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(21, 15);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1641, 36);
            this.PEncabezado.TabIndex = 2;
            // 
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LTituloPrincipal.Location = new System.Drawing.Point(38, 3);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(272, 32);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "HISTORIAL DE VENTAS";
            // 
            // PBIconoTitulo
            // 
            this.PBIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.PBIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.PBIconoTitulo.Name = "PBIconoTitulo";
            this.PBIconoTitulo.Size = new System.Drawing.Size(32, 32);
            this.PBIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoTitulo.TabIndex = 1;
            this.PBIconoTitulo.TabStop = false;
            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1683, 716);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHistorialVentas";
            this.Text = "Historial de Ventas";
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load);
            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).EndInit();
            this.PAccionesTarjeta.ResumeLayout(false);
            this.TLPBotonesAccion.ResumeLayout(false);
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
        private System.Windows.Forms.Label LFiltroTexto;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Label LFiltroFecha;
        private System.Windows.Forms.DateTimePicker DTPDesde;
        private System.Windows.Forms.DateTimePicker DTPHasta;
        private System.Windows.Forms.Label LFiltroEstado;
        private System.Windows.Forms.ComboBox CBOEstado;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.DataGridView DGVDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Panel PAccionesTarjeta;
        private System.Windows.Forms.Label LTotalTexto;
        private System.Windows.Forms.Label LTotalMonto;
        private System.Windows.Forms.TableLayoutPanel TLPBotonesAccion;
        private System.Windows.Forms.Button BReimprimir;
        private System.Windows.Forms.Button BAnular;
    }
}