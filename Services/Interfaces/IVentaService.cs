using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Pagos;

namespace ApiComercial.Services.Interfaces;

public interface IVentaService
{
    Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas();
    Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta);
    Task<string?> VerificaEstadoCuota(int idCuota);
    Task<bool> PagarCuota(PagarCuotaRequest cuota);
    Task<bool> InsertarRefuerzo(RefuerzoRequest refuerzo);
    Task<IEnumerable<RefuerzoResponse>> ObtenerRefuerzos(int idVenta);
    Task<IEnumerable<MediosPagoResponse>> ObtenerMediosPago();
    Task<IEnumerable<VentasResponse>> ObtenerVentasContado();
    Task<bool> EliminarVentaCuotas(int idVenta);
    Task<IEnumerable<ListaAtrasoResponse>> ObtenerListaAtrasos();
    Task<int> CantidadCuotasAtrasadas();
}