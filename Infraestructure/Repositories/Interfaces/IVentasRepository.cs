using ApiComercial.Entities.Cuotas;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Pagos;

namespace ApiComercial.Repositories.Interfaces;
/// <summary>
/// Interfaz para el repositorio de ventas
/// </summary>
public interface IVentasRepository
{
    /// <summary>
    /// Tarea para obtener la cabecera de la venta a cuotas
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas();
    Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta);
    Task<string?> VerificaEstadoCuota(int idCuota);
    Task<bool> PagarCuota(PagarCuotaRequest cuota);
    Task<bool> InsertarRefuerzo(RefuerzoRequest parametros);
    Task<IEnumerable<RefuerzoResponse>> ObtenerRefuerzos(int idVenta);
    Task<IEnumerable<MediosPagoResponse>> ObtenerMediosPago();
    Task<IEnumerable<VentasResponse>> ObtenerVentasContado();
    Task<bool> EliminarVentaCuotas(int idVenta);
    Task<IEnumerable<ListaAtrasoResponse>> ObtenerListaAtrasos();
    Task<int> CantidadCuotasAtrasadas();
    Task<List<ReporteVentaResponse>> ObtenerReporteVentasAsync(ReporteVentasRequest request);
}   
