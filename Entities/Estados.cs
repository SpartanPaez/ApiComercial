namespace ApiComercial.Entities;
   /// <summary>
   /// Clase para mapear la tabla estados
   /// </summary>
    public class Estados
    {
        /// <summary>
        /// Identificador del estado  (PK)
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Descripción del estado
        /// </summary>
        public string Descripcion { get; set; } = string.Empty;
    }
