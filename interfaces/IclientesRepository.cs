using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IclientesRepository
    {
        Task<DatoCliente> GetDatoCliente();
    }
}