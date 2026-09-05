using System;

namespace CapaDatos.DTOs
{
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