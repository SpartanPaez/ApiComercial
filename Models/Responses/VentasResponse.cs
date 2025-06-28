namespace ApiComercial.Models.Responses;

public class VentasResponse
{
    public int VentaId { get; set; }
    public int IdCliente { get; set; }
    public string? CedulaCliente { get; set; }
    public string? NombreCliente { get; set; }
    public string? IdChasis { get; set; }
    public string? Marca { get; set; }
    public int AnoFabricacion { get; set; }
    public string? Precio { get; set; }
    public DateTime FechaCompra { get; set; }
}