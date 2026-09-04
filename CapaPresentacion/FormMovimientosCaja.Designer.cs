namespace CapaPresentacion
{
    partial class FormMovimientosCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlFondo = new System.Windows.Forms.Panel();
            this.tlpContenido = new System.Windows.Forms.TableLayoutPanel();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedioPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEgreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTarjetaLateral = new System.Windows.Forms.Panel();
            this.dgvBalance = new System.Windows.Forms.DataGridView();
            this.colConceptoBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMontoBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAccionesTarjeta = new System.Windows.Forms.Panel();
            this.tlpBotonesAccion = new System.Windows.Forms.TableLayoutPanel();
            this.btnArqueo = new System.Windows.Forms.Button();
            this.btnImprimirInforme = new System.Windows.Forms.Button();
            this.btnNuevoMovimiento = new System.Windows.Forms.Button();
            this.lblSubtituloTarjeta = new System.Windows.Forms.Label();
            this.lblTituloTarjeta = new System.Windows.Forms.Label();
            this.pnlBarraFiltros = new System.Windows.Forms.Panel();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroTipo = new System.Windows.Forms.Label();
            this.cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblFiltroMedio = new System.Windows.Forms.Label();
            this.cboMedioPago = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.pbIconoTitulo = new System.Windows.Forms.PictureBox();
            this.pnlFondo.SuspendLayout();
            this.tlpContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.pnlTarjetaLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).BeginInit();
            this.pnlAccionesTarjeta.SuspendLayout();
            this.tlpBotonesAccion.SuspendLayout();
            this.pnlBarraFiltros.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTitulo)).BeginInit();
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
            this.pnlFondo.Size = new System.Drawing.Size(1371, 693);
            this.pnlFondo.TabIndex = 0;
            // 
            // tlpContenido
            // 
            this.tlpContenido.ColumnCount = 2;
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tlpContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpContenido.Controls.Add(this.dgvMovimientos, 0, 0);
            this.tlpContenido.Controls.Add(this.pnlTarjetaLateral, 1, 0);
            this.tlpContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenido.Location = new System.Drawing.Point(21, 100);
            this.tlpContenido.Name = "tlpContenido";
            this.tlpContenido.RowCount = 1;
            this.tlpContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenido.Size = new System.Drawing.Size(1329, 578);
            this.tlpContenido.TabIndex = 0;
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvMovimientos.ColumnHeadersHeight = 32;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colFechaHora,
            this.colTipo,
            this.colConcepto,
            this.colMedioPago,
            this.colIngreso,
            this.colEgreso,
            this.colUsuario});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(235)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMovimientos.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvMovimientos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvMovimientos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53); // Ocre
            this.dgvMovimientos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(212, 131, 53); // Ocre idéntico
            this.dgvMovimientos.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimientos.EnableHeadersVisualStyles = false;
            this.dgvMovimientos.Location = new System.Drawing.Point(0, 6);
            this.dgvMovimientos.Margin = new System.Windows.Forms.Padding(0, 6, 14, 0);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidth = 51;
            this.dgvMovimientos.RowTemplate.Height = 28;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(942, 572);
            this.dgvMovimientos.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            this.colId.Width = 125;
            // 
            // colFechaHora
            // 
            this.colFechaHora.HeaderText = "Fecha / Hora";
            this.colFechaHora.MinimumWidth = 6;
            this.colFechaHora.Name = "colFechaHora";
            this.colFechaHora.ReadOnly = true;
            this.colFechaHora.Width = 120;
            // 
            // colTipo
            // 
            this.colTipo.HeaderText = "Tipo";
            this.colTipo.MinimumWidth = 6;
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 85;
            // 
            // colConcepto
            // 
            this.colConcepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colConcepto.HeaderText = "Concepto / Detalle";
            this.colConcepto.MinimumWidth = 6;
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.ReadOnly = true;
            // 
            // colMedioPago
            // 
            this.colMedioPago.HeaderText = "Medio Pago";
            this.colMedioPago.MinimumWidth = 6;
            this.colMedioPago.Name = "colMedioPago";
            this.colMedioPago.ReadOnly = true;
            this.colMedioPago.Width = 95;
            // 
            // colIngreso
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.colIngreso.DefaultCellStyle = dataGridViewCellStyle23;
            this.colIngreso.HeaderText = "Ingreso (+)";
            this.colIngreso.MinimumWidth = 6;
            this.colIngreso.Name = "colIngreso";
            this.colIngreso.ReadOnly = true;
            this.colIngreso.Width = 90;
            // 
            // colEgreso
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.colEgreso.DefaultCellStyle = dataGridViewCellStyle24;
            this.colEgreso.HeaderText = "Egreso (-)";
            this.colEgreso.MinimumWidth = 6;
            this.colEgreso.Name = "colEgreso";
            this.colEgreso.ReadOnly = true;
            this.colEgreso.Width = 90;
            // 
            // colUsuario
            // 
            this.colUsuario.HeaderText = "Usuario";
            this.colUsuario.MinimumWidth = 6;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.ReadOnly = true;
            this.colUsuario.Width = 95;
            // 
            // pnlTarjetaLateral
            // 
            this.pnlTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.pnlTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTarjetaLateral.Controls.Add(this.dgvBalance);
            this.pnlTarjetaLateral.Controls.Add(this.pnlAccionesTarjeta);
            this.pnlTarjetaLateral.Controls.Add(this.lblSubtituloTarjeta);
            this.pnlTarjetaLateral.Controls.Add(this.lblTituloTarjeta);
            this.pnlTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTarjetaLateral.Location = new System.Drawing.Point(956, 6);
            this.pnlTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlTarjetaLateral.Name = "pnlTarjetaLateral";
            this.pnlTarjetaLateral.Padding = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.pnlTarjetaLateral.Size = new System.Drawing.Size(373, 572);
            this.pnlTarjetaLateral.TabIndex = 1;
            // 
            // dgvBalance
            // 
            this.dgvBalance.AllowUserToAddRows = false;
            this.dgvBalance.AllowUserToDeleteRows = false;
            this.dgvBalance.AllowUserToResizeColumns = false;
            this.dgvBalance.AllowUserToResizeRows = false;
            this.dgvBalance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.dgvBalance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvBalance.ColumnHeadersHeight = 28;
            this.dgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConceptoBalance,
            this.colMontoBalance});
            this.dgvBalance.DefaultCellStyle = dataGridViewCellStyle27;
            this.dgvBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalance.EnableHeadersVisualStyles = false;
            this.dgvBalance.Location = new System.Drawing.Point(16, 64);
            this.dgvBalance.MultiSelect = false;
            this.dgvBalance.Name = "dgvBalance";
            this.dgvBalance.ReadOnly = true;
            this.dgvBalance.RowHeadersVisible = false;
            this.dgvBalance.RowHeadersWidth = 51;
            this.dgvBalance.RowTemplate.Height = 28;
            this.dgvBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalance.Size = new System.Drawing.Size(341, 397);
            this.dgvBalance.TabIndex = 0;
            // 
            // colConceptoBalance
            // 
            this.colConceptoBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colConceptoBalance.DefaultCellStyle = dataGridViewCellStyle27;
            this.colConceptoBalance.HeaderText = "Concepto";
            this.colConceptoBalance.MinimumWidth = 6;
            this.colConceptoBalance.Name = "colConceptoBalance";
            this.colConceptoBalance.ReadOnly = true;
            this.colConceptoBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colMontoBalance
            // 
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colMontoBalance.DefaultCellStyle = dataGridViewCellStyle28;
            this.colMontoBalance.HeaderText = "Monto ($)";
            this.colMontoBalance.MinimumWidth = 6;
            this.colMontoBalance.Name = "colMontoBalance";
            this.colMontoBalance.ReadOnly = true;
            this.colMontoBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMontoBalance.Width = 105;
            // 
            // pnlAccionesTarjeta
            // 
            this.pnlAccionesTarjeta.Controls.Add(this.tlpBotonesAccion);
            this.pnlAccionesTarjeta.Controls.Add(this.btnNuevoMovimiento);
            this.pnlAccionesTarjeta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAccionesTarjeta.Location = new System.Drawing.Point(16, 461);
            this.pnlAccionesTarjeta.Name = "pnlAccionesTarjeta";
            this.pnlAccionesTarjeta.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlAccionesTarjeta.Size = new System.Drawing.Size(341, 96);
            this.pnlAccionesTarjeta.TabIndex = 1;
            // 
            // tlpBotonesAccion
            // 
            this.tlpBotonesAccion.ColumnCount = 2;
            this.tlpBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotonesAccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBotonesAccion.Controls.Add(this.btnArqueo, 0, 0);
            this.tlpBotonesAccion.Controls.Add(this.btnImprimirInforme, 1, 0);
            this.tlpBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpBotonesAccion.Location = new System.Drawing.Point(0, 45);
            this.tlpBotonesAccion.Name = "tlpBotonesAccion";
            this.tlpBotonesAccion.RowCount = 1;
            this.tlpBotonesAccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBotonesAccion.Size = new System.Drawing.Size(341, 51);
            this.tlpBotonesAccion.TabIndex = 0;
            // 
            // btnArqueo
            // 
            this.btnArqueo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.btnArqueo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArqueo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnArqueo.FlatAppearance.BorderSize = 0;
            this.btnArqueo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArqueo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnArqueo.ForeColor = System.Drawing.Color.White;
            this.btnArqueo.Location = new System.Drawing.Point(0, 4);
            this.btnArqueo.Margin = new System.Windows.Forms.Padding(0, 4, 5, 0);
            this.btnArqueo.Name = "btnArqueo";
            this.btnArqueo.Size = new System.Drawing.Size(165, 47);
            this.btnArqueo.TabIndex = 0;
            this.btnArqueo.Text = "Cierre / Arqueo";
            this.btnArqueo.UseVisualStyleBackColor = false;
            // 
            // btnImprimirInforme
            // 
            this.btnImprimirInforme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.btnImprimirInforme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimirInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImprimirInforme.FlatAppearance.BorderSize = 0;
            this.btnImprimirInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirInforme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimirInforme.ForeColor = System.Drawing.Color.White;
            this.btnImprimirInforme.Location = new System.Drawing.Point(175, 4);
            this.btnImprimirInforme.Margin = new System.Windows.Forms.Padding(5, 4, 0, 0);
            this.btnImprimirInforme.Name = "btnImprimirInforme";
            this.btnImprimirInforme.Size = new System.Drawing.Size(166, 47);
            this.btnImprimirInforme.TabIndex = 1;
            this.btnImprimirInforme.Text = "Exportar PDF";
            this.btnImprimirInforme.UseVisualStyleBackColor = false;
            // 
            // btnNuevoMovimiento
            // 
            this.btnNuevoMovimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnNuevoMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMovimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            this.btnNuevoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoMovimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNuevoMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnNuevoMovimiento.Location = new System.Drawing.Point(0, 4);
            this.btnNuevoMovimiento.Name = "btnNuevoMovimiento";
            this.btnNuevoMovimiento.Size = new System.Drawing.Size(341, 41);
            this.btnNuevoMovimiento.TabIndex = 1;
            this.btnNuevoMovimiento.Text = "+ Nuevo Ingreso / Egreso";
            this.btnNuevoMovimiento.UseVisualStyleBackColor = false;
            // 
            // lblSubtituloTarjeta
            // 
            this.lblSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtituloTarjeta.Location = new System.Drawing.Point(16, 41);
            this.lblSubtituloTarjeta.Name = "lblSubtituloTarjeta";
            this.lblSubtituloTarjeta.Size = new System.Drawing.Size(341, 23);
            this.lblSubtituloTarjeta.TabIndex = 2;
            this.lblSubtituloTarjeta.Text = "Resumen del período seleccionado";
            this.lblSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloTarjeta
            // 
            this.lblTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.lblTituloTarjeta.Location = new System.Drawing.Point(16, 15);
            this.lblTituloTarjeta.Name = "lblTituloTarjeta";
            this.lblTituloTarjeta.Size = new System.Drawing.Size(341, 26);
            this.lblTituloTarjeta.TabIndex = 3;
            this.lblTituloTarjeta.Text = "BALANCE Y ARQUEO";
            this.lblTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBarraFiltros
            // 
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroFecha);
            this.pnlBarraFiltros.Controls.Add(this.dtpDesde);
            this.pnlBarraFiltros.Controls.Add(this.dtpHasta);
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroTipo);
            this.pnlBarraFiltros.Controls.Add(this.cboTipoMovimiento);
            this.pnlBarraFiltros.Controls.Add(this.lblFiltroMedio);
            this.pnlBarraFiltros.Controls.Add(this.cboMedioPago);
            this.pnlBarraFiltros.Controls.Add(this.btnBuscar);
            this.pnlBarraFiltros.Controls.Add(this.btnLimpiar);
            this.pnlBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraFiltros.Location = new System.Drawing.Point(21, 53);
            this.pnlBarraFiltros.Name = "pnlBarraFiltros";
            this.pnlBarraFiltros.Size = new System.Drawing.Size(1329, 47);
            this.pnlBarraFiltros.TabIndex = 1;
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroFecha.Location = new System.Drawing.Point(3, 13);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(60, 20);
            this.lblFiltroFecha.TabIndex = 0;
            this.lblFiltroFecha.Text = "Fechas:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.Location = new System.Drawing.Point(66, 8);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(131, 27);
            this.dtpDesde.TabIndex = 1;
            // 
            // dtpHasta
            // 
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.Location = new System.Drawing.Point(214, 8);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(131, 27);
            this.dtpHasta.TabIndex = 2;
            // 
            // lblFiltroTipo
            // 
            this.lblFiltroTipo.AutoSize = true;
            this.lblFiltroTipo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroTipo.Location = new System.Drawing.Point(363, 11);
            this.lblFiltroTipo.Name = "lblFiltroTipo";
            this.lblFiltroTipo.Size = new System.Drawing.Size(44, 20);
            this.lblFiltroTipo.TabIndex = 3;
            this.lblFiltroTipo.Text = "Tipo:";
            // 
            // cboTipoMovimiento
            // 
            this.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboTipoMovimiento.Items.AddRange(new object[] {
            "Todos",
            "Ingreso",
            "Egreso",
            "Venta",
            "Apertura",
            "Cierre"});
            this.cboTipoMovimiento.Location = new System.Drawing.Point(413, 8);
            this.cboTipoMovimiento.Name = "cboTipoMovimiento";
            this.cboTipoMovimiento.Size = new System.Drawing.Size(131, 28);
            this.cboTipoMovimiento.TabIndex = 4;
            // 
            // lblFiltroMedio
            // 
            this.lblFiltroMedio.AutoSize = true;
            this.lblFiltroMedio.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFiltroMedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblFiltroMedio.Location = new System.Drawing.Point(573, 11);
            this.lblFiltroMedio.Name = "lblFiltroMedio";
            this.lblFiltroMedio.Size = new System.Drawing.Size(96, 20);
            this.lblFiltroMedio.TabIndex = 5;
            this.lblFiltroMedio.Text = "Medio Pago:";
            // 
            // cboMedioPago
            // 
            this.cboMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedioPago.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboMedioPago.Items.AddRange(new object[] {
            "Todos",
            "Efectivo",
            "Débito",
            "Crédito",
            "Transferencia",
            "QR"});
            this.cboMedioPago.Location = new System.Drawing.Point(675, 7);
            this.cboMedioPago.Name = "cboMedioPago";
            this.cboMedioPago.Size = new System.Drawing.Size(137, 28);
            this.cboMedioPago.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(862, 8);
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
            this.btnLimpiar.Location = new System.Drawing.Point(972, 8);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 29);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblTituloPrincipal);
            this.pnlEncabezado.Controls.Add(this.pbIconoTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(21, 15);
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1329, 38);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(358, 28);
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "MOVIMIENTOS Y CONTROL DE CAJA";
            // 
            // pbIconoTitulo
            // 
            this.pbIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pbIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.pbIconoTitulo.Name = "pbIconoTitulo";
            this.pbIconoTitulo.Size = new System.Drawing.Size(37, 34);
            this.pbIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIconoTitulo.TabIndex = 1;
            this.pbIconoTitulo.TabStop = false;
            // 
            // FormMovimientosCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1371, 693);
            this.Controls.Add(this.pnlFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMovimientosCaja";
            this.Text = "Movimientos de Caja";
            this.Load += new System.EventHandler(this.FormMovimientosCaja_Load);
            this.pnlFondo.ResumeLayout(false);
            this.tlpContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.pnlTarjetaLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).EndInit();
            this.pnlAccionesTarjeta.ResumeLayout(false);
            this.tlpBotonesAccion.ResumeLayout(false);
            this.pnlBarraFiltros.ResumeLayout(false);
            this.pnlBarraFiltros.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconoTitulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFondo;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.PictureBox pbIconoTitulo;
        private System.Windows.Forms.Label lblTituloPrincipal;

        private System.Windows.Forms.Panel pnlBarraFiltros;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.Label lblFiltroMedio;
        private System.Windows.Forms.ComboBox cboMedioPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.TableLayoutPanel tlpContenido;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedioPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEgreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsuario;

        private System.Windows.Forms.Panel pnlTarjetaLateral;
        private System.Windows.Forms.Label lblTituloTarjeta;
        private System.Windows.Forms.Label lblSubtituloTarjeta;
        private System.Windows.Forms.DataGridView dgvBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConceptoBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMontoBalance;

        private System.Windows.Forms.Panel pnlAccionesTarjeta;
        private System.Windows.Forms.Button btnNuevoMovimiento;
        private System.Windows.Forms.TableLayoutPanel tlpBotonesAccion;
        private System.Windows.Forms.Button btnArqueo;
        private System.Windows.Forms.Button btnImprimirInforme;
    }
}