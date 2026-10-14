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

        private const string API_BASE_URL = "https://api.serverlabservices.bot.cd";

        public UsuarioDatos()
        {
            _apiClient = new ApiClient(API_BASE_URL);
        }

        /// <summary>
        /// Autentica al usuario contra la API REST.
        /// ✅ MODIFICADO: Se agregó el parámetro out int personalId
        /// </summary>
        public bool Autenticar(string codigoAcceso, string password,
                               out string rol,
                               out string nombreCompleto,
                               out int personalId)
        {
            rol = string.Empty;
            nombreCompleto = string.Empty;
            personalId = 0;

            try
            {
                var task = Task.Run(async () => await _apiClient.LoginAsync(codigoAcceso, password));
                var result = task.Result;

                if (result != null && result.Success)
                {
                    rol = result.Perfil ?? "Usuario";
                    nombreCompleto = result.NombreCompleto ?? codigoAcceso;
                    personalId = result.PersonalId ?? 0;   // ✅ NUEVO
                    return true;
                }

                return false;
            }
            catch (AggregateException ex) when (ex.InnerException is System.Net.Http.HttpRequestException)
            {
                System.Diagnostics.Debug.WriteLine($"Error de conexión en autenticación: {ex.InnerException.Message}");
                throw new System.Net.Http.HttpRequestException("No se pudo conectar con el servidor. Verifique su conexión.");
            }
            catch (System.Net.Http.HttpRequestException)
            {
                System.Diagnostics.Debug.WriteLine("Error de conexión en autenticación");
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en autenticacion API: {ex.Message}");
                return false;
            }
        }

        public string ObtenerToken()
        {
            return TokenManager.Token;
        }

        public bool TokenValido()
        {
            return TokenManager.IsTokenValid();
        }

        public void CerrarSesion()
        {
            TokenManager.ClearToken();
        }
    }
}