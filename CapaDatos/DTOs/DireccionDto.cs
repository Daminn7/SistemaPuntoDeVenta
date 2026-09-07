using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. DIRECCION DTO - PARA CONSULTAS (GET)
    //    Devuelve TODOS los datos de la dirección incluyendo
    //    el nombre de la localidad y provincia.
    //    Se usa en: GET /api/direcciones, GET /api/direcciones/{id}
    // ============================================================
    public class DireccionDto
    {
        public int Id { get; set; }                    // ID de la dirección
        public string Calle { get; set; }              // Nombre de la calle
        public int? Numero { get; set; }               // Número de la calle (opcional)
        public int? Edificio { get; set; }             // Edificio (opcional)
        public int? Piso { get; set; }                 // Piso (opcional)
        public string Departamento { get; set; }       // Departamento (opcional)
        public string Descripcion { get; set; }        // Descripción adicional (opcional)
        public int LocalidadId { get; set; }           // ID de la localidad
        public string LocalidadNombre { get; set; }    // Nombre de la localidad (para mostrar)
        public string ProvinciaNombre { get; set; }    // Nombre de la provincia (para mostrar)
        public bool Estado { get; set; }               // True = Activa, False = Inactiva
        public DateTime FechaAlta { get; set; }        // Fecha de creación
        public DateTime? FechaModificacion { get; set; } // Última modificación
    }

    // ============================================================
    // 2. CREAR DIRECCION DTO - PARA CREACIÓN (POST)
    //    Solo los campos necesarios para crear una dirección.
    //    Se usa en: POST /api/direcciones
    // ============================================================
    public class CrearDireccionDto
    {
        public string Calle { get; set; }              // Obligatorio
        public int? Numero { get; set; }               // Opcional
        public int? Edificio { get; set; }             // Opcional
        public int? Piso { get; set; }                 // Opcional
        public string Departamento { get; set; }       // Opcional
        public string Descripcion { get; set; }        // Opcional
        public int LocalidadId { get; set; }           // Obligatorio
    }

    // ============================================================
    // 3. ACTUALIZAR DIRECCION DTO - PARA MODIFICACIÓN (PUT)
    //    Campos que se pueden modificar de una dirección.
    //    Se usa en: PUT /api/direcciones/{id}
    // ============================================================
    public class ActualizarDireccionDto
    {
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public int? Edificio { get; set; }
        public int? Piso { get; set; }
        public string Departamento { get; set; }
        public string Descripcion { get; set; }
        public int LocalidadId { get; set; }
        public bool Estado { get; set; }
    }
}