using System;

namespace ApiComercial.Models
{
    public class ResponseVehiculo
    {
 public string? IdChasis { get; set; }
    public int? IdMarca { get; set; }
    public string? Marca { get; set; }  // Nombre de la marca
    public int? IdModelo { get; set; }
    public string? Modelo { get; set; } // Nombre del modelo
    public string? TipoCar { get; set; }
    public string AnoFabricacion { get; set; }
    public string Color { get; set; }
    }
}
