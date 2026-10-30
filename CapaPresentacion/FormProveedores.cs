using CapaDatos.DTOs;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormProveedores : Form
    {
        private readonly ProveedorLogica _proveedorLogica = new ProveedorLogica();
        private readonly TablasMaestrasLogica _tablasLogica = new TablasMaestrasLogica();

        private int _idProveedorSeleccionado = 0;
        private bool _esEdicion = false;

        private List<ProvinciaDto> _provincias;
        private List<LocalidadDto> _localidades;

        private bool _mostrarSoloActivos = true;
        private bool _actualizandoCuit = false;
        private bool _cargandoFiltros = false;

        // ✅ NUEVO: CancellationTokenSource
        private CancellationTokenSource _ctsCarga;

        public FormProveedores()
        {
            InitializeComponent();
            InicializarComportamiento();
        }

        private async void FormProveedores_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoProveedores(Color.FromArgb(212, 131, 53));

            AsignarEstiloEIconos();

            try
            {
                // ✅ Cargar provincias y proveedores en paralelo
                await Task.WhenAll(
                    CargarProvinciasAsync(token),
                    CargarProveedoresAsync(token)
                );
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (this.IsDisposed || this.Disposing) return;

            LimpiarFormulario();
            ActualizarBotonesSegunModo();
            BLimpiarFiltros.Text = "Inactivos";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                _ctsCarga?.Cancel();
                _ctsCarga?.Dispose();
                _ctsCarga = null;
            }
            catch { }
            base.OnFormClosing(e);
        }

        private async Task CargarProvinciasAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                _provincias = await _tablasLogica.GetProvincias();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                // Combo del formulario (alta/edición)
                CBProvincia.DataSource = _provincias;
                CBProvincia.DisplayMember = "Descripcion";
                CBProvincia.ValueMember = "Id";
                CBProvincia.SelectedIndex = -1;

                // ✅ NUEVO: Pausar eventos mientras se carga el filtro
                _cargandoFiltros = true;

                // ✅ NUEVO: Combo del FILTRO (con opción "Todas")
                var provinciasFiltro = new List<ProvinciaDto>();
                provinciasFiltro.Add(new ProvinciaDto { Id = 0, Descripcion = "(Todas)" });
                if (_provincias != null) provinciasFiltro.AddRange(_provincias);

                CBFiltroProvincia.DataSource = provinciasFiltro;
                CBFiltroProvincia.DisplayMember = "Descripcion";
                CBFiltroProvincia.ValueMember = "Id";
                CBFiltroProvincia.SelectedIndex = 0;

                // Combo de localidad del filtro: empezar con "Todas"
                CBFiltroLocalidad.Items.Clear();
                CBFiltroLocalidad.Items.Add("(Todas)");
                CBFiltroLocalidad.SelectedIndex = 0;

                // ✅ Reanudar eventos
                _cargandoFiltros = false;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar provincias: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private async Task CargarProveedoresAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var proveedores = await _proveedorLogica.ObtenerTodos();
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                DGVProveedores.SuspendLayout();
                DGVProveedores.Rows.Clear();

                if (proveedores == null || proveedores.Count == 0)
                {
                    DGVProveedores.ResumeLayout();
                    return;
                }

                var filtrados = proveedores
                    .Where(p => _mostrarSoloActivos ? p.Estado : !p.Estado)
                    .ToList();

                foreach (var p in filtrados)
                {
                    string nombreCompleto = $"{p.Nombre ?? ""} {p.Apellido ?? ""}".Trim();
                    string estadoMostrar = p.Estado ? "Habilitado" : "Deshabilitado";

                    DGVProveedores.Rows.Add(
                        p.Id,
                        p.CuilCuit ?? "",
                        nombreCompleto,
                        p.Nombre ?? "",
                        p.Telefono ?? "",
                        p.Email ?? "",
                        p.Localidad ?? "",
                        p.Direccion ?? "",
                        estadoMostrar
                    );
                }

                DGVProveedores.ResumeLayout();
                AplicarFiltroGrilla();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar proveedores: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Image GenerarIconoProveedores(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 3.5f, 8.5f, 15f, 12f);
                    PointF[] cabina = new PointF[]
                    {
                        new PointF(18.5f, 12.5f),
                        new PointF(23.5f, 12.5f),
                        new PointF(27.5f, 16.5f),
                        new PointF(27.5f, 20.5f),
                        new PointF(18.5f, 20.5f)
                    };
                    g.DrawLines(pen, cabina);
                    g.DrawLine(pen, 20.5f, 14.5f, 24.5f, 14.5f);
                    g.FillEllipse(brush, 6.5f, 20.5f, 5f, 5f);
                    g.FillEllipse(brush, 21.5f, 20.5f, 5f, 5f);
                }
            }
            return bmp;
        }

        private Image EscalarIcono(Image imagenOriginal, int ancho, int alto)
        {
            if (imagenOriginal == null) return null;
            Bitmap nuevoBitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(nuevoBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.DrawImage(imagenOriginal, 0, 0, ancho, alto);
            }
            return nuevoBitmap;
        }

        private void AsignarEstiloEIconos()
        {
            try
            {
                BNuevo.Image = EscalarIcono(Properties.Resources.boton_nuevo_blanco, 32, 32);
                BGuardar.Image = EscalarIcono(Properties.Resources.boton_guardar_blanco, 32, 32);
                BActualizar.Image = EscalarIcono(Properties.Resources.boton_limpiar_blanco, 32, 32);
                BDesactivar.Image = EscalarIcono(Properties.Resources.boton_desactivar_blanco, 32, 32);
            }
            catch { }
        }

        private void InicializarComportamiento()
        {
            TBCuit.MaxLength = 15;
            TBCuit.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
                    e.Handled = true;
            };
            ConfigurarFormateoCuitEnVivo();

            TBTelefono.MaxLength = 18;
            TBTelefono.KeyPress += (s, e) =>
            {
                if (char.IsControl(e.KeyChar)) return;
                if (e.KeyChar == '+' && TBTelefono.SelectionStart == 0 && !TBTelefono.Text.Contains("+"))
                    return;
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            };

            TBRazonSocial.KeyPress += SoloLetrasYNumerosYEspacios_KeyPress;
            TBContacto.KeyPress += SoloLetrasYEspacios_KeyPress;

            ConfigurarValidacionEmailEnVivo();
            ConfigurarCascadaProvincias();
            ConfigurarFiltrosDinamicos();
        }

        private void ConfigurarFormateoCuitEnVivo()
        {
            TBCuit.TextChanged += (s, e) =>
            {
                if (_actualizandoCuit) return;

                string digitos = new string(TBCuit.Text.Where(char.IsDigit).ToArray());
                if (digitos.Length > 11) digitos = digitos.Substring(0, 11);

                string textoFormateado = digitos;
                if (digitos.Length > 10)
                {
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2, 8)}-{digitos.Substring(10, 1)}";
                }
                else if (digitos.Length > 2)
                {
                    textoFormateado = $"{digitos.Substring(0, 2)}-{digitos.Substring(2)}";
                }

                _actualizandoCuit = true;
                TBCuit.Text = textoFormateado;
                TBCuit.SelectionStart = TBCuit.Text.Length;
                _actualizandoCuit = false;
            };
        }

        private void ConfigurarValidacionEmailEnVivo()
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            TBEmail.TextChanged += (s, e) =>
            {
                string email = TBEmail.Text.Trim();
                if (string.IsNullOrEmpty(email))
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    return;
                }
                TBEmail.ForeColor = Regex.IsMatch(email, patronEmail)
                    ? Color.FromArgb(39, 174, 96)
                    : Color.FromArgb(38, 40, 44);
            };

            TBEmail.Leave += (s, e) =>
            {
                string email = TBEmail.Text.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43);
                    LEmail.Text = "Correo Electrónico * (Obligatorio)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else if (!Regex.IsMatch(email, patronEmail))
                {
                    TBEmail.ForeColor = Color.FromArgb(192, 57, 43);
                    LEmail.Text = "Correo Electrónico (Formato: ej@dominio.com)";
                    LEmail.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else
                {
                    TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
                    LEmail.Text = "Correo Electrónico:";
                    LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                }
            };

            TBEmail.Enter += (s, e) =>
            {
                LEmail.Text = "Correo Electrónico:";
                LEmail.ForeColor = Color.FromArgb(70, 70, 70);
                TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            };
        }

        private void SoloLetrasYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void SoloLetrasYNumerosYEspacios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
                e.Handled = true;
        }

        private void ConfigurarCascadaProvincias()
        {
            CBProvincia.SelectedIndexChanged += async (s, e) =>
            {
                try
                {
                    if (CBProvincia.SelectedItem == null)
                    {
                        CBLocalidad.DataSource = null;
                        CBLocalidad.Items.Clear();
                        return;
                    }

                    if (CBProvincia.SelectedItem is ProvinciaDto provincia)
                    {
                        await CargarLocalidadesPorProvinciaAsync(provincia.Id, _ctsCarga?.Token ?? CancellationToken.None);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en cascada: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private async Task CargarLocalidadesPorProvinciaAsync(int idProvincia, CancellationToken token = default(CancellationToken))
        {
            try
            {
                _localidades = await _tablasLogica.GetLocalidadesByProvincia(idProvincia);
                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (_localidades == null || _localidades.Count == 0)
                {
                    CBLocalidad.DataSource = null;
                    CBLocalidad.Items.Clear();
                    return;
                }

                CBLocalidad.DataSource = _localidades;
                CBLocalidad.DisplayMember = "Descripcion";
                CBLocalidad.ValueMember = "Id";
                CBLocalidad.SelectedIndex = -1;

                CBFiltroLocalidad.Items.Clear();
                CBFiltroLocalidad.Items.Add("(Todas)");
                foreach (var loc in _localidades)
                    CBFiltroLocalidad.Items.Add(loc.Descripcion);
                CBFiltroLocalidad.SelectedIndex = 0;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarFiltrosDinamicos()
        {
            TBBuscar.TextChanged += (s, e) => AplicarFiltroGrilla();

            // ✅ El evento ahora se dispara, pero el método sabe si debe ignorarlo
            CBFiltroProvincia.SelectedIndexChanged += async (s, e) => await CargarLocalidadesDelFiltroAsync();

            CBFiltroLocalidad.SelectedIndexChanged += (s, e) =>
            {
                if (!_cargandoFiltros) AplicarFiltroGrilla();
            };

            BLimpiarFiltros.Click += BLimpiarFiltros_Click;
        }

        private async Task CargarLocalidadesDelFiltroAsync()
        {
            // ✅ Si estamos cargando los datos iniciales, no hacer nada
            if (_cargandoFiltros) return;

            try
            {
                // ✅ Validación segura para evitar el error de conversión
                if (CBFiltroProvincia.SelectedValue == null || !(CBFiltroProvincia.SelectedValue is int))
                {
                    CBFiltroLocalidad.Items.Clear();
                    CBFiltroLocalidad.Items.Add("(Todas)");
                    CBFiltroLocalidad.SelectedIndex = 0;
                    AplicarFiltroGrilla();
                    return;
                }

                int idProvincia = (int)CBFiltroProvincia.SelectedValue;

                if (idProvincia == 0)
                {
                    CBFiltroLocalidad.Items.Clear();
                    CBFiltroLocalidad.Items.Add("(Todas)");
                    CBFiltroLocalidad.SelectedIndex = 0;
                    AplicarFiltroGrilla();
                    return;
                }

                var localidades = await _tablasLogica.GetLocalidadesByProvincia(idProvincia);

                CBFiltroLocalidad.Items.Clear();
                CBFiltroLocalidad.Items.Add("(Todas)");
                if (localidades != null)
                {
                    foreach (var loc in localidades)
                        CBFiltroLocalidad.Items.Add(loc.Descripcion);
                }
                CBFiltroLocalidad.SelectedIndex = 0;

                AplicarFiltroGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades del filtro: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroGrilla()
        {
            string texto = TBBuscar.Text.Trim().ToLower();
            string provinciaFiltro = CBFiltroProvincia.Text ?? "";
            string localidadFiltro = CBFiltroLocalidad.Text ?? "";

            bool filtrarPorProvincia = !string.IsNullOrEmpty(provinciaFiltro) && provinciaFiltro != "(Todas)";
            bool filtrarPorLocalidad = !string.IsNullOrEmpty(localidadFiltro) && localidadFiltro != "(Todas)";

            DGVProveedores.SuspendLayout();
            foreach (DataGridViewRow row in DGVProveedores.Rows)
            {
                if (row.IsNewRow) continue;

                string cuit = row.Cells["ColCuit"].Value?.ToString().ToLower() ?? "";
                string razon = row.Cells["ColRazonSocial"].Value?.ToString().ToLower() ?? "";
                string contacto = row.Cells["ColContacto"].Value?.ToString().ToLower() ?? "";
                string localidad = row.Cells["ColLocalidad"].Value?.ToString() ?? "";

                bool coincideTexto = string.IsNullOrEmpty(texto) ||
                                     cuit.Contains(texto) ||
                                     razon.Contains(texto) ||
                                     contacto.Contains(texto);

                // Si hay filtro por provincia, solo mostramos las localidades de esa provincia
                // (asumimos que las localidades ya vienen filtradas del combo, pero por las dudas)
                bool coincideProvincia = true;
                if (filtrarPorProvincia)
                {
                    // Si el usuario eligió una localidad específica, ya se filtra abajo
                    // Si no, filtramos por las localidades de esa provincia
                    coincideProvincia = !string.IsNullOrEmpty(localidad) &&
                                        CBFiltroLocalidad.Items.Cast<object>()
                                            .Select(i => i.ToString())
                                            .Contains(localidad);
                }

                bool coincideLocalidad = !filtrarPorLocalidad ||
                                         localidad.Equals(localidadFiltro, StringComparison.OrdinalIgnoreCase);

                row.Visible = coincideTexto && coincideProvincia && coincideLocalidad;
            }
            DGVProveedores.ResumeLayout();
        }
        private async void BLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _cargandoFiltros = true;  // ✅ Pausar eventos al limpiar

            TBBuscar.Clear();
            CBFiltroProvincia.SelectedIndex = 0;
            CBFiltroLocalidad.Items.Clear();
            CBFiltroLocalidad.Items.Add("(Todas)");
            CBFiltroLocalidad.SelectedIndex = 0;

            _cargandoFiltros = false; // ✅ Reanudar

            _mostrarSoloActivos = !_mostrarSoloActivos;
            BLimpiarFiltros.Text = _mostrarSoloActivos ? "Inactivos" : "Activos";

            await CargarProveedoresAsync(_ctsCarga?.Token ?? CancellationToken.None);
        }

        private bool ValidarFormulario(out string mensajeError)
        {
            mensajeError = string.Empty;

            string cuitDigitos = new string(TBCuit.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(TBCuit.Text) || cuitDigitos.Length != 11)
            {
                mensajeError = "Debe ingresar un CUIT válido (11 dígitos, formato XX-XXXXXXXX-X).";
                TBCuit.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBRazonSocial.Text))
            {
                mensajeError = "Debe ingresar el Nombre del proveedor.";
                TBRazonSocial.Focus();
                return false;
            }

            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(TBEmail.Text.Trim()) ||
                !Regex.IsMatch(TBEmail.Text.Trim(), patronEmail))
            {
                mensajeError = "Debe ingresar un Correo Electrónico válido.";
                TBEmail.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(TBCalle.Text) && CBProvincia.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Provincia.";
                CBProvincia.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(TBCalle.Text) && CBLocalidad.SelectedIndex == -1)
            {
                mensajeError = "Debe seleccionar una Localidad.";
                CBLocalidad.Focus();
                return false;
            }

            return true;
        }

        private async void BGuardar_Click(object sender, EventArgs e)
        {
            if (_esEdicion)
            {
                MessageBox.Show("Está en modo edición. Use el botón 'Actualizar'.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                string telCompleto = TBTelefono.Text.Trim();
                string caracteristica = "";
                long numero = 0;

                if (!string.IsNullOrEmpty(telCompleto))
                {
                    string digitosTel = new string(telCompleto.Where(char.IsDigit).ToArray());
                    if (digitosTel.Length > 7)
                    {
                        caracteristica = digitosTel.Substring(0, digitosTel.Length - 7);
                        long.TryParse(digitosTel.Substring(digitosTel.Length - 7), out numero);
                    }
                    else
                    {
                        long.TryParse(digitosTel, out numero);
                    }
                }

                var nuevo = new CrearProveedorDto
                {
                    Nombre = TBRazonSocial.Text.Trim(),
                    Apellido = TBContacto.Text.Trim(),
                    CuilCuit = TBCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Estado = ChBProveedorHabilitado.Checked,
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = null,
                        Departamento = "",
                        Descripcion = null,
                        LocalidadId = CBLocalidad.SelectedValue != null ? (int)CBLocalidad.SelectedValue : 0
                    },
                    Telefono = !string.IsNullOrEmpty(telCompleto) ? new TelefonoCrearDto
                    {
                        Caracteristica = caracteristica,
                        Numero = numero
                    } : null
                };

                await _proveedorLogica.Crear(nuevo);

                MessageBox.Show("Proveedor creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProveedoresAsync(_ctsCarga?.Token ?? CancellationToken.None);
                LimpiarFormulario();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BGuardar.Enabled = true;
                BActualizar.Enabled = false;
            }
        }

        private async void BActualizar_Click(object sender, EventArgs e)
        {
            if (!_esEdicion || _idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para actualizar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarFormulario(out string error))
            {
                MessageBox.Show(error, "Validación de Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BGuardar.Enabled = false;
            BActualizar.Enabled = false;

            try
            {
                string telCompleto = TBTelefono.Text.Trim();
                string caracteristica = "";
                long numero = 0;

                if (!string.IsNullOrEmpty(telCompleto))
                {
                    string digitosTel = new string(telCompleto.Where(char.IsDigit).ToArray());
                    if (digitosTel.Length > 7)
                    {
                        caracteristica = digitosTel.Substring(0, digitosTel.Length - 7);
                        long.TryParse(digitosTel.Substring(digitosTel.Length - 7), out numero);
                    }
                    else
                    {
                        long.TryParse(digitosTel, out numero);
                    }
                }

                var actualizar = new CrearProveedorDto
                {
                    Nombre = TBRazonSocial.Text.Trim(),
                    Apellido = TBContacto.Text.Trim(),
                    CuilCuit = TBCuit.Text.Trim(),
                    Email = TBEmail.Text.Trim(),
                    Estado = ChBProveedorHabilitado.Checked,
                    Direccion = new DireccionCrearDto
                    {
                        Calle = TBCalle.Text.Trim(),
                        Numero = string.IsNullOrWhiteSpace(TBNro.Text) ? (int?)null : int.Parse(TBNro.Text),
                        Edificio = null,
                        Piso = null,
                        Departamento = "",
                        Descripcion = null,
                        LocalidadId = CBLocalidad.SelectedValue != null ? (int)CBLocalidad.SelectedValue : 0
                    },
                    Telefono = !string.IsNullOrEmpty(telCompleto) ? new TelefonoCrearDto
                    {
                        Caracteristica = caracteristica,
                        Numero = numero
                    } : null
                };

                await _proveedorLogica.Actualizar(_idProveedorSeleccionado, actualizar);

                MessageBox.Show("Proveedor actualizado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarProveedoresAsync(_ctsCarga?.Token ?? CancellationToken.None);
                LimpiarFormulario();
                ActualizarBotonesSegunModo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                BGuardar.Enabled = false;
                BActualizar.Enabled = true;
            }
        }

        private async void BDesactivar_Click(object sender, EventArgs e)
        {
            if (_idProveedorSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un proveedor de la grilla para dar de baja.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de dar de baja a este proveedor?",
                "Dar de Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BGuardar.Enabled = false;
                BActualizar.Enabled = false;
                BDesactivar.Enabled = false;

                try
                {
                    await _proveedorLogica.Eliminar(_idProveedorSeleccionado);
                    MessageBox.Show("Proveedor dado de baja exitosamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarProveedoresAsync(_ctsCarga?.Token ?? CancellationToken.None);
                    LimpiarFormulario();
                    BDesactivar.Enabled = true;
                    ActualizarBotonesSegunModo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al dar de baja: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    BDesactivar.Enabled = true;
                    ActualizarBotonesSegunModo();
                }
            }
        }

        private void BNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            _esEdicion = false;
            _idProveedorSeleccionado = 0;
            ActualizarBotonesSegunModo();
            TBCuit.Focus();
        }

        private async void DGVProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var token = _ctsCarga?.Token ?? CancellationToken.None;

            try
            {
                var fila = DGVProveedores.Rows[e.RowIndex];
                int id = Convert.ToInt32(fila.Cells["ColIdProveedor"].Value ?? 0);

                _idProveedorSeleccionado = id;
                _esEdicion = true;

                var proveedor = await _proveedorLogica.ObtenerPorId(id);
                if (token.IsCancellationRequested || this.IsDisposed) return;

                if (proveedor != null)
                {
                    TBRazonSocial.Text = proveedor.Nombre ?? "";
                    TBContacto.Text = proveedor.Apellido ?? "";
                    TBCuit.Text = proveedor.CuilCuit ?? "";
                    TBEmail.Text = proveedor.Email ?? "";
                    TBTelefono.Text = proveedor.Telefono ?? "";

                    string dir = proveedor.Direccion ?? "";
                    if (!string.IsNullOrEmpty(dir))
                    {
                        int lastSpace = dir.LastIndexOf(' ');
                        if (lastSpace > 0 && int.TryParse(dir.Substring(lastSpace + 1), out _))
                        {
                            TBCalle.Text = dir.Substring(0, lastSpace);
                            TBNro.Text = dir.Substring(lastSpace + 1);
                        }
                        else
                        {
                            TBCalle.Text = dir;
                            TBNro.Clear();
                        }
                    }
                    else
                    {
                        TBCalle.Clear();
                        TBNro.Clear();
                    }

                    if (proveedor.LocalidadId > 0)
                    {
                        var localidad = _localidades?.FirstOrDefault(l => l.Id == proveedor.LocalidadId);

                        if (localidad == null)
                        {
                            foreach (var prov in _provincias)
                            {
                                var locs = await _tablasLogica.GetLocalidadesByProvincia(prov.Id);
                                localidad = locs.FirstOrDefault(l => l.Id == proveedor.LocalidadId);
                                if (localidad != null)
                                {
                                    CBProvincia.SelectedValue = prov.Id;
                                    await Task.Delay(200);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var provincia = _provincias?.FirstOrDefault(p => p.Id == localidad.ProvinciaId);
                            if (provincia != null)
                                CBProvincia.SelectedValue = provincia.Id;

                            await Task.Delay(300);
                        }

                        if (localidad != null && CBLocalidad.DataSource != null)
                            CBLocalidad.SelectedValue = proveedor.LocalidadId;
                    }

                    ChBProveedorHabilitado.Checked = proveedor.Estado;
                }

                ActualizarBotonesSegunModo();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested && !this.IsDisposed)
                {
                    MessageBox.Show($"Error al cargar proveedor: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarFormulario()
        {
            _idProveedorSeleccionado = 0;
            _esEdicion = false;

            TBCuit.Clear();
            TBRazonSocial.Clear();
            TBContacto.Clear();
            TBTelefono.Clear();
            TBEmail.Clear();
            TBCalle.Clear();
            TBNro.Clear();

            CBProvincia.SelectedIndex = -1;
            CBLocalidad.DataSource = null;
            CBLocalidad.Items.Clear();

            ChBProveedorHabilitado.Checked = true;

            TBEmail.ForeColor = Color.FromArgb(38, 40, 44);
            LEmail.Text = "Correo Electrónico:";
            LEmail.ForeColor = Color.FromArgb(70, 70, 70);

            DGVProveedores.ClearSelection();
            if (DGVProveedores.CurrentCell != null)
                DGVProveedores.CurrentCell = null;

            BDesactivar.Enabled = true;

            ActualizarBotonesSegunModo();
        }

        private void ActualizarBotonesSegunModo()
        {
            if (_esEdicion)
            {
                BGuardar.Enabled = false;
                BActualizar.Enabled = true;
            }
            else
            {
                BGuardar.Enabled = true;
                BActualizar.Enabled = false;
            }
        }
    }
}