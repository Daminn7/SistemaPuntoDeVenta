using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. TELEFONO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/telefonos, GET /api/telefonos/{id}
    // ============================================================
    public class TelefonoDto
    {
        public int Id { get; set; }
        public string Caracteristica { get; set; }
        public int Numero { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR TELEFONO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/telefonos
    // ============================================================
    public class CrearTelefonoDto
    {
        public string Caracteristica { get; set; }
        public int Numero { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR TELEFONO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/telefonos/{id}
    // ============================================================
    public class ActualizarTelefonoDto
    {
        public string Caracteristica { get; set; }
        public int Numero { get; set; }
        public bool Estado { get; set; }
    }
}