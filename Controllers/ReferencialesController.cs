using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Entities;

namespace ApiComercial.Controllers
{
    //[ApiVersion("1.0")]
    [Route("api")]
    public class ReferencialesController : BaseApiController
    {
        private readonly ILogger<ReferencialesController> _Logger;
        private readonly IMapper _mapper;
        private readonly IreferencialesService _service;

        public ReferencialesController(ILogger<ReferencialesController> logger,
                                    IMapper mapper,
                                    IreferencialesService service)
        {
            _Logger = logger;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet("ciudades/{Id}")]
        [ProducesResponseType(typeof(CiudadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCiudadesPorId(int Id)
        {
            try
            {
                var resultado =  await _service.GetCiudadPorId(Id);
                var respuesta = Mapper.Map<CiudadResponse>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Inserta nuevas ciudades
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>                            
        [HttpPost("ciudades")]
        [ProducesResponseType(typeof(CiudadResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> InsertCiudad(RequestCiudad parametros)
        {
            var request = Mapper.Map<Ciudad>(parametros);
            var resultado = await _service.InsertCiudad(request);
            return Ok();
        }


        [HttpGet("departamentos/{Id}")]
        [ProducesResponseType(typeof(DepartamentoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GeDepartamentoPorId(int Id)
        {
            try
            {
                var resultado =  await _service.GetDepartamentoPorId(Id);
                var respuesta = Mapper.Map<DepartamentoResponse>(resultado);
                return Ok(respuesta);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("departamentos")]
        [ProducesResponseType(typeof(DepartamentoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult>InsertDepartamento(RequestDepartamento parametros)
        {
            var resquet = Mapper.Map<Departamento>(parametros);
            var resultado = await _service.InsertDepartamento(resquet);
            return Ok();
        }
    }
}