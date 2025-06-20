namespace ApiComercial.Models.Responses;

public class DocumentacionPostVentaResponse
{
    public int Id { get; set; }
    public string IdChasis { get; set; } = default!;
    public string? Escribania { get; set; }
    public string Estado { get; set; } = default!;
    public string? Observacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public string UsuarioActualizacion { get; set; } = default!;
}
