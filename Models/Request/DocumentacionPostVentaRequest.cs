namespace  ApiComercial.Models.Request;
public class DocumentacionPostVentaRequest
{
    public string IdChasis { get; set; } = default!;
    public int IdEscribania { get; set; }
    public int Estado { get; set; } = default!;
    public string? Observacion { get; set; }
    public string UsuarioActualizacion { get; set; } = default!;
}
