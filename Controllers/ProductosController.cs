using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Entities;

namespace ApiComercial.Controllers
{
    [Route("api")]
    public class ProductosController : BaseApiController
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IMapper _mapper;
        private readonly IproductosService _service;

        public ProductosController(ILogger<ProductosController> logger,
                                IMapper mapper,
                                IproductosService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("productos")]
        [ProducesResponseType(typeof(ResponseProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProducto()
        {
            try
            {
                var resultado = await _service.GetProductos();
                var respuesta = Mapper.Map<IEnumerable<ResponseProducto>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al consultar los datos del producto");
                return StatusCode(500, new ErrorResponse
                {
                  ErrorType = Enums.ErrorType.error_interno_servidor,
                  ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos del producto"
                });
                
            }
        }
        [HttpPost("productos")]
        [ProducesResponseType(typeof(ResponseProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertUsuarios(RequestProducto parametros)
        {
            try
            {
                var resquet = Mapper.Map<Producto>(parametros);
                var resultado = await _service.InsertProducto(resquet);
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al intentar insertar los datos del producto.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar insertar los datos del producto."
                });
            }

        }
    }
}