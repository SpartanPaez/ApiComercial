using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Entities;

namespace ApiComercial.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : BaseApiController
    {
        private readonly ILogger<ClientesController> _Logger;
        private readonly IMapper _mapper;
        private readonly IclientesServices _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public ClientesController(ILogger<ClientesController> logger,
                                IMapper mapper,
                                IclientesServices service)
        {
            _Logger = logger;
            _mapper = mapper;
            _service = service;
        }
        /// <summary>
        /// Obtiene datos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(typeof(ResponseClientes), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> clientes()
        {
            try
            {
                var resultado = await _service.GetDatoCliente();
                var respuesta = Mapper.Map<IEnumerable<ResponseClientes>>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrió un error al consultar los datos del cliente");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error en el proceso de consulta de datos"
                });

            }

        }
        /// <summary>
        /// Obtiene datos del cliente por id del mismo
        /// </summary>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseClientes), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> clientes(int Id)
        {
            try
            {
                var resultado = await _service.GetClientePorId(Id);
                var respuesta = Mapper.Map<ResponseClientes>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception e)
            {
                _Logger.LogError(e, "Ocurrión un error de consulta de datos.");
                return StatusCode(500, new ErrorResponse
                {
                    ErrorType = Enums.ErrorType.error_interno_servidor,
                    ErrorDescripcion = "Ocurrió un error de consulta de datos."
                });
            }
        }
        /// <summary>
        /// Inserta datos de clientes
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> clientes(RequestDatoCliente parametros)
        {
            var resquest = Mapper.Map<Cliente>(parametros);
            var resultado = await _service.InsertCliente(resquest);
            return CreatedAtAction(nameof(clientes), new { Id = resultado.ClienteId }, resultado);
        }

        /// <summary>
        /// Actualiza datos del cliente
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> cliente(int id, RequestDatoCliente parametros)
        {
            var resquest = Mapper.Map<Cliente>(parametros);
            resquest.ClienteId = id;
            var resultado = await _service.UpdateCliente(resquest);
            return Ok(resultado);
        }
        /// <summary>
        /// Elimina datos del cliente por id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> cliente(int id)
        {
            var resultado = await _service.DeleteCliente(id);
            return Ok(resultado);
        }
    }
}
