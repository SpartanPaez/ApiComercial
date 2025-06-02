namespace ApiComercial.Models.Responses;

public class CabeceraCuotaResponse
{
    public string? CedulaCliente { get; set; }
    public string? NombreCliente { get; set; }
    public string? IdChasis { get; set; }
    public string? Marca { get; set; }
    public int AnoFabricacion { get; set; }
    public string? Precio { get; set; }
    public decimal Interes { get; set; }
    public int CantidadCuotas { get; set; }
    public decimal PrecioTotal { get; set; }
    public DateTime FechaVenta { get; set; }
}