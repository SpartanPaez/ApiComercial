using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Request.Catalogo;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Catalogo;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services.Interfaces.Catalogo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.Request.Catalogo;
using Models.Responses.Catalogo;

namespace ApiComercial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogoAutosController : BaseApiController
{
    private readonly ILogger<CatalogoAutosController> _logger;
    private readonly ICatalogoAutoService _service;
    private readonly IMapper _mapper;

    public CatalogoAutosController(ILogger<CatalogoAutosController> logger,
                                ICatalogoAutoService service,
                                IMapper mapper)
    {
        _logger = logger;
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("auto-foto")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SubirArchivoFotoBase64([FromBody] FotoAutoBase64Request request)
    {
        try
        {
            var response = await _service.subirFoto(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar la foto del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al guardar la foto"
            });
        }
    }
    [HttpPost("auto-caracteristica")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AgregarCaracteristica([FromBody] AutoCaracteristicaRequest request)
    {
        try
        {
            var response = await _service.AgregarCaracteristicaAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar la característica del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al agregar la característica"
            });
        }
    }

    [HttpGet("{idChasis}/auto-caracteristicas")]
    [ProducesResponseType(typeof(List<AutoCaracteristicaResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<AutoCaracteristicaResponse>>> ObtenerCaracteristicas(string idChasis)
    {
        try
        {
            var response = await _service.ObtenerCaracteristicasAsync(idChasis);
            if (response == null || !response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener las características del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al obtener las características"
            });
        }
    }

    [HttpPost("auto-especificacion")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> AgregarEspecificacion([FromBody] AutoEspecificacionRequest request)
    {
        try
        {
            var response = await _service.AgregarEspecificacionAsync(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al agregar la especificación del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al agregar la especificación"
            });
        }
    }
    [HttpGet("{idChasis}/auto-especificaciones")]
    [ProducesResponseType(typeof(List<AutoEspecificacionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<AutoEspecificacionResponse>>> ObtenerEspecificaciones(string
    idChasis)
    {
        try
        {
            var response = await _service.ObtenerEspecificacionesAsync(idChasis);
            if (response == null || !response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener las especificaciones del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al obtener las especificaciones"
            });
        }
    }

    [HttpGet("{idChasis}/detalle")]
    [ProducesResponseType(typeof(AutoDetalleViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AutoDetalleViewModel>> ObtenerDetalleAuto(string idChasis)
    {
        try
        {
            var response = await _service.ObtenerDetalleAutoAsync(idChasis);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener el detalle del auto");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error al obtener el detalle del auto"
            });
        }
    }
   
}