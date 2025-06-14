using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;

namespace ApiComercial.Repositories.Interfaces;
public interface IDocumentoService
{
    Task<IEnumerable<EstadoDocumentoResponse>> ObtenerDocumentos();
    Task<int> InsertarDocumento(EstadoDocumentoRequest documento);
}