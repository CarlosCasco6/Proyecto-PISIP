using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/software-parqueaderos")]
    public class SoftwareParqueaderosController : ControllerBase
    {
        private readonly ISoftwareParqueaderosServicio _softwareParqueaderosServicio;

        public SoftwareParqueaderosController(ISoftwareParqueaderosServicio softwareParqueaderosServicio)
        {
            _softwareParqueaderosServicio = softwareParqueaderosServicio;
        }

        //Obtener todos los registros
        [HttpGet("Listar Regitro de Software de Parqueaderos")]
        public async Task<ActionResult<IEnumerable<software_parqueaderos>>> GetAllAsync()
        {
            var lista = await _softwareParqueaderosServicio.SoftwareParqueaderosGetAllAsync();
            return Ok(lista);
        }

        //  Obtener registro por ID
        [HttpGet("Buscar Registro de Software por ID")]
        public async Task<ActionResult<software_parqueaderos>> GetByIdAsync(int id)
        {
            var registro = await _softwareParqueaderosServicio.SoftwareParqueaderosGetByIdAsync(id);
            if (registro == null)
                return NotFound(new { mensaje = $"No se encontró el software-parqueadero con ID {id}" });

            return Ok(registro);
        }

        //Crear nuevo registro
        [HttpPost("Registar Software")]
        public async Task<IActionResult> CrearAsync([FromBody] software_parqueaderos nuevoRegistro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _softwareParqueaderosServicio.SoftwareParqueaderosAddAsync(nuevoRegistro);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoRegistro.id_software }, nuevoRegistro);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el registro: {ex.Message}");
                return StatusCode(500, "Error interno al crear el registro");
            }
        }

        //Actualizar registro
        [HttpPut("Actualizar Resgisto de Software")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] software_parqueaderos registroActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _softwareParqueaderosServicio.SoftwareParqueaderosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el registro con ID {id}" });

            try
            {
                registroActualizado.id_software = id;
                await _softwareParqueaderosServicio.SoftwareParqueaderosUpdateAsync(registroActualizado);
                return Ok(new { mensaje = "Registro actualizado correctamente", datos = registroActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el registro: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el registro");
            }
        }

        // Eliminar registro
        [HttpDelete("Eliminar Registro de Software")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _softwareParqueaderosServicio.SoftwareParqueaderosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el registro con ID {id}" });

            try
            {
                await _softwareParqueaderosServicio.SoftwareParqueaderosDeleteAsync(id);
                return Ok(new { mensaje = "Registro eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el registro: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el registro");
            }
        }
    }
}