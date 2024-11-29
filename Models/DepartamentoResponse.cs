namespace ApiComercial.Entities
{
    /// <summary>
    /// Datos de los departamentos del pais
    /// </summary>
    public class DepartamentoResponse
    {
        /// <summary>
        /// Codigo del departamento
        /// </summary>
        /// <value></value>
        public int DepartamentoId { get; set; }
        /// <summary>
        /// Nombre del departamento
        /// </summary>
        /// <value></value>
        public string? DepartamentoDesc { get; set; }
    }
}