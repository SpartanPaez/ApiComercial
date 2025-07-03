namespace ApiComercial.Models.Request.Catalogo;
public class FotoAutoBase64Request
{
    public string IdChasis { get; set; } = null!;
    public string NombreArchivo { get; set; } = null!;
    public string ArchivoBase64 { get; set; } = null!;
    public bool EsPrincipal { get; set; } = false;
}
