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

    public async Task<int> InsertarArchivoDocumentoOrigen(ArchivoDocumentoOrigenRequest archivoDocumentoOrigen)
    {
        return await _documentosRepository.InsertarArchivoDocumentoOrigen(archivoDocumentoOrigen);
    }

    public Task<int> InsertarDocumentacionOrigen(DocumentacionOrigenRequest documentacionOrigen)
    {
        return _documentosRepository.InsertarDocumentacionOrigen(documentacionOrigen);
    }

    public async Task<int> InsertarDocumento(EstadoDocumentoRequest documento)
    {
        return await _documentosRepository.InsertarDocumento(documento);
    }

    public async Task<int> InsertarEscribania(EscribaniaRequest escribaniaRequest)
    {
        return await _documentosRepository.InsertarEscribania(escribaniaRequest);
    }

    public async Task<List<ArchivoDocumentoOrigenResponse>> ObtenerArchivosPorDocumentacionId(int documentacionOrigenId)
    {
       return await _documentosRepository.ObtenerArchivosPorDocumentacionId(documentacionOrigenId);
    }

    public Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos()
    {
        return _documentosRepository.ObtenerDocumentos();
    }

    public async Task<IEnumerable<EscribaniaResponse>> ObtenerEscribanias()
    {
        return await _documentosRepository.ObtenerEscribanias();
    }

    public async Task<IEnumerable<DocumentacionOrigenResponse>> ObtenerListadoDocumentacionOrigen()
    {
        return await _documentosRepository.ObtenerListadoDocumentacionOrigen();
    }
}