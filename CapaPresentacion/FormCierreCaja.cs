using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDatos.DTOs;
using CapaDatos.Helpers;
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormCierreCaja : Form
    {
        private readonly CajaLogica _cajaLogica = new CajaLogica();
        private readonly MovimientoCajaLogica _movimientoLogica = new MovimientoCajaLogica();

        private bool _cajaAbierta = false;
        private int _idTurnoCaja = 0;
        private int? _numeroCajaActual = null;
        private string _nombreCajero = "Operador";
        private decimal _fondoInicial = 0m;
        private decimal _ventasEfectivo = 0m;
        private decimal _ingresosMenores = 0m;
        private decimal _egresosMenores = 0m;
        private decimal _cobrosDigitales = 0m;
        private decimal _cobrosTarjetas = 0m;
        private CancellationTokenSource _ctsCarga;

        public FormCierreCaja()
        {
            InitializeComponent();
        }

        private async void FormCierreCaja_Load(object sender, EventArgs e)
        {
            _ctsCarga = new CancellationTokenSource();
            var token = _ctsCarga.Token;

            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoBóveda(Color.FromArgb(212, 131, 53));

            ObtenerDatosOperador();

            try
            {
                await ConsultarEstadoTurnoActualAsync(token);
                if (token.IsCancellationRequested) return;
            }
            catch (OperationCanceledException) { }

            if (!this.IsDisposed)
                ActualizarInterfazSegunEstado();
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

        private void ObtenerDatosOperador()
        {
            _nombreCajero = SesionUsuario.Nombre ?? "Cajero General";
            LInfoOperador.Text = $"Operador de Caja: {_nombreCajero} | Fecha: {DateTime.Now:dd/MM/yyyy}";
        }

        private Image GenerarIconoBóveda(Color color)
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(color, 2.2f))
                using (Brush brush = new SolidBrush(color))
                {
                    g.DrawRectangle(pen, 4f, 4f, 24f, 24f);
                    g.DrawEllipse(pen, 11f, 11f, 10f, 10f);
                    g.FillEllipse(brush, 14.5f, 14.5f, 3f, 3f);
                    g.DrawLine(pen, 16f, 8f, 16f, 11f);
                    g.DrawLine(pen, 16f, 21f, 16f, 24f);
                    g.DrawLine(pen, 8f, 16f, 11f, 16f);
                    g.DrawLine(pen, 21f, 16f, 24f, 16f);
                }
            }
            return bmp;
        }

        private async Task ConsultarEstadoTurnoActualAsync(CancellationToken token = default(CancellationToken))
        {
            try
            {
                var cajaActiva = await _cajaLogica.ObtenerActiva();

                if (token.IsCancellationRequested) return;
                if (this.IsDisposed || this.Disposing) return;

                if (cajaActiva == null)
                {
                    _cajaAbierta = false;
                    _idTurnoCaja = 0;
                    _numeroCajaActual = null;
                    _fondoInicial = 0m;
                    _ventasEfectivo = 0m;
                    _ingresosMenores = 0m;
                    _egresosMenores = 0m;
                    _cobrosDigitales = 0m;
                    _cobrosTarjetas = 0m;
                }
                else
                {
                    _cajaAbierta = true;
                    _idTurnoCaja = cajaActiva.Id;
                    _numeroCajaActual = cajaActiva.NumeroCaja;
                    _fondoInicial = cajaActiva.FondoInicial;
                    _ventasEfectivo = cajaActiva.TotalVentas;
                    _ingresosMenores = cajaActiva.TotalIngresos;
                    _egresosMenores = cajaActiva.TotalEgresos;
                    _cobrosDigitales = 0m;
                    _cobrosTarjetas = 0m;
                }

                RecalcularMetricasVisuales();
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No hay caja activa o error: {ex.Message}");
                _cajaAbierta = false;
                _idTurnoCaja = 0;
                _numeroCajaActual = null;
                _fondoInicial = 0m;
                _ventasEfectivo = 0m;
                _ingresosMenores = 0m;
                _egresosMenores = 0m;
                _cobrosDigitales = 0m;
                _cobrosTarjetas = 0m;
                RecalcularMetricasVisuales();
            }
        }

        private void RecalcularMetricasVisuales()
        {
            TBFondoInicial.Text = $"$ {_fondoInicial:N2}";
            TBVentasEfectivo.Text = $"$ {_ventasEfectivo:N2}";
            TBINGRESO.Text = $"$ {_ingresosMenores:N2}";
            TBEgresosMenores.Text = $"$ {_egresosMenores:N2}";

            TBCobrosDigitales.Text = $"$ {_cobrosDigitales:N2}";
            TBCobrosTarjetas.Text = $"$ {_cobrosTarjetas:N2}";

            decimal totalEnGaveta = _fondoInicial + _ventasEfectivo + _ingresosMenores - _egresosMenores;
            TBTotalGaveta.Text = $"$ {totalEnGaveta:N2}";
            this.Refresh();
        }

        private void ActualizarInterfazSegunEstado()
        {
            if (_cajaAbierta)
            {
                string numeroCajaTexto = _numeroCajaActual.HasValue ? _numeroCajaActual.Value.ToString() : $"id {_idTurnoCaja}";
                LEstadoTurno.Text = $"ESTADO: CAJA {numeroCajaTexto} (ABIERTA) ●";
                LEstadoTurno.ForeColor = Color.FromArgb(39, 174, 96);

                BAbrirTurno.Enabled = false;
                BAbrirTurno.BackColor = Color.FromArgb(180, 180, 180);
                BIngreso.Enabled = true;
                BIngreso.BackColor = Color.FromArgb(39, 174, 96);
                BEgreso.Enabled = true;
                BEgreso.BackColor = Color.FromArgb(192, 57, 43);
                BCerrarTurno.Enabled = true;
                BCerrarTurno.BackColor = Color.FromArgb(192, 57, 43);
            }
            else
            {
                LEstadoTurno.Text = "ESTADO: CAJA CERRADA ●";
                LEstadoTurno.ForeColor = Color.FromArgb(192, 57, 43);

                BAbrirTurno.Enabled = true;
                BAbrirTurno.BackColor = Color.FromArgb(39, 174, 96);
                BIngreso.Enabled = false;
                BIngreso.BackColor = Color.FromArgb(180, 180, 180);
                BEgreso.Enabled = false;
                BEgreso.BackColor = Color.FromArgb(180, 180, 180);
                BCerrarTurno.Enabled = false;
                BCerrarTurno.BackColor = Color.FromArgb(180, 180, 180);

                _fondoInicial = 0m;
                _ventasEfectivo = 0m;
                _ingresosMenores = 0m;
                _egresosMenores = 0m;
                _cobrosDigitales = 0m;
                _cobrosTarjetas = 0m;
                RecalcularMetricasVisuales();
            }
        }

        private async void BAbrirTurno_Click(object sender, EventArgs e)
        {
            using (FormModalAperturaCaja modalApertura = new FormModalAperturaCaja())
            {
                if (modalApertura.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        decimal fondo = modalApertura.FondoInicial;
                        int numeroCaja = modalApertura.NumeroCajaSeleccionada;

                        var nuevaCaja = new CrearCajaDto
                        {
                            PersonalId = SesionUsuario.IdPersonal,
                            NumeroCaja = numeroCaja,
                            FondoInicial = fondo
                        };

                        // 1. Abrir la caja en la API
                        var cajaCreada = await _cajaLogica.Abrir(nuevaCaja);

                        // 2. Recargar los datos desde la API para asegurar que tenemos los valores reales
                        await ConsultarEstadoTurnoActualAsync(_ctsCarga?.Token ?? CancellationToken.None);

                        // 3. Actualizar la interfaz
                        ActualizarInterfazSegunEstado();

                        // 4. Forzar el redibujado de la ventana
                        this.Refresh();

                        MessageBox.Show($"Caja {numeroCaja} abierta correctamente con un fondo de $ {fondo:N2}.",
                                        "Apertura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private async void BIngreso_Click(object sender, EventArgs e)
        {
            using (FormModalMovimientoMenor modalMov = new FormModalMovimientoMenor(1, 0m))
            {
                if (modalMov.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var movimiento = new CrearMovimientoCajaDto
                        {
                            CajaId = _idTurnoCaja,
                            PersonalId = SesionUsuario.IdPersonal,
                            TipoMovimientoId = 1,
                            Monto = modalMov.Monto,
                            Descripcion = modalMov.Motivo
                        };

                        await _movimientoLogica.Registrar(movimiento);
                        await ConsultarEstadoTurnoActualAsync(_ctsCarga?.Token ?? CancellationToken.None);
                        ActualizarInterfazSegunEstado();

                        MessageBox.Show($"Ingreso registrado por $ {modalMov.Monto:N2}.\nConcepto: {modalMov.Motivo}",
                                        "Comprobante de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al registrar ingreso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BEgreso_Click(object sender, EventArgs e)
        {
            decimal maximoDisponible = _fondoInicial + _ventasEfectivo + _ingresosMenores - _egresosMenores;

            using (FormModalMovimientoMenor modalMov = new FormModalMovimientoMenor(2, maximoDisponible))
            {
                if (modalMov.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var movimiento = new CrearMovimientoCajaDto
                        {
                            CajaId = _idTurnoCaja,
                            PersonalId = SesionUsuario.IdPersonal,
                            TipoMovimientoId = 2,
                            Monto = modalMov.Monto,
                            Descripcion = modalMov.Motivo
                        };

                        await _movimientoLogica.Registrar(movimiento);
                        await ConsultarEstadoTurnoActualAsync(_ctsCarga?.Token ?? CancellationToken.None);
                        ActualizarInterfazSegunEstado();

                        MessageBox.Show($"Egreso registrado por $ {modalMov.Monto:N2}.\nConcepto: {modalMov.Motivo}",
                                        "Comprobante de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al registrar egreso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BCerrarTurno_Click(object sender, EventArgs e)
        {
            decimal efectivoTeoricoEsperado = _fondoInicial + _ventasEfectivo + _ingresosMenores - _egresosMenores;

            using (FormModalArqueoCaja modalArqueo = new FormModalArqueoCaja(efectivoTeoricoEsperado))
            {
                if (modalArqueo.ShowDialog(this) == DialogResult.OK)
                {
                    decimal efectivoRealContado = modalArqueo.EfectivoReal;
                    decimal diferencia = modalArqueo.Diferencia;

                    try
                    {
                        await _cajaLogica.Cerrar(_idTurnoCaja);

                        string balance = diferencia == 0m ? "Caja Cuadrada" : (diferencia < 0m ? $"Faltante: $ {Math.Abs(diferencia):N2}" : $"Sobrante: $ {diferencia:N2}");
                        string numeroCajaTexto = _numeroCajaActual.HasValue ? _numeroCajaActual.Value.ToString() : $"id {_idTurnoCaja}";

                        // Fecha de cierre en hora local
                        string fechaCierre = FechaHelper.ToArgentinaString(DateTime.UtcNow, "dd/MM/yyyy HH:mm:ss");

                        string resumenCierre = $"=== RESUMEN DE CIERRE DE CAJA {numeroCajaTexto} ===\n\n" +
                                               $"--- EFECTIVO FÍSICO ---\n" +
                                               $"• Fondo Inicial: $ {_fondoInicial:N2}\n" +
                                               $"• Ventas en Efectivo: $ {_ventasEfectivo:N2}\n" +
                                               $"• Ingresos Menores: $ {_ingresosMenores:N2}\n" +
                                               $"• Egresos Menores: $ {_egresosMenores:N2}\n" +
                                               $"• Total Teórico Esperado: $ {efectivoTeoricoEsperado:N2}\n" +
                                               $"• Efectivo Físico Declarado: $ {efectivoRealContado:N2}\n" +
                                               $"• Resultado de Auditoría: {balance}\n\n" +
                                               $"--- COBROS DIGITALES ---\n" +
                                               $"• Transferencias / QR / MP: $ {_cobrosDigitales:N2}\n" +
                                               $"• Tarjetas Débito / Crédito: $ {_cobrosTarjetas:N2}\n" +
                                               $"• Total Digital: $ {(_cobrosDigitales + _cobrosTarjetas):N2}\n\n" +
                                               $"Fecha de cierre: {fechaCierre}\n" +
                                               $"El turno ha quedado bloqueado exitosamente.";

                        MessageBox.Show(resumenCierre, "Turno Cerrado con Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _cajaAbierta = false;
                        _idTurnoCaja = 0;
                        _numeroCajaActual = null;
                        ActualizarInterfazSegunEstado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cerrar el turno en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}