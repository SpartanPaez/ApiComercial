using ApiComercial.Infraestructure.Repositories.Interfaces;
using ApiComercial.Models.Request.Catalogo;
using ApiComercial.Models.Responses.Catalogo;
using ApiComercial.Services.Interfaces.Catalogo;
using Entities.Catalogo;

namespace ApiComercial.Services.Catalogo;

public class CatalogoAutoService : ICatalogoAutoService
{
    private readonly ICatalogoFotoAutoRepository _fotoAutoRepository;
    public CatalogoAutoService(ICatalogoFotoAutoRepository fotoAutoRepository)
    {
        _fotoAutoRepository = fotoAutoRepository;
    }
    public async Task<FotoAutoResponse> subirFoto(FotoAutoBase64Request request)
    {
        var rutaRelativa = Path.Combine("uploads", "autos", request.IdChasis);
        var rutaFisica = Path.Combine("/var/www/api/wwwroot/uploads/autos", request.IdChasis);

        Directory.CreateDirectory(rutaFisica);

        var rutaCompleta = Path.Combine(rutaFisica, request.NombreArchivo);
        var archivoBytes = Convert.FromBase64String(request.ArchivoBase64);
        await System.IO.File.WriteAllBytesAsync(rutaCompleta, archivoBytes);

        var rutaPublica = Path.Combine("/", rutaRelativa, request.NombreArchivo).Replace("\\", "/");

        var foto = new AutoFoto
        {
            IdChasis = request.IdChasis,
            UrlFoto = rutaPublica,
            EsPrincipal = request.EsPrincipal
        };

        await _fotoAutoRepository.InsertAsync(foto);

        return new FotoAutoResponse
        {
            Id = foto.Id,
            UrlFoto = foto.UrlFoto,
            EsPrincipal = foto.EsPrincipal
        };
    }
}