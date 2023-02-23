using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ApiComercial.Models
{
    public class Clientes 
    {  
        /// <summary>
        /// Cedula del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCedula { get; set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteNombre { get; set; }
        /// <summary>
        /// Dirección del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteDireccion { get; set; }
        /// <summary>
        /// Correo del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteCorreo { get; set; }
        /// <summary>
        /// Estado civil del cliente
        /// </summary>
        /// <value></value>
        public string? ClienteEstadoCivil { get; set; }
        /// <summary>
        /// Fecga de alta del clinete
        /// </summary>
        /// <value></value>
        public DateTime ClienteFechaAlta { get; set; }
        /// <summary>
        /// Estado del cliente(si está activo o no)
        /// </summary>
        /// <value></value>
        public string? ClienteEstado { get; set; }
    }
    
}