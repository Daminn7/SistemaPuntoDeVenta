using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using CapaDatos.DTOs;
using CapaDatos.Helpers;

namespace CapaDatos.Services
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private string _token;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetToken(string token)
        {
            _token = token;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        // ========== AUTENTICACION ==========
        public async Task<LoginResponseDto> LoginAsync(string codUsuario, string contrasena)
        {
            var request = new LoginDto { CodUsuario = codUsuario, Contrasena = contrasena };
            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("/api/auth/login", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginResponseDto>(responseContent);

            if (result?.Success == true && !string.IsNullOrEmpty(result.Token))
            {
                SetToken(result.Token);
                TokenManager.SetToken(result.Token, result.FechaExpiracion ?? DateTime.UtcNow.AddHours(8));
            }

            return result;
        }

        // ========== PRODUCTOS ==========
        public async Task<List<ProductoDto>> GetProductosAsync()
        {
            var response = await _httpClient.GetAsync("/api/productos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductoDto>>(content);
        }

        public async Task<ProductoDto> GetProductoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/productos/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductoDto>(content);
        }

        public async Task<ProductoDto> CreateProductoAsync(ProductoDto producto)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(producto),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("/api/productos", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductoDto>(responseContent);
        }

        public async Task<ProductoDto> UpdateProductoAsync(int id, ProductoDto producto)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(producto),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PutAsync($"/api/productos/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductoDto>(responseContent);
        }

        public async Task DeleteProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/productos/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ========== VENTAS ==========
        public async Task<dynamic> CreateVentaAsync(dynamic venta)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(venta),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("/api/ventas", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> GetVentasAsync()
        {
            var response = await _httpClient.GetAsync("/api/ventas");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        // ========== CAJA ==========
        public async Task<dynamic> AbrirCajaAsync(dynamic caja)
        {
            var content = new StringContent(
                JsonConvert.SerializeObject(caja),
                Encoding.UTF8,
                "application/json");
            var response = await _httpClient.PostAsync("/api/caja/apertura", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> CerrarCajaAsync(int id)
        {
            var response = await _httpClient.PutAsync($"/api/caja/{id}/cierre", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        // ========== REPORTES ==========
        public async Task<dynamic> GetResumenGeneralAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/resumen");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}