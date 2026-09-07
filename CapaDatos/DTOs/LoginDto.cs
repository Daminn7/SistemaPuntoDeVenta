using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. LOGIN DTO - PARA AUTENTICACIÓN (POST)
    //    Se usa en: POST /api/auth/login
    // ============================================================
    public class LoginDto
    {
        public string CodUsuario { get; set; }
        public string Contrasena { get; set; }
    }
    
}