using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. LOCALIDAD DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/localidades, GET /api/localidades/{id}
    // ============================================================
    public class LocalidadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int CodPostal { get; set; }
        public ProvinciaDto Provincia { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR LOCALIDAD DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/localidades
    // ============================================================
    public class CrearLocalidadDto
    {
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int CodPostal { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR LOCALIDAD DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/localidades/{id}
    // ============================================================
    public class ActualizarLocalidadDto
    {
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int CodPostal { get; set; }
        public bool Estado { get; set; }
    }
}