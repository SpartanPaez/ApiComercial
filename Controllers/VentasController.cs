using ApiComercial.Entities;
using ApiComercial.Entities.Cuotas;
using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiComercial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VentasController : BaseApiController
{
    private readonly ILogger<ClientesController> _Logger;
    private readonly IVentaService _service;
    private readonly IMapper _mapper;

    public VentasController(ILogger<ClientesController> logger,
                            IVentaService service,
                            IMapper mapper)
    {
        _Logger = logger;
        _service = service;
        _mapper = mapper;
    }
    //Mostrar medios de pago
    [HttpGet("MediosPago")]
    [ProducesResponseType(typeof(MediosPagoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> MediosPago()
    {
        try
        {
            var resultado = await _service.ObtenerMediosPago();
            var respuesta = _mapper.Map<IEnumerable<MediosPagoResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los medios de pago");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - medios de pago"
            });
        }
    }
    
    [HttpGet("cabeceraCuota")]
    [ProducesResponseType(typeof(CabeceraCuotaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CabeceraCuota()
    {
        try
        {
            var resultado = await _service.ObtenerCabeceraCuotas();
            var respuesta = Mapper.Map<IEnumerable<CabeceraCuotaResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los datos de la cabecera de las cuotas");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - cuotas cabecera"
            });
        }
    }

    [HttpGet("{idVenta}/DetalleCuota")]
    [ProducesResponseType(typeof(DetalleCuotaResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DetalleCuota(int idVenta)
    {
        try
        {
            var resultado = await _service.ObtenerDetalleCuotas(idVenta);
            var respuesta = Mapper.Map<IEnumerable<DetalleCuotaResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los datos de la cabecera de las cuotas");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - cuotas cabecera"
            });
        }
    }

    [HttpPut("PagarCuota")]
    [ProducesResponseType(typeof(PagarCuotaRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PagarCuota(PagarCuotaRequest cuota)
    {
        try
        {
            var resultado = await _service.PagarCuota(cuota);
            return Ok(resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los datos de la cabecera de las cuotas");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - cuotas cabecera"
            });
        }
    }
}