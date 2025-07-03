using ApiComercial.Infraestructure.Data;
using ApiComercial.Infraestructure.Repositories.Interfaces;
using Entities.Catalogo;

public class CatalogoFotoAutoRepository : ICatalogoFotoAutoRepository
{
    private readonly MysqlContext _context;

    public CatalogoFotoAutoRepository(MysqlContext context)
    {
        _context = context;
    }

    public async Task InsertAsync(AutoFoto foto)
    {
        _context.AutoFotos.Add(foto);
        await _context.SaveChangesAsync();
    }
}
