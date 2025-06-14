namespace  ApiComercial.Models.Request;

public class DocumentacionOrigenRequest
{
    public string? IdChasis { get; set; }
    public DateTime FechaRecepcion { get; set; }
    public string? Observacion { get; set; }
    public string? RegistradoPor { get; set; }
}
