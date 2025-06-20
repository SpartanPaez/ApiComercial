namespace ApiComercial.Models.Responses;
public class ArchivoPostVentaResponse
{
    public int Id { get; set; }
    public int IdDocumentacion { get; set; }
    public string NombreArchivo { get; set; } = default!;
    public string RutaArchivo { get; set; } = default!;
    public string Tipo { get; set; } = default!;
    public DateTime FechaCarga { get; set; }
    public string UsuarioCarga { get; set; } = default!;
}
