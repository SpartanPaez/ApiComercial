using ApiComercial.Entitie.Documentaciones;
using ApiComercial.Infraestructure.Data;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiComercial.Infraestructure.Repositories;

public class DocumentosRepository : IDocuementosRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;


    public DocumentosRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<int> InsertarDocumento(EstadoDocumentoRequest documento)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var nuevoDocumento = new EstadoDocumento
        {
            Codigo = documento.Codigo,
            Descripcion = documento.Descripcion,
            Orden = documento.Orden,
            EsFinal = documento.EsFinal
        };

        ctx.EstadosDocumentos.Add(nuevoDocumento);
        await ctx.SaveChangesAsync();

        return nuevoDocumento.Id;
    }

    public async Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await ctx.EstadosDocumentos
            .Select(x => new EstadoDocumentoResponse
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Orden = x.Orden,
                EsFinal = x.EsFinal
            })
            .ToListAsync();
    }
}