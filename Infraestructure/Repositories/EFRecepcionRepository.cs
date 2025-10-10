using ApiComercial.Models.Responses.Recepcion;
using ApiComercial.Repositories.Interfaces;

namespace ApiComercial.Infraestructure.Repositories;

public class EFRecepcionRepository : IRecepcionRepository
{
    public async Task<RecepcionResponse?> GetRecepciones()
    {
        throw new NotImplementedException();
    }

    public async Task<RecepcionResponse?> GetRecepcionByChasis(string chasis)
    {
        throw new NotImplementedException();
    }
}