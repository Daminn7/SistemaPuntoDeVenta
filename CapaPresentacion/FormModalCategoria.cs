using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormModalCategoria : Form
    {
        private readonly CategoriaLogica _categoriaLogica = new CategoriaLogica();

        public int IdCategoriaCreada { get; private set; } = 0;
        public string NombreCategoriaCreada { get; private set; } = string.Empty;

        public FormModalCategoria()
        {
            InitializeComponent();
        }

        private void FormModalCategoria_Paint(object sender, PaintEventArgs e)
        {
            // Borde exterior sutil
            using (Pen penBorde = new Pen(Color.FromArgb(65, 68, 74), 1))
            {
                e.Graphics.DrawRectangle(penBorde, 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private async void BGuardar_Click(object sender, EventArgs e)
        {
            string descripcion = TBNombreCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion) || descripcion.Length < 3)
            {
                MessageBox.Show("Ingrese un nombre de categoría válido (mínimo 3 caracteres).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBNombreCategoria.Focus();
                return;
            }

            try
            {
                var nuevaCategoria = new CategoriaDto { 
                //Nombre = nombre, 
                Descripcion = descripcion
                };
                //var resultado = await _categoriaLogica.Crear(nuevaCategoria);

                //IdCategoriaCreada = resultado.Id;
                //NombreCategoriaCreada = nombre;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar categoría: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
