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
}
