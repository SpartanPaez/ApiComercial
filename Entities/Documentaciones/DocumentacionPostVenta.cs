namespace ApiComercial.Entitie.Documentaciones;
public class DocumentacionPostVenta
{
    public int Id { get; set; }
    public string IdChasis { get; set; } = default!;
    public int IdEscribania { get; set; }
    public int Estado { get; set; } = default!;
    public string? Observacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public string UsuarioActualizacion { get; set; } = default!;
}
