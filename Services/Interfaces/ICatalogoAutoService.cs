using ApiComercial.Models.Request.Catalogo;
using ApiComercial.Models.Responses.Catalogo;
using Models.Request.Catalogo;
using Models.Responses.Catalogo;

namespace ApiComercial.Services.Interfaces.Catalogo;

public interface ICatalogoAutoService
{
    Task<List<FotoAutoResponse>> MostrarFotosAutos(string idChasis);
    Task<FotoAutoResponse> subirFoto(FotoAutoBase64Request request);
    Task<int> AgregarCaracteristicaAsync(AutoCaracteristicaRequest request);
    Task<List<AutoCaracteristicaResponse>> ObtenerCaracteristicasAsync(string idChasis);
    Task<string> AgregarEspecificacionAsync(AutoEspecificacionRequest request);
    Task<List<AutoEspecificacionResponse>> ObtenerEspecificacionesAsync(string idChasis);
    Task<AutoDetalleViewModel> ObtenerDetalleAutoAsync(string idChasis);
}