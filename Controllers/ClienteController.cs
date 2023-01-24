using Microsoft.AspNetCore.Mvc;
using ApiComercial.Models;
using AutoMapper;
using ApiComercial.interfaces;
using ApiComercial.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace ApiComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ClienteController : BaseApiController
    {
        private readonly ILogger<ClienteController> _Logger;
        private readonly IMapper _mapper;
        private readonly IclientesServices _service;
        public ClienteController(ILogger<ClienteController> logger,
                                IMapper mapper,
                                IclientesServices service)
        {
            _Logger = logger;
            _mapper = mapper;
            _service = service;
        }
        //[HttpGet("{id}")]
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

        [HttpGet("{Id}")]
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
        public async Task<ActionResult> GetClientePorId(int Id)
        {
            var resultado = await _service.GetClientePorId(Id);
            var respuesta = Mapper.Map<ResponseClientes>(resultado);
            return Ok(respuesta);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created )]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<Clientes> InsertClientes(Clientes clientes)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCliente()
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public async Task<ResponseClientes> UpdateCliente(Clientes clientes)
        {
            throw new NotImplementedException();
        }
        
    }

}
