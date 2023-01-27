using ApiComercial.Entities;

namespace ApiComercial.Infraestructure.interfaces
{
    public interface IreferencialesRepository
    {
        Task<Ciudad> GetCiudadPorId(int ciudadId);

        Task<Ciudad> InsertCiudad(Ciudad parametros);
    }
}