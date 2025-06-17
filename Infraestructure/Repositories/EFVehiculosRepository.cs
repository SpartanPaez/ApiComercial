using ApiComercial.Entities;
using ApiComercial.Infraestructure.Interfaces;
using ApiComercial.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ApiComercial.Models;

namespace ApiComercial.Infraestructure.Repositories
{
    /// <summary>
    /// Esta clase implementa la interfaz IVehiculoRepository para interactuar con la base de datos usando Entity Framework (EF Core).
    /// </summary>
    public class EFVehiculosRepository : IVehiculoRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;


        public EFVehiculosRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");

        }

        /// <summary>
        /// Consulta para vehiculos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            var vehiculos = await (from v in _my.Vehiculos
                                   join m in _my.Marcas on v.IdMarca equals m.IdMarca
                                   join mo in _my.Modelos on v.IdModelo equals mo.IdModelo
                                   select new Vehiculo
                                   {
                                       IdChasis = v.IdChasis,
                                       IdMarca = v.IdMarca,
                                       Marca = m.DescripcionMarca, // Nombre de la marca
                                       IdModelo = v.IdModelo,
                                       Modelo = mo.DescripcionModelo, // Nombre del modelo
                                       TipoCar = v.TipoCar,
                                       AnoFabricacion = v.AnoFabricacion,  // Convierte a string si es necesario
                                       Color = v.Color,
                                       Usado = v.Usado,
                                       Chapa = v.Chapa,
                                       Estado = v.Estado,
                                       Precio = v.Precio
                                   }).ToListAsync();
            return vehiculos;
        }


        /// <summary>
        /// Repositorio que inserta vehiculos a la base de datos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Vehiculo> InsertVehiculo(Vehiculo parametros)
        {
            // Convertir de InsertarVehiculoRequest a la entidad Vehiculo
            var nuevoVehiculo = new Vehiculo
            {
                IdChasis = parametros.IdChasis,
                IdMarca = parametros.IdMarca,  // Usa IdMarca en lugar de Marca
                IdModelo = parametros.IdModelo,
                TipoCar = parametros.TipoCar,
                AnoFabricacion = parametros.AnoFabricacion,
                Color = parametros.Color,
                Usado = parametros.Usado,
                Chapa = parametros.Chapa,
                Estado = parametros.Estado,
                Precio = parametros.Precio
            };

            await _my.Vehiculos.AddAsync(nuevoVehiculo);
            await _my.SaveChangesAsync();

            return parametros;
        }


        public async Task<Vehiculo> UpdateVehiculo(Vehiculo parametros)
        {
            _my.Vehiculos.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<bool> ExisteVehiculo(string idChasis)
        {
            return await _my.Vehiculos.AnyAsync(v => v.IdChasis == idChasis);
        }

        public async Task<bool> DeleteVehiculo(string idChasis)
        {
            var vehiculo = await _my.Vehiculos.FirstOrDefaultAsync(v => v.IdChasis == idChasis);
            if (vehiculo == null)
                return false;

            _my.Vehiculos.Remove(vehiculo);
            await _my.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculosVencimiento(string fecha)
        {
            return await _my.Vehiculos
                .Where(v => v.AnoFabricacion.ToString() == fecha) // Ajusta el filtro según la lógica de vencimiento
                .ToListAsync();
        }

        public Task<Vehiculo> GetVehiculoPorId(string idChasis)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estados>> GetEstados()
        => await _my.Estados.AsNoTracking().ToListAsync();

        /// <summary>
        /// Inserta estados
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Estados> InsertarEstados(Estados parametros)
        {
            _my.Estados.Add(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Selects de estados de vehiculos
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public async Task<int> GetCountByEstado(string estado)
        {
            var cleanEstado = estado.ToUpperInvariant().Trim();
            
            return await _my.Vehiculos.AsNoTracking()
                .Where(v => v.Estado!.ToUpper().Trim() == cleanEstado)
                .CountAsync();
        }
        /// <summary>
        /// Obtiene total de vehiculos no vendidos
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTotalVehiculos()
        {
            return await _my.Vehiculos.AsNoTracking()
           .Where(v => v.Estado!.Trim().ToUpper() != "VENDIDO")
           .CountAsync();
        }
        /// <summary>
        /// Task para obtener un listado de ventas
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Venta>> GetVentas()
        {
            return await _my.Ventas
            .ToListAsync();
        }
        /// <summary>
        /// Inserta ventas
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Venta> InsertVenta(Venta parametros)
        {
            _my.Ventas.Add(parametros);
            await _my.SaveChangesAsync();
            return parametros;

        }
        /// <summary>
        /// Inserta cuotas
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Cuota> InsertarCUota(Cuota parametros)
        {
            _my.Cuota.Add(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Guarda un detalle de venta en la base de datos.
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<DetalleVenta> InsertarDetalleVenta(DetalleVenta parametros)
        {
            _my.DetalleVenta.Add(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
    }
}
