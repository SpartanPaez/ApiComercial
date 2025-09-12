using System.Threading.Tasks;
using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IAuthRepository
    {
        Task<Usuario?> GetUserByCredentialsAsync(string usuarioNic, string usuarioPass);
    }
}
