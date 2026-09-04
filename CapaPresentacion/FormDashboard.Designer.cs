namespace CapaPresentacion
{
    partial class FormDashboard
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FormDashboard";
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.pbIconoTitulo = new System.Windows.Forms.PictureBox();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.lblSubtituloPrincipal = new System.Windows.Forms.Label();
            this.tlpKPIs = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpiVentas = new System.Windows.Forms.Panel();
            this.lblKpiVentasTitulo = new System.Windows.Forms.Label();
            this.lblKpiVentasValor = new System.Windows.Forms.Label();
            this.lblKpiVentasSub = new System.Windows.Forms.Label();
            this.pnlKpiCaja = new System.Windows.Forms.Panel();
            this.lblKpiCajaTitulo = new System.Windows.Forms.Label();
            this.lblKpiCajaValor = new System.Windows.Forms.Label();
            this.lblKpiCajaSub = new System.Windows.Forms.Label();
            this.pnlKpiClientes = new System.Windows.Forms.Panel();
            this.lblKpiClientesTitulo = new System.Windows.Forms.Label();
            this.lblKpiClientesValor = new System.Windows.Forms.Label();
            this.lblKpiClientesSub = new System.Windows.Forms.Label();
            this.pnlKpiStock = new System.Windows.Forms.Panel();
            this.lblKpiStockTitulo = new System.Windows.Forms.Label();
            this.lblKpiStockValor = new System.Windows.Forms.Label();
            this.lblKpiStockSub = new System.Windows.Forms.Label();
            this.tlpCuerpo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardIzquierda = new System.Windows.Forms.Panel();
            this.lblTituloVentas = new System.Windows.Forms.Label();
            this.dgvUltimasVentas = new System.Windows.Forms.DataGridView();
            this.colVentaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaTicket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCardDerecha = new System.Windows.Forms.Panel();
            this.lblTituloStock = new System.Windows.Forms.Label();
            this.dgvStockCritico = new System.Windows.Forms.DataGridView();
            this.colStockCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.Load += new System.EventHandler(this.FormDashboard_Load);

            this.pnlFondo.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTitulo)).BeginInit();
            this.tlpKPIs.SuspendLayout();
            this.pnlKpiVentas.SuspendLayout();
            this.pnlKpiCaja.SuspendLayout();
            this.pnlKpiClientes.SuspendLayout();
            this.pnlKpiStock.SuspendLayout();
            this.tlpCuerpo.SuspendLayout();
            this.pnlCardIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).BeginInit();
            this.pnlCardDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFondo
            // 
            this.pnlFondo.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.pnlFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFondo.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlFondo.Controls.Add(this.tlpCuerpo);
            this.pnlFondo.Controls.Add(this.tlpKPIs);
            this.pnlFondo.Controls.Add(this.pnlEncabezado);
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Height = 44;
            this.pnlEncabezado.Controls.Add(this.lblSubtituloPrincipal);
            this.pnlEncabezado.Controls.Add(this.lblTituloPrincipal);
            this.pnlEncabezado.Controls.Add(this.pbIconoTitulo);
            this.pnlEncabezado.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlEncabezado.Controls.Add(this.btnActualizar);
            // pbIconoTitulo
            this.pbIconoTitulo.Location = new System.Drawing.Point(0, 3);
            this.pbIconoTitulo.Size = new System.Drawing.Size(32, 32);
            this.pbIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            // lblTituloPrincipal
            this.lblTituloPrincipal.Text = "PANEL DE CONTROL GENERAL";
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTituloPrincipal.Location = new System.Drawing.Point(38, 2);
            this.lblTituloPrincipal.AutoSize = true;
            // lblSubtituloPrincipal
            this.lblSubtituloPrincipal.Text = "Resumen operativo del día y estado de inventario";
            this.lblSubtituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSubtituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSubtituloPrincipal.Location = new System.Drawing.Point(39, 23);
            this.lblSubtituloPrincipal.AutoSize = true;
            // 
            // btnActualizar (Se posiciona a la derecha mediante Dock = Right y márgenes prolijos)
            // 
            this.btnActualizar.Dock = System.Windows.Forms.DockStyle.None;
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(this.pnlEncabezado.Width - 125, 4);
            this.btnActualizar.Size = new System.Drawing.Size(125, 40);
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(38, 40, 44);
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Text = "↻ Actualizar";
            // 
            // tlpKPIs (Fila con 4 tarjetas de 25% cada una)
            // 
            this.tlpKPIs.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPIs.Height = 100;
            this.tlpKPIs.Margin = new System.Windows.Forms.Padding(0);
            this.tlpKPIs.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpKPIs.ColumnCount = 4;
            this.tlpKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPIs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPIs.RowCount = 1;
            this.tlpKPIs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPIs.Controls.Add(this.pnlKpiVentas, 0, 0);
            this.tlpKPIs.Controls.Add(this.pnlKpiCaja, 1, 0);
            this.tlpKPIs.Controls.Add(this.pnlKpiClientes, 2, 0);
            this.tlpKPIs.Controls.Add(this.pnlKpiStock, 3, 0);
            // --- Tarjeta KPI 1: Ventas ---
            this.pnlKpiVentas.BackColor = System.Drawing.Color.White;
            this.pnlKpiVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiVentas.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlKpiVentas.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.lblKpiVentasTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiVentasTitulo.Height = 22;
            this.lblKpiVentasTitulo.Text = "VENTAS DE HOY";
            this.lblKpiVentasTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiVentasTitulo.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblKpiVentasTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiVentasValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiVentasValor.Height = 36;
            this.lblKpiVentasValor.Text = "$ 148.500,00";
            this.lblKpiVentasValor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKpiVentasValor.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53); // Ocre
            this.lblKpiVentasValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiVentasSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiVentasSub.Height = 18;
            this.lblKpiVentasSub.Text = "12 comprobantes";
            this.lblKpiVentasSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKpiVentasSub.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiVentasSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlKpiVentas.Controls.Clear();
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasSub);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasValor);
            this.pnlKpiVentas.Controls.Add(this.lblKpiVentasTitulo);
            // --- Tarjeta KPI 2: Caja ---
            this.pnlKpiCaja.BackColor = System.Drawing.Color.White;
            this.pnlKpiCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiCaja.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlKpiCaja.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.lblKpiCajaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiCajaTitulo.Height = 22;
            this.lblKpiCajaTitulo.Text = "EFECTIVO EN CAJA";
            this.lblKpiCajaTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiCajaTitulo.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblKpiCajaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiCajaValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiCajaValor.Height = 36;
            this.lblKpiCajaValor.Text = "$ 92.300,00";
            this.lblKpiCajaValor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKpiCajaValor.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96); // Verde
            this.lblKpiCajaValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiCajaSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiCajaSub.Height = 18;
            this.lblKpiCajaSub.Text = "Turno abierto";
            this.lblKpiCajaSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKpiCajaSub.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiCajaSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlKpiCaja.Controls.Clear();
            this.pnlKpiCaja.Controls.Add(this.lblKpiCajaSub);
            this.pnlKpiCaja.Controls.Add(this.lblKpiCajaValor);
            this.pnlKpiCaja.Controls.Add(this.lblKpiCajaTitulo);
            // --- Tarjeta KPI 3: Clientes ---
            this.pnlKpiClientes.BackColor = System.Drawing.Color.White;
            this.pnlKpiClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiClientes.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.pnlKpiClientes.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.lblKpiClientesTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiClientesTitulo.Height = 22;
            this.lblKpiClientesTitulo.Text = "CLIENTES REGISTRADOS";
            this.lblKpiClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiClientesTitulo.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblKpiClientesTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiClientesValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiClientesValor.Height = 36;
            this.lblKpiClientesValor.Text = "48";
            this.lblKpiClientesValor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKpiClientesValor.ForeColor = System.Drawing.Color.FromArgb(38, 40, 44); // Grafito
            this.lblKpiClientesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiClientesSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiClientesSub.Height = 18;
            this.lblKpiClientesSub.Text = "Cartera activa";
            this.lblKpiClientesSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKpiClientesSub.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiClientesSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlKpiClientes.Controls.Clear();
            this.pnlKpiClientes.Controls.Add(this.lblKpiClientesSub);
            this.pnlKpiClientes.Controls.Add(this.lblKpiClientesValor);
            this.pnlKpiClientes.Controls.Add(this.lblKpiClientesTitulo);
            // --- Tarjeta KPI 4: Stock ---
            this.pnlKpiStock.BackColor = System.Drawing.Color.White;
            this.pnlKpiStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpiStock.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlKpiStock.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);
            this.lblKpiStockTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiStockTitulo.Height = 22;
            this.lblKpiStockTitulo.Text = "STOCK CRÍTICO";
            this.lblKpiStockTitulo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiStockTitulo.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblKpiStockTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiStockValor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiStockValor.Height = 36;
            this.lblKpiStockValor.Text = "4";
            this.lblKpiStockValor.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKpiStockValor.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43); // Rojo
            this.lblKpiStockValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKpiStockSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiStockSub.Height = 18;
            this.lblKpiStockSub.Text = "Insumos a reponer";
            this.lblKpiStockSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKpiStockSub.ForeColor = System.Drawing.Color.Gray;
            this.lblKpiStockSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlKpiStock.Controls.Clear();
            this.pnlKpiStock.Controls.Add(this.lblKpiStockSub);
            this.pnlKpiStock.Controls.Add(this.lblKpiStockValor);
            this.pnlKpiStock.Controls.Add(this.lblKpiStockTitulo);

            // 
            // tlpCuerpo (Split 60% / 40%)
            // 
            this.tlpCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCuerpo.ColumnCount = 2;
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tlpCuerpo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tlpCuerpo.RowCount = 1;
            this.tlpCuerpo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCuerpo.Controls.Add(this.pnlCardIzquierda, 0, 0);
            this.tlpCuerpo.Controls.Add(this.pnlCardDerecha, 1, 0);
            this.tlpCuerpo.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

            // 
            // pnlCardIzquierda (Últimas Ventas)
            // 
            this.pnlCardIzquierda.BackColor = System.Drawing.Color.White;
            this.pnlCardIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardIzquierda.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.pnlCardIzquierda.Padding = new System.Windows.Forms.Padding(14);
            this.pnlCardIzquierda.Controls.Add(this.dgvUltimasVentas);
            this.pnlCardIzquierda.Controls.Add(this.lblTituloVentas);

            this.lblTituloVentas.Text = "ÚLTIMAS VENTAS REGISTRADAS";
            this.lblTituloVentas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloVentas.ForeColor = System.Drawing.Color.FromArgb(212, 131, 53);
            this.lblTituloVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloVentas.Height = 26;

            // dgvUltimasVentas
            this.dgvUltimasVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUltimasVentas.AllowUserToAddRows = false;
            this.dgvUltimasVentas.AllowUserToDeleteRows = false;
            this.dgvUltimasVentas.AllowUserToResizeRows = false;
            this.dgvUltimasVentas.AllowUserToResizeColumns = false;
            this.dgvUltimasVentas.BackgroundColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.dgvUltimasVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvUltimasVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvUltimasVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUltimasVentas.ColumnHeadersHeight = 28;
            this.dgvUltimasVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvUltimasVentas.ColumnHeadersDefaultCellStyle = dgvHeaderStyle1;
            this.dgvUltimasVentas.EnableHeadersVisualStyles = false;

            dgvRowStyle1.BackColor = System.Drawing.Color.White;
            dgvRowStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle1.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle1.SelectionBackColor = System.Drawing.Color.White;
            dgvRowStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvUltimasVentas.DefaultCellStyle = dgvRowStyle1;
            this.dgvUltimasVentas.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);

            this.colVentaId.HeaderText = "ID";
            this.colVentaId.Visible = false;
            this.colVentaId.Name = "colVentaId";

            this.colVentaHora.HeaderText = "Hora";
            this.colVentaHora.Width = 70;
            this.colVentaHora.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVentaHora.Name = "colVentaHora";

            this.colVentaTicket.HeaderText = "N° Comprobante";
            this.colVentaTicket.Width = 125;
            this.colVentaTicket.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVentaTicket.Name = "colVentaTicket";

            this.colVentaCliente.HeaderText = "Cliente";
            this.colVentaCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colVentaCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVentaCliente.Name = "colVentaCliente";

            this.colVentaTotal.HeaderText = "Total ($)";
            this.colVentaTotal.Width = 100;
            this.colVentaTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colVentaTotal.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.colVentaTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVentaTotal.Name = "colVentaTotal";

            this.dgvUltimasVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colVentaId, this.colVentaHora, this.colVentaTicket, this.colVentaCliente, this.colVentaTotal
            });

            this.dgvUltimasVentas.ReadOnly = true;
            this.dgvUltimasVentas.RowHeadersVisible = false;
            this.dgvUltimasVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUltimasVentas.RowTemplate.Height = 28;

            // 
            // pnlCardDerecha (Alertas de Stock)
            // 
            this.pnlCardDerecha.BackColor = System.Drawing.Color.White;
            this.pnlCardDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardDerecha.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlCardDerecha.Padding = new System.Windows.Forms.Padding(14);
            this.pnlCardDerecha.Controls.Add(this.dgvStockCritico);
            this.pnlCardDerecha.Controls.Add(this.lblTituloStock);

            this.lblTituloStock.Text = "ATENCIÓN: PRODUCTOS CON BAJO STOCK";
            this.lblTituloStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloStock.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43); // Rojo alerta
            this.lblTituloStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloStock.Height = 26;

            // dgvStockCritico
            this.dgvStockCritico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockCritico.AllowUserToAddRows = false;
            this.dgvStockCritico.AllowUserToDeleteRows = false;
            this.dgvStockCritico.AllowUserToResizeRows = false;
            this.dgvStockCritico.AllowUserToResizeColumns = false;
            this.dgvStockCritico.BackgroundColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.dgvStockCritico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvStockCritico.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvStockCritico.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvStockCritico.ColumnHeadersHeight = 28;
            this.dgvStockCritico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            dgvHeaderStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            dgvHeaderStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.dgvStockCritico.ColumnHeadersDefaultCellStyle = dgvHeaderStyle2;
            this.dgvStockCritico.EnableHeadersVisualStyles = false;
            dgvRowStyle2.BackColor = System.Drawing.Color.White;
            dgvRowStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle2.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            dgvRowStyle2.SelectionBackColor = System.Drawing.Color.White;
            dgvRowStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvStockCritico.DefaultCellStyle = dgvRowStyle2;
            this.dgvStockCritico.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.colStockCodigo.HeaderText = "Cód.";
            this.colStockCodigo.Width = 65;
            this.colStockCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStockCodigo.Name = "colStockCodigo";
            this.colStockProducto.HeaderText = "Producto / Insumo";
            this.colStockProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStockProducto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStockProducto.Name = "colStockProducto";
            this.colStockActual.HeaderText = "Actual";
            this.colStockActual.Width = 65;
            this.colStockActual.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStockActual.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.colStockActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStockActual.Name = "colStockActual";
            this.colStockMinimo.HeaderText = "Mín.";
            this.colStockMinimo.Width = 60;
            this.colStockMinimo.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colStockMinimo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStockMinimo.Name = "colStockMinimo";
            this.dgvStockCritico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockCodigo, this.colStockProducto, this.colStockActual, this.colStockMinimo });
            this.dgvStockCritico.ReadOnly = true;
            this.dgvStockCritico.RowHeadersVisible = false;
            this.dgvStockCritico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStockCritico.RowTemplate.Height = 28;
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 237, 230);
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDashboard";
            this.Text = "Panel de Control";
            this.pnlFondo.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTitulo)).EndInit();
            this.tlpKPIs.ResumeLayout(false);
            this.pnlKpiVentas.ResumeLayout(false);
            this.pnlKpiCaja.ResumeLayout(false);
            this.pnlKpiClientes.ResumeLayout(false);
            this.pnlKpiStock.ResumeLayout(false);
            this.tlpCuerpo.ResumeLayout(false);
            this.pnlCardIzquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimasVentas)).EndInit();
            this.pnlCardDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockCritico)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.PictureBox pbIconoTitulo;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Label lblSubtituloPrincipal;
        private System.Windows.Forms.TableLayoutPanel tlpKPIs;
        private System.Windows.Forms.Panel pnlKpiVentas;
        private System.Windows.Forms.Label lblKpiVentasTitulo;
        private System.Windows.Forms.Label lblKpiVentasValor;
        private System.Windows.Forms.Label lblKpiVentasSub;
        private System.Windows.Forms.Panel pnlKpiCaja;
        private System.Windows.Forms.Label lblKpiCajaTitulo;
        private System.Windows.Forms.Label lblKpiCajaValor;
        private System.Windows.Forms.Label lblKpiCajaSub;
        private System.Windows.Forms.Panel pnlKpiClientes;
        private System.Windows.Forms.Label lblKpiClientesTitulo;
        private System.Windows.Forms.Label lblKpiClientesValor;
        private System.Windows.Forms.Label lblKpiClientesSub;
        private System.Windows.Forms.Panel pnlKpiStock;
        private System.Windows.Forms.Label lblKpiStockTitulo;
        private System.Windows.Forms.Label lblKpiStockValor;
        private System.Windows.Forms.Label lblKpiStockSub;
        private System.Windows.Forms.TableLayoutPanel tlpCuerpo;
        private System.Windows.Forms.Panel pnlCardIzquierda;
        private System.Windows.Forms.Label lblTituloVentas;
        private System.Windows.Forms.DataGridView dgvUltimasVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaTotal;
        private System.Windows.Forms.Panel pnlCardDerecha;
        private System.Windows.Forms.Label lblTituloStock;
        private System.Windows.Forms.DataGridView dgvStockCritico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockMinimo;
        private System.Windows.Forms.Button btnActualizar;
    }
    
}