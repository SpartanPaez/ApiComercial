namespace ApiComercial.Entities
{
    public class RequestCiudad
    {
        /// <summary>
        /// Codigo del de departamento asociado
        /// </summary>
        /// <value></value>
        public int DepartamentoId { get; set; }
        /// <summary>
        /// Nombde de la ciudad
        /// </summary>
        /// <value></value>
        public string? CiudadDesc { get; set; }
    }
}