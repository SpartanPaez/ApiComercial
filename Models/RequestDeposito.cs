using System;
using System.Collections.Generic;
using System.Text;

namespace ApiComercial.Models
{
    public class RequestDeposito
    {
        /// <summary>
        /// Nombre del depósito
        /// </summary>
        /// <value></value>
        public string? DepositoNombre { get; set; }
        /// <summary>
        /// Dirección del depósito
        /// </summary>
        /// <value></value>
        public string? DepositoDireccion { get; set; }
        /// <summary>
        /// Teléfono del depósito
        /// </summary>
        /// <value></value>
        public string? DepositoTelefono { get; set; }
        /// <summary>
        /// Id de la ciudad
        /// </summary>
        /// <value></value>
        public int CiudadId { get; set; }
        /// <summary>
        /// Observaciones del depósito
        /// </summary>
        /// <value></value>
        public string? DepositoObservaciones { get; set; }
        /// <summary>
        /// Estado del depósito
        /// </summary>
        /// <value></value>
        public string? DepositoEstado { get; set; }
        /// <summary>
        /// Usuario que da de alta el depósito
        /// </summary>
        /// <value></value>
        public string? DepositoUsuarioAlta { get; set; }
        /// <summary>
        /// Fecha de alta del depósito
        /// </summary>
        /// <value></value>
        public DateTime ?DepositoFechaAlta { get; set; }
        /// <summary>
        /// Usuario que modifica el depósito
        /// </summary>
        /// <value></value>
        public string ?DepositoUsuarioModif { get; set; }
        /// <summary>
        /// Fecha de modificación del depósito
        /// </summary>
        /// <value></value>
        public DateTime? DepositoFechaModif { get; set; }
    }
}