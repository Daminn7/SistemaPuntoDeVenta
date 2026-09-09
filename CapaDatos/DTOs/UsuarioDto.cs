using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. USUARIO DTO - PARA CONSULTAS (GET)
    //    Se usa en: GET /api/usuarios, GET /api/usuarios/{id}
    // ============================================================
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public int? DireccionId { get; set; }
        public int? TelefonoId { get; set; }
        public bool EsPersonal { get; set; }
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // ============================================================
    // 2. CREAR USUARIO DTO - PARA CREACIÓN (POST)
    //    Se usa en: POST /api/usuarios
    // ============================================================
    public class CrearUsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public string Contrasena { get; set; }
        public int? PerfilId { get; set; }
        public int? DireccionId { get; set; }
        public int? TelefonoId { get; set; }
        public bool EsPersonal { get; set; }
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }
    }

    // ============================================================
    // 3. ACTUALIZAR USUARIO DTO - PARA MODIFICACIÓN (PUT)
    //    Se usa en: PUT /api/usuarios/{id}
    // ============================================================
    public class ActualizarUsuarioDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string CuilCuit { get; set; }
        public string Email { get; set; }
        public string CodUsuario { get; set; }
        public int? PerfilId { get; set; }
        public int? DireccionId { get; set; }
        public int? TelefonoId { get; set; }
        public bool EsPersonal { get; set; }
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }
        public bool Estado { get; set; }
    }
}