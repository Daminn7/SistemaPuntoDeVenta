using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. VENTA DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/ventas, GET /api/ventas/{id}
    // ============================================================
    public class VentaDto
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int PersonalId { get; set; }
        public string PersonalNombre { get; set; }
        public int CajaId { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
        public DateTime FechaCobro { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR VENTA DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/ventas
    // ============================================================
    public class CrearVentaDto
    {
        public int OrdenId { get; set; }
        public int PersonalId { get; set; }
        public int CajaId { get; set; }
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR VENTA DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/ventas/{id}
    // ============================================================
    public class ActualizarVentaDto
    {
        public decimal TotalCobrado { get; set; }
        public decimal DescuentoAplicado { get; set; }
        public decimal RecargoAplicado { get; set; }
        public bool Estado { get; set; }
    }
}