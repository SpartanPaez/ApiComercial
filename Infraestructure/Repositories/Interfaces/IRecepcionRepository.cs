using ApiComercial.Models.Responses.Recepcion;

namespace ApiComercial.Repositories.Interfaces;

public interface IRecepcionRepository
{
    Task<RecepcionResponse?> GetRecepciones();
    Task<RecepcionResponse?> GetRecepcionByChasis(string chasis);
    
}