using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. CAJA DTO - PARA CONSULTAS (GET)
    //    Devuelve TODOS los datos de la caja incluyendo relaciones
    //    y campos de solo lectura.
    //    Se usa en: GET /api/caja, GET /api/caja/{id}, GET /api/caja/activa
    // ============================================================
    public class CajaDto
    {
        public int Id { get; set; }                    // ID de la caja
        public int PersonalId { get; set; }            // ID del usuario que abrió la caja
        public string PersonalNombre { get; set; }     // Nombre del usuario (para mostrar)
        public DateTime FechaApertura { get; set; }    // Fecha y hora de apertura
        public decimal FondoInicial { get; set; }      // Monto inicial en caja
        public DateTime? FechaCierre { get; set; }     // Fecha y hora de cierre (NULL si está abierta)
        public decimal TotalVentas { get; set; }       // Total acumulado de ventas
        public decimal TotalIngresos { get; set; }     // Total de ingresos (movimientos +)
        public decimal TotalEgresos { get; set; }      // Total de egresos (movimientos -)
        public bool Estado { get; set; }               // True = Activa, False = Cerrada
    }

    // ============================================================
    // 2. CREAR CAJA DTO - PARA APERTURA (POST)
    //    Solo los campos necesarios para abrir una caja.
    //    Se usa en: POST /api/caja/apertura
    // ============================================================
    public class CrearCajaDto
    {
        public int PersonalId { get; set; }            // ID del usuario que abre la caja
        public decimal FondoInicial { get; set; }      // Monto inicial con el que se abre la caja
    }

    // ============================================================
    // 3. ACTUALIZAR CAJA DTO - PARA CIERRE (PUT)
    //    Campos que se pueden modificar al cerrar la caja.
    //    Se usa en: PUT /api/caja/{id}/cierre
    // ============================================================
    public class ActualizarCajaDto
    {
        public int Id { get; set; }                    // ID de la caja a cerrar
        public DateTime FechaCierre { get; set; }      // Fecha y hora de cierre
        public decimal TotalVentas { get; set; }       // Total de ventas del día
        public decimal TotalIngresos { get; set; }     // Total de ingresos extras
        public decimal TotalEgresos { get; set; }      // Total de egresos
        public bool Estado { get; set; }               // False = Cerrada
    }
}