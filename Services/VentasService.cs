
using ApiComercial.Models.Request;
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

    public async Task<IEnumerable<MediosPagoResponse>> ObtenerMediosPago()
    {
        return await _ventasRepository.ObtenerMediosPago();
    }

    public async Task<bool> PagarCuota(PagarCuotaRequest cuota)
    {
        var validaCuota = await VerificaEstadoCuota(cuota.CuotaId);
        if (validaCuota == "PENDIENTE")
        {
            return await _ventasRepository.PagarCuota(cuota);
        }
        else
        {
            return false;
        }
    }

    public async Task<string?> VerificaEstadoCuota(int idCuota)
    {
        return await _ventasRepository.VerificaEstadoCuota(idCuota);
    }
}
