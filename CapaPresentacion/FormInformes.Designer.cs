namespace CapaPresentacion
{
    partial class FormInformes
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
            this.SCContenidoIzquierdo = new System.Windows.Forms.SplitContainer();
            this.TLPGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.PPanelGraficoBarras = new System.Windows.Forms.Panel();
            this.PPanelGraficoTorta = new System.Windows.Forms.Panel();
            this.DGVResumen = new System.Windows.Forms.DataGridView();
            this.ColPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalCompras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGananciaNeta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMargen = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.TLPMetricas = new System.Windows.Forms.TableLayoutPanel();

            this.PGrupoFacturado = new System.Windows.Forms.Panel();
            this.LValorFacturado = new System.Windows.Forms.Label();
            this.LTituloFacturado = new System.Windows.Forms.Label();

            this.PGrupoGanancia = new System.Windows.Forms.Panel();
            this.LValorGanancia = new System.Windows.Forms.Label();
            this.LTituloGanancia = new System.Windows.Forms.Label();

            this.PGrupoTickets = new System.Windows.Forms.Panel();
            this.LValorTickets = new System.Windows.Forms.Label();
            this.LTituloTickets = new System.Windows.Forms.Label();

            this.PBotonesExportacion = new System.Windows.Forms.Panel();
            this.BExportarPDF = new System.Windows.Forms.Button();
            this.BExportarExcel = new System.Windows.Forms.Button();
            this.BGenerarReporte = new System.Windows.Forms.Button();

            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LFechaDesde = new System.Windows.Forms.Label();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.LFechaHasta = new System.Windows.Forms.Label();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.LTipoReporte = new System.Windows.Forms.Label();
            this.CBTipoReporte = new System.Windows.Forms.ComboBox();
            this.BFiltrar = new System.Windows.Forms.Button();

            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();

            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SCContenidoIzquierdo)).BeginInit();
            this.SCContenidoIzquierdo.Panel1.SuspendLayout();
            this.SCContenidoIzquierdo.Panel2.SuspendLayout();
            this.SCContenidoIzquierdo.SuspendLayout();
            this.TLPGraficos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVResumen)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.TLPMetricas.SuspendLayout();
            this.PGrupoFacturado.SuspendLayout();
            this.PGrupoGanancia.SuspendLayout();
            this.PGrupoTickets.SuspendLayout();
            this.PBotonesExportacion.SuspendLayout();
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
            this.LTituloPrincipal.Size = new System.Drawing.Size(310, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "INFORMES Y ESTADÍSTICAS";

            // 
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.LFechaDesde);
            this.PBarraFiltros.Controls.Add(this.DTPFechaDesde);
            this.PBarraFiltros.Controls.Add(this.LFechaHasta);
            this.PBarraFiltros.Controls.Add(this.DTPFechaHasta);
            this.PBarraFiltros.Controls.Add(this.LTipoReporte);
            this.PBarraFiltros.Controls.Add(this.CBTipoReporte);
            this.PBarraFiltros.Controls.Add(this.BFiltrar);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(21, 53);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1492, 47);
            this.PBarraFiltros.TabIndex = 1;

            // Filtros de fecha
            this.LFechaDesde.AutoSize = true;
            this.LFechaDesde.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFechaDesde.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFechaDesde.Location = new System.Drawing.Point(3, 16);
            this.LFechaDesde.Name = "LFechaDesde";
            this.LFechaDesde.Size = new System.Drawing.Size(99, 20);
            this.LFechaDesde.Text = "Fecha Desde:";

            this.DTPFechaDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(108, 11);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(120, 27);
            this.DTPFechaDesde.TabIndex = 0;

            this.LFechaHasta.AutoSize = true;
            this.LFechaHasta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFechaHasta.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LFechaHasta.Location = new System.Drawing.Point(245, 16);
            this.LFechaHasta.Name = "LFechaHasta";
            this.LFechaHasta.Size = new System.Drawing.Size(95, 20);
            this.LFechaHasta.TabIndex = 1;
            this.LFechaHasta.Text = "Fecha Hasta:";

            this.DTPFechaHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(346, 11);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(120, 27);
            this.DTPFechaHasta.TabIndex = 2;

            this.LTipoReporte.AutoSize = true;
            this.LTipoReporte.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTipoReporte.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.LTipoReporte.Location = new System.Drawing.Point(490, 16);
            this.LTipoReporte.Name = "LTipoReporte";
            this.LTipoReporte.Size = new System.Drawing.Size(117, 20);
            this.LTipoReporte.TabIndex = 3;
            this.LTipoReporte.Text = "Tipo de Análisis:";

            this.CBTipoReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBTipoReporte.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBTipoReporte.Location = new System.Drawing.Point(613, 11);
            this.CBTipoReporte.Name = "CBTipoReporte";
            this.CBTipoReporte.Size = new System.Drawing.Size(220, 28);
            this.CBTipoReporte.TabIndex = 4;

            this.BFiltrar.BackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.BFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BFiltrar.FlatAppearance.BorderSize = 0;
            this.BFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BFiltrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BFiltrar.ForeColor = System.Drawing.Color.White;
            this.BFiltrar.Location = new System.Drawing.Point(850, 10);
            this.BFiltrar.Name = "BFiltrar";
            this.BFiltrar.Size = new System.Drawing.Size(110, 30);
            this.BFiltrar.TabIndex = 5;
            this.BFiltrar.Text = "Actualizar";
            this.BFiltrar.UseVisualStyleBackColor = false;
            this.BFiltrar.Click += new System.EventHandler(this.BFiltrar_Click);

            // 
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.TLPContenido.Controls.Add(this.SCContenidoIzquierdo, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 100);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 707);
            this.TLPContenido.TabIndex = 0;

            // 
            // SCContenidoIzquierdo (Panel de Gráficos arriba + Grilla abajo)
            // 
            this.SCContenidoIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SCContenidoIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.SCContenidoIzquierdo.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.SCContenidoIzquierdo.Name = "SCContenidoIzquierdo";
            this.SCContenidoIzquierdo.Orientation = System.Windows.Forms.Orientation.Horizontal;

            // Panel1: Gráficos
            this.SCContenidoIzquierdo.Panel1.Controls.Add(this.TLPGraficos);
            // Panel2: Tabla
            this.SCContenidoIzquierdo.Panel2.Controls.Add(this.DGVResumen);
            this.SCContenidoIzquierdo.Size = new System.Drawing.Size(1090, 707);
            this.SCContenidoIzquierdo.SplitterDistance = 330;
            this.SCContenidoIzquierdo.TabIndex = 0;

            // 
            // TLPGraficos (2 Gráficos en paralelo)
            // 
            this.TLPGraficos.ColumnCount = 2;
            this.TLPGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.TLPGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.TLPGraficos.Controls.Add(this.PPanelGraficoBarras, 0, 0);
            this.TLPGraficos.Controls.Add(this.PPanelGraficoTorta, 1, 0);
            this.TLPGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPGraficos.Location = new System.Drawing.Point(0, 0);
            this.TLPGraficos.Name = "TLPGraficos";
            this.TLPGraficos.RowCount = 1;
            this.TLPGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPGraficos.Size = new System.Drawing.Size(1090, 330);
            this.TLPGraficos.TabIndex = 0;

            // PPanelGraficoBarras
            this.PPanelGraficoBarras.BackColor = System.Drawing.Color.White;
            this.PPanelGraficoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PPanelGraficoBarras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPanelGraficoBarras.Location = new System.Drawing.Point(0, 0);
            this.PPanelGraficoBarras.Margin = new System.Windows.Forms.Padding(0, 0, 8, 8);
            this.PPanelGraficoBarras.Name = "PPanelGraficoBarras";
            this.PPanelGraficoBarras.Size = new System.Drawing.Size(624, 322);
            this.PPanelGraficoBarras.TabIndex = 0;
            this.PPanelGraficoBarras.Paint += new System.Windows.Forms.PaintEventHandler(this.PPanelGraficoBarras_Paint);

            // PPanelGraficoTorta
            this.PPanelGraficoTorta.BackColor = System.Drawing.Color.White;
            this.PPanelGraficoTorta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PPanelGraficoTorta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PPanelGraficoTorta.Location = new System.Drawing.Point(632, 0);
            this.PPanelGraficoTorta.Margin = new System.Windows.Forms.Padding(8, 0, 0, 8);
            this.PPanelGraficoTorta.Name = "PPanelGraficoTorta";
            this.PPanelGraficoTorta.Size = new System.Drawing.Size(458, 322);
            this.PPanelGraficoTorta.TabIndex = 1;
            this.PPanelGraficoTorta.Paint += new System.Windows.Forms.PaintEventHandler(this.PPanelGraficoTorta_Paint);

            // 
            // DGVResumen
            // 
            this.DGVResumen.AllowUserToAddRows = false;
            this.DGVResumen.AllowUserToDeleteRows = false;
            this.DGVResumen.AllowUserToResizeRows = false;
            this.DGVResumen.BackgroundColor = System.Drawing.Color.White;
            this.DGVResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DGVResumen.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.DGVResumen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DGVResumen.ColumnHeadersHeight = 32;
            this.DGVResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVResumen.EnableHeadersVisualStyles = false;
            this.DGVResumen.GridColor = System.Drawing.Color.FromArgb(230, 233, 238);
            this.DGVResumen.MultiSelect = false;
            this.DGVResumen.ReadOnly = true;
            this.DGVResumen.RowHeadersVisible = false;
            this.DGVResumen.RowTemplate.Height = 28;
            this.DGVResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.DGVResumen.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;

            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVResumen.DefaultCellStyle = dgvRowStyle;

            dgvAltRowStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgvAltRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvAltRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvAltRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53);
            dgvAltRowStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVResumen.AlternatingRowsDefaultCellStyle = dgvAltRowStyle;

            this.DGVResumen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.ColPeriodo,
                this.ColCantVentas,
                this.ColTotalVentas,
                this.ColTotalCompras,
                this.ColGananciaNeta,
                this.ColMargen
            });
            this.DGVResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVResumen.Location = new System.Drawing.Point(0, 0);
            this.DGVResumen.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.DGVResumen.Name = "DGVResumen";
            this.DGVResumen.Size = new System.Drawing.Size(1090, 373);
            this.DGVResumen.TabIndex = 0;

            this.ColPeriodo.HeaderText = "Período / Día";
            this.ColPeriodo.Width = 140;
            this.ColPeriodo.Name = "ColPeriodo";
            this.ColPeriodo.ReadOnly = true;

            this.ColCantVentas.HeaderText = "Comprobantes";
            this.ColCantVentas.Width = 110;
            this.ColCantVentas.Name = "ColCantVentas";
            this.ColCantVentas.ReadOnly = true;

            this.ColTotalVentas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTotalVentas.HeaderText = "Total Ingresos ($)";
            this.ColTotalVentas.Name = "ColTotalVentas";
            this.ColTotalVentas.ReadOnly = true;

            this.ColTotalCompras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColTotalCompras.HeaderText = "Total Costos ($)";
            this.ColTotalCompras.Name = "ColTotalCompras";
            this.ColTotalCompras.ReadOnly = true;

            this.ColGananciaNeta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColGananciaNeta.HeaderText = "Margen Bruto ($)";
            this.ColGananciaNeta.Name = "ColGananciaNeta";
            this.ColGananciaNeta.ReadOnly = true;

            this.ColMargen.HeaderText = "Rentab. (%)";
            this.ColMargen.Width = 110;
            this.ColMargen.Name = "ColMargen";
            this.ColMargen.ReadOnly = true;

            // 
            // PTarjetaLateral
            // 
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.PBotonesExportacion);
            this.PTarjetaLateral.Controls.Add(this.TLPMetricas);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1104, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.PTarjetaLateral.Size = new System.Drawing.Size(388, 707);
            this.PTarjetaLateral.TabIndex = 1;

            // Título lateral
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 11);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(358, 23);
            this.LTituloTarjeta.TabIndex = 0;
            this.LTituloTarjeta.Text = "INDICADORES DEL PERÍODO";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // LSubtituloTarjeta
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 34);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(358, 21);
            this.LSubtituloTarjeta.TabIndex = 1;
            this.LSubtituloTarjeta.Text = "Consolidación de caja y rentabilidad";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // TLPMetricas
            this.TLPMetricas.ColumnCount = 1;
            this.TLPMetricas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPMetricas.Controls.Add(this.PGrupoFacturado, 0, 0);
            this.TLPMetricas.Controls.Add(this.PGrupoGanancia, 0, 1);
            this.TLPMetricas.Controls.Add(this.PGrupoTickets, 0, 2);
            this.TLPMetricas.Dock = System.Windows.Forms.DockStyle.Top; // Dock Top en vez de Fill para no generar vacío
            this.TLPMetricas.Location = new System.Drawing.Point(14, 55);
            this.TLPMetricas.Name = "TLPMetricas";
            this.TLPMetricas.RowCount = 3;
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.TLPMetricas.Size = new System.Drawing.Size(358, 255);
            this.TLPMetricas.TabIndex = 2;

            // Tarjeta Facturado
            this.PGrupoFacturado.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoFacturado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoFacturado.Controls.Add(this.LValorFacturado);
            this.PGrupoFacturado.Controls.Add(this.LTituloFacturado);
            this.PGrupoFacturado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFacturado.Location = new System.Drawing.Point(3, 3);
            this.PGrupoFacturado.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoFacturado.Name = "PGrupoFacturado";
            this.PGrupoFacturado.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoFacturado.Size = new System.Drawing.Size(352, 76);
            this.PGrupoFacturado.TabIndex = 0;

            this.LTituloFacturado.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloFacturado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloFacturado.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloFacturado.Location = new System.Drawing.Point(10, 8);
            this.LTituloFacturado.Name = "LTituloFacturado";
            this.LTituloFacturado.Size = new System.Drawing.Size(330, 20);
            this.LTituloFacturado.Text = "TOTAL INGRESOS PERÍODO";

            this.LValorFacturado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorFacturado.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorFacturado.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.LValorFacturado.Location = new System.Drawing.Point(10, 36);
            this.LValorFacturado.Name = "LValorFacturado";
            this.LValorFacturado.Size = new System.Drawing.Size(330, 30);
            this.LValorFacturado.Text = "$ 0,00";

            // Tarjeta Ganancia
            this.PGrupoGanancia.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoGanancia.Controls.Add(this.LValorGanancia);
            this.PGrupoGanancia.Controls.Add(this.LTituloGanancia);
            this.PGrupoGanancia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoGanancia.Location = new System.Drawing.Point(3, 88);
            this.PGrupoGanancia.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoGanancia.Name = "PGrupoGanancia";
            this.PGrupoGanancia.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoGanancia.Size = new System.Drawing.Size(352, 76);
            this.PGrupoGanancia.TabIndex = 1;

            this.LTituloGanancia.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloGanancia.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloGanancia.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloGanancia.Location = new System.Drawing.Point(10, 8);
            this.LTituloGanancia.Name = "LTituloGanancia";
            this.LTituloGanancia.Size = new System.Drawing.Size(330, 20);
            this.LTituloGanancia.Text = "MARGEN BRUTO ESTIMADO";

            this.LValorGanancia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorGanancia.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorGanancia.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.LValorGanancia.Location = new System.Drawing.Point(10, 36);
            this.LValorGanancia.Name = "LValorGanancia";
            this.LValorGanancia.Size = new System.Drawing.Size(330, 30);
            this.LValorGanancia.Text = "$ 0,00";

            // Tarjeta Operaciones
            this.PGrupoTickets.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.PGrupoTickets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PGrupoTickets.Controls.Add(this.LValorTickets);
            this.PGrupoTickets.Controls.Add(this.LTituloTickets);
            this.PGrupoTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTickets.Location = new System.Drawing.Point(3, 173);
            this.PGrupoTickets.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.PGrupoTickets.Name = "PGrupoTickets";
            this.PGrupoTickets.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.PGrupoTickets.Size = new System.Drawing.Size(352, 76);
            this.PGrupoTickets.TabIndex = 2;

            this.LTituloTickets.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTickets.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloTickets.ForeColor = System.Drawing.Color.FromArgb(100, 105, 110);
            this.LTituloTickets.Location = new System.Drawing.Point(10, 8);
            this.LTituloTickets.Name = "LTituloTickets";
            this.LTituloTickets.Size = new System.Drawing.Size(330, 20);
            this.LTituloTickets.Text = "OPERACIONES REGISTRADAS";

            this.LValorTickets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LValorTickets.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.LValorTickets.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.LValorTickets.Location = new System.Drawing.Point(10, 36);
            this.LValorTickets.Name = "LValorTickets";
            this.LValorTickets.Size = new System.Drawing.Size(330, 30);
            this.LValorTickets.Text = "0 operaciones";

            // 
            // PBotonesExportacion
            // 
            this.PBotonesExportacion.Controls.Add(this.BExportarExcel);
            this.PBotonesExportacion.Controls.Add(this.BExportarPDF);
            this.PBotonesExportacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesExportacion.Location = new System.Drawing.Point(14, 575);
            this.PBotonesExportacion.Name = "PBotonesExportacion";
            this.PBotonesExportacion.Size = new System.Drawing.Size(358, 119);
            this.PBotonesExportacion.TabIndex = 3;

            // BExportarExcel
            this.BExportarExcel.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.BExportarExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BExportarExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BExportarExcel.FlatAppearance.BorderSize = 0;
            this.BExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BExportarExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BExportarExcel.ForeColor = System.Drawing.Color.White;
            this.BExportarExcel.Location = new System.Drawing.Point(0, 0);
            this.BExportarExcel.Name = "BExportarExcel";
            this.BExportarExcel.Size = new System.Drawing.Size(358, 52);
            this.BExportarExcel.TabIndex = 0;
            this.BExportarExcel.Text = "📊 Descargar en Excel (.csv)";
            this.BExportarExcel.UseVisualStyleBackColor = false;
            this.BExportarExcel.Click += new System.EventHandler(this.BExportarExcel_Click);

            // BExportarPDF
            this.BExportarPDF.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.BExportarPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BExportarPDF.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BExportarPDF.FlatAppearance.BorderSize = 0;
            this.BExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BExportarPDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BExportarPDF.ForeColor = System.Drawing.Color.White;
            this.BExportarPDF.Location = new System.Drawing.Point(0, 67);
            this.BExportarPDF.Name = "BExportarPDF";
            this.BExportarPDF.Size = new System.Drawing.Size(358, 52);
            this.BExportarPDF.TabIndex = 1;
            this.BExportarPDF.Text = "📄 Imprimir / Generar PDF";
            this.BExportarPDF.UseVisualStyleBackColor = false;
            this.BExportarPDF.Click += new System.EventHandler(this.BExportarPDF_Click);

            // 
            // FormInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInformes";
            this.Text = "Informes y Estadísticas";
            this.Load += new System.EventHandler(this.FormInformes_Load);

            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            this.SCContenidoIzquierdo.Panel1.ResumeLayout(false);
            this.SCContenidoIzquierdo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SCContenidoIzquierdo)).EndInit();
            this.SCContenidoIzquierdo.ResumeLayout(false);
            this.TLPGraficos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVResumen)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.TLPMetricas.ResumeLayout(false);
            this.PGrupoFacturado.ResumeLayout(false);
            this.PGrupoGanancia.ResumeLayout(false);
            this.PGrupoTickets.ResumeLayout(false);
            this.PBotonesExportacion.ResumeLayout(false);
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
        private System.Windows.Forms.Label LFechaDesde;
        private System.Windows.Forms.DateTimePicker DTPFechaDesde;
        private System.Windows.Forms.Label LFechaHasta;
        private System.Windows.Forms.DateTimePicker DTPFechaHasta;
        private System.Windows.Forms.Label LTipoReporte;
        private System.Windows.Forms.ComboBox CBTipoReporte;
        private System.Windows.Forms.Button BFiltrar;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.SplitContainer SCContenidoIzquierdo;
        private System.Windows.Forms.TableLayoutPanel TLPGraficos;
        private System.Windows.Forms.Panel PPanelGraficoBarras;
        private System.Windows.Forms.Panel PPanelGraficoTorta;
        private System.Windows.Forms.DataGridView DGVResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalCompras;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGananciaNeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMargen;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.TableLayoutPanel TLPMetricas;
        private System.Windows.Forms.Panel PGrupoFacturado;
        private System.Windows.Forms.Label LValorFacturado;
        private System.Windows.Forms.Label LTituloFacturado;
        private System.Windows.Forms.Panel PGrupoGanancia;
        private System.Windows.Forms.Label LValorGanancia;
        private System.Windows.Forms.Label LTituloGanancia;
        private System.Windows.Forms.Panel PGrupoTickets;
        private System.Windows.Forms.Label LValorTickets;
        private System.Windows.Forms.Label LTituloTickets;
        private System.Windows.Forms.Panel PBotonesExportacion;
        private System.Windows.Forms.Button BExportarExcel;
        private System.Windows.Forms.Button BExportarPDF;
        private System.Windows.Forms.Button BGenerarReporte;
    }
}