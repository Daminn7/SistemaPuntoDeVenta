using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. PERSONAL DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/personal, GET /api/personal/{id}
    // ============================================================
    public class PersonalDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR PERSONAL DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/personal
    // ============================================================
    public class CrearPersonalDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public string Contrasena { get; set; }
        public int PerfilId { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR PERSONAL DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/personal/{id}
    // ============================================================
    public class ActualizarPersonalDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public int PerfilId { get; set; }
        public bool Estado { get; set; }
    }
}