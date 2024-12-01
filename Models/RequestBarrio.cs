using FluentValidation;
namespace ApiComercial.Entities
{
    /// <summary>
    /// Clase que envia los datos a la BD
    /// </summary>
    public class RequestBarrio
    {
        /// <summary>
        /// Id del departamentow
        /// </summary>
        public int IdCiudad { get; set; }
        /// <summary>
        /// Descripcion del barrio
        /// </summary>
        public string? Descripcion { get; set; }
    }
}