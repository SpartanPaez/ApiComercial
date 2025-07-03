using ApiComercial.Models.Request.Catalogo;
using ApiComercial.Models.Responses.Catalogo;

namespace ApiComercial.Services.Interfaces.Catalogo;

public interface ICatalogoAutoService
{
    Task<FotoAutoResponse> subirFoto(FotoAutoBase64Request request);
}