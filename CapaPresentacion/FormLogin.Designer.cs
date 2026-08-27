namespace CapaPresentacion
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.PIzquierdo = new System.Windows.Forms.Panel();
            this.PBLogo = new System.Windows.Forms.PictureBox();
            this.PUsuario = new System.Windows.Forms.Panel();
            this.TUsuario = new System.Windows.Forms.TextBox();
            this.PBIconoUsuario = new System.Windows.Forms.PictureBox();
            this.PPassword = new System.Windows.Forms.Panel();
            this.TPassword = new System.Windows.Forms.TextBox();
            this.PBIconoPassword = new System.Windows.Forms.PictureBox();
            this.BIngresar = new System.Windows.Forms.Button();
            this.LHora = new System.Windows.Forms.Label();
            this.LFecha = new System.Windows.Forms.Label();
            this.LErrorUsuario = new System.Windows.Forms.Label();
            this.LErrorPassword = new System.Windows.Forms.Label();
            this.PIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
            this.PUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoUsuario)).BeginInit();
            this.PPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // PIzquierdo
            // 
            this.PIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(32)))));
            this.PIzquierdo.Controls.Add(this.PBLogo);
            this.PIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.PIzquierdo.Name = "PIzquierdo";
            this.PIzquierdo.Size = new System.Drawing.Size(555, 561);
            this.PIzquierdo.TabIndex = 0;
            // 
            // PBLogo
            // 
            this.PBLogo.Image = global::CapaPresentacion.Properties.Resources.logo;
            this.PBLogo.Location = new System.Drawing.Point(0, 0);
            this.PBLogo.Name = "PBLogo";
            this.PBLogo.Size = new System.Drawing.Size(555, 558);
            this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBLogo.TabIndex = 2;
            this.PBLogo.TabStop = false;
            // 
            // PUsuario
            // 
            this.PUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.PUsuario.Controls.Add(this.TUsuario);
            this.PUsuario.Controls.Add(this.PBIconoUsuario);
            this.PUsuario.Location = new System.Drawing.Point(581, 175);
            this.PUsuario.Name = "PUsuario";
            this.PUsuario.Size = new System.Drawing.Size(330, 40);
            this.PUsuario.TabIndex = 1;
            // 
            // TUsuario
            // 
            this.TUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.TUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TUsuario.ForeColor = System.Drawing.Color.White;
            this.TUsuario.Location = new System.Drawing.Point(61, 7);
            this.TUsuario.Name = "TUsuario";
            this.TUsuario.Size = new System.Drawing.Size(250, 27);
            this.TUsuario.TabIndex = 1;
            this.TUsuario.Text = "Usuario";
            // 
            // PBIconoUsuario
            // 
            this.PBIconoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PBIconoUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.PBIconoUsuario.Image = ((System.Drawing.Image)(resources.GetObject("PBIconoUsuario.Image")));
            this.PBIconoUsuario.Location = new System.Drawing.Point(0, 0);
            this.PBIconoUsuario.Name = "PBIconoUsuario";
            this.PBIconoUsuario.Size = new System.Drawing.Size(45, 40);
            this.PBIconoUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoUsuario.TabIndex = 0;
            this.PBIconoUsuario.TabStop = false;
            // 
            // PPassword
            // 
            this.PPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.PPassword.Controls.Add(this.TPassword);
            this.PPassword.Controls.Add(this.PBIconoPassword);
            this.PPassword.Location = new System.Drawing.Point(581, 258);
            this.PPassword.Name = "PPassword";
            this.PPassword.Size = new System.Drawing.Size(330, 41);
            this.PPassword.TabIndex = 2;
            // 
            // TPassword
            // 
            this.TPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(44)))));
            this.TPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TPassword.ForeColor = System.Drawing.Color.White;
            this.TPassword.Location = new System.Drawing.Point(61, 7);
            this.TPassword.Name = "TPassword";
            this.TPassword.Size = new System.Drawing.Size(250, 27);
            this.TPassword.TabIndex = 4;
            this.TPassword.Text = "Contraseña";
            // 
            // PBIconoPassword
            // 
            this.PBIconoPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.PBIconoPassword.Image = ((System.Drawing.Image)(resources.GetObject("PBIconoPassword.Image")));
            this.PBIconoPassword.Location = new System.Drawing.Point(0, 0);
            this.PBIconoPassword.Name = "PBIconoPassword";
            this.PBIconoPassword.Size = new System.Drawing.Size(45, 40);
            this.PBIconoPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBIconoPassword.TabIndex = 3;
            this.PBIconoPassword.TabStop = false;
            // 
            // BIngresar
            // 
            this.BIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(131)))), ((int)(((byte)(53)))));
            this.BIngresar.FlatAppearance.BorderSize = 0;
            this.BIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIngresar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIngresar.ForeColor = System.Drawing.Color.White;
            this.BIngresar.Location = new System.Drawing.Point(586, 339);
            this.BIngresar.Name = "BIngresar";
            this.BIngresar.Size = new System.Drawing.Size(320, 45);
            this.BIngresar.TabIndex = 3;
            this.BIngresar.Text = "INGRESAR";
            this.BIngresar.UseVisualStyleBackColor = false;
            this.BIngresar.Click += new System.EventHandler(this.BIngresar_Click);
            // 
            // LHora
            // 
            this.LHora.AutoSize = true;
            this.LHora.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.LHora.Location = new System.Drawing.Point(815, 415);
            this.LHora.Name = "LHora";
            this.LHora.Size = new System.Drawing.Size(77, 27);
            this.LHora.TabIndex = 4;
            this.LHora.Text = "00:00";
            // 
            // LFecha
            // 
            this.LFecha.AutoSize = true;
            this.LFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LFecha.Location = new System.Drawing.Point(796, 442);
            this.LFecha.Name = "LFecha";
            this.LFecha.Size = new System.Drawing.Size(112, 20);
            this.LFecha.TabIndex = 5;
            this.LFecha.Text = "27 de ago 2026";
            // 
            // LErrorUsuario
            // 
            this.LErrorUsuario.AutoSize = true;
            this.LErrorUsuario.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LErrorUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LErrorUsuario.Location = new System.Drawing.Point(716, 218);
            this.LErrorUsuario.Name = "LErrorUsuario";
            this.LErrorUsuario.Size = new System.Drawing.Size(166, 17);
            this.LErrorUsuario.TabIndex = 6;
            this.LErrorUsuario.Text = "*Debe ingresar su código";
            this.LErrorUsuario.Visible = false;
            // 
            // LErrorPassword
            // 
            this.LErrorPassword.AutoSize = true;
            this.LErrorPassword.Font = new System.Drawing.Font("Segoe UI Black", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LErrorPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.LErrorPassword.Location = new System.Drawing.Point(690, 302);
            this.LErrorPassword.Name = "LErrorPassword";
            this.LErrorPassword.Size = new System.Drawing.Size(192, 17);
            this.LErrorPassword.TabIndex = 7;
            this.LErrorPassword.Text = "*Debe ingresar su contraseña";
            this.LErrorPassword.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(943, 561);
            this.Controls.Add(this.LErrorPassword);
            this.Controls.Add(this.LErrorUsuario);
            this.Controls.Add(this.LFecha);
            this.Controls.Add(this.LHora);
            this.Controls.Add(this.BIngresar);
            this.Controls.Add(this.PPassword);
            this.Controls.Add(this.PUsuario);
            this.Controls.Add(this.PIzquierdo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(130)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hierro y Forja - Inicio de Sesión";
            this.PIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
            this.PUsuario.ResumeLayout(false);
            this.PUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoUsuario)).EndInit();
            this.PPassword.ResumeLayout(false);
            this.PPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBIconoPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PIzquierdo;
        private System.Windows.Forms.PictureBox PBLogo;
        private System.Windows.Forms.Panel PUsuario;
        private System.Windows.Forms.PictureBox PBIconoUsuario;
        private System.Windows.Forms.TextBox TUsuario;
        private System.Windows.Forms.Panel PPassword;
        private System.Windows.Forms.PictureBox PBIconoPassword;
        private System.Windows.Forms.TextBox TPassword;
        private System.Windows.Forms.Button BIngresar;
        private System.Windows.Forms.Label LHora;
        private System.Windows.Forms.Label LFecha;
        private System.Windows.Forms.Label LErrorUsuario;
        private System.Windows.Forms.Label LErrorPassword;
    }
}