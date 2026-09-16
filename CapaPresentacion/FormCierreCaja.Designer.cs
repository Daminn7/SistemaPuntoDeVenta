namespace CapaPresentacion
{
    partial class FormCierreCaja
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
            this.PFondo = new System.Windows.Forms.Panel();
            this.TLPContenedorPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.PTarjetaResumen = new System.Windows.Forms.Panel();
            this.TLPResumenTurno = new System.Windows.Forms.TableLayoutPanel();
            this.PGrupoFondoInicial = new System.Windows.Forms.Panel();
            this.TBFondoInicial = new System.Windows.Forms.TextBox();
            this.LFondoInicial = new System.Windows.Forms.Label();
            this.PGrupoVentasEfectivo = new System.Windows.Forms.Panel();
            this.TBVentasEfectivo = new System.Windows.Forms.TextBox();
            this.LVentasEfectivo = new System.Windows.Forms.Label();
            this.PGrupoCobrosDigitales = new System.Windows.Forms.Panel();
            this.TBCobrosDigitales = new System.Windows.Forms.TextBox();
            this.LCobrosDigitales = new System.Windows.Forms.Label();
            this.PGrupoCobrosTarjetas = new System.Windows.Forms.Panel();
            this.TBCobrosTarjetas = new System.Windows.Forms.TextBox();
            this.LCobrosTarjetas = new System.Windows.Forms.Label();
            this.PGrupoEgresosMenores = new System.Windows.Forms.Panel();
            this.TBEgresosMenores = new System.Windows.Forms.TextBox();
            this.LEgresosMenores = new System.Windows.Forms.Label();
            this.PGrupoTotalGaveta = new System.Windows.Forms.Panel();
            this.TBTotalGaveta = new System.Windows.Forms.TextBox();
            this.LTotalGaveta = new System.Windows.Forms.Label();
            this.LSubtituloResumen = new System.Windows.Forms.Label();
            this.LTituloResumen = new System.Windows.Forms.Label();
            this.PTarjetaAcciones = new System.Windows.Forms.Panel();
            this.PContenedorBotones = new System.Windows.Forms.Panel();
            this.BCerrarTurno = new System.Windows.Forms.Button();
            this.BMovimientoMenor = new System.Windows.Forms.Button();
            this.BAbrirTurno = new System.Windows.Forms.Button();
            this.LSubtituloAcciones = new System.Windows.Forms.Label();
            this.LTituloAcciones = new System.Windows.Forms.Label();
            this.PFranjaEstado = new System.Windows.Forms.Panel();
            this.LEstadoTurno = new System.Windows.Forms.Label();
            this.LInfoOperador = new System.Windows.Forms.Label();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PFondo.SuspendLayout();
            this.TLPContenedorPrincipal.SuspendLayout();
            this.PTarjetaResumen.SuspendLayout();
            this.TLPResumenTurno.SuspendLayout();
            this.PGrupoFondoInicial.SuspendLayout();
            this.PGrupoVentasEfectivo.SuspendLayout();
            this.PGrupoCobrosDigitales.SuspendLayout();
            this.PGrupoCobrosTarjetas.SuspendLayout();
            this.PGrupoEgresosMenores.SuspendLayout();
            this.PGrupoTotalGaveta.SuspendLayout();
            this.PTarjetaAcciones.SuspendLayout();
            this.PContenedorBotones.SuspendLayout();
            this.PFranjaEstado.SuspendLayout();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // PFondo
            // 
            this.PFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.PFondo.Controls.Add(this.TLPContenedorPrincipal);
            this.PFondo.Controls.Add(this.PFranjaEstado);
            this.PFondo.Controls.Add(this.PEncabezado);
            this.PFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PFondo.Location = new System.Drawing.Point(0, 0);
            this.PFondo.Name = "PFondo";
            this.PFondo.Padding = new System.Windows.Forms.Padding(21, 15, 21, 15);
            this.PFondo.Size = new System.Drawing.Size(1200, 720);
            this.PFondo.TabIndex = 0;
            // 
            // TLPContenedorPrincipal
            // 
            this.TLPContenedorPrincipal.ColumnCount = 2;
            this.TLPContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.TLPContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.TLPContenedorPrincipal.Controls.Add(this.PTarjetaResumen, 0, 0);
            this.TLPContenedorPrincipal.Controls.Add(this.PTarjetaAcciones, 1, 0);
            this.TLPContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenedorPrincipal.Location = new System.Drawing.Point(21, 101);
            this.TLPContenedorPrincipal.Name = "TLPContenedorPrincipal";
            this.TLPContenedorPrincipal.RowCount = 1;
            this.TLPContenedorPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenedorPrincipal.Size = new System.Drawing.Size(1158, 604);
            this.TLPContenedorPrincipal.TabIndex = 2;
            // 
            // PTarjetaResumen
            // 
            this.PTarjetaResumen.BackColor = System.Drawing.Color.White;
            this.PTarjetaResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaResumen.Controls.Add(this.TLPResumenTurno);
            this.PTarjetaResumen.Controls.Add(this.LSubtituloResumen);
            this.PTarjetaResumen.Controls.Add(this.LTituloResumen);
            this.PTarjetaResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaResumen.Location = new System.Drawing.Point(0, 0);
            this.PTarjetaResumen.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PTarjetaResumen.Name = "PTarjetaResumen";
            this.PTarjetaResumen.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.PTarjetaResumen.Size = new System.Drawing.Size(661, 604);
            this.PTarjetaResumen.TabIndex = 0;
            // 
            // TLPResumenTurno
            // 
            this.TLPResumenTurno.ColumnCount = 2;
            this.TLPResumenTurno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPResumenTurno.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPResumenTurno.Controls.Add(this.PGrupoFondoInicial, 0, 0);
            this.TLPResumenTurno.Controls.Add(this.PGrupoVentasEfectivo, 1, 0);
            this.TLPResumenTurno.Controls.Add(this.PGrupoCobrosDigitales, 0, 1);
            this.TLPResumenTurno.Controls.Add(this.PGrupoCobrosTarjetas, 1, 1);
            this.TLPResumenTurno.Controls.Add(this.PGrupoEgresosMenores, 0, 2);
            this.TLPResumenTurno.Controls.Add(this.PGrupoTotalGaveta, 0, 3);
            this.TLPResumenTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPResumenTurno.Location = new System.Drawing.Point(18, 62);
            this.TLPResumenTurno.Name = "TLPResumenTurno";
            this.TLPResumenTurno.RowCount = 4;
            this.TLPResumenTurno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TLPResumenTurno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TLPResumenTurno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.TLPResumenTurno.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPResumenTurno.Size = new System.Drawing.Size(623, 526);
            this.TLPResumenTurno.TabIndex = 2;
            // 
            // PGrupoFondoInicial
            // 
            this.PGrupoFondoInicial.Controls.Add(this.TBFondoInicial);
            this.PGrupoFondoInicial.Controls.Add(this.LFondoInicial);
            this.PGrupoFondoInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoFondoInicial.Location = new System.Drawing.Point(0, 0);
            this.PGrupoFondoInicial.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.PGrupoFondoInicial.Name = "PGrupoFondoInicial";
            this.PGrupoFondoInicial.Size = new System.Drawing.Size(303, 66);
            this.PGrupoFondoInicial.TabIndex = 0;
            // 
            // TBFondoInicial
            // 
            this.TBFondoInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.TBFondoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBFondoInicial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBFondoInicial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBFondoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TBFondoInicial.Location = new System.Drawing.Point(0, 34);
            this.TBFondoInicial.Name = "TBFondoInicial";
            this.TBFondoInicial.ReadOnly = true;
            this.TBFondoInicial.Size = new System.Drawing.Size(303, 32);
            this.TBFondoInicial.TabIndex = 1;
            this.TBFondoInicial.Text = "$ 0,00";
            this.TBFondoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LFondoInicial
            // 
            this.LFondoInicial.AutoSize = true;
            this.LFondoInicial.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFondoInicial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LFondoInicial.Location = new System.Drawing.Point(0, 5);
            this.LFondoInicial.Name = "LFondoInicial";
            this.LFondoInicial.Size = new System.Drawing.Size(183, 20);
            this.LFondoInicial.TabIndex = 0;
            this.LFondoInicial.Text = "Fondo Inicial de Apertura:";
            // 
            // PGrupoVentasEfectivo
            // 
            this.PGrupoVentasEfectivo.Controls.Add(this.TBVentasEfectivo);
            this.PGrupoVentasEfectivo.Controls.Add(this.LVentasEfectivo);
            this.PGrupoVentasEfectivo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoVentasEfectivo.Location = new System.Drawing.Point(319, 0);
            this.PGrupoVentasEfectivo.Margin = new System.Windows.Forms.Padding(8, 0, 0, 4);
            this.PGrupoVentasEfectivo.Name = "PGrupoVentasEfectivo";
            this.PGrupoVentasEfectivo.Size = new System.Drawing.Size(304, 66);
            this.PGrupoVentasEfectivo.TabIndex = 1;
            // 
            // TBVentasEfectivo
            // 
            this.TBVentasEfectivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.TBVentasEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBVentasEfectivo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBVentasEfectivo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBVentasEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.TBVentasEfectivo.Location = new System.Drawing.Point(0, 34);
            this.TBVentasEfectivo.Name = "TBVentasEfectivo";
            this.TBVentasEfectivo.ReadOnly = true;
            this.TBVentasEfectivo.Size = new System.Drawing.Size(304, 32);
            this.TBVentasEfectivo.TabIndex = 1;
            this.TBVentasEfectivo.Text = "$ 0,00";
            this.TBVentasEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LVentasEfectivo
            // 
            this.LVentasEfectivo.AutoSize = true;
            this.LVentasEfectivo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LVentasEfectivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LVentasEfectivo.Location = new System.Drawing.Point(0, 5);
            this.LVentasEfectivo.Name = "LVentasEfectivo";
            this.LVentasEfectivo.Size = new System.Drawing.Size(155, 20);
            this.LVentasEfectivo.TabIndex = 0;
            this.LVentasEfectivo.Text = "Cobros en Efectivo (+):";
            // 
            // PGrupoCobrosDigitales
            // 
            this.PGrupoCobrosDigitales.Controls.Add(this.TBCobrosDigitales);
            this.PGrupoCobrosDigitales.Controls.Add(this.LCobrosDigitales);
            this.PGrupoCobrosDigitales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCobrosDigitales.Location = new System.Drawing.Point(0, 70);
            this.PGrupoCobrosDigitales.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.PGrupoCobrosDigitales.Name = "PGrupoCobrosDigitales";
            this.PGrupoCobrosDigitales.Size = new System.Drawing.Size(303, 66);
            this.PGrupoCobrosDigitales.TabIndex = 2;
            // 
            // TBCobrosDigitales
            // 
            this.TBCobrosDigitales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.TBCobrosDigitales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCobrosDigitales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCobrosDigitales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBCobrosDigitales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.TBCobrosDigitales.Location = new System.Drawing.Point(0, 34);
            this.TBCobrosDigitales.Name = "TBCobrosDigitales";
            this.TBCobrosDigitales.ReadOnly = true;
            this.TBCobrosDigitales.Size = new System.Drawing.Size(303, 32);
            this.TBCobrosDigitales.TabIndex = 1;
            this.TBCobrosDigitales.Text = "$ 0,00";
            this.TBCobrosDigitales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LCobrosDigitales
            // 
            this.LCobrosDigitales.AutoSize = true;
            this.LCobrosDigitales.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LCobrosDigitales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LCobrosDigitales.Location = new System.Drawing.Point(0, 5);
            this.LCobrosDigitales.Name = "LCobrosDigitales";
            this.LCobrosDigitales.Size = new System.Drawing.Size(183, 20);
            this.LCobrosDigitales.TabIndex = 0;
            this.LCobrosDigitales.Text = "Transferencias / QR / MP:";
            // 
            // PGrupoCobrosTarjetas
            // 
            this.PGrupoCobrosTarjetas.Controls.Add(this.TBCobrosTarjetas);
            this.PGrupoCobrosTarjetas.Controls.Add(this.LCobrosTarjetas);
            this.PGrupoCobrosTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCobrosTarjetas.Location = new System.Drawing.Point(319, 70);
            this.PGrupoCobrosTarjetas.Margin = new System.Windows.Forms.Padding(8, 0, 0, 4);
            this.PGrupoCobrosTarjetas.Name = "PGrupoCobrosTarjetas";
            this.PGrupoCobrosTarjetas.Size = new System.Drawing.Size(304, 66);
            this.PGrupoCobrosTarjetas.TabIndex = 3;
            // 
            // TBCobrosTarjetas
            // 
            this.TBCobrosTarjetas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.TBCobrosTarjetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBCobrosTarjetas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCobrosTarjetas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBCobrosTarjetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.TBCobrosTarjetas.Location = new System.Drawing.Point(0, 34);
            this.TBCobrosTarjetas.Name = "TBCobrosTarjetas";
            this.TBCobrosTarjetas.ReadOnly = true;
            this.TBCobrosTarjetas.Size = new System.Drawing.Size(304, 32);
            this.TBCobrosTarjetas.TabIndex = 1;
            this.TBCobrosTarjetas.Text = "$ 0,00";
            this.TBCobrosTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LCobrosTarjetas
            // 
            this.LCobrosTarjetas.AutoSize = true;
            this.LCobrosTarjetas.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LCobrosTarjetas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LCobrosTarjetas.Location = new System.Drawing.Point(0, 5);
            this.LCobrosTarjetas.Name = "LCobrosTarjetas";
            this.LCobrosTarjetas.Size = new System.Drawing.Size(184, 20);
            this.LCobrosTarjetas.TabIndex = 0;
            this.LCobrosTarjetas.Text = "Tarjetas Débito / Crédito:";
            // 
            // PGrupoEgresosMenores
            // 
            this.PGrupoEgresosMenores.Controls.Add(this.TBEgresosMenores);
            this.PGrupoEgresosMenores.Controls.Add(this.LEgresosMenores);
            this.PGrupoEgresosMenores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoEgresosMenores.Location = new System.Drawing.Point(0, 140);
            this.PGrupoEgresosMenores.Margin = new System.Windows.Forms.Padding(0, 0, 8, 4);
            this.PGrupoEgresosMenores.Name = "PGrupoEgresosMenores";
            this.PGrupoEgresosMenores.Size = new System.Drawing.Size(303, 66);
            this.PGrupoEgresosMenores.TabIndex = 4;
            // 
            // TBEgresosMenores
            // 
            this.TBEgresosMenores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.TBEgresosMenores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBEgresosMenores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBEgresosMenores.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TBEgresosMenores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.TBEgresosMenores.Location = new System.Drawing.Point(0, 34);
            this.TBEgresosMenores.Name = "TBEgresosMenores";
            this.TBEgresosMenores.ReadOnly = true;
            this.TBEgresosMenores.Size = new System.Drawing.Size(303, 32);
            this.TBEgresosMenores.TabIndex = 1;
            this.TBEgresosMenores.Text = "$ 0,00";
            this.TBEgresosMenores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LEgresosMenores
            // 
            this.LEgresosMenores.AutoSize = true;
            this.LEgresosMenores.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LEgresosMenores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LEgresosMenores.Location = new System.Drawing.Point(0, 5);
            this.LEgresosMenores.Name = "LEgresosMenores";
            this.LEgresosMenores.Size = new System.Drawing.Size(184, 20);
            this.LEgresosMenores.TabIndex = 0;
            this.LEgresosMenores.Text = "Retiros / Gastos Caja (-):";
            // 
            // PGrupoTotalGaveta
            // 
            this.TLPResumenTurno.SetColumnSpan(this.PGrupoTotalGaveta, 2);
            this.PGrupoTotalGaveta.Controls.Add(this.TBTotalGaveta);
            this.PGrupoTotalGaveta.Controls.Add(this.LTotalGaveta);
            this.PGrupoTotalGaveta.Dock = System.Windows.Forms.DockStyle.Top;
            this.PGrupoTotalGaveta.Location = new System.Drawing.Point(0, 220);
            this.PGrupoTotalGaveta.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PGrupoTotalGaveta.Name = "PGrupoTotalGaveta";
            this.PGrupoTotalGaveta.Size = new System.Drawing.Size(623, 110);
            this.PGrupoTotalGaveta.TabIndex = 5;
            // 
            // TBTotalGaveta
            // 
            this.TBTotalGaveta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.TBTotalGaveta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBTotalGaveta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBTotalGaveta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.TBTotalGaveta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.TBTotalGaveta.Location = new System.Drawing.Point(0, 39);
            this.TBTotalGaveta.Name = "TBTotalGaveta";
            this.TBTotalGaveta.ReadOnly = true;
            this.TBTotalGaveta.Size = new System.Drawing.Size(623, 47);
            this.TBTotalGaveta.TabIndex = 1;
            this.TBTotalGaveta.Text = "$ 0,00";
            this.TBTotalGaveta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LTotalGaveta
            // 
            this.LTotalGaveta.AutoSize = true;
            this.LTotalGaveta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTotalGaveta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LTotalGaveta.Location = new System.Drawing.Point(0, 5);
            this.LTotalGaveta.Name = "LTotalGaveta";
            this.LTotalGaveta.Size = new System.Drawing.Size(306, 25);
            this.LTotalGaveta.TabIndex = 0;
            this.LTotalGaveta.Text = "TOTAL EFECTIVO TEÓRICO EN GAVETA:";
            // 
            // LSubtituloResumen
            // 
            this.LSubtituloResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloResumen.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloResumen.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloResumen.Location = new System.Drawing.Point(18, 38);
            this.LSubtituloResumen.Name = "LSubtituloResumen";
            this.LSubtituloResumen.Size = new System.Drawing.Size(623, 24);
            this.LSubtituloResumen.TabIndex = 1;
            this.LSubtituloResumen.Text = "Balance contable acumulado de la sesión en curso";
            // 
            // LTituloResumen
            // 
            this.LTituloResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloResumen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LTituloResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloResumen.Location = new System.Drawing.Point(18, 14);
            this.LTituloResumen.Name = "LTituloResumen";
            this.LTituloResumen.Size = new System.Drawing.Size(623, 24);
            this.LTituloResumen.TabIndex = 0;
            this.LTituloResumen.Text = "ESTADO DE RECAUDACIÓN Y MOVIMIENTOS";
            // 
            // PTarjetaAcciones
            // 
            this.PTarjetaAcciones.BackColor = System.Drawing.Color.White;
            this.PTarjetaAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaAcciones.Controls.Add(this.PContenedorBotones);
            this.PTarjetaAcciones.Controls.Add(this.LSubtituloAcciones);
            this.PTarjetaAcciones.Controls.Add(this.LTituloAcciones);
            this.PTarjetaAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaAcciones.Location = new System.Drawing.Point(681, 0);
            this.PTarjetaAcciones.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.PTarjetaAcciones.Name = "PTarjetaAcciones";
            this.PTarjetaAcciones.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.PTarjetaAcciones.Size = new System.Drawing.Size(477, 604);
            this.PTarjetaAcciones.TabIndex = 1;
            // 
            // PContenedorBotones
            // 
            this.PContenedorBotones.Controls.Add(this.BCerrarTurno);
            this.PContenedorBotones.Controls.Add(this.BMovimientoMenor);
            this.PContenedorBotones.Controls.Add(this.BAbrirTurno);
            this.PContenedorBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenedorBotones.Location = new System.Drawing.Point(18, 62);
            this.PContenedorBotones.Name = "PContenedorBotones";
            this.PContenedorBotones.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.PContenedorBotones.Size = new System.Drawing.Size(439, 526);
            this.PContenedorBotones.TabIndex = 2;
            // 
            // BCerrarTurno
            // 
            this.BCerrarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BCerrarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarTurno.Dock = System.Windows.Forms.DockStyle.Top;
            this.BCerrarTurno.FlatAppearance.BorderSize = 0;
            this.BCerrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrarTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BCerrarTurno.ForeColor = System.Drawing.Color.White;
            this.BCerrarTurno.Location = new System.Drawing.Point(0, 145);
            this.BCerrarTurno.Name = "BCerrarTurno";
            this.BCerrarTurno.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.BCerrarTurno.Size = new System.Drawing.Size(439, 55);
            this.BCerrarTurno.TabIndex = 2;
            this.BCerrarTurno.Text = "🔒 Arqueo y Cierre de Turno";
            this.BCerrarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCerrarTurno.UseVisualStyleBackColor = false;
            this.BCerrarTurno.Click += new System.EventHandler(this.BCerrarTurno_Click);
            // 
            // BMovimientoMenor
            // 
            this.BMovimientoMenor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.BMovimientoMenor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMovimientoMenor.Dock = System.Windows.Forms.DockStyle.Top;
            this.BMovimientoMenor.FlatAppearance.BorderSize = 0;
            this.BMovimientoMenor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BMovimientoMenor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BMovimientoMenor.ForeColor = System.Drawing.Color.White;
            this.BMovimientoMenor.Location = new System.Drawing.Point(0, 80);
            this.BMovimientoMenor.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.BMovimientoMenor.Name = "BMovimientoMenor";
            this.BMovimientoMenor.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.BMovimientoMenor.Size = new System.Drawing.Size(439, 55);
            this.BMovimientoMenor.TabIndex = 1;
            this.BMovimientoMenor.Text = "💸 Registrar Ingreso / Egreso Menor";
            this.BMovimientoMenor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BMovimientoMenor.UseVisualStyleBackColor = false;
            this.BMovimientoMenor.Click += new System.EventHandler(this.BMovimientoMenor_Click);
            // 
            // BAbrirTurno
            // 
            this.BAbrirTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BAbrirTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAbrirTurno.Dock = System.Windows.Forms.DockStyle.Top;
            this.BAbrirTurno.FlatAppearance.BorderSize = 0;
            this.BAbrirTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAbrirTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BAbrirTurno.ForeColor = System.Drawing.Color.White;
            this.BAbrirTurno.Location = new System.Drawing.Point(0, 15);
            this.BAbrirTurno.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.BAbrirTurno.Name = "BAbrirTurno";
            this.BAbrirTurno.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.BAbrirTurno.Size = new System.Drawing.Size(439, 55);
            this.BAbrirTurno.TabIndex = 0;
            this.BAbrirTurno.Text = "🔓 Apertura de Turno y Caja";
            this.BAbrirTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BAbrirTurno.UseVisualStyleBackColor = false;
            this.BAbrirTurno.Click += new System.EventHandler(this.BAbrirTurno_Click);
            // 
            // LSubtituloAcciones
            // 
            this.LSubtituloAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloAcciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloAcciones.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloAcciones.Location = new System.Drawing.Point(18, 38);
            this.LSubtituloAcciones.Name = "LSubtituloAcciones";
            this.LSubtituloAcciones.Size = new System.Drawing.Size(439, 24);
            this.LSubtituloAcciones.TabIndex = 1;
            this.LSubtituloAcciones.Text = "Control operativo de inicio, egresos menores y corte de turno";
            // 
            // LTituloAcciones
            // 
            this.LTituloAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloAcciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LTituloAcciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloAcciones.Location = new System.Drawing.Point(18, 14);
            this.LTituloAcciones.Name = "LTituloAcciones";
            this.LTituloAcciones.Size = new System.Drawing.Size(439, 24);
            this.LTituloAcciones.TabIndex = 0;
            this.LTituloAcciones.Text = "OPERACIONES DE CAJA";
            // 
            // PFranjaEstado
            // 
            this.PFranjaEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.PFranjaEstado.Controls.Add(this.LEstadoTurno);
            this.PFranjaEstado.Controls.Add(this.LInfoOperador);
            this.PFranjaEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PFranjaEstado.Location = new System.Drawing.Point(21, 53);
            this.PFranjaEstado.Name = "PFranjaEstado";
            this.PFranjaEstado.Padding = new System.Windows.Forms.Padding(14, 0, 14, 0);
            this.PFranjaEstado.Size = new System.Drawing.Size(1158, 48);
            this.PFranjaEstado.TabIndex = 1;
            // 
            // LEstadoTurno
            // 
            this.LEstadoTurno.Dock = System.Windows.Forms.DockStyle.Right;
            this.LEstadoTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LEstadoTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.LEstadoTurno.Location = new System.Drawing.Point(844, 0);
            this.LEstadoTurno.Name = "LEstadoTurno";
            this.LEstadoTurno.Size = new System.Drawing.Size(300, 48);
            this.LEstadoTurno.TabIndex = 1;
            this.LEstadoTurno.Text = "ESTADO: CAJA ABIERTA ●";
            this.LEstadoTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LInfoOperador
            // 
            this.LInfoOperador.Dock = System.Windows.Forms.DockStyle.Left;
            this.LInfoOperador.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.LInfoOperador.ForeColor = System.Drawing.Color.White;
            this.LInfoOperador.Location = new System.Drawing.Point(14, 0);
            this.LInfoOperador.Name = "LInfoOperador";
            this.LInfoOperador.Size = new System.Drawing.Size(650, 48);
            this.LInfoOperador.TabIndex = 0;
            this.LInfoOperador.Text = "Operador de Caja: - | Turno: - | Fecha: -";
            this.LInfoOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PEncabezado
            // 
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(21, 15);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1158, 38);
            this.PEncabezado.TabIndex = 0;
            // 
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LTituloPrincipal.Location = new System.Drawing.Point(43, 5);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(325, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "ARQUEO Y CIERRE DE CAJA";
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
            // FormCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCierreCaja";
            this.Text = "Arqueo y Cierre de Caja";
            this.Load += new System.EventHandler(this.FormCierreCaja_Load);
            this.PFondo.ResumeLayout(false);
            this.TLPContenedorPrincipal.ResumeLayout(false);
            this.PTarjetaResumen.ResumeLayout(false);
            this.TLPResumenTurno.ResumeLayout(false);
            this.PGrupoFondoInicial.ResumeLayout(false);
            this.PGrupoFondoInicial.PerformLayout();
            this.PGrupoVentasEfectivo.ResumeLayout(false);
            this.PGrupoVentasEfectivo.PerformLayout();
            this.PGrupoCobrosDigitales.ResumeLayout(false);
            this.PGrupoCobrosDigitales.PerformLayout();
            this.PGrupoCobrosTarjetas.ResumeLayout(false);
            this.PGrupoCobrosTarjetas.PerformLayout();
            this.PGrupoEgresosMenores.ResumeLayout(false);
            this.PGrupoEgresosMenores.PerformLayout();
            this.PGrupoTotalGaveta.ResumeLayout(false);
            this.PGrupoTotalGaveta.PerformLayout();
            this.PTarjetaAcciones.ResumeLayout(false);
            this.PContenedorBotones.ResumeLayout(false);
            this.PFranjaEstado.ResumeLayout(false);
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
        private System.Windows.Forms.Panel PFranjaEstado;
        private System.Windows.Forms.Label LInfoOperador;
        private System.Windows.Forms.Label LEstadoTurno;
        private System.Windows.Forms.TableLayoutPanel TLPContenedorPrincipal;
        private System.Windows.Forms.Panel PTarjetaResumen;
        private System.Windows.Forms.Label LTituloResumen;
        private System.Windows.Forms.Label LSubtituloResumen;
        private System.Windows.Forms.TableLayoutPanel TLPResumenTurno;
        private System.Windows.Forms.Panel PGrupoFondoInicial;
        private System.Windows.Forms.Label LFondoInicial;
        private System.Windows.Forms.TextBox TBFondoInicial;
        private System.Windows.Forms.Panel PGrupoVentasEfectivo;
        private System.Windows.Forms.Label LVentasEfectivo;
        private System.Windows.Forms.TextBox TBVentasEfectivo;
        private System.Windows.Forms.Panel PGrupoCobrosDigitales;
        private System.Windows.Forms.Label LCobrosDigitales;
        private System.Windows.Forms.TextBox TBCobrosDigitales;
        private System.Windows.Forms.Panel PGrupoCobrosTarjetas;
        private System.Windows.Forms.Label LCobrosTarjetas;
        private System.Windows.Forms.TextBox TBCobrosTarjetas;
        private System.Windows.Forms.Panel PGrupoEgresosMenores;
        private System.Windows.Forms.Label LEgresosMenores;
        private System.Windows.Forms.TextBox TBEgresosMenores;
        private System.Windows.Forms.Panel PGrupoTotalGaveta;
        private System.Windows.Forms.Label LTotalGaveta;
        private System.Windows.Forms.TextBox TBTotalGaveta;
        private System.Windows.Forms.Panel PTarjetaAcciones;
        private System.Windows.Forms.Label LTituloAcciones;
        private System.Windows.Forms.Label LSubtituloAcciones;
        private System.Windows.Forms.Panel PContenedorBotones;
        private System.Windows.Forms.Button BAbrirTurno;
        private System.Windows.Forms.Button BMovimientoMenor;
        private System.Windows.Forms.Button BCerrarTurno;
    }
}