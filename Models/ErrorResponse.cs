using System;
using Microsoft.Extensions.Configuration;
using ApiComercial.Models;

namespace ApiComercial.Models
{
    public class ErrorResponse
    {
        public ErrorType ErrorType { get; set; }
        public string ErrorDescripcion { get;  set; }
    }
}