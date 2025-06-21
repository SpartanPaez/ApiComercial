namespace  ApiComercial.Models.Request;

public class ArchivoPostVentaRequest
{
 public int DocumentacionPostVentaId { get; set; }

    public string? NombreArchivo { get; set; }

    public string? RutaArchivo { get; set; }
    public string Tipo { get; set; }

    public string? UsuarioCarga { get; set; }

    public string? ArchivoBase64 { get; set; }
}
