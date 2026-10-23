using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. COMPRA DTO (GET)
    // ============================================================
    public class CompraDto
    {
        [JsonProperty("idCompra")]
        public int IdCompra { get; set; }

        [JsonProperty("numeroFactura")]
        public string NumeroFactura { get; set; }

        [JsonProperty("proveedorId")]
        public int ProveedorId { get; set; }

        [JsonProperty("proveedorNombre")]
        public string ProveedorNombre { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("personalNombre")]
        public string PersonalNombre { get; set; }

        [JsonProperty("tipoComprobante")]
        public string TipoComprobante { get; set; }

        [JsonProperty("formaPago")]
        public string FormaPago { get; set; }

        [JsonProperty("fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("iva")]
        public decimal Iva { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("estado")]
        public bool Estado { get; set; }

        [JsonProperty("fechaAlta")]
        public DateTime FechaAlta { get; set; }

        [JsonProperty("detalles")]
        public List<DetalleCompraDto> Detalles { get; set; } = new List<DetalleCompraDto>();
    }

    public class DetalleCompraDto
    {
        [JsonProperty("idDetalleCompra")]
        public int IdDetalleCompra { get; set; }

        [JsonProperty("productoId")]
        public int ProductoId { get; set; }

        [JsonProperty("productoNombre")]
        public string ProductoNombre { get; set; }

        [JsonProperty("productoCodigo")]
        public string ProductoCodigo { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("costoUnitario")]
        public decimal CostoUnitario { get; set; }

        [JsonProperty("subtotal")]
        public decimal Subtotal { get; set; }
    }

    // ============================================================
    // 2. CREAR COMPRA DTO (POST)
    // ============================================================
    public class CrearCompraDto
    {
        [JsonProperty("numeroFactura")]
        public string NumeroFactura { get; set; }

        [JsonProperty("proveedorId")]
        public int ProveedorId { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("tipoComprobante")]
        public string TipoComprobante { get; set; }

        [JsonProperty("formaPago")]
        public string FormaPago { get; set; }

        [JsonProperty("fechaEmision")]
        public DateTime FechaEmision { get; set; }

        [JsonProperty("detalles")]
        public List<CrearDetalleCompraDto> Detalles { get; set; } = new List<CrearDetalleCompraDto>();
    }

    public class CrearDetalleCompraDto
    {
        [JsonProperty("productoId")]
        public int ProductoId { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("costoUnitario")]
        public decimal CostoUnitario { get; set; }
    }
}