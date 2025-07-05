using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories.Interfaces;
using ApiComercial.Models.Responses.Catalogo;
using Entities.Catalogo;
using Microsoft.EntityFrameworkCore;
using Models.Request.Catalogo;
using Models.Responses.Catalogo;

public class CatalogoFotoAutoRepository : ICatalogoFotoAutoRepository
{
    private readonly MysqlContext _context;

    public CatalogoFotoAutoRepository(MysqlContext context)
    {
        _context = context;
    }

    public async Task<List<AutoCaracteristicaResponse>> ObtenerCaracteristicasPorChasis(string idChasis)
    {
        return await _context.AutoCaracteristicas
            .Where(c => c.IdChasis == idChasis)
            .Select(c => new AutoCaracteristicaResponse
            {
                Id = c.Id,
                Caracteristica = c.Caracteristica!
            })
            .ToListAsync();
    }

    public async Task InsertAsync(AutoFoto foto)
    {
        _context.AutoFotos.Add(foto);
        await _context.SaveChangesAsync();
    }

    public async Task<int> InsertarCaracteristica(AutoCaracteristicaRequest entity)
    {
        var caracteristica = new AutoCaracteristica
        {
            IdChasis = entity.IdChasis,
            Caracteristica = entity.Caracteristica
        };

        _context.AutoCaracteristicas.Add(caracteristica);
        await _context.SaveChangesAsync();

        return caracteristica.Id; // Retorna el ID de la nueva característica insertada
    }

    public async Task<string> InsertarEspecificacion(AutoEspecificacionRequest entity)
    {
        _context.AutoEspecificaciones.Add(new AutoEspecificacion
        {
            IdChasis = entity.IdChasis,
            Clave = entity.Clave,
            Valor = entity.Valor
        });
        await _context.SaveChangesAsync();
        return entity.IdChasis; // Retorna el ID del chasis asociado

    }

    public async Task<List<AutoEspecificacionResponse>> ObtenerEspecificacion(string idChasis)
    {

        return await _context.AutoEspecificaciones
            .Where(e => e.IdChasis == idChasis)
            .Select(e => new AutoEspecificacionResponse
            {
                Id = e.Id,
                Clave = e.Clave,
                Valor = e.Valor
            })
            .ToListAsync();
    }

    public async Task<AutoDetalleViewModel> ObtenerDetalleAutoAsync(string idChasis)
    {
        // 1. Consulta los datos básicos del vehículo
        var vehiculo = await (from v in _context.Vehiculos
                              join m in _context.Marcas on v.IdMarca equals m.IdMarca
                              join mo in _context.Modelos on v.IdModelo equals mo.IdModelo
                              where v.IdChasis == idChasis && v.Estado != "VENDIDO"
                              select new
                              {
                                  v.IdChasis,
                                  v.IdMarca,
                                  Marca = m.DescripcionMarca,
                                  v.IdModelo,
                                  Modelo = mo.DescripcionModelo,
                                  v.TipoCar,
                                  v.AnoFabricacion,
                                  v.Usado,
                                  v.Chapa,
                                  v.Estado,
                                  v.Precio
                              }).FirstOrDefaultAsync();

        if (vehiculo == null)
            return null;

        // 2. Resto de datos relacionados
        var fotos = await GetFotosAuto(idChasis);
        var caracteristicas = await ObtenerCaracteristicasPorChasis(idChasis);
        var especificaciones = await ObtenerEspecificacion(idChasis);

        // 3. Devuelve el ViewModel completo
        return new AutoDetalleViewModel
        {
            IdChasis = vehiculo.IdChasis,
            IdMarca = vehiculo.IdMarca,
            Marca = vehiculo.Marca,
            IdModelo = vehiculo.IdModelo,
            Modelo = vehiculo.Modelo,
            TipoCar = vehiculo.TipoCar,
            AnoFabricacion = vehiculo.AnoFabricacion,
            Usado = vehiculo.Usado,
            Chapa = vehiculo.Chapa,
            Estado = vehiculo.Estado,
            Precio = vehiculo.Precio,
            Fotos = fotos,
            Caracteristicas = caracteristicas,
            Especificaciones = especificaciones
        };
    }

    public async Task<List<FotoAutoResponse>> GetFotosAuto(string idChasis)
    {
        return await _context.AutoFotos
            .Where(f => f.IdChasis == idChasis)
            .Select(f => new FotoAutoResponse
            {
                Id = f.Id,
                UrlFoto = f.UrlFoto,
                EsPrincipal = f.EsPrincipal
            })
            .ToListAsync();
    }
    
}
