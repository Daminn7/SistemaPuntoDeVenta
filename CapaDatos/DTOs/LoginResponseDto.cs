using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 2. LOGIN RESPONSE DTO - RESPUESTA DEL LOGIN (RESPONSE)
    //    Devuelve el token y datos del usuario autenticado.
    //    Se usa en: POST /api/auth/login (Response)
    // ============================================================
    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public int? PersonalId { get; set; }
        public string NombreCompleto { get; set; }
        public string Perfil { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}