using Microsoft.AspNetCore.Mvc;
using Sucursales.Models;
using Sucursales.Service;

namespace Sucursales.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoService _puestoService;

        public PuestoController(IPuestoService puestoService)
        {
            _puestoService = puestoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var puesto = await _puestoService.GetAllAsync();
                return Ok(puesto);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
                var puesto = await _puestoService.GetById(id);
                if(puesto == null){
                    return NotFound();
                }
                return Ok(puesto);
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Puesto puesto)
        {

            if(puesto == null){
                return BadRequest("Product cannot be null");
            }
            try{
                var puestos = await _puestoService.AddAsync(puesto);
                return CreatedAtAction(nameof(Get), new{Id = puesto.IdPuesto}, puesto);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Puesto puesto)
        {

            if(puesto == null){
                return BadRequest("Product cannot be null");
            }
            try{
                var puestos = await _puestoService.UpdateAsync(puesto);
                return Ok(puesto);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var puestos = await _puestoService.DeleteAsync(id);
                return Ok();
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

    }
}
