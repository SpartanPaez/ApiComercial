namespace ApiComercial.Models.Responses.Recepcion;
public class RecepcionResponse
{
    public int RecepcionId { get; set; }
    public string? Chasis { get; set; }
    public string? Observacion { get; set; }
    public string? RecibidoPor { get; set; }
    public string? EntregadoPor { get; set; }
}