using Microsoft.EntityFrameworkCore;
using ApiComercial.Entities;
using ApiComercial.interfaces;

namespace ApiComercial.Infraestructure.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MysqlContext _context;
        public AuthRepository(MysqlContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUserByCredentialsAsync(string usuarioNic, string usuarioPass)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.UsuarioNic == usuarioNic && u.UsuarioPass == usuarioPass);
        }
    }
}
