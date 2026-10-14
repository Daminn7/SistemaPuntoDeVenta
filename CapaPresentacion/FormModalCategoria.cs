using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Drawing;
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

        // ✅ CORREGIDO: Ahora crea la categoría en la API
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
                // ✅ Crear el DTO correcto (CrearCategoriaDto, no CategoriaDto)
                var nuevaCategoria = new CrearCategoriaDto
                {
                    Descripcion = descripcion
                };

                // ✅ Llamar a la API (descomentado)
                var resultado = await _categoriaLogica.Crear(nuevaCategoria);

                IdCategoriaCreada = resultado.Id;
                NombreCategoriaCreada = resultado.Descripcion;

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