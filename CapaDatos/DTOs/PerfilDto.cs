using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PERFIL DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/perfiles, GET /api/perfiles/{id}
    // ============================================================
    public class PerfilDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PERFIL DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/perfiles
    // ============================================================
    public class CrearPerfilDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PERFIL DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/perfiles/{id}
    // ============================================================
    public class ActualizarPerfilDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}