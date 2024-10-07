using Microsoft.AspNetCore.Mvc;
using Sucursales.Models;
using Sucursales.Service;

namespace Sucursales.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var empleado = await _empleadoService.GetAllAsync();
                return Ok(empleado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpGet("bySucursal/{id}")] 
        public async Task<IActionResult> GetBySucursal(int id)
        {
           
                var empleado = await _empleadoService.GetAllEmpleadoBySucursalAsync(id);
                return Ok(empleado);
            
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empleado = await _empleadoService.GetById(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                return Ok(empleado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal service error");

            }


        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {

            if (empleado == null)
            {
                return BadRequest("Product cannot be null");
            }
            try
            {
                var empleados = await _empleadoService.AddAsync(empleado);
                return CreatedAtAction(nameof(Get), new { Id = empleado.IdSucursal }, empleado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Empleado empleado)
        {

            if (empleado == null)
            {
                return BadRequest("Product cannot be null");
            }
            try
            {
                var empleados = await _empleadoService.UpdateAsync(empleado);
                return Ok(empleado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal service error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var empleado = await _empleadoService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal service error");
            }
        }

    }
}
