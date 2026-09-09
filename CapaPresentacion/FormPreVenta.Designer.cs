using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace CapaPresentacion
{
    partial class FormPreVenta
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
            this.DGVDetalle = new System.Windows.Forms.DataGridView();
            this.ColIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStockDisp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.PBotonesVenta = new System.Windows.Forms.Panel();
            this.BCancelarVenta = new System.Windows.Forms.Button();
            this.BGuardarPresupuesto = new System.Windows.Forms.Button();
            this.BEnviarACaja = new System.Windows.Forms.Button();
            this.PContenedorTotales = new System.Windows.Forms.Panel();
            this.LTotalMonto = new System.Windows.Forms.Label();
            this.LTituloTotal = new System.Windows.Forms.Label();
            this.PLineaDivisoria = new System.Windows.Forms.Panel();
            this.LItemsCantidad = new System.Windows.Forms.Label();
            this.LTituloItems = new System.Windows.Forms.Label();
            this.LSubtotalMonto = new System.Windows.Forms.Label();
            this.LTituloSubtotal = new System.Windows.Forms.Label();
            this.POpcionesVenta = new System.Windows.Forms.Panel();
            this.RBPremioMayorista = new System.Windows.Forms.RadioButton();
            this.RBPremioMinorista = new System.Windows.Forms.RadioButton();
            this.LTituloListaPrecio = new System.Windows.Forms.Label();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.PBarraArticulo = new System.Windows.Forms.Panel();
            this.BAgregarItem = new System.Windows.Forms.Button();
            this.NUDCantidad = new System.Windows.Forms.NumericUpDown();
            this.LCantidad = new System.Windows.Forms.Label();
            this.TBBuscarArticulo = new System.Windows.Forms.TextBox();
            this.LBuscarArticulo = new System.Windows.Forms.Label();
            this.CBClientes = new System.Windows.Forms.ComboBox();
            this.LCliente = new System.Windows.Forms.Label();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.PBotonesVenta.SuspendLayout();
            this.PContenedorTotales.SuspendLayout();
            this.POpcionesVenta.SuspendLayout();
            this.PBarraArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).BeginInit();
            this.PEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoTitulo)).BeginInit();
            this.SuspendLayout();
            // 
            // PFondo
            // 
            this.PFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.PFondo.Controls.Add(this.TLPContenido);
            this.PFondo.Controls.Add(this.PBarraArticulo);
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
            this.TLPContenido.Controls.Add(this.DGVDetalle, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(21, 113);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1492, 694);
            this.TLPContenido.TabIndex = 0;
            // 
            // DGVDetalle
            // 
            this.DGVDetalle.AllowUserToAddRows = false;
            this.DGVDetalle.AllowUserToDeleteRows = false;
            this.DGVDetalle.AllowUserToResizeColumns = false;
            this.DGVDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DGVDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVDetalle.BackgroundColor = System.Drawing.Color.White;
            this.DGVDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DGVDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVDetalle.ColumnHeadersHeight = 34;
            this.DGVDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdProducto,
            this.ColCodigo,
            this.ColDescripcion,
            this.ColStockDisp,
            this.ColCantidad,
            this.ColPrecioUnit,
            this.ColSubtotal,
            this.ColEliminar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVDetalle.EnableHeadersVisualStyles = false;
            this.DGVDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.DGVDetalle.Location = new System.Drawing.Point(0, 10);
            this.DGVDetalle.Margin = new System.Windows.Forms.Padding(0, 10, 14, 0);
            this.DGVDetalle.MultiSelect = false;
            this.DGVDetalle.Name = "DGVDetalle";
            this.DGVDetalle.ReadOnly = true;
            this.DGVDetalle.RowHeadersVisible = false;
            this.DGVDetalle.RowHeadersWidth = 51;
            this.DGVDetalle.RowTemplate.Height = 30;
            this.DGVDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVDetalle.Size = new System.Drawing.Size(1060, 684);
            this.DGVDetalle.TabIndex = 0;
            this.DGVDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVDetalle_CellClick);
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
            // 
            // ColDescripcion
            // 
            this.ColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDescripcion.HeaderText = "Descripción del Insumo";
            this.ColDescripcion.MinimumWidth = 6;
            this.ColDescripcion.Name = "ColDescripcion";
            this.ColDescripcion.ReadOnly = true;
            // 
            // ColStockDisp
            // 
            this.ColStockDisp.HeaderText = "Stock";
            this.ColStockDisp.MinimumWidth = 6;
            this.ColStockDisp.Name = "ColStockDisp";
            this.ColStockDisp.ReadOnly = true;
            this.ColStockDisp.Width = 70;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "Cant.";
            this.ColCantidad.MinimumWidth = 6;
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            this.ColCantidad.Width = 80;
            // 
            // ColPrecioUnit
            // 
            this.ColPrecioUnit.HeaderText = "Precio Unit. ($)";
            this.ColPrecioUnit.MinimumWidth = 6;
            this.ColPrecioUnit.Name = "ColPrecioUnit";
            this.ColPrecioUnit.ReadOnly = true;
            this.ColPrecioUnit.Width = 130;
            // 
            // ColSubtotal
            // 
            this.ColSubtotal.HeaderText = "Subtotal ($)";
            this.ColSubtotal.MinimumWidth = 6;
            this.ColSubtotal.Name = "ColSubtotal";
            this.ColSubtotal.ReadOnly = true;
            this.ColSubtotal.Width = 135;
            // 
            // ColEliminar
            // 
            this.ColEliminar.HeaderText = "Quitar";
            this.ColEliminar.MinimumWidth = 6;
            this.ColEliminar.Name = "ColEliminar";
            this.ColEliminar.ReadOnly = true;
            this.ColEliminar.Text = "✕";
            this.ColEliminar.UseColumnTextForButtonValue = true;
            this.ColEliminar.Width = 65;
            // 
            // PTarjetaLateral
            // 
            this.PTarjetaLateral.BackColor = System.Drawing.Color.White;
            this.PTarjetaLateral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PTarjetaLateral.Controls.Add(this.PBotonesVenta);
            this.PTarjetaLateral.Controls.Add(this.PContenedorTotales);
            this.PTarjetaLateral.Controls.Add(this.POpcionesVenta);
            this.PTarjetaLateral.Controls.Add(this.LSubtituloTarjeta);
            this.PTarjetaLateral.Controls.Add(this.LTituloTarjeta);
            this.PTarjetaLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PTarjetaLateral.Location = new System.Drawing.Point(1074, 10);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(14);
            this.PTarjetaLateral.Size = new System.Drawing.Size(418, 684);
            this.PTarjetaLateral.TabIndex = 1;
            // 
            // PBotonesVenta
            // 
            this.PBotonesVenta.Controls.Add(this.BCancelarVenta);
            this.PBotonesVenta.Controls.Add(this.BGuardarPresupuesto);
            this.PBotonesVenta.Controls.Add(this.BEnviarACaja);
            this.PBotonesVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesVenta.Location = new System.Drawing.Point(14, 492);
            this.PBotonesVenta.Name = "PBotonesVenta";
            this.PBotonesVenta.Size = new System.Drawing.Size(388, 176);
            this.PBotonesVenta.TabIndex = 4;
            // 
            // BCancelarVenta
            // 
            this.BCancelarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BCancelarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCancelarVenta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCancelarVenta.FlatAppearance.BorderSize = 0;
            this.BCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelarVenta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BCancelarVenta.ForeColor = System.Drawing.Color.White;
            this.BCancelarVenta.Location = new System.Drawing.Point(0, 124);
            this.BCancelarVenta.Name = "BCancelarVenta";
            this.BCancelarVenta.Size = new System.Drawing.Size(388, 52);
            this.BCancelarVenta.TabIndex = 2;
            this.BCancelarVenta.Text = "🧹 Limpiar Operación";
            this.BCancelarVenta.UseVisualStyleBackColor = false;
            this.BCancelarVenta.Click += new System.EventHandler(this.BCancelarVenta_Click);
            // 
            // BGuardarPresupuesto
            // 
            this.BGuardarPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.BGuardarPresupuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardarPresupuesto.Dock = System.Windows.Forms.DockStyle.Top;
            this.BGuardarPresupuesto.FlatAppearance.BorderSize = 0;
            this.BGuardarPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarPresupuesto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BGuardarPresupuesto.ForeColor = System.Drawing.Color.White;
            this.BGuardarPresupuesto.Location = new System.Drawing.Point(0, 52);
            this.BGuardarPresupuesto.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.BGuardarPresupuesto.Name = "BGuardarPresupuesto";
            this.BGuardarPresupuesto.Size = new System.Drawing.Size(388, 52);
            this.BGuardarPresupuesto.TabIndex = 1;
            this.BGuardarPresupuesto.Text = "📄 Imprimir Presupuesto";
            this.BGuardarPresupuesto.UseVisualStyleBackColor = false;
            this.BGuardarPresupuesto.Click += new System.EventHandler(this.BGuardarPresupuesto_Click);
            // 
            // BEnviarACaja
            // 
            this.BEnviarACaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BEnviarACaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEnviarACaja.Dock = System.Windows.Forms.DockStyle.Top;
            this.BEnviarACaja.FlatAppearance.BorderSize = 0;
            this.BEnviarACaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEnviarACaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BEnviarACaja.ForeColor = System.Drawing.Color.White;
            this.BEnviarACaja.Location = new System.Drawing.Point(0, 0);
            this.BEnviarACaja.Name = "BEnviarACaja";
            this.BEnviarACaja.Size = new System.Drawing.Size(388, 52);
            this.BEnviarACaja.TabIndex = 0;
            this.BEnviarACaja.Text = "✔ Enviar Pedido a Caja";
            this.BEnviarACaja.UseVisualStyleBackColor = false;
            this.BEnviarACaja.Click += new System.EventHandler(this.BEnviarACaja_Click);
            // 
            // PContenedorTotales
            // 
            this.PContenedorTotales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.PContenedorTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PContenedorTotales.Controls.Add(this.LTotalMonto);
            this.PContenedorTotales.Controls.Add(this.LTituloTotal);
            this.PContenedorTotales.Controls.Add(this.PLineaDivisoria);
            this.PContenedorTotales.Controls.Add(this.LItemsCantidad);
            this.PContenedorTotales.Controls.Add(this.LTituloItems);
            this.PContenedorTotales.Controls.Add(this.LSubtotalMonto);
            this.PContenedorTotales.Controls.Add(this.LTituloSubtotal);
            this.PContenedorTotales.Dock = System.Windows.Forms.DockStyle.Top;
            this.PContenedorTotales.Location = new System.Drawing.Point(14, 122);
            this.PContenedorTotales.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.PContenedorTotales.Name = "PContenedorTotales";
            this.PContenedorTotales.Padding = new System.Windows.Forms.Padding(12);
            this.PContenedorTotales.Size = new System.Drawing.Size(388, 160);
            this.PContenedorTotales.TabIndex = 3;
            // 
            // LTotalMonto
            // 
            this.LTotalMonto.AutoSize = true;
            this.LTotalMonto.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.LTotalMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTotalMonto.Location = new System.Drawing.Point(10, 105);
            this.LTotalMonto.Name = "LTotalMonto";
            this.LTotalMonto.Size = new System.Drawing.Size(102, 41);
            this.LTotalMonto.TabIndex = 6;
            this.LTotalMonto.Text = "$ 0,00";
            // 
            // LTituloTotal
            // 
            this.LTituloTotal.AutoSize = true;
            this.LTituloTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LTituloTotal.Location = new System.Drawing.Point(12, 80);
            this.LTituloTotal.Name = "LTituloTotal";
            this.LTituloTotal.Size = new System.Drawing.Size(144, 23);
            this.LTituloTotal.TabIndex = 5;
            this.LTituloTotal.Text = "TOTAL A PAGAR:";
            // 
            // PLineaDivisoria
            // 
            this.PLineaDivisoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.PLineaDivisoria.Location = new System.Drawing.Point(12, 68);
            this.PLineaDivisoria.Name = "PLineaDivisoria";
            this.PLineaDivisoria.Size = new System.Drawing.Size(360, 1);
            this.PLineaDivisoria.TabIndex = 4;
            // 
            // LItemsCantidad
            // 
            this.LItemsCantidad.AutoSize = true;
            this.LItemsCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.LItemsCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LItemsCantidad.Location = new System.Drawing.Point(144, 10);
            this.LItemsCantidad.Name = "LItemsCantidad";
            this.LItemsCantidad.Size = new System.Drawing.Size(65, 21);
            this.LItemsCantidad.TabIndex = 1;
            this.LItemsCantidad.Text = "0 ítems";
            // 
            // LTituloItems
            // 
            this.LTituloItems.AutoSize = true;
            this.LTituloItems.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTituloItems.ForeColor = System.Drawing.Color.Gray;
            this.LTituloItems.Location = new System.Drawing.Point(12, 12);
            this.LTituloItems.Name = "LTituloItems";
            this.LTituloItems.Size = new System.Drawing.Size(130, 20);
            this.LTituloItems.TabIndex = 0;
            this.LTituloItems.Text = "Artículos Totales:";
            // 
            // LSubtotalMonto
            // 
            this.LSubtotalMonto.AutoSize = true;
            this.LSubtotalMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.LSubtotalMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LSubtotalMonto.Location = new System.Drawing.Point(144, 36);
            this.LSubtotalMonto.Name = "LSubtotalMonto";
            this.LSubtotalMonto.Size = new System.Drawing.Size(54, 21);
            this.LSubtotalMonto.TabIndex = 3;
            this.LSubtotalMonto.Text = "$ 0,00";
            // 
            // LTituloSubtotal
            // 
            this.LTituloSubtotal.AutoSize = true;
            this.LTituloSubtotal.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LTituloSubtotal.ForeColor = System.Drawing.Color.Gray;
            this.LTituloSubtotal.Location = new System.Drawing.Point(12, 38);
            this.LTituloSubtotal.Name = "LTituloSubtotal";
            this.LTituloSubtotal.Size = new System.Drawing.Size(72, 20);
            this.LTituloSubtotal.TabIndex = 2;
            this.LTituloSubtotal.Text = "Subtotal:";
            // 
            // POpcionesVenta
            // 
            this.POpcionesVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.POpcionesVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.POpcionesVenta.Controls.Add(this.RBPremioMayorista);
            this.POpcionesVenta.Controls.Add(this.RBPremioMinorista);
            this.POpcionesVenta.Controls.Add(this.LTituloListaPrecio);
            this.POpcionesVenta.Dock = System.Windows.Forms.DockStyle.Top;
            this.POpcionesVenta.Location = new System.Drawing.Point(14, 58);
            this.POpcionesVenta.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.POpcionesVenta.Name = "POpcionesVenta";
            this.POpcionesVenta.Padding = new System.Windows.Forms.Padding(8);
            this.POpcionesVenta.Size = new System.Drawing.Size(388, 64);
            this.POpcionesVenta.TabIndex = 2;
            // 
            // RBPremioMayorista
            // 
            this.RBPremioMayorista.AutoSize = true;
            this.RBPremioMayorista.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.RBPremioMayorista.Location = new System.Drawing.Point(135, 30);
            this.RBPremioMayorista.Name = "RBPremioMayorista";
            this.RBPremioMayorista.Size = new System.Drawing.Size(95, 24);
            this.RBPremioMayorista.TabIndex = 2;
            this.RBPremioMayorista.Text = "Mayorista";
            this.RBPremioMayorista.UseVisualStyleBackColor = true;
            this.RBPremioMayorista.CheckedChanged += new System.EventHandler(this.TipoPrecio_CheckedChanged);
            // 
            // RBPremioMinorista
            // 
            this.RBPremioMinorista.AutoSize = true;
            this.RBPremioMinorista.Checked = true;
            this.RBPremioMinorista.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.RBPremioMinorista.Location = new System.Drawing.Point(14, 30);
            this.RBPremioMinorista.Name = "RBPremioMinorista";
            this.RBPremioMinorista.Size = new System.Drawing.Size(92, 24);
            this.RBPremioMinorista.TabIndex = 1;
            this.RBPremioMinorista.TabStop = true;
            this.RBPremioMinorista.Text = "Minorista";
            this.RBPremioMinorista.UseVisualStyleBackColor = true;
            this.RBPremioMinorista.CheckedChanged += new System.EventHandler(this.TipoPrecio_CheckedChanged);
            // 
            // LTituloListaPrecio
            // 
            this.LTituloListaPrecio.AutoSize = true;
            this.LTituloListaPrecio.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTituloListaPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LTituloListaPrecio.Location = new System.Drawing.Point(10, 8);
            this.LTituloListaPrecio.Name = "LTituloListaPrecio";
            this.LTituloListaPrecio.Size = new System.Drawing.Size(117, 19);
            this.LTituloListaPrecio.TabIndex = 0;
            this.LTituloListaPrecio.Text = "Lista de Precios:";
            // 
            // LSubtituloTarjeta
            // 
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(14, 38);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(388, 20);
            this.LSubtituloTarjeta.TabIndex = 1;
            this.LSubtituloTarjeta.Text = "Presupuestos y tickets de mostrador";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloTarjeta.Location = new System.Drawing.Point(14, 14);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(388, 24);
            this.LTituloTarjeta.TabIndex = 0;
            this.LTituloTarjeta.Text = "RESUMEN DE OPERACIÓN";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBarraArticulo
            // 
            this.PBarraArticulo.BackColor = System.Drawing.Color.White;
            this.PBarraArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PBarraArticulo.Controls.Add(this.BAgregarItem);
            this.PBarraArticulo.Controls.Add(this.NUDCantidad);
            this.PBarraArticulo.Controls.Add(this.LCantidad);
            this.PBarraArticulo.Controls.Add(this.TBBuscarArticulo);
            this.PBarraArticulo.Controls.Add(this.LBuscarArticulo);
            this.PBarraArticulo.Controls.Add(this.CBClientes);
            this.PBarraArticulo.Controls.Add(this.LCliente);
            this.PBarraArticulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraArticulo.Location = new System.Drawing.Point(21, 53);
            this.PBarraArticulo.Name = "PBarraArticulo";
            this.PBarraArticulo.Size = new System.Drawing.Size(1492, 60);
            this.PBarraArticulo.TabIndex = 1;
            // 
            // BAgregarItem
            // 
            this.BAgregarItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BAgregarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BAgregarItem.FlatAppearance.BorderSize = 0;
            this.BAgregarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAgregarItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BAgregarItem.ForeColor = System.Drawing.Color.White;
            this.BAgregarItem.Location = new System.Drawing.Point(1065, 12);
            this.BAgregarItem.Name = "BAgregarItem";
            this.BAgregarItem.Size = new System.Drawing.Size(130, 33);
            this.BAgregarItem.TabIndex = 3;
            this.BAgregarItem.Text = "➕ Agregar";
            this.BAgregarItem.UseVisualStyleBackColor = false;
            this.BAgregarItem.Click += new System.EventHandler(this.BAgregarItem_Click);
            // 
            // NUDCantidad
            // 
            this.NUDCantidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.NUDCantidad.Location = new System.Drawing.Point(967, 15);
            this.NUDCantidad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDCantidad.Name = "NUDCantidad";
            this.NUDCantidad.Size = new System.Drawing.Size(75, 29);
            this.NUDCantidad.TabIndex = 2;
            this.NUDCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUDCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LCantidad
            // 
            this.LCantidad.AutoSize = true;
            this.LCantidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LCantidad.Location = new System.Drawing.Point(915, 19);
            this.LCantidad.Name = "LCantidad";
            this.LCantidad.Size = new System.Drawing.Size(45, 20);
            this.LCantidad.TabIndex = 2;
            this.LCantidad.Text = "Cant:";
            // 
            // TBBuscarArticulo
            // 
            this.TBBuscarArticulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.TBBuscarArticulo.Location = new System.Drawing.Point(546, 15);
            this.TBBuscarArticulo.Name = "TBBuscarArticulo";
            this.TBBuscarArticulo.Size = new System.Drawing.Size(340, 29);
            this.TBBuscarArticulo.TabIndex = 1;
            // 
            // LBuscarArticulo
            // 
            this.LBuscarArticulo.AutoSize = true;
            this.LBuscarArticulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LBuscarArticulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LBuscarArticulo.Location = new System.Drawing.Point(370, 19);
            this.LBuscarArticulo.Name = "LBuscarArticulo";
            this.LBuscarArticulo.Size = new System.Drawing.Size(163, 20);
            this.LBuscarArticulo.TabIndex = 1;
            this.LBuscarArticulo.Text = "Buscar Insumo / Cód.:";
            // 
            // CBClientes
            // 
            this.CBClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBClientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.CBClientes.Location = new System.Drawing.Point(82, 15);
            this.CBClientes.Name = "CBClientes";
            this.CBClientes.Size = new System.Drawing.Size(260, 29);
            this.CBClientes.TabIndex = 0;
            // 
            // LCliente
            // 
            this.LCliente.AutoSize = true;
            this.LCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.LCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LCliente.Location = new System.Drawing.Point(14, 19);
            this.LCliente.Name = "LCliente";
            this.LCliente.Size = new System.Drawing.Size(61, 20);
            this.LCliente.TabIndex = 0;
            this.LCliente.Text = "Cliente:";
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
            this.LTituloPrincipal.Size = new System.Drawing.Size(353, 28);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "PREVENTA Y ATENCIÓN A CLIENTES";
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
            // FormPreVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1534, 822);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPreVenta";
            this.Text = "PreVenta";
            this.Load += new System.EventHandler(this.FormPreVenta_Load);
            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetalle)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.PBotonesVenta.ResumeLayout(false);
            this.PContenedorTotales.ResumeLayout(false);
            this.PContenedorTotales.PerformLayout();
            this.POpcionesVenta.ResumeLayout(false);
            this.POpcionesVenta.PerformLayout();
            this.PBarraArticulo.ResumeLayout(false);
            this.PBarraArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDCantidad)).EndInit();
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
            private System.Windows.Forms.Panel PBarraArticulo;
            private System.Windows.Forms.Label LCliente;
            private System.Windows.Forms.ComboBox CBClientes;
            private System.Windows.Forms.Label LBuscarArticulo;
            private System.Windows.Forms.TextBox TBBuscarArticulo;
            private System.Windows.Forms.Label LCantidad;
            private System.Windows.Forms.NumericUpDown NUDCantidad;
            private System.Windows.Forms.Button BAgregarItem;
            private System.Windows.Forms.TableLayoutPanel TLPContenido;
            private System.Windows.Forms.DataGridView DGVDetalle;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColIdProducto;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColCodigo;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColDescripcion;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColStockDisp;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecioUnit;
            private System.Windows.Forms.DataGridViewTextBoxColumn ColSubtotal;
            private System.Windows.Forms.DataGridViewButtonColumn ColEliminar;
            private System.Windows.Forms.Panel PTarjetaLateral;
            private System.Windows.Forms.Label LTituloTarjeta;
            private System.Windows.Forms.Label LSubtituloTarjeta;
            private System.Windows.Forms.Panel POpcionesVenta;
            private System.Windows.Forms.Label LTituloListaPrecio;
            private System.Windows.Forms.RadioButton RBPremioMinorista;
            private System.Windows.Forms.RadioButton RBPremioMayorista;
            private System.Windows.Forms.Panel PContenedorTotales;
            private System.Windows.Forms.Label LTituloItems;
            private System.Windows.Forms.Label LItemsCantidad;
            private System.Windows.Forms.Label LTituloSubtotal;
            private System.Windows.Forms.Label LSubtotalMonto;
            private System.Windows.Forms.Panel PLineaDivisoria;
            private System.Windows.Forms.Label LTituloTotal;
            private System.Windows.Forms.Label LTotalMonto;
            private System.Windows.Forms.Panel PBotonesVenta;
            private System.Windows.Forms.Button BEnviarACaja;
            private System.Windows.Forms.Button BGuardarPresupuesto;
            private System.Windows.Forms.Button BCancelarVenta;
        }
}