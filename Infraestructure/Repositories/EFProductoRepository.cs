using ApiComercial.interfaces;
using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    public class EFProductoRepository : IproductoRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;
        public EFProductoRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        /// <summary>
        /// </summary>
        /// <param name="ProductoId"></param>
        /// <param name="ProductoLote"></param>
        /// <returns>Verifica si existe un producto en la base de datos</returns>
        public async Task<bool> ExisteProducto(int ProductoId, string ProductoLote)
        => await _my.Productos.Where(x => x.ProductoId == ProductoId)
        .Where(x => x.ProductoLote == ProductoLote)
        .CountAsync() > 0;

        /// <summary>
        /// Obtiene un producto por su codigo de barra
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <returns></returns>
        public async Task<Producto> GetProductoPorId(string codigoBarra)
        => await _my.Productos.Where(x => x.ProductoCodigoBarra == codigoBarra)
        .FirstOrDefaultAsync();

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Producto>> GetProductos()
         => await _my.Productos.ToListAsync();

        /// <summary>
        /// Inserta un producto en la base de datos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Producto> InsertProducto(Producto parametros)
        {
            await _my.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Actualiza un producto en la base de datos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Producto> UpdateProducto(Producto parametros)
        {
            _my.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        /// <param name="ProductoId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProducto(int ProductoId)
        {
            var producto = await _my.Productos.Where(x => x.ProductoId == ProductoId).FirstOrDefaultAsync();
            if (producto == null)
            {
                return false;
            }
            else
            {
                _my.Productos.Remove(producto);
                await _my.SaveChangesAsync();
                return true;
            }
        }
        //reporte de productos por fecha en entity framework
        public async Task<IEnumerable<Producto>> GetProductosPorFecha(DateTime fecha)
        => await _my.Productos.Where(x => x.ProductoFechaVencimiento == fecha).ToListAsync();


    }
}