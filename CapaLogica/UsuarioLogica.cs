using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();

        public string ValidarLogin(string usuario, string password, out string rol, out string nombreCompleto)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;

            // 1. Validaciones individuales de obligatoriedad
            if (string.IsNullOrWhiteSpace(usuario))
                return "Debe ingresar su código de usuario.";

            if (string.IsNullOrWhiteSpace(password))
                return "Debe ingresar su contraseña.";

            // 2. Validación de formato para el Usuario/Código (solo alfanumérico)
            if (!Regex.IsMatch(usuario, @"^[a-zA-Z0-9]+$"))
            {
                return "El código solo puede contener letras y números.";
            }

            // 3. Validación de formato para Contraseña (alfanumérico + @ # $ % * ! _ - .)
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9@#$%*!_\-\.]+$"))
            {
                return "La contraseña contiene caracteres no permitidos. Solo se aceptan letras, números y los símbolos: @ # $ % * ! _ - .";
            }

            // Delegamos la verificación a CapaDatos
            bool autenticado = _usuarioDatos.Autenticar(usuario, password, out rol, out nombreCompleto);

            if (!autenticado)
                return "Código de usuario o contraseña incorrectos.";

            return string.Empty; // Sin errores
        }
    }
}
