using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // MOVIMIENTO CAJA DTOs
    // ============================================================

    /// <summary>
    /// DTO para registrar un movimiento de caja.
    /// Se usa en: POST /api/caja/movimiento
    /// </summary>
    public class CrearMovimientoCajaDto
    {
        public int CajaId { get; set; }
        public int PersonalId { get; set; }
        public int TipoMovimientoId { get; set; }  // 1=Ingreso, 2=Egreso, 3=Apertura, 4=Cierre, 5=Retiro, 6=Deposito, 7=Ajuste
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
    }
}