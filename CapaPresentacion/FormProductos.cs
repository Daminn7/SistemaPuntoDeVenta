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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
            AsignarEstiloEIconos();
        }

        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }

        private void AsignarEstiloEIconos()
        {
            BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);;
            BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
            BEditar.Image = EscalarIcono(Properties.Resources.boton_editar_blanco, 32, 32);
            BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            BLimpiar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números (0-9) y teclas de control como Backspace o Delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Cancela la tecla pulsada
            }
        }

        private bool ValidarCamposProducto()
        {
            // 1. Código Interno
            if (string.IsNullOrWhiteSpace(TCodigoInterno.Text) || !long.TryParse(TCodigoInterno.Text.Trim(), out _))
            {
                MessageBox.Show("El Código Interno es obligatorio y debe ser exclusivamente numérico.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCodigoInterno.Focus();
                return false;
            }

            // 2. Código de Barras (si se ingresó algo)
            if (!string.IsNullOrWhiteSpace(TCodBarras.Text) && !long.TryParse(TCodBarras.Text.Trim(), out _))
            {
                MessageBox.Show("El Código de Barras debe ser numérico.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TCodBarras.Focus();
                return false;
            }

            // 3. Nombre del Producto
            if (string.IsNullOrWhiteSpace(TNombreProducto.Text) || TNombreProducto.Text.Trim().Length < 3)
            {
                MessageBox.Show("Debe ingresar un Nombre de Producto válido (mínimo 3 caracteres).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNombreProducto.Focus();
                return false;
            }

            // 4. Categoría
            if (CBCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una Categoría.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBCategoria.Focus();
                return false;
            }

            // 5. Precios (Decimales)
            if (!IntentarConvertirDecimal(TPrecioMinorista.Text, out decimal precioMinorista) || precioMinorista <= 0)
            {
                MessageBox.Show("Ingrese un Precio Minorista válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TPrecioMinorista.Focus();
                return false;
            }

            if (!IntentarConvertirDecimal(TPrecioMayorista.Text, out decimal precioMayorista) || precioMayorista <= 0)
            {
                MessageBox.Show("Ingrese un Precio Mayorista válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TPrecioMayorista.Focus();
                return false;
            }

            // Regla comercial estricta: No permite guardar (CONVERSAR)
            if (precioMayorista > precioMinorista)
            {
                MessageBox.Show("El precio mayorista no puede superar al precio minorista.",
                                "Error de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TPrecioMayorista.Focus();
                return false; 
            }
            // 6. Reglas de Stock (Coherencia operativa)
            if (NUDStockMinimo.Value <= 0)
            {
                MessageBox.Show("El Stock Mínimo debe ser de al menos 1 unidad para activar alertas de reposición.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDStockMinimo.Focus();
                return false;
            }

            // Advertencia informativa si se crea el producto con stock por debajo del mínimo
            if (NUDStockActual.Value < NUDStockMinimo.Value)
            {
                DialogResult res = MessageBox.Show(
                    "El Stock Actual ingresado es menor al Stock Mínimo requerido.\n¿Desea registrar el producto bajo nivel crítico de reposición?",
                    "Aviso de Stock Crítico",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (res == DialogResult.No)
                {
                    NUDStockActual.Focus();
                    return false;
                }
            }

            // 7. Descripción que no supere una longitud establecida
            if (TDescripcion.Text.Trim().Length > 300)
            {
                MessageBox.Show("La descripción no puede exceder los 300 caracteres.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDescripcion.Focus();
                return false;
            }
            return true;
        }

        private void ValidarDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null) return;

            // Permitir teclas de control 
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Si escribe '.' o ',', normalizamos permitiendo solo un separador decimal
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Si ya contiene un punto o una coma, bloqueamos el ingreso
                if (txt.Text.Contains(",") || txt.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }

                // Si es el primer carácter, colocamos "0," automáticamente
                if (txt.Text.Length == 0)
                {
                    txt.Text = "0,";
                    txt.SelectionStart = txt.Text.Length;
                    e.Handled = true;
                    return;
                }

                //Estandarizar la tecla a coma ',' para que siempre se vea igual
                e.KeyChar = ',';
                return;
            }

            // Manejo de dígitos (0-9)
            if (char.IsDigit(e.KeyChar))
            {
                // Buscamos si ya hay separador en el texto
                int indexSeparador = txt.Text.IndexOfAny(new char[] { ',', '.' });

                if (indexSeparador != -1)
                {
                    // Solo restringimos si el cursor está escribiendo a la derecha de la coma
                    // y no hay texto seleccionado (si hay texto marcado, se reemplaza)
                    if (txt.SelectionStart > indexSeparador && txt.SelectionLength == 0)
                    {
                        string parteDecimal = txt.Text.Substring(indexSeparador + 1);

                        // Si ya tiene 2 decimales, no permitir más dígitos
                        if (parteDecimal.Length >= 2)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
                return;
            }

            // Bloquear cualquier otra tecla (letras, símbolos, espacios)
            e.Handled = true;
        }

        public static bool IntentarConvertirDecimal(string texto, out decimal valor)
        {
            valor = 0;
            if (string.IsNullOrWhiteSpace(texto)) return false;

            // Reemplazamos coma por punto para trabajar con formato invariante estándar
            string textoNormalizado = texto.Trim().Replace(',', '.');

            return decimal.TryParse(
                textoNormalizado,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture,
                out valor
            );
        }

        private void FormatearMoneda_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text)) return;

            if (IntentarConvertirDecimal(txt.Text, out decimal valor))
            {
                // Formatea siempre con 2 decimales exactos
                txt.Text = valor.ToString("0.00");
            }
        }

    }
}
