using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CapaPresentacion.FormPrincipal;

namespace CapaPresentacion
{
    public partial class FormCierreCaja : Form
    {
        // =========================================================================
        // VARIABLES Y ESTADO DEL TURNO
        // =========================================================================
        private bool _cajaAbierta = false;
        private int _idTurnoCaja = 0;
        private string _nombreCajero = "Operador";

        // Acumuladores contables del turno
        private decimal _fondoInicial = 0m;
        private decimal _ventasEfectivo = 0m;
        private decimal _cobrosDigitales = 0m;
        private decimal _cobrosTarjetas = 0m;
        private decimal _egresosMenores = 0m;

        public FormCierreCaja()
        {
            InitializeComponent();
        }

        // =========================================================================
        // CARGA DEL FORMULARIO
        // =========================================================================
        private async void FormCierreCaja_Load(object sender, EventArgs e)
        {
            if (PBIconoTitulo != null)
                PBIconoTitulo.Image = GenerarIconoBóveda(Color.FromArgb(212, 131, 53));

            ObtenerDatosOperador();
            await ConsultarEstadoTurnoActualAsync();
            ActualizarInterfazSegunEstado();
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

        private async Task ConsultarEstadoTurnoActualAsync()
        {
            try
            {
                // Conexión futura con _cajaLogica.ObtenerTurnoActivoAsync()
                await Task.Delay(100);

                _cajaAbierta = false;
                _idTurnoCaja = 1042;

                _fondoInicial = 20000.00m;
                _ventasEfectivo = 85400.00m;
                _cobrosDigitales = 42000.00m;
                _cobrosTarjetas = 31500.00m;
                _egresosMenores = 5000.00m;

                RecalcularMetricasVisuales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el turno de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcularMetricasVisuales()
        {
            TBFondoInicial.Text = $"$ {_fondoInicial:N2}";
            TBVentasEfectivo.Text = $"$ {_ventasEfectivo:N2}";
            TBCobrosDigitales.Text = $"$ {_cobrosDigitales:N2}";
            TBCobrosTarjetas.Text = $"$ {_cobrosTarjetas:N2}";
            TBEgresosMenores.Text = $"$ {_egresosMenores:N2}";

            decimal totalEnGaveta = _fondoInicial + _ventasEfectivo - _egresosMenores;
            TBTotalGaveta.Text = $"$ {totalEnGaveta:N2}";
        }

        private void ActualizarInterfazSegunEstado()
        {
            if (_cajaAbierta)
            {
                LEstadoTurno.Text = $"ESTADO: TURNO N° {_idTurnoCaja} (ABIERTO) ●";
                LEstadoTurno.ForeColor = Color.FromArgb(39, 174, 96);

                BAbrirTurno.Enabled = false;
                BAbrirTurno.BackColor = Color.FromArgb(180, 180, 180);

                BMovimientoMenor.Enabled = true;
                BMovimientoMenor.BackColor = Color.FromArgb(48, 51, 57);

                BCerrarTurno.Enabled = true;
                BCerrarTurno.BackColor = Color.FromArgb(192, 57, 43);
            }
            else
            {
                LEstadoTurno.Text = "ESTADO: CAJA CERRADA ●";
                LEstadoTurno.ForeColor = Color.FromArgb(192, 57, 43);

                BAbrirTurno.Enabled = true;
                BAbrirTurno.BackColor = Color.FromArgb(39, 174, 96);

                BMovimientoMenor.Enabled = false;
                BMovimientoMenor.BackColor = Color.FromArgb(180, 180, 180);

                BCerrarTurno.Enabled = false;
                BCerrarTurno.BackColor = Color.FromArgb(180, 180, 180);

                _fondoInicial = 0m;
                _ventasEfectivo = 0m;
                _cobrosDigitales = 0m;
                _cobrosTarjetas = 0m;
                _egresosMenores = 0m;
                RecalcularMetricasVisuales();
            }
        }

        // =========================================================================
        // ACCIÓN 1: APERTURA DE TURNO (C# PURO CON MODAL NATIVO)
        // =========================================================================
        private async void BAbrirTurno_Click(object sender, EventArgs e)
        {
            using (FormModalAperturaCaja modalApertura = new FormModalAperturaCaja())
            {
                if (modalApertura.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        decimal fondo = modalApertura.FondoInicial;

                        // Conexión futura con _cajaLogica.AbrirTurnoAsync(fondo, usuarioId)
                        await Task.Delay(150);

                        _fondoInicial = fondo;
                        _cajaAbierta = true;
                        _idTurnoCaja = new Random().Next(1000, 9999);

                        RecalcularMetricasVisuales();
                        ActualizarInterfazSegunEstado();

                        MessageBox.Show($"Turno N° {_idTurnoCaja} abierto correctamente con un fondo de $ {fondo:N2}.",
                                        "Apertura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al abrir turno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // =========================================================================
        // ACCIÓN 2: REGISTRO DE MOVIMIENTO MENOR (C# PURO CON MODAL NATIVO)
        // =========================================================================
        private void BMovimientoMenor_Click(object sender, EventArgs e)
        {
            decimal maximoDisponible = _fondoInicial + _ventasEfectivo - _egresosMenores;

            using (FormModalMovimientoMenor modalMov = new FormModalMovimientoMenor(maximoDisponible))
            {
                if (modalMov.ShowDialog(this) == DialogResult.OK)
                {
                    decimal monto = modalMov.MontoEgreso;
                    string motivo = modalMov.MotivoEgreso;

                    _egresosMenores += monto;
                    RecalcularMetricasVisuales();

                    MessageBox.Show($"Egreso registrado por $ {monto:N2}.\nConcepto: {motivo}",
                                    "Comprobante de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // =========================================================================
        // ACCIÓN 3: ARQUEO Y CIERRE DE TURNO
        // =========================================================================
        private async void BCerrarTurno_Click(object sender, EventArgs e)
        {
            decimal efectivoTeoricoEsperado = _fondoInicial + _ventasEfectivo - _egresosMenores;

            using (FormModalArqueoCaja modalArqueo = new FormModalArqueoCaja(efectivoTeoricoEsperado))
            {
                if (modalArqueo.ShowDialog(this) == DialogResult.OK)
                {
                    decimal efectivoRealContado = modalArqueo.EfectivoReal;
                    decimal diferencia = modalArqueo.Diferencia;
                    string observaciones = modalArqueo.Observaciones;

                    try
                    {
                        // Conexión futura con _cajaLogica.CerrarTurnoAsync(...)
                        await Task.Delay(200);

                        string balance = diferencia == 0m
                            ? "Caja Cuadrada"
                            : (diferencia < 0m ? $"Faltante: $ {Math.Abs(diferencia):N2}" : $"Sobrante: $ {diferencia:N2}");

                        string resumenCierre = $"=== RESUMEN DE CIERRE DE CAJA (TURNO N° {_idTurnoCaja}) ===\n\n" +
                                               $"• Cajero: {_nombreCajero}\n" +
                                               $"• Fondo Inicial: $ {_fondoInicial:N2}\n" +
                                               $"• Cobros en Efectivo: $ {_ventasEfectivo:N2}\n" +
                                               $"• Retiros Menores: $ {_egresosMenores:N2}\n" +
                                               $"• Total Teórico Esperado: $ {efectivoTeoricoEsperado:N2}\n" +
                                               $"------------------------------------------------------\n" +
                                               $"• Efectivo Físico Declarado: $ {efectivoRealContado:N2}\n" +
                                               $"• Resultado de Auditoría: {balance}\n" +
                                               $"• Pagos Digitales / Bancarios: $ {(_cobrosDigitales + _cobrosTarjetas):N2}\n\n" +
                                               $"El turno ha quedado bloqueado exitosamente.";

                        MessageBox.Show(resumenCierre, "Turno Cerrado con Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _cajaAbierta = false;
                        _idTurnoCaja = 0;
                        ActualizarInterfazSegunEstado();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al asentar el cierre en la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

