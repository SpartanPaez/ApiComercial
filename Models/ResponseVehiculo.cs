using System;

namespace ApiComercial.Models
{
    /// <summary>
    /// Clase de respuesta de vehiculos
    /// </summary>
    public class ResponseVehiculo
    {
        /// <summary>
        /// Numero de chasis del vehiculo
        /// </summary>
        public string? IdChasis { get; set; }
        /// <summary>
        /// Codigo de la marca del vehiculo
        /// </summary>
        public int? IdMarca { get; set; }
        /// <summary>
        /// Marca del vechiculo
        /// </summary>
        public string? Marca { get; set; } = string.Empty;
        /// <summary>
        /// Codigo del modelo
        /// </summary>
        public int? IdModelo { get; set; }
        /// <summary>
        /// Modelo del vehiculo
        /// </summary>
        public string? Modelo { get; set; } = string.Empty;
        /// <summary>
        /// Tipo del vehiculo
        /// </summary>
        public string? TipoCar { get; set; } = string.Empty;
        /// <summary>
        /// Año de fabricación
        /// </summary>
        public string AnoFabricacion { get; set; } = string.Empty;
        /// <summary>
        /// Color del vehiculo
        /// </summary>
        public string Color { get; set; } = string.Empty;
        public string? Usado { get; set; } = string.Empty;
        public string? Chapa { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
    }
}
