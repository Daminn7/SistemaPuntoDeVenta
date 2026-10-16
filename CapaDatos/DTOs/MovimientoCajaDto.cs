using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // MOVIMIENTO CAJA - DTO DE LECTURA
    // ============================================================

    /// <summary>
    /// DTO para leer un movimiento de caja desde la API.
    /// Se usa en: GET /api/caja/{id}/movimientos
    /// </summary>
    public class MovimientoCajaDto
    {
        public int IdMovimiento { get; set; }
        public int CajaId { get; set; }
        public int PersonalId { get; set; }
        public string PersonalNombre { get; set; }
        public int TipoMovimientoId { get; set; }
        public string TipoMovimientoDescripcion { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}