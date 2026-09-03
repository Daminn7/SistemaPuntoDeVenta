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
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.tlpContenido = new System.Windows.Forms.TableLayoutPanel();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.colIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNroTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTarjetaLateral = new System.Windows.Forms.Panel();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.colCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAccionesTarjeta = new System.Windows.Forms.Panel();
            this.tlpBotonesAccion = new System.Windows.Forms.TableLayoutPanel();
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.lblTotalMonto = new System.Windows.Forms.Label();
            this.lblTotalTexto = new System.Windows.Forms.Label();
            this.lblSubtituloTarjeta = new System.Windows.Forms.Label();
            this.lblTituloTarjeta = new System.Windows.Forms.Label();
            this.pnlBarraFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroTexto = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.pbIconoTitulo = new System.Windows.Forms.PictureBox();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.pnlFondo.SuspendLayout();
            this.tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.pnlTarjetaLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.pnlAccionesTarjeta.SuspendLayout();
            this.tlpBotonesAccion.SuspendLayout();
            this.pnlBarraFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.pnlFondo.Controls.Add(this.tlpContenido);
            this.pnlFondo.Controls.Add(this.pnlBarraFiltros);
            this.pnlFondo.Controls.Add(this.pnlEncabezado);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFondo.Location = new System.Drawing.Point(0, 0);
            this.pnlFondo.Name = "pnlFondo";
            this.pnlFondo.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.pnlFondo.Size = new System.Drawing.Size(1683, 716);
            this.pnlFondo.TabIndex = 0;
            // 
            // tlpContenido
            // 
            this.tlpContenido.ColumnCount = 2;
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpContenido.Controls.Add(this.dgvVentas, 0, 0);
            this.tlpContenido.Controls.Add(this.pnlTarjetaLateral, 1, 0);
            this.tlpContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenido.Location = new System.Drawing.Point(21, 101);
            this.tlpContenido.Name = "tlpContenido";
            this.tlpContenido.RowCount = 1;
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenido.Size = new System.Drawing.Size(1641, 600);
            this.tlpContenido.TabIndex = 0;
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVentas.ColumnHeadersHeight = 32;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.EnableHeadersVisualStyles = false;
            this.dgvVentas.Location = new System.Drawing.Point(0, 6);
            this.dgvVentas.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.dgvVentas.MultiSelect = false;
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.RowHeadersVisible = false;
            this.dgvVentas.RowHeadersWidth = 51;
            this.dgvVentas.RowTemplate.Height = 28;
            this.dgvVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVentas.Size = new System.Drawing.Size(1167, 594);
            this.dgvVentas.TabIndex = 0;
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
            // pnlTarjetaLateral
            // 
            this.pnlTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaLateral.Controls.Add(this.dgvDetalle);
            this.pnlTarjetaLateral.Controls.Add(this.pnlAccionesTarjeta);
            this.pnlTarjetaLateral.Controls.Add(this.lblSubtituloTarjeta);
            this.pnlTarjetaLateral.Controls.Add(this.lblTituloTarjeta);
            this.pnlTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjetaLateral.Location = new System.Drawing.Point(1181, 6);
            this.pnlTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlTarjetaLateral.Name = "pnlTarjetaLateral";
            this.pnlTarjetaLateral.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.pnlTarjetaLateral.Size = new System.Drawing.Size(460, 594);
            this.pnlTarjetaLateral.TabIndex = 1;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetalle.ColumnHeadersHeight = 26;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(16, 64);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(428, 360);
            this.dgvDetalle.TabIndex = 0;
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
            // pnlAccionesTarjeta
            // 
            this.pnlAccionesTarjeta.Controls.Add(this.tlpBotonesAccion);
            this.pnlAccionesTarjeta.Controls.Add(this.btnNuevaVenta);
            this.pnlAccionesTarjeta.Controls.Add(this.lblTotalMonto);
            this.pnlAccionesTarjeta.Controls.Add(this.lblTotalTexto);
            this.pnlAccionesTarjeta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccionesTarjeta.Location = new System.Drawing.Point(16, 424);
            this.pnlAccionesTarjeta.Name = "pnlAccionesTarjeta";
            this.pnlAccionesTarjeta.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlAccionesTarjeta.Size = new System.Drawing.Size(428, 155);
            this.pnlAccionesTarjeta.TabIndex = 1;
            // 
            // tlpBotonesAccion
            // 
            this.tlpBotonesAccion.ColumnCount = 2;
            this.tlpBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotonesAccion.Controls.Add(this.btnReimprimir, 0, 0);
            this.tlpBotonesAccion.Controls.Add(this.btnAnular, 1, 0);
            this.tlpBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBotonesAccion.Location = new System.Drawing.Point(0, 111);
            this.tlpBotonesAccion.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBotonesAccion.Name = "tlpBotonesAccion";
            this.tlpBotonesAccion.RowCount = 1;
            this.tlpBotonesAccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBotonesAccion.Size = new System.Drawing.Size(428, 44);
            this.tlpBotonesAccion.TabIndex = 0;
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.btnReimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReimprimir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReimprimir.FlatAppearance.BorderSize = 0;
            this.btnReimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReimprimir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimir.ForeColor = System.Drawing.Color.White;
            this.btnReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReimprimir.Location = new System.Drawing.Point(0, 2);
            this.btnReimprimir.Margin = new System.Windows.Forms.Padding(0, 2, 1, 0);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnReimprimir.Size = new System.Drawing.Size(213, 42);
            this.btnReimprimir.TabIndex = 0;
            this.btnReimprimir.Text = "Reimprimir";
            this.btnReimprimir.UseVisualStyleBackColor = false;
            // 
            // btnAnular
            // 
            this.btnAnular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnAnular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnular.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnular.FlatAppearance.BorderSize = 0;
            this.btnAnular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnular.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.ForeColor = System.Drawing.Color.White;
            this.btnAnular.Location = new System.Drawing.Point(215, 2);
            this.btnAnular.Margin = new System.Windows.Forms.Padding(1, 2, 0, 0);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.btnAnular.Size = new System.Drawing.Size(213, 42);
            this.btnAnular.TabIndex = 1;
            this.btnAnular.Text = "Anular Venta";
            this.btnAnular.UseVisualStyleBackColor = false;
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnNuevaVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.White;
            this.btnNuevaVenta.Location = new System.Drawing.Point(0, 64);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnNuevaVenta.Size = new System.Drawing.Size(428, 48);
            this.btnNuevaVenta.TabIndex = 1;
            this.btnNuevaVenta.Text = "+ Abrir Terminal Mostrador";
            this.btnNuevaVenta.UseVisualStyleBackColor = false;
            // 
            // lblTotalMonto
            // 
            this.lblTotalMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalMonto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.lblTotalMonto.Location = new System.Drawing.Point(0, 26);
            this.lblTotalMonto.Name = "lblTotalMonto";
            this.lblTotalMonto.Size = new System.Drawing.Size(428, 38);
            this.lblTotalMonto.TabIndex = 2;
            this.lblTotalMonto.Text = "$ 0,00";
            // 
            // lblTotalTexto
            // 
            this.lblTotalTexto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTotalTexto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTotalTexto.Location = new System.Drawing.Point(0, 8);
            this.lblTotalTexto.Name = "lblTotalTexto";
            this.lblTotalTexto.Size = new System.Drawing.Size(428, 18);
            this.lblTotalTexto.TabIndex = 3;
            this.lblTotalTexto.Text = "TOTAL DE LA VENTA:";
            // 
            // lblSubtituloTarjeta
            // 
            this.lblSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtituloTarjeta.Location = new System.Drawing.Point(16, 41);
            this.lblSubtituloTarjeta.Name = "lblSubtituloTarjeta";
            this.lblSubtituloTarjeta.Size = new System.Drawing.Size(428, 23);
            this.lblSubtituloTarjeta.TabIndex = 2;
            this.lblSubtituloTarjeta.Text = "Seleccione una venta para ver sus artículos";
            this.lblSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloTarjeta
            // 
            this.lblTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.lblTituloTarjeta.Location = new System.Drawing.Point(16, 15);
            this.lblTituloTarjeta.Name = "lblTituloTarjeta";
            this.lblTituloTarjeta.Size = new System.Drawing.Size(428, 26);
            this.lblTituloTarjeta.TabIndex = 3;
            this.lblTituloTarjeta.Text = "DETALLE DEL COMPROBANTE";
            this.lblTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBarraFiltros
            // 
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroTexto);
            this.pnlBarraFiltros.Controls.Add(this.txtBuscar);
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroFecha);
            this.pnlBarraFiltros.Controls.Add(this.dtpDesde);
            this.pnlBarraFiltros.Controls.Add(this.dtpHasta);
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroEstado);
            this.pnlBarraFiltros.Controls.Add(this.cboEstado);
            this.pnlBarraFiltros.Controls.Add(this.btnBuscar);
            this.pnlBarraFiltros.Controls.Add(this.btnLimpiar);
            this.pnlBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraFiltros.Location = new System.Drawing.Point(21, 54);
            this.pnlBarraFiltros.Name = "pnlBarraFiltros";
            this.pnlBarraFiltros.Size = new System.Drawing.Size(1641, 47);
            this.pnlBarraFiltros.TabIndex = 1;
            // 
            // lblFiltroTexto
            // 
            this.lblFiltroTexto.AutoSize = true;
            this.lblFiltroTexto.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroTexto.Location = new System.Drawing.Point(1, 15);
            this.lblFiltroTexto.Name = "lblFiltroTexto";
            this.lblFiltroTexto.Size = new System.Drawing.Size(169, 20);
            this.lblFiltroTexto.TabIndex = 0;
            this.lblFiltroTexto.Text = "Buscar Ticket / Cliente:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(190, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(195, 29);
            this.txtBuscar.TabIndex = 1;
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroFecha.Location = new System.Drawing.Point(400, 15);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(60, 20);
            this.lblFiltroFecha.TabIndex = 2;
            this.lblFiltroFecha.Text = "Fechas:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(463, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(131, 27);
            this.dtpDesde.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(603, 11);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(131, 27);
            this.dtpHasta.TabIndex = 4;
            // 
            // lblFiltroEstado
            // 
            this.lblFiltroEstado.AutoSize = true;
            this.lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroEstado.Location = new System.Drawing.Point(750, 14);
            this.lblFiltroEstado.Name = "lblFiltroEstado";
            this.lblFiltroEstado.Size = new System.Drawing.Size(60, 20);
            this.lblFiltroEstado.TabIndex = 5;
            this.lblFiltroEstado.Text = "Estado:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEstado.Items.AddRange(new object[] {
            "Todos",
            "Cobrado",
            "Pendiente",
            "Anulado"});
            this.cboEstado.Location = new System.Drawing.Point(826, 10);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(114, 28);
            this.cboEstado.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(972, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 29);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Filtrar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(1076, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 29);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // pnlEncabezado (Dock = Top para que se apile antes de los filtros)
            // 
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Height = 36;
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEncabezado.Controls.Add(this.lblTituloPrincipal);
            this.pnlEncabezado.Controls.Add(this.pbIconoTitulo);

            // 
            // pbIconoTitulo (Alineado con margen)
            // 
            this.pbIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.pbIconoTitulo.Size = new System.Drawing.Size(32, 32);
            this.pbIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconoTitulo.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Text = "HISTORIAL DE VENTAS";
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTituloPrincipal.Location = new System.Drawing.Point(38, 5);
            this.lblTituloPrincipal.AutoSize = true;
            //
            this.Load += new System.EventHandler(this.FormHistorialVentas_Load);

            // 
            // FormHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1683, 716);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormHistorialVentas";
            this.Text = "Historial de Ventas";
            this.pnlFondo.ResumeLayout(false);
            this.tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.pnlTarjetaLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.pnlAccionesTarjeta.ResumeLayout(false);
            this.tlpBotonesAccion.ResumeLayout(false);
            this.pnlBarraFiltros.ResumeLayout(false);
            this.pnlBarraFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Panel pnlBarraFiltros;
        private System.Windows.Forms.Label lblFiltroTexto;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.TableLayoutPanel tlpContenido;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNroTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;

        private System.Windows.Forms.Panel pnlTarjetaLateral;
        private System.Windows.Forms.Label lblTituloTarjeta;
        private System.Windows.Forms.Label lblSubtituloTarjeta;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;

        private System.Windows.Forms.Panel pnlAccionesTarjeta;
        private System.Windows.Forms.Label lblTotalTexto;
        private System.Windows.Forms.Label lblTotalMonto;
        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.TableLayoutPanel tlpBotonesAccion;
        private System.Windows.Forms.PictureBox pbIconoTitulo;
        private System.Windows.Forms.Panel pnlEncabezado;
    } 
}