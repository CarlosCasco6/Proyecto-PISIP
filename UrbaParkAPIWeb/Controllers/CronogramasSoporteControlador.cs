using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/[controller]")]
    public class CronogramasSoporteControlador : ControllerBase
    {
        private readonly ICronogramasSoporteServicio _cronogramasSoporteServicio;

        public CronogramasSoporteControlador(ICronogramasSoporteServicio cronogramasSoporteServicio)
        {
            _cronogramasSoporteServicio =  cronogramasSoporteServicio;
        }

        // Listar todos los cronogramas
        [HttpGet("Listar Cronograma")]
        public Task<IEnumerable<cronogramas_soporte>> CronogramaSoporteGetAllAsync()
        {
            return _cronogramasSoporteServicio.CronogramaSoporteGetAllAsync();
        }

        // Crear un nuevo cronograma
        [HttpPost("crear cronograma")]
        public async Task<IActionResult> CrearCronograma([FromBody] cronogramas_soporte nuevocronograma)
        {
            try
            {
                await _cronogramasSoporteServicio.CronogramaSoporteAddAsync(nuevocronograma);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el cronograma: {ex.Message}");
                return StatusCode(500, "Error al crear el cronograma");
            }
        }

        // Obtener cronograma por ID
        [HttpGet("Obtener Cronograma por ID")] //se debe modificar
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cronograma = await _cronogramasSoporteServicio.CronogramaSoporteGetByIdAsync(id);
            if (cronograma == null)
                return NotFound(new { mensaje = $"No se encontró el cronograma con ID {id}" });

            return Ok(cronograma);
        }

        // Actualizar cronograma por ID
        [HttpPut("Actualizar Cronograma")]
        public async Task<IActionResult> ActualizarCronograma(int id, [FromBody] cronogramas_soporte cronogramaActualizado)
        {
            try
            {
                var existe = await _cronogramasSoporteServicio.CronogramaSoporteGetByIdAsync(id);
                if (existe == null)
                    return NotFound(new { mensaje = $"No existe el cronograma con ID {id}" });

                cronogramaActualizado.id_cronograma = id; // Asegurar integridad de la ID
                await _cronogramasSoporteServicio.CronogramaSoporteUpdateAsync(cronogramaActualizado);

                return Ok(new { mensaje = "Cronograma actualizado correctamente", datos = cronogramaActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el cronograma: {ex.Message}");
                return StatusCode(500, "Error al actualizar el cronograma");
            }
        }

        // Eliminar cronograma por ID
        [HttpDelete("Eliminar Cronograma por ID")]
        public async Task<IActionResult> EliminarCronograma(int id)
        {
            try
            {
                var existe = await _cronogramasSoporteServicio.CronogramaSoporteGetByIdAsync(id);
                if (existe == null)
                    return NotFound(new { mensaje = $"No existe el cronograma con ID {id}" });

                await _cronogramasSoporteServicio.CronogramaSoporteDeleteAsync(id);
                return Ok(new { mensaje = "Cronograma eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el cronograma: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el cronograma");
            }
        }
    }
}