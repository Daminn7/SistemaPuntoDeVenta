using CapaDatos;
using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CapaLogica
{
    // ============================================================
    // CAPA LÓGICA - USUARIO
    // ============================================================
    // Esta clase es el intermediario entre la presentación (formularios)
    // y la capa de datos.
    // Contiene la lógica de negocio para la autenticación y gestión de usuarios.
    // ============================================================

    public class UsuarioLogica
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();
        private readonly ApiClient _apiClient;

        // ============================================================
        // CONSTRUCTOR
        // ============================================================
        public UsuarioLogica()
        {
            _apiClient = new ApiClient("https://api.serverlabservices.bot.cd");
            if (TokenManager.IsAuthenticated)
                _apiClient.SetToken(TokenManager.Token);
        }

        // ============================================================
        // MÉTODOS PÚBLICOS
        // ============================================================

        /// <summary>
        /// Valida las credenciales de un usuario contra la API.
        /// </summary>
        public string ValidarLogin(string usuario, string password, out string rol, out string nombreCompleto)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;

            // Validaciones de entrada
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
            catch (System.Net.Http.HttpRequestException)
            {
                // ✅ Error de conexión a la API
                return "Error de conexión con el servidor. No se pudo contactar con la API.";
            }
            catch (Exception ex)
            {
                return $"Error de conexión con el servidor: {ex.Message}";
            }
        }

        /// <summary>
        /// Crea un nuevo usuario (cliente, personal o proveedor).
        /// Se usa en: POST /api/usuarios
        /// </summary>
        public async Task<UsuarioDto> CrearUsuario(CrearUsuarioDto usuario)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Dni))
                throw new Exception("El DNI es obligatorio.");

            // Para clientes: codUsuario y contrasena van vacíos
            if (usuario.EsCliente)
            {
                usuario.CodUsuario = null;
                usuario.Contrasena = null;
                usuario.PerfilId = null;
            }

            try
            {
                // Llamar a la API
                return await _apiClient.CreateUsuarioAsync(usuario);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al crear usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear usuario: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// Se usa en: PUT /api/usuarios/{id}
        /// </summary>
        /// <param name="id">ID del usuario a actualizar</param>
        /// <param name="usuario">Datos actualizados del usuario</param>
        /// <returns>Usuario actualizado</returns>
        public async Task<UsuarioDto> ActualizarUsuario(int id, ActualizarUsuarioDto usuario)
        {
            // Validaciones de negocio
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new Exception("El email es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Dni))
                throw new Exception("El DNI es obligatorio.");

            try
            {
                // Llamar a la API
                return await _apiClient.UpdateUsuarioAsync(id, usuario);
            }
            catch (System.Net.Http.HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar usuario: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar usuario: {ex.Message}");
            }
        }
    }
}