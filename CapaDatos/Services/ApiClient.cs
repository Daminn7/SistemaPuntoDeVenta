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

        // ========== USUARIOS ==========
        public async Task<List<UsuarioDto>> GetUsuariosAsync()
        {
            var response = await _httpClient.GetAsync("/api/usuarios");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UsuarioDto>>(content);
        }

        public async Task<UsuarioDto> GetUsuarioAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/usuarios/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsuarioDto>(content);
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioDto usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/usuarios", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsuarioDto>(responseContent);
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, UsuarioDto usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/usuarios/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsuarioDto>(responseContent);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/usuarios/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ========== PERSONAL ==========
        public async Task<List<PersonalDto>> GetPersonalAsync()
        {
            var response = await _httpClient.GetAsync("/api/personal");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PersonalDto>>(content);
        }

        public async Task<PersonalDto> GetPersonalByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/personal/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonalDto>(content);
        }

        public async Task<PersonalDto> CreatePersonalAsync(PersonalDto personal)
        {
            var content = new StringContent(JsonConvert.SerializeObject(personal), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/personal", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonalDto>(responseContent);
        }

        public async Task<PersonalDto> UpdatePersonalAsync(int id, PersonalDto personal)
        {
            var content = new StringContent(JsonConvert.SerializeObject(personal), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/personal/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonalDto>(responseContent);
        }

        public async Task DeletePersonalAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/personal/{id}");
            response.EnsureSuccessStatusCode();
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
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/productos", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductoDto>(responseContent);
        }

        public async Task<ProductoDto> UpdateProductoAsync(int id, ProductoDto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
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

        public async Task<List<ProductoStockBajoDto>> GetProductosStockBajoAsync()
        {
            var response = await _httpClient.GetAsync("/api/productos/stock-bajo");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(content);
            return JsonConvert.DeserializeObject<List<ProductoStockBajoDto>>(result.productos.ToString());
        }

        // ========== CLIENTES ==========
        public async Task<List<ClienteDto>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync("/api/clientes");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClienteDto>>(content);
        }

        public async Task<ClienteDto> GetClienteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/clientes/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClienteDto>(content);
        }

        public async Task<ClienteDto> CreateClienteAsync(ClienteDto cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/clientes", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClienteDto>(responseContent);
        }

        public async Task<ClienteDto> UpdateClienteAsync(int id, ClienteDto cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/clientes/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClienteDto>(responseContent);
        }

        public async Task DeleteClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/clientes/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ========== CATEGORIAS ==========
        public async Task<List<CategoriaDto>> GetCategoriasAsync()
        {
            var response = await _httpClient.GetAsync("/api/categorias");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CategoriaDto>>(content);
        }

        public async Task<CategoriaDto> GetCategoriaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/categorias/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriaDto>(content);
        }

        public async Task<CategoriaDto> CreateCategoriaAsync(CategoriaDto categoria)
        {
            var content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/categorias", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriaDto>(responseContent);
        }

        public async Task<CategoriaDto> UpdateCategoriaAsync(int id, CategoriaDto categoria)
        {
            var content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/categorias/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriaDto>(responseContent);
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/categorias/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ========== PROVEEDORES ==========
        public async Task<List<ProveedorDto>> GetProveedoresAsync()
        {
            var response = await _httpClient.GetAsync("/api/proveedores");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProveedorDto>>(content);
        }

        public async Task<ProveedorDto> GetProveedorAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/proveedores/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProveedorDto>(content);
        }

        public async Task<ProveedorDto> CreateProveedorAsync(ProveedorDto proveedor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/proveedores", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProveedorDto>(responseContent);
        }

        public async Task<ProveedorDto> UpdateProveedorAsync(int id, ProveedorDto proveedor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/proveedores/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProveedorDto>(responseContent);
        }

        public async Task DeleteProveedorAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/proveedores/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ========== VENTAS ==========
        public async Task<List<VentaDto>> GetVentasAsync()
        {
            var response = await _httpClient.GetAsync("/api/ventas");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<VentaDto>>(content);
        }

        public async Task<VentaDto> GetVentaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/ventas/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VentaDto>(content);
        }

        public async Task<VentaDto> CreateVentaAsync(VentaDto venta)
        {
            var content = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/ventas", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VentaDto>(responseContent);
        }

        public async Task<VentaDto> UpdateVentaAsync(int id, VentaDto venta)
        {
            var content = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/ventas/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VentaDto>(responseContent);
        }

        public async Task DeleteVentaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/ventas/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<dynamic> AnularVentaAsync(int id)
        {
            var response = await _httpClient.PostAsync($"/api/ventas/{id}/anular", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        // ========== CAJA ==========
        public async Task<List<CajaDto>> GetCajasAsync()
        {
            var response = await _httpClient.GetAsync("/api/caja");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CajaDto>>(content);
        }

        public async Task<CajaDto> GetCajaAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/caja/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CajaDto>(content);
        }

        public async Task<CajaDto> GetCajaActivaAsync()
        {
            var response = await _httpClient.GetAsync("/api/caja/activa");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CajaDto>(content);
        }

        public async Task<CajaDto> AbrirCajaAsync(CajaDto caja)
        {
            var content = new StringContent(JsonConvert.SerializeObject(caja), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/caja/apertura", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CajaDto>(responseContent);
        }

        public async Task<dynamic> CerrarCajaAsync(int id)
        {
            var response = await _httpClient.PutAsync($"/api/caja/{id}/cierre", null);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        // ========== TABLAS MAESTRAS ==========
        public async Task<List<ProvinciaDto>> GetProvinciasAsync()
        {
            var response = await _httpClient.GetAsync("/api/provincias");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProvinciaDto>>(content);
        }

        public async Task<List<LocalidadDto>> GetLocalidadesAsync()
        {
            var response = await _httpClient.GetAsync("/api/localidades");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<LocalidadDto>>(content);
        }

        public async Task<List<PerfilDto>> GetPerfilesAsync()
        {
            var response = await _httpClient.GetAsync("/api/perfiles");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PerfilDto>>(content);
        }

        public async Task<List<TipoDocumentoDto>> GetTipoDocumentosAsync()
        {
            var response = await _httpClient.GetAsync("/api/tipodocumentos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TipoDocumentoDto>>(content);
        }

        public async Task<List<EstadoVentaDto>> GetEstadoVentasAsync()
        {
            var response = await _httpClient.GetAsync("/api/estadoventas");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<EstadoVentaDto>>(content);
        }

        public async Task<List<MedioPagoDto>> GetMedioPagosAsync()
        {
            var response = await _httpClient.GetAsync("/api/mediopagos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<MedioPagoDto>>(content);
        }

        public async Task<List<TipoMovimientoDto>> GetTipoMovimientosAsync()
        {
            var response = await _httpClient.GetAsync("/api/tipomovimientos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TipoMovimientoDto>>(content);
        }

        // ========== REPORTES ==========
        public async Task<dynamic> GetReporteVentasDiaAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/ventas/dia");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> GetReporteVentasSemanaAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/ventas/semana");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> GetReporteProductosMasVendidosAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/productos/mas-vendidos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> GetReporteStockBajoAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/stock-bajo");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> GetReporteCajaDiaAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/caja/dia");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> GetResumenGeneralAsync()
        {
            var response = await _httpClient.GetAsync("/api/reportes/resumen");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        // ========== HEALTH CHECK ==========
        public async Task<dynamic> HealthCheckAsync()
        {
            var response = await _httpClient.GetAsync("/health");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}