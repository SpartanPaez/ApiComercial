using ApiComercial.Models.Responses;

namespace ApiComercial.Services.Interfaces;

public interface IVentaService
{
    Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas();
    Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta);
}