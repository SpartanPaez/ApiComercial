using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;

namespace ApiComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReferencialesController : BaseApiController
    {
        private readonly IclientesServices _service;
        [HttpGet()]
        /// <summary>
        /// </summary>
        /// <param name="ClienteId">Recibe el codigo del cliente a ser consultado</param>
        /// <returns></returns>
        /// 
        [ProducesResponseType(typeof(ResponseClientes), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetCliente()
        {
            var resultado = await _service.GetDatoCliente();
            var respuesta = Mapper.Map<ResponseClientes>(resultado);
            return Ok(respuesta);
        }
    }
}