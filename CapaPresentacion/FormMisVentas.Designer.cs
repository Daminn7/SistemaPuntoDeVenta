namespace CapaPresentacion
{
    partial class FormMisVentas
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
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.ColIdVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.PBotonesAccion = new System.Windows.Forms.Panel();
            this.BExportarExcel = new System.Windows.Forms.Button();
            this.BReimprimirTicket = new System.Windows.Forms.Button();
            this.TLPMetricas = new System.Windows.Forms.TableLayoutPanel();
            this.PGrupoTotalVentas = new System.Windows.Forms.Panel();
            this.LValorTotalVentas = new System.Windows.Forms.Label();
            this.LTituloTotalVentas = new System.Windows.Forms.Label();
            this.PGrupoOperaciones = new System.Windows.Forms.Panel();
            this.LValorOperaciones = new System.Windows.Forms.Label();
            this.LTituloOperaciones = new System.Windows.Forms.Label();
            this.PGrupoComision = new System.Windows.Forms.Panel();
            this.LValorComision = new System.Windows.Forms.Label();
            this.LTituloComision = new System.Windows.Forms.Label();

            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();

            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.CBFiltroEstado = new System.Windows.Forms.ComboBox();
            this.LFiltroEstado = new System.Windows.Forms.Label();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LBuscar = new System.Windows.Forms.Label();

            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();

            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.PBotonesAccion.SuspendLayout();
            this.TLPMetricas.SuspendLayout();
            this.PGrupoTotalVentas.SuspendLayout();
            this.PGrupoOperaciones.SuspendLayout();
            this.PGrupoComision.SuspendLayout();
            this.PBarraFiltros.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();

            // PFondo
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
            this.LTituloPrincipal.Size = new System.Drawing.Size(370, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "MIS VENTAS Y PEDIDOS REALIZADOS";

            // PBarraFiltros
            this.PBarraFiltros.Controls.Add(this.BLimpiarFiltros);
            this.PBarraFiltros.Controls.Add(this.CBFiltroEstado);
            this.PBarraFiltros.Controls.Add(this.LFiltroEstado);
            this.PBarraFiltros.Controls.Add(this.DTPFechaHasta);
            this.PBarraFiltros.Controls.Add(this.LFechaHasta);
            this.PBarraFiltros.Controls.Add(this.DTPFechaDesde);
            this.PBarraFiltros.Controls.Add(this.LFechaDesde);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LBuscar);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(21, 53);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1492, 47);
            this.PBarraFiltros.TabIndex = 1;

            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LBuscar.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LBuscar.Location = new System.Drawing.Point(3, 16);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(155, 20);
            this.LBuscar.TabIndex = 0;
            this.LBuscar.Text = "Buscar Comprobante:";

            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBBuscar.Location = new System.Drawing.Point(165, 11);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(200, 27);
            this.TBBuscar.TabIndex = 1;

            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFechaDesde.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFechaDesde.Location = new System.Drawing.Point(385, 16);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(56, 20);
            this.LFechaDesde.TabIndex = 2;
            this.LFechaDesde.Text = "Desde:";

            this.DTPFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(445, 11);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(115, 27);
            this.DTPFechaDesde.TabIndex = 3;

            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFechaHasta.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFechaHasta.Location = new System.Drawing.Point(575, 16);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(52, 20);
            this.LFechaHasta.TabIndex = 4;
            this.LFechaHasta.Text = "Hasta:";

            this.DTPFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(633, 11);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(115, 27);
            this.DTPFechaHasta.TabIndex = 5;

            this.LFiltroEstado.AutoSize = true;
            this.LFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFiltroEstado.Location = new System.Drawing.Point(765, 16);
            this.LFiltroEstado.Name = "LFiltroEstado";
            this.LFiltroEstado.Size = new System.Drawing.Size(59, 20);
            this.LFiltroEstado.TabIndex = 6;
            this.LFiltroEstado.Text = "Estado:";

            this.CBFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFiltroEstado.Location = new System.Drawing.Point(830, 11);
            this.CBFiltroEstado.Name = "CBFiltroEstado";
            this.CBFiltroEstado.Size = new System.Drawing.Size(150, 28);
            this.CBFiltroEstado.TabIndex = 7;

            this.BLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.BLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(1000, 10);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(95, 30);
            this.BLimpiarFiltros.TabIndex = 8;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;

            // TLPContenido
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.DGVVentas, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 100);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 707);
            this.TLPContenido.TabIndex = 0;

            // DGVVentas
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.AllowUserToResizeColumns = false;
            this.DGVVentas.AllowUserToResizeRows = false;
            this.DGVVentas.BackgroundColor = System.Drawing.Color.White;
            this.DGVVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVVentas.ColumnHeadersHeight = 32;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVVentas.EnableHeadersVisualStyles = false;
            this.DGVVentas.GridColor = System.Drawing.Color.FromArgb(230, 233, 238);
            this.DGVVentas.MultiSelect = false;
            this.DGVVentas.ReadOnly = true;
            this.DGVVentas.RowHeadersVisible = false;
            this.DGVVentas.RowTemplate.Height = 28;
            this.DGVVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.DGVVentas.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;

            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVVentas.DefaultCellStyle = dgvRowStyle;

            dgvAltRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvAltRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvAltRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvAltRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvAltRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVVentas.AlternatingRowsDefaultCellStyle = dgvAltRowStyle;

            this.DGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColIdVenta,
                this.ColFecha,
                this.ColComprobante,
                this.ColCliente,
                this.ColCantItems,
                this.ColTotal,
                this.ColEstado
            });
            this.DGVVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVVentas.Location = new System.Drawing.Point(0, 6);
            this.DGVVentas.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.DGVVentas.Name = "DGVVentas";
            this.DGVVentas.Size = new System.Drawing.Size(1060, 701);
            this.DGVVentas.TabIndex = 0;

            this.ColIdVenta.HeaderText = "ID";
            this.ColIdVenta.Name = "ColIdVenta";
            this.ColIdVenta.ReadOnly = true;
            this.ColIdVenta.Visible = false;

            this.ColFecha.HeaderText = "Fecha / Hora";
            this.ColFecha.Width = 140;
            this.ColFecha.Name = "ColFecha";
            this.ColFecha.ReadOnly = true;

            this.ColComprobante.HeaderText = "N° Comprobante";
            this.ColComprobante.Width = 140;
            this.ColComprobante.Name = "ColComprobante";
            this.ColComprobante.ReadOnly = true;

            this.ColCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColCliente.HeaderText = "Cliente";
            this.ColCliente.Name = "ColCliente";
            this.ColCliente.ReadOnly = true;

            this.ColCantItems.HeaderText = "Ítems";
            this.ColCantItems.Width = 75;
            this.ColCantItems.Name = "ColCantItems";
            this.ColCantItems.ReadOnly = true;

            this.ColTotal.HeaderText = "Total ($)";
            this.ColTotal.Width = 130;
            this.ColTotal.Name = "ColTotal";
            this.ColTotal.ReadOnly = true;

            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Width = 110;
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;

            // PTarjetaLateral
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.PBotonesAccion);
            this.PTarjetaLateral.Controls.Add(this.TLPMetricas);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1074, 6);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.PTarjetaLateral.Size = new System.Drawing.Size(418, 701);
            this.PTarjetaLateral.TabIndex = 1;

            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 11);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(388, 23);
            this.LTituloTarjeta.TabIndex = 0;
            this.LTituloTarjeta.Text = "MI RENDIMIENTO PERSONAL";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 34);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(388, 21);
            this.LSubtituloTarjeta.TabIndex = 1;
            this.LSubtituloTarjeta.Text = "Métricas y comprobantes del vendedor";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // TLPMetricas
            this.TLPMetricas.ColumnCount = 1;
            this.TLPMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMetricas.Controls.Add(this.PGrupoTotalVentas, 0, 0);
            this.TLPMetricas.Controls.Add(this.PGrupoOperaciones, 0, 1);
            this.TLPMetricas.Controls.Add(this.PGrupoComision, 0, 2);
            this.TLPMetricas.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPMetricas.Location = new System.Drawing.Point(14, 55);
            this.TLPMetricas.Name = "TLPMetricas";
            this.TLPMetricas.RowCount = 3;
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.Size = new System.Drawing.Size(388, 255);
            this.TLPMetricas.TabIndex = 2;

            // Tarjeta 1: Total Facturado
            this.PGrupoTotalVentas.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoTotalVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoTotalVentas.Controls.Add(this.LValorTotalVentas);
            this.PGrupoTotalVentas.Controls.Add(this.LTituloTotalVentas);
            this.PGrupoTotalVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTotalVentas.Location = new System.Drawing.Point(3, 3);
            this.PGrupoTotalVentas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoTotalVentas.Name = "PGrupoTotalVentas";
            this.PGrupoTotalVentas.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoTotalVentas.Size = new System.Drawing.Size(382, 76);
            this.PGrupoTotalVentas.TabIndex = 0;

            this.LTituloTotalVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTotalVentas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloTotalVentas.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloTotalVentas.Location = new System.Drawing.Point(10, 8);
            this.LTituloTotalVentas.Name = "LTituloTotalVentas";
            this.LTituloTotalVentas.Size = new System.Drawing.Size(360, 20);
            this.LTituloTotalVentas.Text = "TOTAL FACTURADO EN PERÍODO";

            this.LValorTotalVentas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorTotalVentas.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorTotalVentas.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.LValorTotalVentas.Location = new System.Drawing.Point(10, 36);
            this.LValorTotalVentas.Name = "LValorTotalVentas";
            this.LValorTotalVentas.Size = new System.Drawing.Size(360, 30);
            this.LValorTotalVentas.Text = "$ 0,00";

            // Tarjeta 2: Operaciones
            this.PGrupoOperaciones.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoOperaciones.Controls.Add(this.LValorOperaciones);
            this.PGrupoOperaciones.Controls.Add(this.LTituloOperaciones);
            this.PGrupoOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoOperaciones.Location = new System.Drawing.Point(3, 88);
            this.PGrupoOperaciones.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoOperaciones.Name = "PGrupoOperaciones";
            this.PGrupoOperaciones.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoOperaciones.Size = new System.Drawing.Size(382, 76);
            this.PGrupoOperaciones.TabIndex = 1;

            this.LTituloOperaciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloOperaciones.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloOperaciones.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloOperaciones.Location = new System.Drawing.Point(10, 8);
            this.LTituloOperaciones.Name = "LTituloOperaciones";
            this.LTituloOperaciones.Size = new System.Drawing.Size(360, 20);
            this.LTituloOperaciones.Text = "VENTAS COBRADAS";

            this.LValorOperaciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorOperaciones.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorOperaciones.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.LValorOperaciones.Location = new System.Drawing.Point(10, 36);
            this.LValorOperaciones.Name = "LValorOperaciones";
            this.LValorOperaciones.Size = new System.Drawing.Size(360, 30);
            this.LValorOperaciones.Text = "0 operaciones";

            // Tarjeta 3: Comisión
            this.PGrupoComision.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoComision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoComision.Controls.Add(this.LValorComision);
            this.PGrupoComision.Controls.Add(this.LTituloComision);
            this.PGrupoComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoComision.Location = new System.Drawing.Point(3, 173);
            this.PGrupoComision.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoComision.Name = "PGrupoComision";
            this.PGrupoComision.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoComision.Size = new System.Drawing.Size(382, 76);
            this.PGrupoComision.TabIndex = 2;

            this.LTituloComision.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloComision.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloComision.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloComision.Location = new System.Drawing.Point(10, 8);
            this.LTituloComision.Name = "LTituloComision";
            this.LTituloComision.Size = new System.Drawing.Size(360, 20);
            this.LTituloComision.Text = "COMISIÓN ESTIMADA (2.5%)";

            this.LValorComision.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorComision.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorComision.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LValorComision.Location = new System.Drawing.Point(10, 36);
            this.LValorComision.Name = "LValorComision";
            this.LValorComision.Size = new System.Drawing.Size(360, 30);
            this.LValorComision.Text = "$ 0,00";

            // PBotonesAccion
            this.PBotonesAccion.Controls.Add(this.BExportarExcel);
            this.PBotonesAccion.Controls.Add(this.BReimprimirTicket);
            this.PBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesAccion.Location = new System.Drawing.Point(14, 569);
            this.PBotonesAccion.Name = "PBotonesAccion";
            this.PBotonesAccion.Size = new System.Drawing.Size(388, 119);
            this.PBotonesAccion.TabIndex = 3;

            // BReimprimirTicket
            this.BReimprimirTicket.BackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.BReimprimirTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BReimprimirTicket.Dock = System.Windows.Forms.DockStyle.Top;
            this.BReimprimirTicket.FlatAppearance.BorderSize = 0;
            this.BReimprimirTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BReimprimirTicket.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BReimprimirTicket.ForeColor = System.Drawing.Color.White;
            this.BReimprimirTicket.Location = new System.Drawing.Point(0, 0);
            this.BReimprimirTicket.Name = "BReimprimirTicket";
            this.BReimprimirTicket.Size = new System.Drawing.Size(388, 52);
            this.BReimprimirTicket.TabIndex = 0;
            this.BReimprimirTicket.Text = "🖨 Reimprimir Comprobante";
            this.BReimprimirTicket.UseVisualStyleBackColor = false;
            this.BReimprimirTicket.Click += new System.EventHandler(this.BReimprimirTicket_Click);

            // BExportarExcel
            this.BExportarExcel.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.BExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BExportarExcel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BExportarExcel.FlatAppearance.BorderSize = 0;
            this.BExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BExportarExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BExportarExcel.ForeColor = System.Drawing.Color.White;
            this.BExportarExcel.Location = new System.Drawing.Point(0, 67);
            this.BExportarExcel.Name = "BExportarExcel";
            this.BExportarExcel.Size = new System.Drawing.Size(388, 52);
            this.BExportarExcel.TabIndex = 1;
            this.BExportarExcel.Text = "📊 Exportar Mis Ventas (.xls)";
            this.BExportarExcel.UseVisualStyleBackColor = false;
            this.BExportarExcel.Click += new System.EventHandler(this.BExportarExcel_Click);

            // FormMisVentas
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMisVentas";
            this.Text = "Mis Ventas";
            this.Load += new System.EventHandler(this.FormMisVentas_Load);

            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.PBotonesAccion.ResumeLayout(false);
            this.TLPMetricas.ResumeLayout(false);
            this.PGrupoTotalVentas.ResumeLayout(false);
            this.PGrupoOperaciones.ResumeLayout(false);
            this.PGrupoComision.ResumeLayout(false);
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
        private System.Windows.Forms.Label LFechaDesde;
        private System.Windows.Forms.DateTimePicker DTPFechaDesde;
        private System.Windows.Forms.Label LFechaHasta;
        private System.Windows.Forms.DateTimePicker DTPFechaHasta;
        private System.Windows.Forms.Label LFiltroEstado;
        private System.Windows.Forms.ComboBox CBFiltroEstado;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.TableLayoutPanel TLPMetricas;
        private System.Windows.Forms.Panel PGrupoTotalVentas;
        private System.Windows.Forms.Label LValorTotalVentas;
        private System.Windows.Forms.Label LTituloTotalVentas;
        private System.Windows.Forms.Panel PGrupoOperaciones;
        private System.Windows.Forms.Label LValorOperaciones;
        private System.Windows.Forms.Label LTituloOperaciones;
        private System.Windows.Forms.Panel PGrupoComision;
        private System.Windows.Forms.Label LValorComision;
        private System.Windows.Forms.Label LTituloComision;
        private System.Windows.Forms.Panel PBotonesAccion;
        private System.Windows.Forms.Button BReimprimirTicket;
        private System.Windows.Forms.Button BExportarExcel;
    }
}