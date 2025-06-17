using System.Runtime.CompilerServices;
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

    public async Task<int> InsertarArchivoDocumentoOrigen(ArchivoDocumentoOrigenRequest archivoDocumentoOrigen)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var nuevoArchivo = new ArchivoDocumentoOrigen
        {
            DocumentacionOrigenId = archivoDocumentoOrigen.DocumentacionOrigenId,
            NombreArchivo = archivoDocumentoOrigen.NombreArchivo,
            RutaArchivo = archivoDocumentoOrigen.RutaArchivo,
            FechaSubida = DateTime.UtcNow
        };

        ctx.ArchivosDocumentacionOrigen.Add(nuevoArchivo);
        await ctx.SaveChangesAsync();

        return nuevoArchivo.Id;
    }

    public async Task<int> InsertarDocumentacionOrigen(DocumentacionOrigenRequest documentacionOrigen)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        var nuevaDocumentacion = new DocumentacionOrigen
        {
            IdChasis = documentacionOrigen.IdChasis,
            FechaRecepcion = documentacionOrigen.FechaRecepcion,
            Observacion = documentacionOrigen.Observacion,
            RegistradoPor = documentacionOrigen.RegistradoPor
        };

        ctx.ArchivosDocumentosOrigen.Add(nuevaDocumentacion);
        await ctx.SaveChangesAsync();

        return nuevaDocumentacion.Id;
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

    public async Task<List<ArchivoDocumentoOrigenResponse>> ObtenerArchivosPorDocumentacionId(int documentacionOrigenId)
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();
        return await ctx.ArchivosDocumentacionOrigen
            .Where(x => x.DocumentacionOrigenId == documentacionOrigenId)
            .Select(x => new ArchivoDocumentoOrigenResponse
            {
                Id = x.Id,
                DocumentacionOrigenId = x.DocumentacionOrigenId,
                NombreArchivo = x.NombreArchivo,
                RutaArchivo = x.RutaArchivo,
                FechaSubida = x.FechaSubida
            })
            .ToListAsync();
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

    public async Task<IEnumerable<DocumentacionOrigenResponse>> ObtenerListadoDocumentacionOrigen()
    {
        using var scope = _serviceScopeFactory.CreateAsyncScope();
        var ctx = scope.ServiceProvider.GetRequiredService<MysqlContext>();

        return await ctx.ArchivosDocumentosOrigen
            .Select(x => new DocumentacionOrigenResponse
            {
                Id = x.Id,
                IdChasis = x.IdChasis,
                FechaRecepcion = x.FechaRecepcion,
                Observacion = x.Observacion,
                RegistradoPor = x.RegistradoPor
            })
            .ToListAsync();
    }
}