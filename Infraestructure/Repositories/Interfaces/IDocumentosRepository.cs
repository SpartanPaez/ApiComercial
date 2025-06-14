using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;

namespace ApiComercial.Repositories.Interfaces;

public interface IDocuementosRepository
{
    Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos();
    Task<int> InsertarDocumento(EstadoDocumentoRequest documento);
    Task<int> InsertarDocumentacionOrigen(DocumentacionOrigenRequest documentacionOrigen);
    Task<IEnumerable<DocumentacionOrigenResponse>> ObtenerListadoDocumentacionOrigen();
    Task<int> InsertarArchivoDocumentoOrigen(ArchivoDocumentoOrigenRequest archivoDocumentoOrigen);
}
