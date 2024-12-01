using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class EFReferencialesRepository : IreferencialesRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="my"></param>
        /// <param name="configuration"></param>
        public EFReferencialesRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        /// <summary>
        /// Consulta la tabla de ciudades por codigo de departamento
        /// </summary>
        /// <param name="departamentoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Ciudad>> GetCiudadPorId(int departamentoId)
         => await _my.Ciudades
            .Where(c => c.DepartamentoId == departamentoId)
            .ToListAsync();

        /// <summary>
        /// Consulta la tabla de departamentos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Departamento>> GetDepartamentoPorId()
           => await _my.Departamentos.ToListAsync();
        /// <summary>
        /// Consulta la tabla de paises
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Pais>> GetPais()
        => await _my.Paises.ToListAsync();
        /// <summary>
        /// Consulta datos de la tabla de usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<Usuario> GetUsuarios()
        => await _my.Usuarios.FirstOrDefaultAsync();
        /// <summary>
        /// inserta datos de ciudades
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            await _my.Ciudades.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Inserta datos para departamentos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Departamento> InsertDepartamento(Departamento parametros)
        {
            await _my.Departamentos.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Inserta datos de pais
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Pais> InsertPais(Pais parametros)
        {
            await _my.Paises.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Inserta datos de usuario
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Usuario> InsertUsuario(Usuario parametros)
        {
            await _my.Usuarios.AddRangeAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Actualiza los datos de la ciudad
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Ciudad> UpdateCiudad(Ciudad parametros)
        {
            _my.Ciudades.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Inserta datos de depositos
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Deposito> InsertDeposito(Deposito parametros)
        {
            await _my.Depositos.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Actualiza los datos de los depositos 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Deposito> UpdateDeposito(Deposito parametros)
        {
            _my.Depositos.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Consulta datos de depositos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Deposito>> GetDepositos()
        {
            return await _my.Depositos.ToListAsync();
        }
        /// <summary>
        /// Consulta los datos para login
        /// </summary>
        /// <param name="UsarName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public async Task<bool> LoginUsuario(string UsarName, string Password)
         => await _my.Usuarios.Where(c => c.UsuarioNic == UsarName && c.UsuarioPass == Password).CountAsync() > 0;
        /// <summary>
        /// Inserta los datos de los proveedores
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Proveedor> InsertarProveedor(Proveedor parametros)
        {
            await _my.proveedores.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Consulta los datos de los proveedores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Proveedor>> GetProveedor()
        => await _my.proveedores.ToListAsync();
        /// <summary>
        /// Consulta datos de categorias
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categoria>> GetCategoria()
        => await _my.categorias.ToListAsync();
        /// <summary>
        /// Inserta en la tabla de categorias
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<Categoria> InsertarCategoria(Categoria parametros)
        {
            await _my.categorias.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
        /// <summary>
        /// Obtiene los datos de barrio mediante ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Barrio>> GetBarrio(int id)
        => await _my.Barrios.AsNoTracking().Where(c => c.IdBarrio == id).ToListAsync();
        /// <summary>
        /// Consulta SQL que obtiene un listado de barrios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Barrio>> GetBarrios()
        {
            var barrios = await (from b in _my.Barrios.AsNoTracking()
                                 join c in _my.Ciudades.AsNoTracking() on b.IdCiudad equals c.CiudadId
                                 select new Barrio
                                 {
                                     IdBarrio = b.IdBarrio,
                                     Descripcion = b.Descripcion,
                                     ciudadDescripcion = c.CiudadDesc
                                 }).ToListAsync();
            return barrios;
        }
        /// <summary>
        /// EF para insertar Barrio
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Barrio> InsertatBarrio(Barrio parametros)
        {
            await _my.Barrios.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        /// <summary>
        /// Ef que enlista las ciudades
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ciudad>> GetCiudades()
        {
            return await _my.Ciudades.AsNoTracking().ToListAsync();
        }
    }
}