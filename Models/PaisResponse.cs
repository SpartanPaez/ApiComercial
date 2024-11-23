namespace ApiComercial.Entities
{
    public class PaisResponse
    {
        /// <summary>
        /// Codigo del pais
        /// </summary>
        /// <value></value>
        public int PaisId { get; set; }
        /// <summary>
        /// Descripción del país
        /// </summary>
        /// <value></value>
        public string? PaisDescripcion { get; set; }
        /// <summary>
        /// Nacionalidad del páis
        /// </summary>
        /// <value></value>
        public string? PaisNacionalidad { get; set; }
    }
}