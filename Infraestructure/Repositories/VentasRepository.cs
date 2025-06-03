using ApiComercial.Infraestructure.Data;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories;

/// <summary>
/// Aqui van todas las consultas a la base de datos
/// </summary>
public class VentasRepository : IVentasRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    /// <summary>
    /// Constructor de la clase 
    /// </summary>
    /// <param name="serviceScopeFactory"></param>
    public VentasRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    /// <summary>
    /// Consulta los datos de cabeceras de ventas a cuotas
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<CabeceraCuotaResponse>> ObtenerCabeceraCuotas()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await (from ventas in ctx.Ventas.AsNoTracking()
                      join detalleventas in ctx.DetalleVenta.AsNoTracking()
                      on ventas.VentaId equals detalleventas.VentaId
                      join clientes in ctx.Clientes.AsNoTracking()
                      on ventas.ClienteId equals clientes.ClienteId
                      join autos in ctx.Vehiculos.AsNoTracking()
                      on detalleventas.IdChasis equals autos.IdChasis
                      join marcas in ctx.Marcas.AsNoTracking()
                      on autos.IdMarca equals marcas.IdMarca
                      where ventas.CantidadCuotas > 0
                      select new CabeceraCuotaResponse
                      {
                          IdVenta = ventas.VentaId,
                          CedulaCliente = clientes.ClienteCedula,
                          NombreCliente = clientes.ClienteNombre,
                          IdChasis = detalleventas.IdChasis,
                          Marca = marcas.DescripcionMarca,
                          AnoFabricacion = autos.AnoFabricacion,
                          Precio = autos.Precio,
                          Interes = ventas.InteresAnual,
                          CantidadCuotas = ventas.CantidadCuotas,
                          PrecioTotal = ventas.PrecioTotal,
                          FechaVenta = ventas.FechaVenta
                      })
                      .ToListAsync();
    }

    public async Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await (from cuotas in ctx.Cuota.AsNoTracking()
                      where cuotas.VentaId == idVenta
                      select new DetalleCuotaResponse
                      {
                          NumeroCuota = cuotas.NumeroCuota,
                          MontoCuota = cuotas.MontoCuota,
                          FechaVencimiento = cuotas.FechaVencimiento
                      })
                      .ToListAsync();
    }
}