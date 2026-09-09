using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. MEDIO PAGO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/mediopagos, GET /api/mediopagos/{id}
    // ============================================================
    public class MedioPagoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR MEDIO PAGO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/mediopagos
    // ============================================================
    public class CrearMedioPagoDto
    {
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR MEDIO PAGO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/mediopagos/{id}
    // ============================================================
    public class ActualizarMedioPagoDto
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}