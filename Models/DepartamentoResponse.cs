namespace ApiComercial.Entities
{
    public class DepartamentoResponse
    {
        /// <summary>
        /// Codigo del departamento
        /// </summary>
        /// <value></value>
        public int DepartamentoId { get; set; }
        /// <summary>
        /// Pais asociado
        /// </summary>
        /// <value></value>
        public int PaisId { get; set; }
        /// <summary>
        /// Nombre del departamento
        /// </summary>
        /// <value></value>
        public string? DepartamentoDesc { get; set; }
    }
}