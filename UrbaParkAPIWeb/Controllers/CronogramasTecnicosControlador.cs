using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/[controller]")]
    public class CronogramasTecnicosControlador : ControllerBase
    {
        private readonly ICronogramasTecnicosServicio _cronogramasTecnicosServicio;

        public CronogramasTecnicosControlador(ICronogramasTecnicosServicio cronogramasTecnicosServicio)
        {
            _cronogramasTecnicosServicio = cronogramasTecnicosServicio;
        }

        // Listar todos los cronogramas técnicos
        [HttpGet("Listar Cronograma")]
        public Task<IEnumerable<rel_cronogramas_tecnicos>> GetAllAsync()
        {
            return _cronogramasTecnicosServicio.CronogramaTecnicosGetAllAsync();
        }

        // Crear un nuevo cronograma técnico
        [HttpPost("crear nuevo cronograma")]
        public async Task<IActionResult> Crear([FromBody] rel_cronogramas_tecnicos nuevoCronograma)
        {
            try
            {
                await _cronogramasTecnicosServicio.CronogramaTecnicosAddAsync(nuevoCronograma);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el cronograma técnico: {ex.Message}");
                return StatusCode(500, "Error al crear el cronograma técnico");
            }
        }

        // Obtener cronograma técnico por ID
        [HttpGet("obtener cronograma técnico por ID")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cronograma = await _cronogramasTecnicosServicio.CronogramaTecnicosGetByIdAsync(id);
            if (cronograma == null)
                return NotFound(new { mensaje = $"No se encontró el cronograma técnico con ID {id}" });

            return Ok(cronograma);
        }

        // Actualizar cronograma técnico por ID
        [HttpPut("actualizar cronograma técnoco por ID")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] rel_cronogramas_tecnicos cronogramaActualizado)
        {
            try
            {
                var existe = await _cronogramasTecnicosServicio.CronogramaTecnicosGetByIdAsync(id);
                if (existe == null)
                    return NotFound(new { mensaje = $"No existe el cronograma técnico con ID {id}" });

                cronogramaActualizado.id_cronograma = id;
                await _cronogramasTecnicosServicio.CronogramaTecnicosUpdateAsync(cronogramaActualizado);

                return Ok(new { mensaje = "Cronograma técnico actualizado correctamente", datos = cronogramaActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el cronograma técnico: {ex.Message}");
                return StatusCode(500, "Error al actualizar el cronograma técnico");
            }
        }

        // Eliminar cronograma técnico por ID
        [HttpDelete("eliminar cronograma tecnoco por ID")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                var existe = await _cronogramasTecnicosServicio.CronogramaTecnicosGetByIdAsync(id);
                if (existe == null)
                    return NotFound(new { mensaje = $"No existe el cronograma técnico con ID {id}" });

                await _cronogramasTecnicosServicio.CronogramaTecnicosDeleteAsync(id);
                return Ok(new { mensaje = "Cronograma técnico eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el cronograma técnico: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el cronograma técnico");
            }
        }
    }
}