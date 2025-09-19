namespace ApiComercial.Models.Responses.Pagos;

public class ListaAtrasoResponse
{
    public int VentaId { get; set; }
    public int NumeroCuota { get; set; }
    public string? CedulaCliente { get; set; }
    public string? NombreCliente { get; set; }
    public string? Celular { get; set; }
    public string? IdChasis { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? CantidadCuotasAtrasadas { get; set; }
}