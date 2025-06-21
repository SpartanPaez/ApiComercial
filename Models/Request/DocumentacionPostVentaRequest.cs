namespace  ApiComercial.Models.Request;
public class DocumentacionPostVentaRequest
{
    public string? IdChasis { get; set; }
    public int IdEscribania { get; set; }
    public int Estado { get; set; }
    public string? Observacion { get; set; }
    public string? UsuarioActualizacion { get; set; }
}

