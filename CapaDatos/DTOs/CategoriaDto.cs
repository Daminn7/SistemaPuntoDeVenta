using System;

namespace CapaDatos.DTOs
{
    // ============================================================
    // 1. CATEGORIA DTO - PARA CONSULTAS (GET)
    //    Devuelve TODOS los datos de la categoría.
    //    Se usa en: GET /api/categorias, GET /api/categorias/{id}
    // ============================================================
    public class CategoriaDto
    {
        public int Id { get; set; }                    // ID de la categoría
        public string Descripcion { get; set; }        // Nombre/descripción de la categoría
        public bool Estado { get; set; }               // True = Activa, False = Inactiva
        public DateTime FechaAlta { get; set; }        // Fecha de creación
        public DateTime? FechaModificacion { get; set; } // Última modificación
    }

    // ============================================================
    // 2. CREAR CATEGORIA DTO - PARA CREACIÓN (POST)
    //    Solo los campos necesarios para crear una categoría.
    //    Se usa en: POST /api/categorias
    // ============================================================
    public class CrearCategoriaDto
    {
        public string Descripcion { get; set; }        // Nombre de la categoría (Obligatorio)
    }

    // ============================================================
    // 3. ACTUALIZAR CATEGORIA DTO - PARA MODIFICACIÓN (PUT)
    //    Campos que se pueden modificar de una categoría.
    //    Se usa en: PUT /api/categorias/{id}
    // ============================================================
    public class ActualizarCategoriaDto
    {
        public string Descripcion { get; set; }        // Nuevo nombre de la categoría
        public bool Estado { get; set; }               // Activar o desactivar
    }
}