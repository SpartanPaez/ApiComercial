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
        /// <summary>
        /// Reporte de productos por fecha 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Producto>> GetProductosPorFecha(DateTime fecha)
        => await _my.Productos.Where(x => x.ProductoFechaVencimiento == fecha).ToListAsync();
        /// <summary>
        /// Reporte de productos por fecha de vencimiento
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Producto>> GetProductosVencimiento(DateTime fecha)
        => await _my.Productos.Where(x => x.ProductoFechaVencimiento == fecha).ToListAsync();

        //un metodo que actualice los datos de los productos en la base de datos con el codigo de barra
        public async Task<Producto> UpdateProductoPorCodigoBarra(Producto parametros)
        {
            var producto = await _my.Productos.Where(x => x.ProductoCodigoBarra == parametros.ProductoCodigoBarra).FirstOrDefaultAsync();
            if (producto == null)
            {
                return null;
            }
            else
            {
                producto.ProductoNombre = parametros.ProductoNombre;
                producto.ProductoPrecio = parametros.ProductoPrecio;
                producto.ProductoFechaVencimiento = parametros.ProductoFechaVencimiento;
                producto.ProductoLote = parametros.ProductoLote;
                producto.ProductoExistencia = parametros.ProductoExistencia;
                producto.ProductoDescripcion = parametros.ProductoDescripcion;
                producto.IdCategoria = parametros.IdCategoria;
                await _my.SaveChangesAsync();
                return producto;
            }
        }


    }
}