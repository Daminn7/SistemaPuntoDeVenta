using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        // ============================================================
        // AUTENTICACION
        // ============================================================
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

        // ============================================================
        // USUARIOS
        // ============================================================
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

        public async Task<UsuarioDto> CreateUsuarioAsync(CrearUsuarioDto usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/usuarios", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsuarioDto>(responseContent);
        }

        public async Task<UsuarioDto> UpdateUsuarioAsync(int id, ActualizarUsuarioDto usuario)
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

        // ============================================================
        // PERSONAL
        // ============================================================
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

        public async Task<PersonalDto> CreatePersonalAsync(CrearPersonalDto personal)
        {
            var content = new StringContent(JsonConvert.SerializeObject(personal), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/personal", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PersonalDto>(responseContent);
        }

        public async Task<PersonalDto> UpdatePersonalAsync(int id, ActualizarPersonalDto personal)
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

        // ============================================================
        // PRODUCTOS
        // ============================================================
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

        public async Task<ProductoDto> CreateProductoAsync(CrearProductoDto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/productos", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductoDto>(responseContent);
        }

        public async Task<ProductoDto> UpdateProductoAsync(int id, ActualizarProductoDto producto)
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

        // ============================================================
        // CLIENTES
        // ============================================================
        public async Task<List<ClienteResponseDto>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync("/api/clientes");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ClienteResponseDto>>(content);
        }

        public async Task<ClienteResponseDto> GetClienteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/clientes/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ClienteResponseDto>(content);
        }

        public async Task<dynamic> CreateClienteAsync(CrearClienteDto cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/clientes", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> UpdateClienteAsync(int id, CrearClienteDto cliente)
        {
            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/clientes/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task DeleteClienteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/clientes/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ============================================================
        // DIRECCIONES
        // ============================================================
        public async Task<List<DireccionDto>> GetDireccionesAsync()
        {
            var response = await _httpClient.GetAsync("/api/direcciones");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<DireccionDto>>(content);
        }

        public async Task<DireccionDto> GetDireccionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/direcciones/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DireccionDto>(content);
        }
        public async Task<DireccionDto> CreateDireccionAsync(CrearDireccionDto direccion)
        {
            var json = JsonConvert.SerializeObject(direccion);

            System.Diagnostics.Debug.WriteLine($"JSON enviado a /api/direcciones: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/direcciones", content);

            var responseContent = await response.Content.ReadAsStringAsync();

            // ✅ Mostrar más detalles
            System.Diagnostics.Debug.WriteLine($"Status: {response.StatusCode}");
            System.Diagnostics.Debug.WriteLine($"Respuesta: '{responseContent}'");
            System.Diagnostics.Debug.WriteLine($"Headers: {response.Headers}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error {response.StatusCode}: {responseContent}");
            }

            return JsonConvert.DeserializeObject<DireccionDto>(responseContent);
        }

        public async Task<DireccionDto> UpdateDireccionAsync(int id, ActualizarDireccionDto direccion)
        {
            var content = new StringContent(JsonConvert.SerializeObject(direccion), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/direcciones/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DireccionDto>(responseContent);
        }

        public async Task DeleteDireccionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/direcciones/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ============================================================
        // TELEFONOS
        // ============================================================
        public async Task<List<TelefonoDto>> GetTelefonosAsync()
        {
            var response = await _httpClient.GetAsync("/api/telefonos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TelefonoDto>>(content);
        }

        public async Task<TelefonoDto> GetTelefonoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/telefonos/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TelefonoDto>(content);
        }

        public async Task<TelefonoDto> CreateTelefonoAsync(CrearTelefonoDto telefono)
        {
            var json = JsonConvert.SerializeObject(telefono);
            System.Diagnostics.Debug.WriteLine($"JSON enviado a /api/telefonos: {json}");

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/telefonos", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TelefonoDto>(responseContent);
        }

        public async Task<TelefonoDto> UpdateTelefonoAsync(int id, ActualizarTelefonoDto telefono)
        {
            var content = new StringContent(JsonConvert.SerializeObject(telefono), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/telefonos/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TelefonoDto>(responseContent);
        }

        public async Task DeleteTelefonoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/telefonos/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ============================================================
        // CATEGORIAS
        // ============================================================
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

        public async Task<CategoriaDto> CreateCategoriaAsync(CrearCategoriaDto categoria)
        {
            var content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/categorias", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CategoriaDto>(responseContent);
        }

        public async Task<CategoriaDto> UpdateCategoriaAsync(int id, ActualizarCategoriaDto categoria)
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

        // ============================================================
        // PROVEEDORES
        // ============================================================
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

        public async Task<ProveedorDto> CreateProveedorAsync(CrearProveedorDto proveedor)
        {
            var content = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/proveedores", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProveedorDto>(responseContent);
        }

        public async Task<ProveedorDto> UpdateProveedorAsync(int id, ActualizarProveedorDto proveedor)
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

        // ============================================================
        // VENTAS
        // ============================================================
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

        public async Task<VentaDto> CreateVentaAsync(CrearVentaDto venta)
        {
            var content = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/ventas", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<VentaDto>(responseContent);
        }

        public async Task<VentaDto> UpdateVentaAsync(int id, ActualizarVentaDto venta)
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

        public async Task<dynamic> AnularVentaAsync(int id, AnularVentaDto motivo)
        {
            var content = new StringContent(JsonConvert.SerializeObject(motivo), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/ventas/{id}/anular", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        // ============================================================
        // ORDENES Y DETALLES
        // ============================================================
        public async Task<dynamic> GetDetallesByOrdenIdAsync(int ordenId)
        {
            var response = await _httpClient.GetAsync($"/api/ordenventa/{ordenId}/detalles");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> AddDetalleToOrdenAsync(int ordenId, CrearDetalleOrdenDto detalle)
        {
            var content = new StringContent(JsonConvert.SerializeObject(detalle), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/ordenventa/{ordenId}/detalles", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> UpdateDetalleOrdenAsync(int id, ActualizarDetalleOrdenDto detalle)
        {
            var content = new StringContent(JsonConvert.SerializeObject(detalle), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/detalleorden/{id}", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task DeleteDetalleOrdenAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/detalleorden/{id}");
            response.EnsureSuccessStatusCode();
        }

        // ============================================================
        // CAJA Y MOVIMIENTOS
        // ============================================================
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

        public async Task<CajaDto> AbrirCajaAsync(CrearCajaDto caja)
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

        public async Task<dynamic> GetMovimientosCajaAsync(int cajaId)
        {
            var response = await _httpClient.GetAsync($"/api/caja/{cajaId}/movimientos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<dynamic> RegistrarMovimientoCajaAsync(CrearMovimientoCajaDto movimiento)
        {
            var content = new StringContent(JsonConvert.SerializeObject(movimiento), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/caja/movimiento", content);
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        // ============================================================
        // TABLAS MAESTRAS (CON MAPEO MANUAL - SIN DEPURACIÓN)
        // ============================================================

        /// <summary>
        /// Obtiene todas las provincias usando mapeo manual.
        /// Se usa en: GET /api/provincias
        /// </summary>
        public async Task<List<ProvinciaDto>> GetProvinciasAsync()
        {
            var response = await _httpClient.GetAsync("/api/provincias");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var jsonArray = JArray.Parse(content);
            var provincias = new List<ProvinciaDto>();

            foreach (var item in jsonArray)
            {
                int id = item["idProvincia"]?.Value<int>() ?? 0;
                if (id == 0)
                    id = item["id"]?.Value<int>() ?? 0;

                string descripcion = item["descripcion"]?.Value<string>() ?? "";
                if (string.IsNullOrEmpty(descripcion))
                    descripcion = item["nombre"]?.Value<string>() ?? "";

                provincias.Add(new ProvinciaDto
                {
                    Id = id,
                    Descripcion = descripcion,
                    Estado = item["estado"]?.Value<bool>() ?? true,
                    FechaAlta = item["fechaAlta"]?.Value<DateTime>() ?? DateTime.Now,
                    FechaModificacion = item["fechaModificacion"]?.Value<DateTime?>()
                });
            }

            return provincias;
        }

        /// <summary>
        /// Obtiene localidades filtradas por provincia.
        /// Se usa en: GET /api/localidades/provincia/{id}
        /// </summary>
        public async Task<List<LocalidadDto>> GetLocalidadesByProvinciaAsync(int provinciaId)
        {
            var response = await _httpClient.GetAsync($"/api/localidades/provincia/{provinciaId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var jsonArray = JArray.Parse(content);
            var localidades = new List<LocalidadDto>();

            foreach (var item in jsonArray)
            {
                int id = item["idLocalidad"]?.Value<int>() ?? 0;
                if (id == 0)
                    id = item["id"]?.Value<int>() ?? 0;

                string descripcion = item["descripcion"]?.Value<string>() ?? "";
                if (string.IsNullOrEmpty(descripcion))
                    descripcion = item["nombre"]?.Value<string>() ?? "";

                int provinciaIdValue = item["provinciaId"]?.Value<int>() ?? 0;
                if (provinciaIdValue == 0)
                    provinciaIdValue = item["idProvincia"]?.Value<int>() ?? 0;

                localidades.Add(new LocalidadDto
                {
                    Id = id,
                    Descripcion = descripcion,
                    ProvinciaId = provinciaIdValue,
                    CodPostal = item["codPostal"]?.Value<int>() ?? item["codigoPostal"]?.Value<int>() ?? 0,
                    Estado = item["estado"]?.Value<bool>() ?? true,
                    FechaAlta = item["fechaAlta"]?.Value<DateTime>() ?? DateTime.Now,
                    FechaModificacion = item["fechaModificacion"]?.Value<DateTime?>()
                });
            }

            return localidades;
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

        // ============================================================
        // REPORTES
        // ============================================================
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

        // ============================================================
        // HEALTH CHECK
        // ============================================================
        public async Task<dynamic> HealthCheckAsync()
        {
            var response = await _httpClient.GetAsync("/health");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(content);
        }
    }
}