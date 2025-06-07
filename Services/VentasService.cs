using ApiComercial.Entities;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services.Interfaces;

namespace ApiComercial.Services;

public class VentasService : IVentaService
{
    private readonly IVentasRepository _ventasRepository;
    public VentasService(IVentasRepository ventasRepository)
    {
        _ventasRepository = ventasRepository;
    }
    public async Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas()
    {
        return await _ventasRepository.ObtenerCabeceraCuotas();
    }

    public async Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta)
    {
        return await _ventasRepository.ObtenerDetalleCuotas(idVenta);
    }

    public async Task<bool> PagarCuota(Cuota cuota)
    {
        var validaCuota = await VerificaEstadoCuota(cuota.CuotaId, cuota.VentaId);
        if (validaCuota >= 0)
        {
            return await _ventasRepository.PagarCuota(cuota);
        }
        else
        {
            return false;
        }
    }

    public async Task<int?> VerificaEstadoCuota(int idCuota, int idVenta)
    {
        return await _ventasRepository.VerificaEstadoCuota(idCuota, idVenta);
    }
}
