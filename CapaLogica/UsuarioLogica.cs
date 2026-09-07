using CapaDatos;
using System;
using System.Text.RegularExpressions;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - USUARIO
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos (UsuarioDatos).
    // Contiene la lógica de negocio para la autenticación de usuarios.
    // ============================================================

    public class UsuarioLogica
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Valida las credenciales de un usuario contra la API.
        /// </summary>
        /// <param name="usuario">Código de usuario</param>
        /// <param name="password">Contraseña</param>
        /// <param name="rol">Perfil del usuario (Administrador, Vendedor, etc.)</param>
        /// <param name="nombreCompleto">Nombre completo del usuario</param>
        /// <returns>String vacío si es exitoso, mensaje de error si falla</returns>
        public string ValidarLogin(string usuario, string password, out string rol, out string nombreCompleto)
        {
            // ============================================================
            // INICIALIZACIÓN DE PARÁMETROS DE SALIDA
            // ============================================================
            rol = string.Empty;
            nombreCompleto = string.Empty;

            // ============================================================
            // VALIDACIONES DE ENTRADA
            // ============================================================

            // 1. Validar que el usuario no esté vacío
            if (string.IsNullOrWhiteSpace(usuario))
                return "Debe ingresar su código de usuario.";

            // 2. Validar que la contraseña no esté vacía
            if (string.IsNullOrWhiteSpace(password))
                return "Debe ingresar su contraseña.";

            // 3. Validar que el usuario solo contenga letras y números
            if (!Regex.IsMatch(usuario, @"^[a-zA-Z0-9]+$"))
                return "El código solo puede contener letras y números.";

            // 4. Validar que la contraseña solo contenga caracteres permitidos
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9@#$%*!_\-\.]+$"))
                return "La contraseña contiene caracteres no permitidos. Solo se aceptan letras, números y los símbolos: @ # $ % * ! _ - .";

            // ============================================================
            // AUTENTICACIÓN CONTRA LA API
            // ============================================================
            try
            {
                // Intentar autenticar contra la API
                bool autenticado = _usuarioDatos.Autenticar(usuario, password, out rol, out nombreCompleto);

                // Si no se autentica, devolver mensaje de error
                if (!autenticado)
                    return "Código de usuario o contraseña incorrectos.";

                // Autenticación exitosa
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Error de conexión o excepción no controlada
                return $"Error de conexión con el servidor: {ex.Message}";
            }
        }
    }
}