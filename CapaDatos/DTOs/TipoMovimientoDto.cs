using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. TIPO MOVIMIENTO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/tipomovimientos, GET /api/tipomovimientos/{id}
    // ============================================================
    public class TipoMovimientoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR TIPO MOVIMIENTO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/tipomovimientos
    // ============================================================
    public class CrearTipoMovimientoDto
    {
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR TIPO MOVIMIENTO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/tipomovimientos/{id}
    // ============================================================
    public class ActualizarTipoMovimientoDto
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}