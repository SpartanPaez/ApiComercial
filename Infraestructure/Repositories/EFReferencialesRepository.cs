using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories
{
    public class EFReferencialesRepository : IreferencialesRepository
    {
        private readonly MysqlContext _my;
        private readonly string? _mysqlconnection;
        public EFReferencialesRepository(MysqlContext my, IConfiguration configuration)
        {
            _my = my;
            _mysqlconnection = configuration.GetConnectionString("Default");
        }
        public async Task<Ciudad> GetCiudadPorId(int departamentoId)
         => await _my.Ciudades
            .Where(c => c.DepartamentoId == departamentoId)
            .FirstOrDefaultAsync();

        public async Task<Departamento> GetDepartamentoPorId(int departamentoId)
           => await _my.Departamentos
                    .Where(c => c.DepartamentoId == departamentoId)
                    .FirstOrDefaultAsync();

        public async Task<IEnumerable<Pais>> GetPais()
        => await _my.Paises.ToListAsync();

        public async Task<Usuario> GetUsuarios()
        => await _my.Usuarios.FirstOrDefaultAsync();

        public async Task<Ciudad> InsertCiudad(Ciudad parametros)
        {
            await _my.Ciudades.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Departamento> InsertDepartamento(Departamento parametros)
        {
            await _my.Departamentos.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Pais> InsertPais(Pais parametros)
        {
            await _my.Paises.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Usuario> InsertUsuario(Usuario parametros)
        {
            await _my.Usuarios.AddRangeAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Ciudad> UpdateCiudad(Ciudad parametros)
        {
            _my.Ciudades.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Deposito> InsertDeposito(Deposito parametros)
        {
            await _my.Depositos.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<Deposito> UpdateDeposito(Deposito parametros)
        {
            _my.Depositos.Update(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }

        public async Task<IEnumerable<Deposito>> GetDepositos()
        {
            return await _my.Depositos.ToListAsync();
        }

        public async Task<bool> LoginUsuario(string UsarName, string Password)
         => await _my.Usuarios.Where(c => c.UsuarioNic == UsarName && c.UsuarioPass == Password).CountAsync() > 0;

        public async Task<Proveedor> InsertarProveedor(Proveedor parametros)
        {
            await _my.proveedores.AddAsync(parametros);
            await _my.SaveChangesAsync();
            return parametros;
        }
    }
}