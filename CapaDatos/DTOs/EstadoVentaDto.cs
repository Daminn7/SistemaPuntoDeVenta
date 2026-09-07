using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. ESTADO VENTA DTO - PARA CONSULTAS (GET)
    //    Devuelve TODOS los datos del estado de venta.
    //    Se usa en: GET /api/estadoventas, GET /api/estadoventas/{id}
    // ============================================================
    public class EstadoVentaDto
    {
        public int Id { get; set; }                    // ID del estado
        public string Descripcion { get; set; }        // Nombre del estado (Pendiente, Confirmada, etc.)
        public bool Estado { get; set; }               // True = Activo, False = Inactivo
        public DateTime FechaAlta { get; set; }        // Fecha de creación
        public DateTime? FechaModificacion { get; set; } // Última modificación
    }

    // ============================================================
    // 2. CREAR ESTADO VENTA DTO - PARA CREACIÓN (POST)
    //    Solo los campos necesarios para crear un estado de venta.
    //    Se usa en: POST /api/estadoventas
    // ============================================================
    public class CrearEstadoVentaDto
    {
        public string Descripcion { get; set; }        // Obligatorio. Debe ser: Pendiente, Confirmada, Cancelada, Finalizada o Anulada
    }

    // ============================================================
    // 3. ACTUALIZAR ESTADO VENTA DTO - PARA MODIFICACIÓN (PUT)
    //    Campos que se pueden modificar de un estado de venta.
    //    Se usa en: PUT /api/estadoventas/{id}
    // ============================================================
    public class ActualizarEstadoVentaDto
    {
        public string Descripcion { get; set; }        // Nuevo nombre del estado
        public bool Estado { get; set; }               // Activar o desactivar
    }
}