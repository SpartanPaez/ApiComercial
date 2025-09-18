using ApiComercial.Models;
using ApiComercial.Models.Request;
using ApiComercial.Models.Responses;
using ApiComercial.Models.Responses.Pagos;
using ApiComercial.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiComercial.Controllers;

[ApiController]
[Authorize]
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

    /// <summary>
    /// Consulta las ventas al contado
    /// </summary>
    [HttpGet("VentasContado")]
    [ProducesResponseType(typeof(IEnumerable<VentasResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> VentasContado()
    {
        try
        {
            var resultado = await _service.ObtenerVentasContado();
            if (resultado == null || !resultado.Any())
            {
                return NoContent();
            }
            var respuesta = _mapper.Map<IEnumerable<VentasResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar las ventas al contado");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - ventas al contado"
            });
        }
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
    //para obtener refuerzos
    [HttpGet("{idVenta}/Refuerzos")]
    [ProducesResponseType(typeof(RefuerzoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ObtenerRefuerzos(int idVenta)
    {
        try
        {
            var resultado = await _service.ObtenerRefuerzos(idVenta);
            var respuesta = _mapper.Map<IEnumerable<RefuerzoResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar los refuerzos");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - refuerzos"
            });
        }
    }

    //para insertar refuerzo
    [HttpPost("InsertarRefuerzo")]
    [ProducesResponseType(typeof(RefuerzoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertarRefuerzo(RefuerzoRequest parametros)
    {
        try
        {
            var resultado = await _service.InsertarRefuerzo(parametros);
            return Ok(resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al insertar el refuerzo");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de inserción del refuerzo"
            });
        }
    }
    //Eliminar venta a cuotas
    [HttpDelete("EliminarVentaCuotas/{idVenta}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> EliminarVentaCuotas(int idVenta)
    {
        try
        {
            var resultado = await _service.EliminarVentaCuotas(idVenta);
            return Ok(resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al eliminar la venta a cuotas");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de eliminación de la venta a cuotas"
            });
        }

    }

    [HttpGet("ListaAtrasos")]
    [ProducesResponseType(typeof(IEnumerable<ListaAtrasoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> ObtenerListaAtrasos()
    {
        try
        {
            var resultado = await _service.ObtenerListaAtrasos();
            if (resultado == null || !resultado.Any())
            {
                return NoContent();
            }
            var respuesta = _mapper.Map<IEnumerable<ListaAtrasoResponse>>(resultado);
            return Ok(respuesta);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar la lista de atrasos");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - lista de atrasos"
            });
        }
    }
    [HttpGet("CantidadCuotasAtrasadas")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CantidadCuotasAtrasadas()
    {
        try
        {
            var resultado = await _service.CantidadCuotasAtrasadas();
            return Ok(resultado);
        }
        catch (System.Exception e)
        {
            _Logger.LogError(e, "Ocurrió un error al consultar la cantidad de cuotas atrasadas");
            return StatusCode(500, new ErrorResponse
            {
                ErrorType = Enums.ErrorType.error_interno_servidor,
                ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos - cantidad de cuotas atrasadas"
            });
        }
    }
}