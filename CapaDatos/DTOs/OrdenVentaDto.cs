using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. ORDEN VENTA DTO - PARA CONSULTAS (GET)
    // ============================================================
    public class OrdenVentaDto
    {
        [JsonProperty("idOrden")]
        public int IdOrden { get; set; }

        [JsonProperty("numeroPresupuesto")]
        public string NumeroPresupuesto { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("personalNombre")]
        public string PersonalNombre { get; set; }

        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("clienteNombre")]
        public string ClienteNombre { get; set; }

        [JsonProperty("clienteDocumento")]
        public string ClienteDocumento { get; set; }

        [JsonProperty("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [JsonProperty("fechaValidez")]
        public DateTime? FechaValidez { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("tipoDocumentoId")]
        public int TipoDocumentoId { get; set; }

        [JsonProperty("tipoDocumentoDescripcion")]
        public string TipoDocumentoDescripcion { get; set; }

        [JsonProperty("estadoVentaId")]
        public int EstadoVentaId { get; set; }

        [JsonProperty("estadoVentaDescripcion")]
        public string EstadoVentaDescripcion { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("detalles")]
        public List<DetalleOrdenDto> Detalles { get; set; } = new List<DetalleOrdenDto>();
    }

    // ============================================================
    // 2. DETALLE ORDEN DTO
    // ============================================================
    public class DetalleOrdenDto
    {
        [JsonProperty("idDetalle")]
        public int IdDetalle { get; set; }

        [JsonProperty("productoId")]
        public int ProductoId { get; set; }

        [JsonProperty("productoCodigo")]
        public string ProductoCodigo { get; set; }

        [JsonProperty("productoNombre")]
        public string ProductoNombre { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("precioUnitario")]
        public decimal PrecioUnitario { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }
    }

    // ============================================================
    // 3. CREAR ORDEN VENTA DTO - PARA POST
    // ============================================================
    public class CrearOrdenVentaDto
    {
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("tipoDocumentoId")]
        public int TipoDocumentoId { get; set; } = 5; // Presupuesto

        [JsonProperty("estadoVentaId")]
        public int EstadoVentaId { get; set; } = 1; // Pendiente

        [JsonProperty("fechaValidez")]
        public DateTime? FechaValidez { get; set; }

        [JsonProperty("detalles")]
        public List<CrearDetalleOrdenDto> Detalles { get; set; } = new List<CrearDetalleOrdenDto>();
    }
    // ============================================================
    // 5. RESPUESTA DE CREAR ORDEN
    // ============================================================
    public class CrearOrdenVentaResponseDto
    {
        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("idOrden")]
        public int IdOrden { get; set; }

        [JsonProperty("numeroPresupuesto")]
        public string NumeroPresupuesto { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }
    }
}