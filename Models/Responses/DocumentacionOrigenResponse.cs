namespace ApiComercial.Models.Responses;

public class DocumentacionOrigenResponse
{
    public int Id { get; set; }
    public string? IdChasis { get; set; }
    public DateTime FechaRecepcion { get; set; }
    public string? Observacion { get; set; }
    public string? RegistradoPor { get; set; }
}
