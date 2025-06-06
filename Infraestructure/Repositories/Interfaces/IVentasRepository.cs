using ApiComercial.Entities;
using ApiComercial.Models.Responses;

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
    Task<int?> VerificaEstadoCuota(int idCuota, int idVenta);
    Task<bool> PagarCuota(Cuota cuota);
}   
