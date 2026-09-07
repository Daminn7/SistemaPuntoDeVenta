using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PROVINCIA DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/provincias, GET /api/provincias/{id}
    // ============================================================
    public class ProvinciaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PROVINCIA DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/provincias
    // ============================================================
    public class CrearProvinciaDto
    {
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PROVINCIA DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/provincias/{id}
    // ============================================================
    public class ActualizarProvinciaDto
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}