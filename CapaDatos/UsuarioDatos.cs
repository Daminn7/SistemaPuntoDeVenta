using System;
using System.Threading.Tasks;
using CapaDatos.DTOs;
using CapaDatos.Services;
using CapaDatos.Helpers;

namespace CapaDatos
{
    public class UsuarioDatos
    {
        private readonly ApiClient _apiClient;

        // URL base de tu API (cambiala si es necesario)
        private const string API_BASE_URL = "https://api.serverlabservices.bot.cd";

        public UsuarioDatos()
        {
            _apiClient = new ApiClient(API_BASE_URL);
        }

        /// <summary>
        /// Autentica al usuario contra la API REST.
        /// </summary>
        public bool Autenticar(string codigoAcceso, string password, out string rol, out string nombreCompleto)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;

            try
            {
                // Llamada sincrona a la API (para no romper la firma existente)
                var task = Task.Run(async () => await _apiClient.LoginAsync(codigoAcceso, password));
                var result = task.Result;

                if (result != null && result.Success)
                {
                    rol = result.Perfil ?? "Usuario";
                    nombreCompleto = result.NombreCompleto ?? codigoAcceso;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Si la API falla, podemos loguear el error
                System.Diagnostics.Debug.WriteLine($"Error en autenticacion API: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Obtiene el token actual del usuario autenticado.
        /// </summary>
        public string ObtenerToken()
        {
            return TokenManager.Token;
        }

        /// <summary>
        /// Verifica si el token actual es valido.
        /// </summary>
        public bool TokenValido()
        {
            return TokenManager.IsTokenValid();
        }

        /// <summary>
        /// Cierra la sesion actual limpiando el token.
        /// </summary>
        public void CerrarSesion()
        {
            TokenManager.ClearToken();
        }
    }
}