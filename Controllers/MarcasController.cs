using ApiComercial.Entities;
using ApiComercial.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComercial.Controllers
{
[ApiController]
[Authorize]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaModeloService _service;

        public MarcasController(IMarcaModeloService service)
        {
            _service = service;
        }

        // Endpoints para MarcaAuto
        [HttpGet("marcas")]
        public async Task<ActionResult<IEnumerable<MarcaAuto>>> GetMarcas()
        {
            var marcas = await _service.GetMarcas();
            return Ok(marcas);
        }

        [HttpGet("marcas/{id}")]
        public async Task<ActionResult<MarcaAuto>> GetMarcaPorId(int id)
        {
            var marca = await _service.GetMarcaPorId(id);
            if (marca == null)
                return NotFound();
            return Ok(marca);
        }

        [HttpPost("marcas")]
        public async Task<ActionResult<MarcaAuto>> InsertMarca(MarcaAuto marca)
        {
            var nuevaMarca = await _service.InsertMarca(marca);
            return CreatedAtAction(nameof(GetMarcaPorId), new { id = nuevaMarca.IdMarca }, nuevaMarca);
        }

        [HttpPut("marcas/{id}")]
        public async Task<ActionResult> UpdateMarca(int id, MarcaAuto marca)
        {
            if (id != marca.IdMarca)
                return BadRequest();
            
            await _service.UpdateMarca(marca);
            return NoContent();
        }

        [HttpDelete("marcas/{id}")]
        public async Task<ActionResult> DeleteMarca(int id)
        {
            var result = await _service.DeleteMarca(id);
            if (!result)
                return NotFound();
            
            return NoContent();
        }
    }
}
