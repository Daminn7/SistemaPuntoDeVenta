using CapaDatos;
using System;
using System.Text.RegularExpressions;

namespace CapaLogica
{
    public class UsuarioLogica
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();

        public string ValidarLogin(string usuario, string password, out string rol, out string nombreCompleto)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;

            if (string.IsNullOrWhiteSpace(usuario))
                return "Debe ingresar su código de usuario.";

            if (string.IsNullOrWhiteSpace(password))
                return "Debe ingresar su contraseña.";

            if (!Regex.IsMatch(usuario, @"^[a-zA-Z0-9]+$"))
                return "El código solo puede contener letras y números.";

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9@#$%*!_\-\.]+$"))
                return "La contraseña contiene caracteres no permitidos. Solo se aceptan letras, números y los símbolos: @ # $ % * ! _ - .";

            try
            {
                bool autenticado = _usuarioDatos.Autenticar(usuario, password, out rol, out nombreCompleto);

                if (!autenticado)
                    return "Código de usuario o contraseña incorrectos.";

                return string.Empty;
            }
            catch (Exception ex)
            {
                return $"Error de conexión con el servidor: {ex.Message}";
            }
        }
    }
}