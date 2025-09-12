using System.Threading.Tasks;
using ApiComercial.Models.Request;
using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IAuthService
    {
        Task<Usuario?> ValidateUserAsync(LoginRequest request);
        string GenerateJwtToken(Usuario user);
    }
}
