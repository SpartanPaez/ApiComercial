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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        public async Task<ActionResult> InsertProducto(RequestProducto parametros)
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

        [HttpPut("productos")]
        [ProducesResponseType(typeof(ResponseProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProducto(ResponseProducto parametros)
        {
            try
            {
                var resquet = Mapper.Map<Producto>(parametros);
                bool existe = await _service.ExisteProducto(parametros.ProductoId, parametros.ProductoLote!);
                if (existe)
                {
                    var resultado = await _service.UpdateProducto(resquet);
                    return Ok();
                }
                else
                {
                   var resultado = await _service.InsertProducto(resquet);
                   return Created("", _service.GetProductoPorId(parametros.ProductoLote!));
                } 
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al intentar actualizar los datos del producto.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar actualizar los datos del producto."
                });
            }

        }
        [HttpDelete("productos/{ProductoId}")]
        [ProducesResponseType(typeof(ResponseProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteProducto(int ProductoId)
        {
            try
            {
                var resultado = await _service.DeleteProducto(ProductoId);
                return Ok();
            }
            catch (System.Exception e)
            {
                _logger.LogError(e, "Ocurrió un error al intentar eliminar los datos del producto.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error al intentar eliminar los datos del producto."
                });
            }
        }
        //Necesito un endpoint que me muestre los productos por vencerse en los proximos 30 dias
        [HttpGet("productos/vencimiento")]
        [ProducesResponseType(typeof(ResponseProducto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetProductoVencimiento( DateTime FechaVencimiento)
        {
            try
            {
                var resultado = await _service.GetProductosVencimiento(FechaVencimiento);
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


    }
}