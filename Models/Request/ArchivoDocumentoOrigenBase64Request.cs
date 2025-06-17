public class ArchivoDocumentoOrigenBase64Request
{
    public int DocumentacionOrigenId { get; set; }
    public string NombreArchivo { get; set; } = null!;
    public string ArchivoBase64 { get; set; } = null!;
}
