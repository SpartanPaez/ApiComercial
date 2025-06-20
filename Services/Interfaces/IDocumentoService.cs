using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;

namespace ApiComercial.Repositories.Interfaces;

public interface IDocumentoService
{
    Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos();
    Task<int> InsertarDocumento(EstadoDocumentoRequest documento);
    Task<int> InsertarDocumentacionOrigen(DocumentacionOrigenRequest documentacionOrigen);
    Task<IEnumerable<DocumentacionOrigenResponse>> ObtenerListadoDocumentacionOrigen();
    Task<int> InsertarArchivoDocumentoOrigen(ArchivoDocumentoOrigenRequest archivoDocumentoOrigen);
    Task<List<ArchivoDocumentoOrigenResponse>> ObtenerArchivosPorDocumentacionId(int documentacionOrigenId);
    Task<int> InsertarEscribania(EscribaniaRequest escribaniaRequest);
    Task<IEnumerable<EscribaniaResponse>> ObtenerEscribanias();
    Task<int> InsertarDocumentacionPostVenta(DocumentacionPostVentaRequest documentacionPostVenta);
    Task<IEnumerable<DocumentacionPostVentaResponse>> ObtenerDocumentacionPostVenta();
    Task<int> InsertarArchivoDocumentoPostVenta(ArchivoPostVentaRequest archivoPostVentaRequest);
    Task<List<ArchivoPostVentaResponse>> ObtenerArchivosPorDocumentacionPostVentaId(int documentacionPostVentaId);
}