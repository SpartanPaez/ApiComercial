using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;

namespace ApiComercial.Services;

public class DocumentoService : IDocumentoService
{
    private readonly IDocuementosRepository _documentosRepository;
    public DocumentoService(IDocuementosRepository documentosRepository)
    {
        _documentosRepository = documentosRepository;
    }
    public async Task<int> InsertarDocumento(EstadoDocumentoRequest documento)
    {
        return await _documentosRepository.InsertarDocumento(documento);
    }

    public Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos()
    {
        return _documentosRepository.ObtenerDocumentos();
    }
}