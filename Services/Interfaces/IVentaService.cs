using ApiComercial.Entities;
using ApiComercial.Models.Responses;

namespace ApiComercial.Services.Interfaces;

public interface IVentaService
{
    Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas();
    Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta);
    Task<int?> VerificaEstadoCuota(int idCuota, int idVenta);
    Task<bool> PagarCuota(Cuota cuota);
}