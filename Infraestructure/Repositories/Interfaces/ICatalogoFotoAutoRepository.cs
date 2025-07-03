using Entities.Catalogo;

namespace ApiComercial.Infraestructure.Repositories.Interfaces;

public interface ICatalogoFotoAutoRepository
{
    Task InsertAsync(AutoFoto foto);
}
