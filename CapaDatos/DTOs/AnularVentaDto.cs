using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // ANULAR VENTA DTO
    // ============================================================

    /// <summary>
    /// DTO para anular una venta.
    /// Se usa en: POST /api/ventas/{id}/anular
    /// </summary>
    public class AnularVentaDto
    {
        public string Motivo { get; set; }
    }
}