using System;

namespace ApiComercial.Models
{
    public class RequestVehiculo
    {
        /// <summary>
        /// Identificador único del chasis del vehículo
        /// </summary>
        public string? IdChasis { get; set; }  // Asegúrate de que este campo sea requerido para insertar el vehículo.

        /// <summary>
        /// Identificador de la marca del vehículo
        /// </summary>
        public int? IdMarca { get; set; }

        /// <summary>
        /// Identificador del modelo del vehículo
        /// </summary>
        public int? IdModelo { get; set; }

        /// <summary>
        /// Tipo de carrocería del vehículo
        /// </summary>
        public string? TipoCar { get; set; }

        /// <summary>
        /// Año de fabricación del vehículo
        /// </summary>
        public int AnoFabricacion { get; set; }  // Cambiar a string si decidiste usarlo como string.

        /// <summary>
        /// Color del vehículo
        /// </summary>
        public string? Color { get; set; }
    }
}
