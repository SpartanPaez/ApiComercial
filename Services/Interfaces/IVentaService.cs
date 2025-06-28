using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;

namespace ApiComercial.Services.Interfaces;

public interface IVentaService
{
    Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas();
    Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta);
    Task<string?> VerificaEstadoCuota(int idCuota);
    Task<bool> PagarCuota(PagarCuotaRequest cuota);
    Task<IEnumerable<MediosPagoResponse>> ObtenerMediosPago();
    Task<IEnumerable<VentasResponse>> ObtenerVentasContado();
}