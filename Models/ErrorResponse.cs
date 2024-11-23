using System;
using Microsoft.Extensions.Configuration;
using ApiComercial.Models;
using ApiComercial.Enums;

namespace ApiComercial.Models
{
    /// <summary>
    /// Clase que muestra los errores
    /// </summary>
    public class ErrorResponse
    {
        public ErrorType ErrorType { get; set; }
        public string? ErrorDescripcion { get;  set; }
    }
}