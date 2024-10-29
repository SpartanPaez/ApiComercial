namespace ApiComercial.Entities
{
    public class ModeloAuto
    {
        /// <summary>
        /// Identificador del modelo de auto (PK)
        /// </summary>
        public int? IdModelo { get; set; }

        /// <summary>
        /// Identificador de la marca de auto (FK)
        /// </summary>
        public int IdMarca { get; set; }

        /// <summary>
        /// Descripción del modelo de auto
        /// </summary>
        public string DescripcionModelo { get; set; }

    }
}
