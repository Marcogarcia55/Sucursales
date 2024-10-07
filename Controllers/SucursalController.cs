using Microsoft.AspNetCore.Mvc;
using Sucursales.Models;
using Sucursales.Service;

namespace Sucursales.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class SucursalController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var sucursal = await _sucursalService.GetAllAsync();
                return Ok(sucursal);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
                var sucursal = await _sucursalService.GetById(id);
                if(sucursal == null){
                    return NotFound();
                }
                return Ok(sucursal);
            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sucursal sucursal)
        {

            if(sucursal == null){
                return BadRequest("Product cannot be null");
            }
            try{
                var sucursals = await _sucursalService.AddAsync(sucursal);
                return CreatedAtAction(nameof(Get), new{Id = sucursal.IdSucursal}, sucursal);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Sucursal sucursal)
        {

            if(sucursal == null){
                return BadRequest("Product cannot be null");
            }
            try{
                var sucursals = await _sucursalService.UpdateAsync(sucursal);
                return Ok(sucursal);
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                var sucursal = await _sucursalService.DeleteAsync(id);
                return Ok();
            }catch(Exception){
                return StatusCode(500, "Internal service error");
            }
        }

    }
}
