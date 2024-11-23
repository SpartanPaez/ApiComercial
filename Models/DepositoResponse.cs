using System;
using Microsoft.Extensions.Configuration;
using ApiComercial.Models;
using ApiComercial.Enums;

namespace ApiComercial.Models
{
    public class DepositoResponse
    {
        public int DepositoID { get; set; }
        public string? DepositoNombre { get; set; }
        public string? DepositoDireccion { get; set; }
        public string? DepositoTelefono { get; set; }
        public int CiudadId { get; set; }
        public string ?DepositoObservaciones { get; set; }
        public string ?DepositoEstado { get; set; }
        public string ?DepositoUsuarioAlta { get; set; }
        public DateTime DepositoFechaAlta { get; set; }
        public string ?DepositoUsuarioModif { get; set; }
    
        public DateTime? DepositoFechaModif { get; set; }
    }
}