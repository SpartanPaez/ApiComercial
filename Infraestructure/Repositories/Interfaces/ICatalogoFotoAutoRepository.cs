using ApiComercial.Models.Responses.Catalogo;
using Entities.Catalogo;
using Models.Request.Catalogo;
using Models.Responses.Catalogo;

namespace ApiComercial.Infraestructure.Repositories.Interfaces;

public interface ICatalogoFotoAutoRepository
{
    Task <List<FotoAutoResponse>>GetFotosAuto(string idChasis);
    Task InsertAsync(AutoFoto foto);
    Task<int> InsertarCaracteristica(AutoCaracteristicaRequest entity);
    Task<List<AutoCaracteristicaResponse>> ObtenerCaracteristicasPorChasis(string idChasis);
    Task<string> InsertarEspecificacion(AutoEspecificacionRequest entity);
    Task<List<AutoEspecificacionResponse>> ObtenerEspecificacion(string idChasis);
    Task<AutoDetalleViewModel> ObtenerDetalleAutoAsync(string idChasis);

}
