using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Request.Catalogo;
using ApiComercial.Models.Responses;
using ApiComercial.Repositories.Interfaces;
using ApiComercial.Services.Interfaces.Catalogo;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

}