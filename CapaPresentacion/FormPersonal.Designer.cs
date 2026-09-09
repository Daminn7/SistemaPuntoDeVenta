namespace CapaPresentacion
{
    partial class FormPersonal
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
            this.DGVPersonal = new System.Windows.Forms.DataGridView();
            this.ColIdUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCuil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTarjetaLateral = new System.Windows.Forms.Panel();
            this.TLPFormularioEdicion = new System.Windows.Forms.TableLayoutPanel();
            this.PGrupoDni = new System.Windows.Forms.Panel();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.LDni = new System.Windows.Forms.Label();
            this.PGrupoCuil = new System.Windows.Forms.Panel();
            this.TBCuil = new System.Windows.Forms.TextBox();
            this.LCuil = new System.Windows.Forms.Label();
            this.PGrupoNombre = new System.Windows.Forms.Panel();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LNombre = new System.Windows.Forms.Label();
            this.PGrupoApellido = new System.Windows.Forms.Panel();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.LApellido = new System.Windows.Forms.Label();
            this.PGrupoTelefono = new System.Windows.Forms.Panel();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.PGrupoEmail = new System.Windows.Forms.Panel();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.LSubtituloCredenciales = new System.Windows.Forms.Label();
            this.PGrupoRol = new System.Windows.Forms.Panel();
            this.CBRol = new System.Windows.Forms.ComboBox();
            this.LRol = new System.Windows.Forms.Label();
            this.PGrupoUsuario = new System.Windows.Forms.Panel();
            this.TBUsuario = new System.Windows.Forms.TextBox();
            this.LUsuario = new System.Windows.Forms.Label();
            this.PGrupoPassword = new System.Windows.Forms.Panel();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.LPassword = new System.Windows.Forms.Label();
            this.PHabilitado = new System.Windows.Forms.Panel();
            this.ChBUsuarioHabilitado = new System.Windows.Forms.CheckBox();
            this.PBotonesAccion = new System.Windows.Forms.Panel();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.TLPBotonesMed = new System.Windows.Forms.TableLayoutPanel();
            this.BEditar = new System.Windows.Forms.Button();
            this.BDesactivar = new System.Windows.Forms.Button();
            this.TPLBotonesSup = new System.Windows.Forms.TableLayoutPanel();
            this.BNuevo = new System.Windows.Forms.Button();
            this.BGuardar = new System.Windows.Forms.Button();
            this.LSubtituloTarjeta = new System.Windows.Forms.Label();
            this.LTituloTarjeta = new System.Windows.Forms.Label();
            this.PBarraFiltros = new System.Windows.Forms.Panel();
            this.LBuscar = new System.Windows.Forms.Label();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.LFiltroRol = new System.Windows.Forms.Label();
            this.CBFiltroRol = new System.Windows.Forms.ComboBox();
            this.BLimpiarFiltros = new System.Windows.Forms.Button();
            this.PEncabezado = new System.Windows.Forms.Panel();
            this.LTituloPrincipal = new System.Windows.Forms.Label();
            this.PBIconoTitulo = new System.Windows.Forms.PictureBox();
            this.PFondo.SuspendLayout();
            this.TLPContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPersonal)).BeginInit();
            this.PTarjetaLateral.SuspendLayout();
            this.TLPFormularioEdicion.SuspendLayout();
            this.PGrupoDni.SuspendLayout();
            this.PGrupoCuil.SuspendLayout();
            this.PGrupoNombre.SuspendLayout();
            this.PGrupoApellido.SuspendLayout();
            this.PGrupoTelefono.SuspendLayout();
            this.PGrupoEmail.SuspendLayout();
            this.PGrupoRol.SuspendLayout();
            this.PGrupoUsuario.SuspendLayout();
            this.PGrupoPassword.SuspendLayout();
            this.PHabilitado.SuspendLayout();
            this.PBotonesAccion.SuspendLayout();
            this.TLPBotonesMed.SuspendLayout();
            this.TPLBotonesSup.SuspendLayout();
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
            this.PFondo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PFondo.Name = "PFondo";
            this.PFondo.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.PFondo.Size = new System.Drawing.Size(1040, 640);
            this.PFondo.TabIndex = 0;
            // 
            // TLPContenido
            // 
            this.TLPContenido.ColumnCount = 2;
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.TLPContenido.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.TLPContenido.Controls.Add(this.DGVPersonal, 0, 0);
            this.TLPContenido.Controls.Add(this.PTarjetaLateral, 1, 0);
            this.TLPContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPContenido.Location = new System.Drawing.Point(16, 81);
            this.TLPContenido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPContenido.Name = "TLPContenido";
            this.TLPContenido.RowCount = 1;
            this.TLPContenido.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPContenido.Size = new System.Drawing.Size(1008, 547);
            this.TLPContenido.TabIndex = 0;
            // 
            // DGVPersonal
            // 
            this.DGVPersonal.AllowUserToAddRows = false;
            this.DGVPersonal.AllowUserToDeleteRows = false;
            this.DGVPersonal.AllowUserToResizeColumns = false;
            this.DGVPersonal.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DGVPersonal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPersonal.BackgroundColor = System.Drawing.Color.White;
            this.DGVPersonal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.DGVPersonal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPersonal.ColumnHeadersHeight = 32;
            this.DGVPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPersonal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdUsuario,
            this.ColDni,
            this.ColCuil,
            this.ColNombreCompleto,
            this.ColRol,
            this.ColTelefono,
            this.ColEmail,
            this.ColEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVPersonal.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPersonal.EnableHeadersVisualStyles = false;
            this.DGVPersonal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(233)))), ((int)(((byte)(238)))));
            this.DGVPersonal.Location = new System.Drawing.Point(0, 5);
            this.DGVPersonal.Margin = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.DGVPersonal.MultiSelect = false;
            this.DGVPersonal.Name = "DGVPersonal";
            this.DGVPersonal.ReadOnly = true;
            this.DGVPersonal.RowHeadersVisible = false;
            this.DGVPersonal.RowHeadersWidth = 51;
            this.DGVPersonal.RowTemplate.Height = 28;
            this.DGVPersonal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPersonal.Size = new System.Drawing.Size(715, 542);
            this.DGVPersonal.TabIndex = 0;
            this.DGVPersonal.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPersonal_CellClick);
            // 
            // ColIdUsuario
            // 
            this.ColIdUsuario.HeaderText = "ID";
            this.ColIdUsuario.Name = "ColIdUsuario";
            this.ColIdUsuario.ReadOnly = true;
            this.ColIdUsuario.Visible = false;
            // 
            // ColDni
            // 
            this.ColDni.HeaderText = "DNI";
            this.ColDni.Name = "ColDni";
            this.ColDni.ReadOnly = true;
            this.ColDni.Width = 90;
            // 
            // ColCuil
            // 
            this.ColCuil.HeaderText = "CUIL";
            this.ColCuil.Name = "ColCuil";
            this.ColCuil.ReadOnly = true;
            this.ColCuil.Width = 110;
            // 
            // ColNombreCompleto
            // 
            this.ColNombreCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColNombreCompleto.HeaderText = "Nombre y Apellido";
            this.ColNombreCompleto.Name = "ColNombreCompleto";
            this.ColNombreCompleto.ReadOnly = true;
            // 
            // ColRol
            // 
            this.ColRol.HeaderText = "Rol / Perfil";
            this.ColRol.Name = "ColRol";
            this.ColRol.ReadOnly = true;
            this.ColRol.Width = 140;
            // 
            // ColTelefono
            // 
            this.ColTelefono.HeaderText = "Teléfono";
            this.ColTelefono.Name = "ColTelefono";
            this.ColTelefono.ReadOnly = true;
            this.ColTelefono.Width = 120;
            // 
            // ColEmail
            // 
            this.ColEmail.HeaderText = "Correo Electrónico";
            this.ColEmail.Name = "ColEmail";
            this.ColEmail.ReadOnly = true;
            this.ColEmail.Width = 170;
            // 
            // ColEstado
            // 
            this.ColEstado.HeaderText = "Estado";
            this.ColEstado.Name = "ColEstado";
            this.ColEstado.ReadOnly = true;
            this.ColEstado.Width = 95;
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
            this.PTarjetaLateral.Location = new System.Drawing.Point(725, 5);
            this.PTarjetaLateral.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PTarjetaLateral.Name = "PTarjetaLateral";
            this.PTarjetaLateral.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.PTarjetaLateral.Size = new System.Drawing.Size(283, 542);
            this.PTarjetaLateral.TabIndex = 1;
            // 
            // TLPFormularioEdicion
            // 
            this.TLPFormularioEdicion.ColumnCount = 2;
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoDni, 0, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoCuil, 1, 0);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoNombre, 0, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoApellido, 1, 1);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoTelefono, 0, 2);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoEmail, 1, 2);
            this.TLPFormularioEdicion.Controls.Add(this.LSubtituloCredenciales, 0, 3);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoRol, 0, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoUsuario, 1, 4);
            this.TLPFormularioEdicion.Controls.Add(this.PGrupoPassword, 0, 5);
            this.TLPFormularioEdicion.Controls.Add(this.PHabilitado, 0, 6);
            this.TLPFormularioEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPFormularioEdicion.Location = new System.Drawing.Point(10, 45);
            this.TLPFormularioEdicion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPFormularioEdicion.Name = "TLPFormularioEdicion";
            this.TLPFormularioEdicion.RowCount = 7;
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.TLPFormularioEdicion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPFormularioEdicion.Size = new System.Drawing.Size(261, 343);
            this.TLPFormularioEdicion.TabIndex = 0;
            // 
            // PGrupoDni
            // 
            this.PGrupoDni.Controls.Add(this.TBDni);
            this.PGrupoDni.Controls.Add(this.LDni);
            this.PGrupoDni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoDni.Location = new System.Drawing.Point(0, 0);
            this.PGrupoDni.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.PGrupoDni.Name = "PGrupoDni";
            this.PGrupoDni.Size = new System.Drawing.Size(128, 39);
            this.PGrupoDni.TabIndex = 0;
            // 
            // TBDni
            // 
            this.TBDni.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBDni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBDni.Location = new System.Drawing.Point(0, 16);
            this.TBDni.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(128, 23);
            this.TBDni.TabIndex = 0;
            // 
            // LDni
            // 
            this.LDni.Dock = System.Windows.Forms.DockStyle.Top;
            this.LDni.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LDni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LDni.Location = new System.Drawing.Point(0, 0);
            this.LDni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(128, 18);
            this.LDni.TabIndex = 1;
            this.LDni.Text = "DNI:";
            // 
            // PGrupoCuil
            // 
            this.PGrupoCuil.Controls.Add(this.TBCuil);
            this.PGrupoCuil.Controls.Add(this.LCuil);
            this.PGrupoCuil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoCuil.Location = new System.Drawing.Point(132, 0);
            this.PGrupoCuil.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.PGrupoCuil.Name = "PGrupoCuil";
            this.PGrupoCuil.Size = new System.Drawing.Size(129, 39);
            this.PGrupoCuil.TabIndex = 1;
            // 
            // TBCuil
            // 
            this.TBCuil.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBCuil.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBCuil.Location = new System.Drawing.Point(0, 16);
            this.TBCuil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBCuil.Name = "TBCuil";
            this.TBCuil.Size = new System.Drawing.Size(129, 23);
            this.TBCuil.TabIndex = 0;
            // 
            // LCuil
            // 
            this.LCuil.Dock = System.Windows.Forms.DockStyle.Top;
            this.LCuil.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LCuil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LCuil.Location = new System.Drawing.Point(0, 0);
            this.LCuil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LCuil.Name = "LCuil";
            this.LCuil.Size = new System.Drawing.Size(129, 18);
            this.LCuil.TabIndex = 1;
            this.LCuil.Text = "CUIL:";
            // 
            // PGrupoNombre
            // 
            this.PGrupoNombre.Controls.Add(this.TBNombre);
            this.PGrupoNombre.Controls.Add(this.LNombre);
            this.PGrupoNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoNombre.Location = new System.Drawing.Point(0, 41);
            this.PGrupoNombre.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.PGrupoNombre.Name = "PGrupoNombre";
            this.PGrupoNombre.Size = new System.Drawing.Size(128, 39);
            this.PGrupoNombre.TabIndex = 2;
            // 
            // TBNombre
            // 
            this.TBNombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBNombre.Location = new System.Drawing.Point(0, 16);
            this.TBNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(128, 23);
            this.TBNombre.TabIndex = 0;
            // 
            // LNombre
            // 
            this.LNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.LNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LNombre.Location = new System.Drawing.Point(0, 0);
            this.LNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(128, 18);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // PGrupoApellido
            // 
            this.PGrupoApellido.Controls.Add(this.TBApellido);
            this.PGrupoApellido.Controls.Add(this.LApellido);
            this.PGrupoApellido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoApellido.Location = new System.Drawing.Point(132, 41);
            this.PGrupoApellido.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.PGrupoApellido.Name = "PGrupoApellido";
            this.PGrupoApellido.Size = new System.Drawing.Size(129, 39);
            this.PGrupoApellido.TabIndex = 3;
            // 
            // TBApellido
            // 
            this.TBApellido.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBApellido.Location = new System.Drawing.Point(0, 16);
            this.TBApellido.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(129, 23);
            this.TBApellido.TabIndex = 0;
            // 
            // LApellido
            // 
            this.LApellido.Dock = System.Windows.Forms.DockStyle.Top;
            this.LApellido.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LApellido.Location = new System.Drawing.Point(0, 0);
            this.LApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(129, 18);
            this.LApellido.TabIndex = 1;
            this.LApellido.Text = "Apellido:";
            // 
            // PGrupoTelefono
            // 
            this.PGrupoTelefono.Controls.Add(this.TBTelefono);
            this.PGrupoTelefono.Controls.Add(this.LTelefono);
            this.PGrupoTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoTelefono.Location = new System.Drawing.Point(0, 82);
            this.PGrupoTelefono.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.PGrupoTelefono.Name = "PGrupoTelefono";
            this.PGrupoTelefono.Size = new System.Drawing.Size(128, 39);
            this.PGrupoTelefono.TabIndex = 4;
            // 
            // TBTelefono
            // 
            this.TBTelefono.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBTelefono.Location = new System.Drawing.Point(0, 16);
            this.TBTelefono.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(128, 23);
            this.TBTelefono.TabIndex = 0;
            // 
            // LTelefono
            // 
            this.LTelefono.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTelefono.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LTelefono.Location = new System.Drawing.Point(0, 0);
            this.LTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(128, 18);
            this.LTelefono.TabIndex = 1;
            this.LTelefono.Text = "Teléfono:";
            // 
            // PGrupoEmail
            // 
            this.PGrupoEmail.Controls.Add(this.TBEmail);
            this.PGrupoEmail.Controls.Add(this.LEmail);
            this.PGrupoEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoEmail.Location = new System.Drawing.Point(132, 82);
            this.PGrupoEmail.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.PGrupoEmail.Name = "PGrupoEmail";
            this.PGrupoEmail.Size = new System.Drawing.Size(129, 39);
            this.PGrupoEmail.TabIndex = 5;
            // 
            // TBEmail
            // 
            this.TBEmail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBEmail.Location = new System.Drawing.Point(0, 16);
            this.TBEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(129, 23);
            this.TBEmail.TabIndex = 0;
            // 
            // LEmail
            // 
            this.LEmail.Dock = System.Windows.Forms.DockStyle.Top;
            this.LEmail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LEmail.Location = new System.Drawing.Point(0, 0);
            this.LEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(129, 18);
            this.LEmail.TabIndex = 1;
            this.LEmail.Text = "Correo Electrónico:";
            // 
            // LSubtituloCredenciales
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.LSubtituloCredenciales, 2);
            this.LSubtituloCredenciales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LSubtituloCredenciales.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LSubtituloCredenciales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LSubtituloCredenciales.Location = new System.Drawing.Point(2, 123);
            this.LSubtituloCredenciales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LSubtituloCredenciales.Name = "LSubtituloCredenciales";
            this.LSubtituloCredenciales.Size = new System.Drawing.Size(257, 23);
            this.LSubtituloCredenciales.TabIndex = 6;
            this.LSubtituloCredenciales.Text = "SEGURIDAD Y ROL";
            this.LSubtituloCredenciales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PGrupoRol
            // 
            this.PGrupoRol.Controls.Add(this.CBRol);
            this.PGrupoRol.Controls.Add(this.LRol);
            this.PGrupoRol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoRol.Location = new System.Drawing.Point(0, 146);
            this.PGrupoRol.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.PGrupoRol.Name = "PGrupoRol";
            this.PGrupoRol.Size = new System.Drawing.Size(128, 39);
            this.PGrupoRol.TabIndex = 7;
            // 
            // CBRol
            // 
            this.CBRol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CBRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBRol.Location = new System.Drawing.Point(0, 16);
            this.CBRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBRol.Name = "CBRol";
            this.CBRol.Size = new System.Drawing.Size(128, 23);
            this.CBRol.TabIndex = 0;
            // 
            // LRol
            // 
            this.LRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.LRol.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LRol.Location = new System.Drawing.Point(0, 0);
            this.LRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LRol.Name = "LRol";
            this.LRol.Size = new System.Drawing.Size(128, 18);
            this.LRol.TabIndex = 1;
            this.LRol.Text = "Rol / Nivel de Acceso:";
            // 
            // PGrupoUsuario
            // 
            this.PGrupoUsuario.Controls.Add(this.TBUsuario);
            this.PGrupoUsuario.Controls.Add(this.LUsuario);
            this.PGrupoUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoUsuario.Location = new System.Drawing.Point(132, 146);
            this.PGrupoUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.PGrupoUsuario.Name = "PGrupoUsuario";
            this.PGrupoUsuario.Size = new System.Drawing.Size(129, 39);
            this.PGrupoUsuario.TabIndex = 8;
            // 
            // TBUsuario
            // 
            this.TBUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBUsuario.Location = new System.Drawing.Point(0, 16);
            this.TBUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBUsuario.Name = "TBUsuario";
            this.TBUsuario.Size = new System.Drawing.Size(129, 23);
            this.TBUsuario.TabIndex = 0;
            // 
            // LUsuario
            // 
            this.LUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.LUsuario.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LUsuario.Location = new System.Drawing.Point(0, 0);
            this.LUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(129, 18);
            this.LUsuario.TabIndex = 1;
            this.LUsuario.Text = "Usuario de Sistema:";
            // 
            // PGrupoPassword
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PGrupoPassword, 2);
            this.PGrupoPassword.Controls.Add(this.TBPassword);
            this.PGrupoPassword.Controls.Add(this.LPassword);
            this.PGrupoPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PGrupoPassword.Location = new System.Drawing.Point(0, 187);
            this.PGrupoPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.PGrupoPassword.Name = "PGrupoPassword";
            this.PGrupoPassword.Size = new System.Drawing.Size(261, 39);
            this.PGrupoPassword.TabIndex = 9;
            // 
            // TBPassword
            // 
            this.TBPassword.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TBPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBPassword.Location = new System.Drawing.Point(0, 16);
            this.TBPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '●';
            this.TBPassword.Size = new System.Drawing.Size(261, 23);
            this.TBPassword.TabIndex = 0;
            // 
            // LPassword
            // 
            this.LPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.LPassword.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.LPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.LPassword.Location = new System.Drawing.Point(0, 0);
            this.LPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LPassword.Name = "LPassword";
            this.LPassword.Size = new System.Drawing.Size(261, 18);
            this.LPassword.TabIndex = 1;
            this.LPassword.Text = "Contraseña (dejar en blanco para conservar):";
            // 
            // PHabilitado
            // 
            this.TLPFormularioEdicion.SetColumnSpan(this.PHabilitado, 2);
            this.PHabilitado.Controls.Add(this.ChBUsuarioHabilitado);
            this.PHabilitado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PHabilitado.Location = new System.Drawing.Point(2, 230);
            this.PHabilitado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PHabilitado.Name = "PHabilitado";
            this.PHabilitado.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.PHabilitado.Size = new System.Drawing.Size(257, 111);
            this.PHabilitado.TabIndex = 10;
            // 
            // ChBUsuarioHabilitado
            // 
            this.ChBUsuarioHabilitado.Checked = true;
            this.ChBUsuarioHabilitado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChBUsuarioHabilitado.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChBUsuarioHabilitado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.ChBUsuarioHabilitado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.ChBUsuarioHabilitado.Location = new System.Drawing.Point(0, 6);
            this.ChBUsuarioHabilitado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChBUsuarioHabilitado.Name = "ChBUsuarioHabilitado";
            this.ChBUsuarioHabilitado.Size = new System.Drawing.Size(257, 21);
            this.ChBUsuarioHabilitado.TabIndex = 0;
            this.ChBUsuarioHabilitado.Text = "Personal Habilitado (Activo)";
            // 
            // PBotonesAccion
            // 
            this.PBotonesAccion.Controls.Add(this.BLimpiar);
            this.PBotonesAccion.Controls.Add(this.TLPBotonesMed);
            this.PBotonesAccion.Controls.Add(this.TPLBotonesSup);
            this.PBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PBotonesAccion.Location = new System.Drawing.Point(10, 388);
            this.PBotonesAccion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PBotonesAccion.Name = "PBotonesAccion";
            this.PBotonesAccion.Size = new System.Drawing.Size(261, 143);
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
            this.BLimpiar.Location = new System.Drawing.Point(0, 90);
            this.BLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.BLimpiar.Size = new System.Drawing.Size(261, 42);
            this.BLimpiar.TabIndex = 0;
            this.BLimpiar.Text = "Limpiar Campos";
            this.BLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BLimpiar.UseVisualStyleBackColor = false;
            this.BLimpiar.Click += new System.EventHandler(this.BLimpiar_Click);
            // 
            // TLPBotonesMed
            // 
            this.TLPBotonesMed.ColumnCount = 2;
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPBotonesMed.Controls.Add(this.BEditar, 0, 0);
            this.TLPBotonesMed.Controls.Add(this.BDesactivar, 1, 0);
            this.TLPBotonesMed.Dock = System.Windows.Forms.DockStyle.Top;
            this.TLPBotonesMed.Location = new System.Drawing.Point(0, 45);
            this.TLPBotonesMed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TLPBotonesMed.Name = "TLPBotonesMed";
            this.TLPBotonesMed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPBotonesMed.Size = new System.Drawing.Size(261, 45);
            this.TLPBotonesMed.TabIndex = 1;
            // 
            // BEditar
            // 
            this.BEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BEditar.FlatAppearance.BorderSize = 0;
            this.BEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEditar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BEditar.ForeColor = System.Drawing.Color.White;
            this.BEditar.Location = new System.Drawing.Point(0, 0);
            this.BEditar.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.BEditar.Name = "BEditar";
            this.BEditar.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.BEditar.Size = new System.Drawing.Size(128, 43);
            this.BEditar.TabIndex = 0;
            this.BEditar.Text = "Editar";
            this.BEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BEditar.UseVisualStyleBackColor = false;
            this.BEditar.Click += new System.EventHandler(this.BEditar_Click);
            // 
            // BDesactivar
            // 
            this.BDesactivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.BDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BDesactivar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BDesactivar.FlatAppearance.BorderSize = 0;
            this.BDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BDesactivar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.BDesactivar.ForeColor = System.Drawing.Color.White;
            this.BDesactivar.Location = new System.Drawing.Point(132, 0);
            this.BDesactivar.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.BDesactivar.Name = "BDesactivar";
            this.BDesactivar.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.BDesactivar.Size = new System.Drawing.Size(129, 43);
            this.BDesactivar.TabIndex = 1;
            this.BDesactivar.Text = "Dar de Baja";
            this.BDesactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BDesactivar.UseVisualStyleBackColor = false;
            this.BDesactivar.Click += new System.EventHandler(this.BDesactivar_Click);
            // 
            // TPLBotonesSup
            // 
            this.TPLBotonesSup.ColumnCount = 2;
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPLBotonesSup.Controls.Add(this.BNuevo, 0, 0);
            this.TPLBotonesSup.Controls.Add(this.BGuardar, 1, 0);
            this.TPLBotonesSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.TPLBotonesSup.Location = new System.Drawing.Point(0, 0);
            this.TPLBotonesSup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TPLBotonesSup.Name = "TPLBotonesSup";
            this.TPLBotonesSup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TPLBotonesSup.Size = new System.Drawing.Size(261, 45);
            this.TPLBotonesSup.TabIndex = 2;
            // 
            // BNuevo
            // 
            this.BNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.BNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BNuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BNuevo.FlatAppearance.BorderSize = 0;
            this.BNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BNuevo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.BNuevo.ForeColor = System.Drawing.Color.White;
            this.BNuevo.Location = new System.Drawing.Point(0, 0);
            this.BNuevo.Margin = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.BNuevo.Name = "BNuevo";
            this.BNuevo.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.BNuevo.Size = new System.Drawing.Size(128, 43);
            this.BNuevo.TabIndex = 0;
            this.BNuevo.Text = "Nuevo";
            this.BNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BNuevo.UseVisualStyleBackColor = false;
            this.BNuevo.Click += new System.EventHandler(this.BNuevo_Click);
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
            this.BGuardar.Location = new System.Drawing.Point(132, 0);
            this.BGuardar.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.BGuardar.Name = "BGuardar";
            this.BGuardar.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.BGuardar.Size = new System.Drawing.Size(129, 43);
            this.BGuardar.TabIndex = 1;
            this.BGuardar.Text = "Guardar";
            this.BGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BGuardar.UseVisualStyleBackColor = false;
            this.BGuardar.Click += new System.EventHandler(this.BGuardar_Click);
            // 
            // LSubtituloTarjeta
            // 
            this.LSubtituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LSubtituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.LSubtituloTarjeta.ForeColor = System.Drawing.Color.Gray;
            this.LSubtituloTarjeta.Location = new System.Drawing.Point(10, 28);
            this.LSubtituloTarjeta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LSubtituloTarjeta.Name = "LSubtituloTarjeta";
            this.LSubtituloTarjeta.Size = new System.Drawing.Size(261, 17);
            this.LSubtituloTarjeta.TabIndex = 2;
            this.LSubtituloTarjeta.Text = "Datos de empleados y roles de acceso";
            this.LSubtituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LTituloTarjeta
            // 
            this.LTituloTarjeta.Dock = System.Windows.Forms.DockStyle.Top;
            this.LTituloTarjeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.LTituloTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.LTituloTarjeta.Location = new System.Drawing.Point(10, 9);
            this.LTituloTarjeta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTituloTarjeta.Name = "LTituloTarjeta";
            this.LTituloTarjeta.Size = new System.Drawing.Size(261, 19);
            this.LTituloTarjeta.TabIndex = 3;
            this.LTituloTarjeta.Text = "FICHA DEL PERSONAL";
            this.LTituloTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBarraFiltros
            // 
            this.PBarraFiltros.Controls.Add(this.LBuscar);
            this.PBarraFiltros.Controls.Add(this.TBBuscar);
            this.PBarraFiltros.Controls.Add(this.LFiltroRol);
            this.PBarraFiltros.Controls.Add(this.CBFiltroRol);
            this.PBarraFiltros.Controls.Add(this.BLimpiarFiltros);
            this.PBarraFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBarraFiltros.Location = new System.Drawing.Point(16, 43);
            this.PBarraFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PBarraFiltros.Name = "PBarraFiltros";
            this.PBarraFiltros.Size = new System.Drawing.Size(1008, 38);
            this.PBarraFiltros.TabIndex = 1;
            // 
            // LBuscar
            // 
            this.LBuscar.AutoSize = true;
            this.LBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LBuscar.Location = new System.Drawing.Point(2, 13);
            this.LBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBuscar.Name = "LBuscar";
            this.LBuscar.Size = new System.Drawing.Size(151, 15);
            this.LBuscar.TabIndex = 0;
            this.LBuscar.Text = "Buscar por DNI / Nombre:";
            // 
            // TBBuscar
            // 
            this.TBBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBBuscar.Location = new System.Drawing.Point(165, 9);
            this.TBBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(218, 23);
            this.TBBuscar.TabIndex = 1;
            // 
            // LFiltroRol
            // 
            this.LFiltroRol.AutoSize = true;
            this.LFiltroRol.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.LFiltroRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LFiltroRol.Location = new System.Drawing.Point(405, 12);
            this.LFiltroRol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LFiltroRol.Name = "LFiltroRol";
            this.LFiltroRol.Size = new System.Drawing.Size(71, 15);
            this.LFiltroRol.TabIndex = 2;
            this.LFiltroRol.Text = "Rol / Cargo:";
            // 
            // CBFiltroRol
            // 
            this.CBFiltroRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBFiltroRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CBFiltroRol.Location = new System.Drawing.Point(484, 8);
            this.CBFiltroRol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CBFiltroRol.Name = "CBFiltroRol";
            this.CBFiltroRol.Size = new System.Drawing.Size(144, 23);
            this.CBFiltroRol.TabIndex = 3;
            // 
            // BLimpiarFiltros
            // 
            this.BLimpiarFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.BLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.BLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiarFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.BLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.BLimpiarFiltros.Location = new System.Drawing.Point(641, 7);
            this.BLimpiarFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BLimpiarFiltros.Name = "BLimpiarFiltros";
            this.BLimpiarFiltros.Size = new System.Drawing.Size(64, 24);
            this.BLimpiarFiltros.TabIndex = 4;
            this.BLimpiarFiltros.Text = "Limpiar";
            this.BLimpiarFiltros.UseVisualStyleBackColor = false;
            // 
            // PEncabezado
            // 
            this.PEncabezado.Controls.Add(this.LTituloPrincipal);
            this.PEncabezado.Controls.Add(this.PBIconoTitulo);
            this.PEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PEncabezado.Location = new System.Drawing.Point(16, 12);
            this.PEncabezado.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PEncabezado.Name = "PEncabezado";
            this.PEncabezado.Size = new System.Drawing.Size(1008, 31);
            this.PEncabezado.TabIndex = 2;
            // 
            // LTituloPrincipal
            // 
            this.LTituloPrincipal.AutoSize = true;
            this.LTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.LTituloPrincipal.Location = new System.Drawing.Point(32, 4);
            this.LTituloPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LTituloPrincipal.Name = "LTituloPrincipal";
            this.LTituloPrincipal.Size = new System.Drawing.Size(189, 21);
            this.LTituloPrincipal.TabIndex = 0;
            this.LTituloPrincipal.Text = "GESTIÓN DE PERSONAL";
            // 
            // PBIconoTitulo
            // 
            this.PBIconoTitulo.BackColor = System.Drawing.Color.Transparent;
            this.PBIconoTitulo.Location = new System.Drawing.Point(0, 2);
            this.PBIconoTitulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PBIconoTitulo.Name = "PBIconoTitulo";
            this.PBIconoTitulo.Size = new System.Drawing.Size(28, 28);
            this.PBIconoTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoTitulo.TabIndex = 1;
            this.PBIconoTitulo.TabStop = false;
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(237)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.PFondo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPersonal";
            this.Text = "Gestión de Personal";
            this.Load += new System.EventHandler(this.FormPersonal_Load);
            this.PFondo.ResumeLayout(false);
            this.TLPContenido.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPersonal)).EndInit();
            this.PTarjetaLateral.ResumeLayout(false);
            this.TLPFormularioEdicion.ResumeLayout(false);
            this.PGrupoDni.ResumeLayout(false);
            this.PGrupoDni.PerformLayout();
            this.PGrupoCuil.ResumeLayout(false);
            this.PGrupoCuil.PerformLayout();
            this.PGrupoNombre.ResumeLayout(false);
            this.PGrupoNombre.PerformLayout();
            this.PGrupoApellido.ResumeLayout(false);
            this.PGrupoApellido.PerformLayout();
            this.PGrupoTelefono.ResumeLayout(false);
            this.PGrupoTelefono.PerformLayout();
            this.PGrupoEmail.ResumeLayout(false);
            this.PGrupoEmail.PerformLayout();
            this.PGrupoRol.ResumeLayout(false);
            this.PGrupoUsuario.ResumeLayout(false);
            this.PGrupoUsuario.PerformLayout();
            this.PGrupoPassword.ResumeLayout(false);
            this.PGrupoPassword.PerformLayout();
            this.PHabilitado.ResumeLayout(false);
            this.PBotonesAccion.ResumeLayout(false);
            this.TLPBotonesMed.ResumeLayout(false);
            this.TPLBotonesSup.ResumeLayout(false);
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
        private System.Windows.Forms.Label LFiltroRol;
        private System.Windows.Forms.ComboBox CBFiltroRol;
        private System.Windows.Forms.Button BLimpiarFiltros;
        private System.Windows.Forms.TableLayoutPanel TLPContenido;
        private System.Windows.Forms.DataGridView DGVPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCuil;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEstado;
        private System.Windows.Forms.Panel PTarjetaLateral;
        private System.Windows.Forms.Label LTituloTarjeta;
        private System.Windows.Forms.Label LSubtituloTarjeta;
        private System.Windows.Forms.TableLayoutPanel TLPFormularioEdicion;
        private System.Windows.Forms.Panel PGrupoDni;
        private System.Windows.Forms.Label LDni;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.Panel PGrupoCuil;
        private System.Windows.Forms.Label LCuil;
        private System.Windows.Forms.TextBox TBCuil;
        private System.Windows.Forms.Panel PGrupoNombre;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Panel PGrupoApellido;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.Panel PGrupoTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Panel PGrupoEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LSubtituloCredenciales;
        private System.Windows.Forms.Panel PGrupoRol;
        private System.Windows.Forms.Label LRol;
        private System.Windows.Forms.ComboBox CBRol;
        private System.Windows.Forms.Panel PGrupoUsuario;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.Panel PGrupoPassword;
        private System.Windows.Forms.Label LPassword;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Panel PHabilitado;
        private System.Windows.Forms.CheckBox ChBUsuarioHabilitado;
        private System.Windows.Forms.Panel PBotonesAccion;
        private System.Windows.Forms.TableLayoutPanel TPLBotonesSup;
        private System.Windows.Forms.Button BNuevo;
        private System.Windows.Forms.Button BGuardar;
        private System.Windows.Forms.TableLayoutPanel TLPBotonesMed;
        private System.Windows.Forms.Button BEditar;
        private System.Windows.Forms.Button BDesactivar;
        private System.Windows.Forms.Button BLimpiar;
    }
}