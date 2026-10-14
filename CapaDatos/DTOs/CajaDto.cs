using System;
using Newtonsoft.Json;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. CAJA DTO - PARA CONSULTAS (GET)
    //    ✅ MODIFICADO: Alineado con la respuesta real de la API
    //    La API devuelve "idCaja" y "estadoCaja" (no "id" ni "estado")
    // ============================================================
    public class CajaDto
    {
        [JsonProperty("idCaja")]
        public int Id { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("personalNombre")]
        public string PersonalNombre { get; set; }

        [JsonProperty("fechaApertura")]
        public DateTime FechaApertura { get; set; }

        [JsonProperty("fondoInicial")]
        public decimal FondoInicial { get; set; }

        [JsonProperty("fechaCierre")]
        public DateTime? FechaCierre { get; set; }

        [JsonProperty("totalVentas")]
        public decimal TotalVentas { get; set; }

        [JsonProperty("totalIngresos")]
        public decimal TotalIngresos { get; set; }

        [JsonProperty("totalEgresos")]
        public decimal TotalEgresos { get; set; }

        [JsonProperty("estadoCaja")]
        public bool Estado { get; set; }
    }

    // ============================================================
    // 2. CREAR CAJA DTO - PARA APERTURA (POST)
    // ============================================================
    public class CrearCajaDto
    {
        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("fondoInicial")]
        public decimal FondoInicial { get; set; }
    }

    // ============================================================
    // 3. MOVIMIENTO CAJA DTO - PARA CONSULTAS (GET)
    // ============================================================
    public class MovimientoCajaDto
    {
        [JsonProperty("idMovimiento")]
        public int Id { get; set; }

        [JsonProperty("cajaId")]
        public int CajaId { get; set; }

        [JsonProperty("personalId")]
        public int PersonalId { get; set; }

        [JsonProperty("personalNombre")]
        public string PersonalNombre { get; set; }

        [JsonProperty("tipoMovimientoId")]
        public int TipoMovimientoId { get; set; }

        [JsonProperty("tipoMovimientoDescripcion")]
        public string TipoMovimientoDescripcion { get; set; }

        [JsonProperty("monto")]
        public decimal Monto { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("fechaMovimiento")]
        public DateTime FechaMovimiento { get; set; }
    }

    // ✅ CrearMovimientoCajaDto se mantiene en MovimientoCajaDto.cs
}