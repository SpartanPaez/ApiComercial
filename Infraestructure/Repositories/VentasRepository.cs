using ApiComercial.Entities;
using ApiComercial.Entities.Cuotas;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Pagos;
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
                      join cuotas in ctx.Cuota.AsNoTracking()
                      on ventas.VentaId equals cuotas.VentaId into cuotasVenta
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
                          PrecioTotal = ventas.PrecioTotalCuotas,
                          FechaVenta = ventas.FechaVenta,
                          // NUEVO: Cuotas pagadas
                          CantidadCuotasPagadas = cuotasVenta.Count(c => c.EstadoCodigo == "PAGADO"),
                          // NUEVO: Total pagado (si pagas por cuota)
                          TotalPagado = cuotasVenta.Where(c => c.EstadoCodigo == "PAGADO").Sum(c => c.MontoCuota),
                          // NUEVO: Total restante (precio total - pagado)
                          TotalRestante = ventas.PrecioTotalCuotas - cuotasVenta.Where(c => c.EstadoCodigo == "PAGADO").Sum(c => c.MontoCuota)
                      })
                      .ToListAsync();
    }

    public async Task<IEnumerable<VentasResponse>> ObtenerVentasContado()
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
                      where ventas.CantidadCuotas == 0 // Ventas al contado
                      select new VentasResponse
                      {
                          VentaId = ventas.VentaId,
                          IdCliente = clientes.ClienteId,
                          CedulaCliente = clientes.ClienteCedula,
                          NombreCliente = clientes.ClienteNombre,
                          IdChasis = detalleventas.IdChasis,
                          Marca = marcas.DescripcionMarca,
                          AnoFabricacion = autos.AnoFabricacion,
                          Precio = autos.Precio,
                          FechaCompra = ventas.FechaVenta
                      })
                      .ToListAsync();

    }

    public async Task<IEnumerable<DetalleCuotaResponse>> ObtenerDetalleCuotas(int idVenta)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await (from cuotas in ctx.Cuota.AsNoTracking()
                      join ventas in ctx.Ventas.AsNoTracking()
                      on cuotas.VentaId equals ventas.VentaId
                      where cuotas.VentaId == idVenta
                      select new DetalleCuotaResponse
                      {
                          VentaId = cuotas.VentaId,
                          IdCuota = cuotas.CuotaId,
                          NumeroCuota = cuotas.NumeroCuota,
                          MontoCuota = cuotas.MontoCuota,
                          FechaVencimiento = cuotas.FechaVencimiento,
                          EstadoCodigo = cuotas.EstadoCodigo,
                          EsRefuerzo = cuotas.EsRefuerzo
                      })
                      .ToListAsync();
    }

    public async Task<IEnumerable<MediosPagoResponse>> ObtenerMediosPago()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await ctx.MediosPago.AsNoTracking()
            .Select(m => new MediosPagoResponse
            {
                MedioPagoId = m.MedioPagoId,
                Codigo = m.Codigo,
                Nombre = m.Nombre
            })
            .ToListAsync();
    }

    public async Task<bool> PagarCuota(PagarCuotaRequest request)
    {
        // 1. Arrancar el scope y el contexto
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        // 2. Cargar la cuota que vamos a pagar
        var cuota = await ctx.Cuota
            .FirstOrDefaultAsync(c => c.CuotaId == request.CuotaId);
        if (cuota is null)
            throw new KeyNotFoundException($"No existe cuota con Id {request.CuotaId}");

        // 3. Insertar un pago en la tabla Pagos
        var pago = new Pago
        {
            CuotaId = request.CuotaId,
            MedioPagoId = request.MedioPagoId,
            Monto = request.MontoPagado,
            Referencia = request.Referencia,
            FechaPago = DateTime.UtcNow
        };
        ctx.Pagos.Add(pago);

        // 4. Actualizar el monto de la cuota restando el pago
        cuota.MontoCuota -= request.MontoPagado;
        cuota.FechaPago = request.FechaPago;

        // 5. Marcar como PAGADO solo si el monto restante es 0 o negativo
        if (cuota.MontoCuota <= 0)
        {
            cuota.EstadoCodigo = "PAGADO";
            cuota.MontoCuota = 0; // Asegurar que no sea negativo
        }

        var cambios = await ctx.SaveChangesAsync();
        return cambios > 0;
    }

    public async Task<string?> VerificaEstadoCuota(int idCuota)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await (from cuotas in ctx.Cuota.AsNoTracking()
                      where cuotas.CuotaId == idCuota
                      && cuotas.EstadoCodigo == "PENDIENTE"
                      select cuotas.EstadoCodigo)
                      .FirstOrDefaultAsync();
    }

    public async Task<bool> InsertarRefuerzo(RefuerzoRequest parametros)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var refuerzo = new Refuerzo
        {
            VentaId = parametros.VentaId,
            MontoRefuerzo = parametros.MontoRefuerzo,
            FechaVencimiento = parametros.FechaVencimiento
        };

        ctx.Refuerzos.Add(refuerzo);
        var cambios = await ctx.SaveChangesAsync();
        return cambios > 0;
    }

    public async Task<IEnumerable<RefuerzoResponse>> ObtenerRefuerzos(int idVenta)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await ctx.Refuerzos.AsNoTracking()
            .Where(r => r.VentaId == idVenta)
            .Select(r => new RefuerzoResponse
            {
                RefuerzoId = r.RefuerzoId,
                VentaId = r.VentaId,
                MontoRefuerzo = r.MontoRefuerzo,
                FechaVencimiento = r.FechaVencimiento
            })
            .ToListAsync();
    }

    public async Task<bool> EliminarVentaCuotas(int idVenta)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();
        using var transaction = await ctx.Database.BeginTransactionAsync();
        try
        {
            // 1. Eliminar pagos de las cuotas de la venta
            var cuotas = await ctx.Cuota.Where(c => c.VentaId == idVenta).ToListAsync();
            var cuotaIds = cuotas.Select(c => c.CuotaId).ToList();
            var pagos = await ctx.Pagos.Where(p => cuotaIds.Contains(p.CuotaId)).ToListAsync();
            ctx.Pagos.RemoveRange(pagos);
            await ctx.SaveChangesAsync(); // Guardar cambios para eliminar pagos primero

            // 2. Eliminar cuotas
            ctx.Cuota.RemoveRange(cuotas);
            await ctx.SaveChangesAsync(); // Guardar cambios para eliminar cuotas

            // 3. Eliminar refuerzos
            var refuerzos = await ctx.Refuerzos.Where(r => r.VentaId == idVenta).ToListAsync();
            ctx.Refuerzos.RemoveRange(refuerzos);
            await ctx.SaveChangesAsync(); // Guardar cambios para eliminar refuerzos

            // 4. Eliminar detalles de venta
            var detalles = await ctx.DetalleVenta.Where(d => d.VentaId == idVenta).ToListAsync();
            ctx.DetalleVenta.RemoveRange(detalles);
            await ctx.SaveChangesAsync(); // Guardar cambios para eliminar detalles

            // 5. Eliminar la venta
            var venta = await ctx.Ventas.FirstOrDefaultAsync(v => v.VentaId == idVenta);
            if (venta != null)
                ctx.Ventas.Remove(venta);
            await ctx.SaveChangesAsync(); // Guardar cambios para eliminar venta

            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<IEnumerable<ListaAtrasoResponse>> ObtenerListaAtrasos()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var fechaActual = DateTime.Now;

        return await (from cuotas in ctx.Cuota.AsNoTracking()
                      join ventas in ctx.Ventas.AsNoTracking()
                      on cuotas.VentaId equals ventas.VentaId
                      join detalleventas in ctx.DetalleVenta.AsNoTracking()
                      on ventas.VentaId equals detalleventas.VentaId
                      join clientes in ctx.Clientes.AsNoTracking()
                      on ventas.ClienteId equals clientes.ClienteId
                      join autos in ctx.Vehiculos.AsNoTracking()
                      on detalleventas.IdChasis equals autos.IdChasis
                      join marcas in ctx.Marcas.AsNoTracking()
                      on autos.IdMarca equals marcas.IdMarca
                      join modelos in ctx.Modelos.AsNoTracking()
                      on autos.IdModelo equals modelos.IdModelo
                      where cuotas.EstadoCodigo == "PENDIENTE" && cuotas.FechaVencimiento < fechaActual
                      group cuotas by new { ventas.VentaId, clientes.ClienteCedula, clientes.ClienteNombre, clientes.ClienteCelular, detalleventas.IdChasis, marcas.DescripcionMarca, modelos.DescripcionModelo } into g
                      select new ListaAtrasoResponse
                      {
                          VentaId = g.Key.VentaId,
                          NumeroCuota = g.Count(), 
                          CedulaCliente = g.Key.ClienteCedula,
                          NombreCliente = g.Key.ClienteNombre,
                          Celular = g.Key.ClienteCelular,
                          IdChasis = g.Key.IdChasis,
                          Marca = g.Key.DescripcionMarca,
                          Modelo = g.Key.DescripcionModelo,
                          CantidadCuotasAtrasadas = g.Count().ToString()
                      }).ToListAsync();
    }

    public async Task<int> CantidadCuotasAtrasadas()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var fechaActual = DateTime.Now;

        return await ctx.Cuota.AsNoTracking()
            .CountAsync(c => c.EstadoCodigo == "PENDIENTE" && c.FechaVencimiento < fechaActual);
    }

    public async Task<List<ReporteVentaResponse>> ObtenerReporteVentasAsync(ReporteVentasRequest request)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var query = from venta in ctx.Ventas.AsNoTracking()
                    join detalle in ctx.DetalleVenta.AsNoTracking() on venta.VentaId equals detalle.VentaId
                    join vehiculo in ctx.Vehiculos.AsNoTracking() on detalle.IdChasis equals vehiculo.IdChasis
                    join cliente in ctx.Clientes.AsNoTracking() on venta.ClienteId equals cliente.ClienteId
                    join marca in ctx.Marcas.AsNoTracking() on vehiculo.IdMarca equals marca.IdMarca
                    join modelo in ctx.Modelos.AsNoTracking() on vehiculo.IdModelo equals modelo.IdModelo
                    select new {
                        venta,
                        detalle,
                        vehiculo,
                        cliente,
                        marca,
                        modelo,
                        CostoString = vehiculo.Costo
                    };

        if (request.FechaInicio.HasValue)
            query = query.Where(x => x.venta.FechaVenta >= request.FechaInicio.Value);
        if (request.FechaFin.HasValue)
            query = query.Where(x => x.venta.FechaVenta <= request.FechaFin.Value);
        if (request.ClienteId.HasValue)
            query = query.Where(x => x.cliente.ClienteId == request.ClienteId.Value);
        if (request.MarcaId.HasValue)
            query = query.Where(x => x.marca.IdMarca == request.MarcaId.Value);
        if (request.ModeloId.HasValue)
            query = query.Where(x => x.modelo.IdModelo == request.ModeloId.Value);
        if (request.SoloContado.HasValue && request.SoloContado.Value)
            query = query.Where(x => x.venta.CantidadCuotas == 0);

        var tempList = await query.ToListAsync();

        var result = tempList.Select(x => {
            decimal costo = 0;
            decimal.TryParse(x.CostoString, out costo);
            var precioVenta = x.detalle.PrecioUnitario ?? 0;
            return new ReporteVentaResponse
            {
                VentaId = x.venta.VentaId,
                FechaVenta = x.venta.FechaVenta,
                ClienteNombre = x.cliente.ClienteNombre ?? string.Empty,
                Marca = x.marca.DescripcionMarca ?? string.Empty,
                Modelo = x.modelo.DescripcionModelo ?? string.Empty,
                PrecioVenta = precioVenta,
                Costo = costo,
                Ganancia = precioVenta - costo,
                EsContado = x.venta.CantidadCuotas == 0,
                Estado = x.vehiculo.Estado ?? string.Empty
            };
        }).ToList();

        return result;
    }

    public async Task<int> InsertarCoDeudor(VentaCoDeudorRequest request)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var coDeudor = new VentaCoDeudor
        {
            VentaId = request.VentaId,
            ClienteId = request.ClienteId,
            FechaAgregado = DateTime.Now
        };

        ctx.VentaCoDeudor.Add(coDeudor);
        await ctx.SaveChangesAsync();

        return coDeudor.VentaCoDeudorId;
    }
}