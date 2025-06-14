using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiComercial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentosController : BaseApiController
{
    private readonly ILogger<DocumentosController> _Logger;
    private readonly IDocumentoService _service;
    private readonly IMapper _mapper;

    public DocumentosController(ILogger<DocumentosController> logger,
                                IDocumentoService service,
                                IMapper mapper)
    {
        _Logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{idEstado}")]
    [ProducesResponseType(typeof(EstadoDocumentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ObtenerDocumentos(int idEstado)
    {
        try
        {
            var resultado = await _service.ObtenerDocumentos(idEstado);
            var respuesta = _mapper.Map<IEnumerable<EstadoDocumentoResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los documentos");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de documentos"
            });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarDocumento([FromBody] EstadoDocumentoRequest documento)
    {
        try
        {
            if (documento == null)
            {
                return BadRequest(new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "El documento no puede ser nulo"
                });
            }

            var resultado = await _service.InsertarDocumento(documento);
            return CreatedAtAction(nameof(ObtenerDocumentos), new { idEstado = documento.Codigo }, resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar el documento");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción del documento"
            });
        }
    }
}     