using ApiComercial.Entities;
using ApiComercial.Entities.Cuotas;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Models.Request.Refuerzos;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Pagos;
using ApiComercial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApiComercial.Models.Request;

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

        // Primero obtenemos las cabeceras de cuotas
        var cabeceras = await (from ventas in ctx.Ventas.AsNoTracking()
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
                          Telefono = clientes.ClienteCelular,
                          Direccion = clientes.ClienteDireccion,
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
                          TotalRestante = ventas.PrecioTotalCuotas - cuotasVenta.Where(c => c.EstadoCodigo == "PAGADO").Sum(c => c.MontoCuota),
                          CoDeudores = new List<CoDeudorResponse>()
                      })
                      .ToListAsync();

        // Luego obtenemos los co-deudores para cada venta
        var ventaIds = cabeceras.Select(c => c.IdVenta).Distinct().ToList();
        var coDeudores = await (from cd in ctx.VentaCoDeudor.AsNoTracking()
                               join cl in ctx.Clientes.AsNoTracking()
                               on cd.ClienteId equals cl.ClienteId
                               where ventaIds.Contains(cd.VentaId)
                               select new 
                               {
                                   VentaId = cd.VentaId,
                                   ClienteId = cd.ClienteId,
                                   CedulaCliente = cl.ClienteCedula,
                                   NombreCliente = cl.ClienteNombre,
                                   Telefono = cl.ClienteCelular,
                                   Direccion = cl.ClienteDireccion,
                                   FechaAgregado = cd.FechaAgregado
                               }).ToListAsync();
        
        // Asignamos los co-deudores a cada cabecera
        foreach (var cabecera in cabeceras)
        {
            cabecera.CoDeudores = coDeudores
                .Where(cd => cd.VentaId == cabecera.IdVenta)
                .Select(cd => new CoDeudorResponse
                {
                    ClienteId = cd.ClienteId,
                    CedulaCliente = cd.CedulaCliente,
                    NombreCliente = cd.NombreCliente,
                    Telefono = cd.Telefono,
                    Direccion = cd.Direccion,
                    FechaAgregado = cd.FechaAgregado
                }).ToList();
        }

        return cabeceras;
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

        // Traemos cuotas de la venta + pagos asociados para calcular montos derivados
        var cuotas = await (from c in ctx.Cuota.AsNoTracking()
                            where c.VentaId == idVenta
                            orderby c.FechaVencimiento ascending, c.NumeroCuota ascending
                            select c).ToListAsync();

        var cuotaIds = cuotas.Select(c => c.CuotaId).ToList();
        var pagos = await ctx.Pagos.AsNoTracking()
            .Where(p => cuotaIds.Contains(p.CuotaId))
            .ToListAsync();

        var resultado = cuotas.Select(c => {
            var pagosCuota = pagos.Where(p => p.CuotaId == c.CuotaId);
            var montoPagado = pagosCuota.Sum(p => p.Monto);
            // Regla: si MontoCuota > 0, lo tomamos como "monto original".
            // Si MontoCuota == 0 y hay pagos (caso histórico de mutación a saldo), el original es lo pagado.
            var montoOriginal = c.MontoCuota > 0 ? Convert.ToDecimal(c.MontoCuota) : montoPagado;
            var saldo = Math.Max(0m, montoOriginal - montoPagado);
            return new DetalleCuotaResponse
            {
                VentaId = c.VentaId,
                IdCuota = c.CuotaId,
                NumeroCuota = c.NumeroCuota,
                MontoCuota = c.MontoCuota,
                FechaVencimiento = c.FechaVencimiento,
                EstadoCodigo = c.EstadoCodigo,
                EsRefuerzo = c.EsRefuerzo,
                // Nuevos campos
                MontoOriginal = montoOriginal,
                MontoPagado = montoPagado,
                SaldoPendiente = saldo,
                DiasAtraso = c.DiasAtraso,
                MontoAtraso = c.MontoAtraso
            };
        }).ToList();

        return resultado;
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
        // 1) Contexto
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        // 2) Validaciones básicas
        //if (request.MontoPagado <= 0)
            ///throw new ArgumentException("El monto a pagar debe ser mayor a 0", nameof(request.MontoPagado));

        // 3) Cargar cuota
        var cuota = await ctx.Cuota.FirstOrDefaultAsync(c => c.CuotaId == request.CuotaId);
        if (cuota is null)
            throw new KeyNotFoundException($"No existe cuota con Id {request.CuotaId}");

        // 4) Calcular pagos previos y saldo pendiente usando la tabla Pagos
        var pagosPrevios = await ctx.Pagos
            .Where(p => p.CuotaId == request.CuotaId)
            .SumAsync(p => (decimal?)p.Monto) ?? 0m;

        var montoOriginal = Convert.ToDecimal(cuota.MontoCuota);
        var saldoPendiente = montoOriginal - pagosPrevios;

        if (saldoPendiente <= 0)
            throw new InvalidOperationException("La cuota ya se encuentra totalmente pagada.");

       // if (request.MontoPagado > saldoPendiente)
            //throw new InvalidOperationException($"El monto a pagar ({request.MontoPagado:N0}) supera el saldo pendiente ({saldoPendiente:N0}).");

        // 5) Registrar pago (no mutamos MontoCuota)
        var pago = new Pago
        {
            CuotaId = request.CuotaId,
            MedioPagoId = request.MedioPagoId,
            Monto = request.MontoPagado,
            Referencia = request.Referencia,
            FechaPago = request.FechaPago ?? DateTime.UtcNow
        };
        ctx.Pagos.Add(pago);

        // 6) Actualizar estado de la cuota según acumulado
        var pagadoLuego = pagosPrevios + request.MontoPagado;
        if (pagadoLuego >= montoOriginal)
        {
            cuota.DiasAtraso = request.DiasAtraso;
            cuota.MontoAtraso = request.MontoAtraso;
            cuota.EstadoCodigo = "PAGADO";
            if (!cuota.FechaPago.HasValue)
                cuota.FechaPago = request.FechaPago ?? DateTime.UtcNow;
        }
        // Si es pago parcial, no cambiamos EstadoCodigo para evitar violar la FK (dejar "PENDIENTE").

        var cambios = await ctx.SaveChangesAsync();
        return cambios > 0;
    }

    public async Task<string?> VerificaEstadoCuota(int idCuota)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await (from cuotas in ctx.Cuota.AsNoTracking()
                      where cuotas.CuotaId == idCuota
                      && (cuotas.EstadoCodigo == "PENDIENTE" || cuotas.EstadoCodigo == "PARCIAL")
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
            .OrderBy(r => r.FechaVencimiento)
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

    public async Task<int> PagarRefuerzo(PagarRefuerzoRequest parametros)
    {
        if (parametros.Monto <= 0)
            throw new ArgumentException("El monto a pagar debe ser mayor a 0", nameof(parametros.Monto));

        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var refuerzo = await ctx.Refuerzos.FirstOrDefaultAsync(r => r.RefuerzoId == parametros.RefuerzoId);
        if (refuerzo == null)
            throw new KeyNotFoundException($"No existe refuerzo con Id {parametros.RefuerzoId}");

        // Si ya está pagado, no procesar nuevamente
        if (refuerzo.Estado == "1")
            return refuerzo.RefuerzoId;

        // Validar que el pago no supere el saldo pendiente
        if (parametros.Monto > refuerzo.MontoRefuerzo)
            throw new InvalidOperationException($"El monto a pagar ({parametros.Monto:N0}) no puede superar el saldo pendiente del refuerzo ({refuerzo.MontoRefuerzo:N0}).");

        // Registrar historial del pago del refuerzo
        var pagoRef = new PagoRefuerzo
        {
            RefuerzoId = refuerzo.RefuerzoId,
            FechaPago = DateTime.UtcNow,
            Monto = parametros.Monto,
            MedioPagoId = parametros.MedioPagoId,
            IdBanco = parametros.IdBanco,
            Referencia = parametros.Referencia
        };
        ctx.PagosRefuerzos.Add(pagoRef);

        // Restar el pago del saldo del refuerzo
        refuerzo.MontoRefuerzo -= parametros.Monto;
        if (refuerzo.MontoRefuerzo <= 0)
        {
            refuerzo.MontoRefuerzo = 0; // no permitir negativos
            refuerzo.Estado = "1"; // pagado
        }

        // Guardar metadatos del último pago
        refuerzo.MedioPagoId = parametros.MedioPagoId;
        refuerzo.Referencia = parametros.Referencia;
        refuerzo.IdBanco = parametros.IdBanco;
        refuerzo.FechaPago = DateTime.UtcNow;

        await ctx.SaveChangesAsync();
        return refuerzo.RefuerzoId;
    }

    public async Task<ReportePagosResponse> ObtenerReportePagosAsync(ReportePagosRequest request)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var fechaHoy = DateTime.Today;

        var items = new List<ReportePagoItem>();

        // 1) Cuotas + Pagos
        if (request.IncluirCuotas)
        {
            var cuotasQuery = from cuota in ctx.Cuota.AsNoTracking()
                               join venta in ctx.Ventas.AsNoTracking() on cuota.VentaId equals venta.VentaId
                               join cliente in ctx.Clientes.AsNoTracking() on venta.ClienteId equals cliente.ClienteId
                               select new { cuota, venta, cliente };

            if (request.ClienteId.HasValue)
                cuotasQuery = cuotasQuery.Where(x => x.venta.ClienteId == request.ClienteId.Value);

            // Filtrado por vencimiento si corresponde
            if (string.Equals(request.TipoRango, "Vencimiento", StringComparison.OrdinalIgnoreCase) &&
                request.FechaInicio.HasValue && request.FechaFin.HasValue)
            {
                var ini = request.FechaInicio.Value.Date;
                var fin = request.FechaFin.Value.Date.AddDays(1).AddTicks(-1);
                cuotasQuery = cuotasQuery.Where(x => x.cuota.FechaVencimiento >= ini && x.cuota.FechaVencimiento <= fin);
            }

            var cuotasList = await cuotasQuery.ToListAsync();

            var cuotaIds = cuotasList.Select(x => x.cuota.CuotaId).ToList();
            var pagosCuotas = await ctx.Pagos.AsNoTracking()
                .Where(p => cuotaIds.Contains(p.CuotaId))
                .ToListAsync();

            foreach (var x in cuotasList)
            {
                var pagosDeCuota = pagosCuotas.Where(p => p.CuotaId == x.cuota.CuotaId);
                var montoOriginal = Convert.ToDecimal(x.cuota.MontoCuota);
                var pagadoTotal = pagosDeCuota.Sum(p => p.Monto);
                decimal pagadoEnRango = 0;
                var tipoRango = (request.TipoRango ?? "Todos").Trim();
                if ((string.Equals(tipoRango, "Pago", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(tipoRango, "Todos", StringComparison.OrdinalIgnoreCase))
                    && request.FechaInicio.HasValue && request.FechaFin.HasValue)
                {
                    var ini = request.FechaInicio.Value.Date;
                    var fin = request.FechaFin.Value.Date.AddDays(1).AddTicks(-1);
                    pagadoEnRango = pagosDeCuota.Where(p => p.FechaPago >= ini && p.FechaPago <= fin)
                                                .Sum(p => p.Monto);
                }

                var saldo = montoOriginal - pagadoTotal;
                var fechaPrimerPago = pagosDeCuota.Any() ? pagosDeCuota.Min(p => p.FechaPago) : (DateTime?)null;
                var fechaUltimoPago = pagosDeCuota.Any() ? pagosDeCuota.Max(p => p.FechaPago) : (DateTime?)null;

                var estado = pagadoTotal <= 0 ? "PENDIENTE" : (pagadoTotal < montoOriginal ? "PARCIAL" : "PAGADO");

                int? diasAtraso = null, diasAnticipo = null, diasVencidosActual = null;
                if (fechaUltimoPago.HasValue)
                {
                    var diff = (fechaUltimoPago.Value.Date - x.cuota.FechaVencimiento.Date).Days;
                    if (diff > 0) diasAtraso = diff;
                    if (diff < 0) diasAnticipo = Math.Abs(diff);
                }
                if (estado != "PAGADO" && x.cuota.FechaVencimiento.Date < fechaHoy)
                {
                    diasVencidosActual = (fechaHoy - x.cuota.FechaVencimiento.Date).Days;
                }

                items.Add(new ReportePagoItem
                {
                    Tipo = "Cuota",
                    VentaId = x.venta.VentaId,
                    ClienteId = x.cliente.ClienteId,
                    ClienteNombre = x.cliente.ClienteNombre ?? string.Empty,
                    CuotaId = x.cuota.CuotaId,
                    NumeroCuota = x.cuota.NumeroCuota,
                    RefuerzoId = null,
                    MontoOriginal = montoOriginal,
                    MontoPagadoTotal = pagadoTotal,
                    MontoPagadoEnRango = pagadoEnRango,
                    SaldoPendiente = saldo,
                    FechaVencimiento = x.cuota.FechaVencimiento,
                    FechaPrimerPago = fechaPrimerPago,
                    FechaUltimoPago = fechaUltimoPago,
                    Estado = estado,
                    DiasAtrasoAlCancelar = diasAtraso,
                    DiasAnticipoAlCancelar = diasAnticipo,
                    DiasVencidosActual = diasVencidosActual
                });
            }
        }

        // 2) Refuerzos + PagosRefuerzos
        if (request.IncluirRefuerzos)
        {
            var refQuery = from r in ctx.Refuerzos.AsNoTracking()
                           join v in ctx.Ventas.AsNoTracking() on r.VentaId equals v.VentaId
                           join c in ctx.Clientes.AsNoTracking() on v.ClienteId equals c.ClienteId
                           select new { r, v, c };

            if (request.ClienteId.HasValue)
                refQuery = refQuery.Where(x => x.v.ClienteId == request.ClienteId.Value);

            if (string.Equals(request.TipoRango, "Vencimiento", StringComparison.OrdinalIgnoreCase) &&
                request.FechaInicio.HasValue && request.FechaFin.HasValue)
            {
                var ini = request.FechaInicio.Value.Date;
                var fin = request.FechaFin.Value.Date.AddDays(1).AddTicks(-1);
                refQuery = refQuery.Where(x => x.r.FechaVencimiento >= ini && x.r.FechaVencimiento <= fin);
            }

            var refList = await refQuery.ToListAsync();

            var refIds = refList.Select(x => x.r.RefuerzoId).ToList();
            var pagosRef = await ctx.PagosRefuerzos.AsNoTracking()
                .Where(p => refIds.Contains(p.RefuerzoId))
                .ToListAsync();

            foreach (var x in refList)
            {
                var pagos = pagosRef.Where(p => p.RefuerzoId == x.r.RefuerzoId);
                var montoOriginal = x.r.MontoOriginal ?? x.r.MontoRefuerzo; // fallback por si no se pudo backfillear
                var pagadoTotal = pagos.Sum(p => p.Monto);
                decimal pagadoEnRango = 0;
                var tipoRangoRef = (request.TipoRango ?? "Todos").Trim();
                if ((string.Equals(tipoRangoRef, "Pago", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(tipoRangoRef, "Todos", StringComparison.OrdinalIgnoreCase))
                    && request.FechaInicio.HasValue && request.FechaFin.HasValue)
                {
                    var ini = request.FechaInicio.Value.Date;
                    var fin = request.FechaFin.Value.Date.AddDays(1).AddTicks(-1);
                    pagadoEnRango = pagos.Where(p => p.FechaPago >= ini && p.FechaPago <= fin)
                                         .Sum(p => p.Monto);
                }

                var saldo = (montoOriginal) - pagadoTotal;
                var fechaPrimerPago = pagos.Any() ? pagos.Min(p => p.FechaPago) : (DateTime?)null;
                var fechaUltimoPago = pagos.Any() ? pagos.Max(p => p.FechaPago) : (DateTime?)null;

                var estado = pagadoTotal <= 0 ? "PENDIENTE" : (pagadoTotal < montoOriginal ? "PARCIAL" : "PAGADO");

                int? diasAtraso = null, diasAnticipo = null, diasVencidosActual = null;
                if (fechaUltimoPago.HasValue && x.r.FechaVencimiento.HasValue)
                {
                    var diff = (fechaUltimoPago.Value.Date - x.r.FechaVencimiento.Value.Date).Days;
                    if (diff > 0) diasAtraso = diff;
                    if (diff < 0) diasAnticipo = Math.Abs(diff);
                }
                if (estado != "PAGADO" && x.r.FechaVencimiento.HasValue && x.r.FechaVencimiento.Value.Date < fechaHoy)
                {
                    diasVencidosActual = (fechaHoy - x.r.FechaVencimiento.Value.Date).Days;
                }

                items.Add(new ReportePagoItem
                {
                    Tipo = "Refuerzo",
                    VentaId = x.v.VentaId,
                    ClienteId = x.c.ClienteId,
                    ClienteNombre = x.c.ClienteNombre ?? string.Empty,
                    CuotaId = null,
                    NumeroCuota = null,
                    RefuerzoId = x.r.RefuerzoId,
                    MontoOriginal = montoOriginal,
                    MontoPagadoTotal = pagadoTotal,
                    MontoPagadoEnRango = pagadoEnRango,
                    SaldoPendiente = saldo,
                    FechaVencimiento = x.r.FechaVencimiento,
                    FechaPrimerPago = fechaPrimerPago,
                    FechaUltimoPago = fechaUltimoPago,
                    Estado = estado,
                    DiasAtrasoAlCancelar = diasAtraso,
                    DiasAnticipoAlCancelar = diasAnticipo,
                    DiasVencidosActual = diasVencidosActual
                });
            }
        }

        // Filtrado final por rango según TipoRango
        if (request.FechaInicio.HasValue && request.FechaFin.HasValue)
        {
            var ini = request.FechaInicio.Value.Date;
            var fin = request.FechaFin.Value.Date.AddDays(1).AddTicks(-1);
            var tipo = (request.TipoRango ?? "Todos").Trim();

            if (string.Equals(tipo, "Vencimiento", StringComparison.OrdinalIgnoreCase))
            {
                items = items.Where(i => i.FechaVencimiento.HasValue && i.FechaVencimiento.Value >= ini && i.FechaVencimiento.Value <= fin)
                             .ToList();
            }
            else if (string.Equals(tipo, "Pago", StringComparison.OrdinalIgnoreCase))
            {
                items = items.Where(i => i.FechaPrimerPago.HasValue || i.FechaUltimoPago.HasValue)
                             .Where(i => i.FechaPrimerPago.GetValueOrDefault() >= ini && i.FechaPrimerPago.GetValueOrDefault() <= fin
                                      || i.FechaUltimoPago.GetValueOrDefault() >= ini && i.FechaUltimoPago.GetValueOrDefault() <= fin)
                             .ToList();
            }
            else // "Todos" => cualquier item que venza en rango o tenga pagos en rango
            {
                items = items.Where(i =>
                        (i.FechaVencimiento.HasValue && i.FechaVencimiento.Value >= ini && i.FechaVencimiento.Value <= fin)
                     || (i.FechaPrimerPago.HasValue && i.FechaPrimerPago.Value >= ini && i.FechaPrimerPago.Value <= fin)
                     || (i.FechaUltimoPago.HasValue && i.FechaUltimoPago.Value >= ini && i.FechaUltimoPago.Value <= fin)
                ).ToList();
            }
        }

        // Totales
        var response = new ReportePagosResponse
        {
            Items = items,
            TotalPagadoEnRango = items.Sum(i => i.MontoPagadoEnRango),
            TotalPendiente = items.Sum(i => i.SaldoPendiente),
            TotalVenceEnRango = (request.FechaInicio.HasValue && request.FechaFin.HasValue)
                ? items.Where(i => i.FechaVencimiento.HasValue && i.FechaVencimiento.Value.Date >= request.FechaInicio.Value.Date && i.FechaVencimiento.Value.Date <= request.FechaFin.Value.Date)
                       .Sum(i => i.SaldoPendiente)
                : 0,
            TotalVencidoAlDia = items.Where(i => i.DiasVencidosActual.HasValue).Sum(i => i.SaldoPendiente)
        };

        return response;
    }
}