using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/parqueaderos")]
    public class ParqueaderosController : ControllerBase
    {
        private readonly IParqueaderosServicio _parqueaderosServicio;

        public ParqueaderosController(IParqueaderosServicio parqueaderosServicio)
        {
            _parqueaderosServicio = parqueaderosServicio;
        }

        //Obtener todos los parqueaderos
        [HttpGet("Listar todos los Parqueaderos")]
        public async Task<ActionResult<IEnumerable<parqueaderos>>> GetAllAsync()
        {
            var lista = await _parqueaderosServicio.ParqueaderosGetAllAsync();
            return Ok(lista);
        }

        // Obtener parqueadero por ID
        [HttpGet("Buscar Parquedero por ID")]
        public async Task<ActionResult<parqueaderos>> GetByIdAsync(int id)
        {
            var parqueadero = await _parqueaderosServicio.ParqueaderosGetByIdAsync(id);
            if (parqueadero == null)
                return NotFound(new { mensaje = $"No se encontró el parqueadero con ID {id}" });

            return Ok(parqueadero);
        }

        // Crear nuevo parqueadero
        [HttpPost("Crear Parqueadero")]
        public async Task<IActionResult> CrearAsync([FromBody] parqueaderos nuevoParqueadero)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _parqueaderosServicio.ParqueaderosAddAsync(nuevoParqueadero);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoParqueadero.id_parqueadero }, nuevoParqueadero);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el parqueadero: {ex.Message}");
                return StatusCode(500, "Error interno al crear el parqueadero");
            }
        }

        //Actualizar parqueadero
        [HttpPut("Acrualizar Parqueadero")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] parqueaderos parqueaderoActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _parqueaderosServicio.ParqueaderosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el parqueadero con ID {id}" });

            try
            {
                parqueaderoActualizado.id_parqueadero = id;
                await _parqueaderosServicio.ParqueaderosUpdateAsync(parqueaderoActualizado);
                return Ok(new { mensaje = "Parqueadero actualizado correctamente", datos = parqueaderoActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el parqueadero: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el parqueadero");
            }
        }

        // Eliminar parqueadero
        [HttpDelete("Eliminar Parqueadero por ID")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _parqueaderosServicio.ParqueaderosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el parqueadero con ID {id}" });

            try
            {
                await _parqueaderosServicio.ParqueaderosDeleteAsync(id);
                return Ok(new { mensaje = "Parqueadero eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el parqueadero: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el parqueadero");
            }
        }
    }
}