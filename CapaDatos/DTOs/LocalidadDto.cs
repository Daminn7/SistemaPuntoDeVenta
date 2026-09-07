using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. LOCALIDAD DTO - PARA CONSULTAS (GET)
    //    Devuelve TODOS los datos de la localidad incluyendo
    //    el nombre de la provincia.
    //    Se usa en: GET /api/localidades, GET /api/localidades/{id}
    // ============================================================
    public class LocalidadDto
    {
        public int Id { get; set; }                    // ID de la localidad
        public string Descripcion { get; set; }        // Nombre de la localidad
        public int ProvinciaId { get; set; }           // ID de la provincia
        public string ProvinciaNombre { get; set; }    // Nombre de la provincia (para mostrar)
        public int CodPostal { get; set; }             // Código postal
        public bool Estado { get; set; }               // True = Activa, False = Inactiva
        public DateTime FechaAlta { get; set; }        // Fecha de creación
        public DateTime? FechaModificacion { get; set; } // Última modificación
    }

    // ============================================================
    // 2. CREAR LOCALIDAD DTO - PARA CREACIÓN (POST)
    //    Solo los campos necesarios para crear una localidad.
    //    Se usa en: POST /api/localidades
    // ============================================================
    public class CrearLocalidadDto
    {
        public string Descripcion { get; set; }        // Obligatorio
        public int ProvinciaId { get; set; }           // Obligatorio
        public int CodPostal { get; set; }             // Obligatorio
    }

    // ============================================================
    // 3. ACTUALIZAR LOCALIDAD DTO - PARA MODIFICACIÓN (PUT)
    //    Campos que se pueden modificar de una localidad.
    //    Se usa en: PUT /api/localidades/{id}
    // ============================================================
    public class ActualizarLocalidadDto
    {
        public string Descripcion { get; set; }
        public int ProvinciaId { get; set; }
        public int CodPostal { get; set; }
        public bool Estado { get; set; }
    }
}