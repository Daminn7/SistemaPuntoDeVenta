using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // DETALLE ORDEN DTOs
    // ============================================================

    /// <summary>
    /// DTO para agregar un detalle a una orden.
    /// Se usa en: POST /api/ordenventa/{id}/detalles
    /// </summary>
    public class CrearDetalleOrdenDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    /// <summary>
    /// DTO para actualizar un detalle de orden.
    /// Se usa en: PUT /api/detalleorden/{id}
    /// </summary>
    public class ActualizarDetalleOrdenDto
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}