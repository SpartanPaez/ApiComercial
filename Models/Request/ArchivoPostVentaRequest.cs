namespace  ApiComercial.Models.Request;

public class ArchivoPostVentaRequest
{
    public int IdDocumentacion { get; set; }
    public string NombreArchivo { get; set; } = default!;
    public string RutaArchivo { get; set; } = default!;
    public string Tipo { get; set; } = default!;
    public string UsuarioCarga { get; set; } = default!;
}
