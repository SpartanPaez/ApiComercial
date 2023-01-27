using ApiComercial.Entities;

namespace ApiComercial.interfaces
{
    public interface IreferencialesService
    {
        Task<Ciudad> GetCiudadPorId(int ciudadId);

        Task<Ciudad> InsertCiudad(Ciudad parametros);
    }
}