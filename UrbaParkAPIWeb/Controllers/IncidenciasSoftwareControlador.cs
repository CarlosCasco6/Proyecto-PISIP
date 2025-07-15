using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/incidencias-software")]
    public class IncidenciasSoftwareController : ControllerBase
    {
        private readonly IIncidenciasSoftwareServicio _incidenciasSoftwareServicio;

        public IncidenciasSoftwareController(IIncidenciasSoftwareServicio incidenciasSoftwareServicio)
        {
            this._incidenciasSoftwareServicio = incidenciasSoftwareServicio;
        }

        // Obtener todas las incidencias
        [HttpGet("Listar todas las Incidencias")]
        public async Task<ActionResult<IEnumerable<incidencias_software>>> GetAllAsync()
        {
            var lista = await _incidenciasSoftwareServicio.IncidenciasSoftwareGetAllAsync();
            return Ok(lista);
        }

        // Obtener por ID
        [HttpGet("Buscar Incidencias por ID")]
        public async Task<ActionResult<incidencias_software>> GetByIdAsync(int id)
        {
            var incidencia = await _incidenciasSoftwareServicio.IncidenciasSoftwareGetByIdAsync(id);
            if (incidencia == null)
                return NotFound(new { mensaje = $"No se encontró la incidencia con ID {id}" });

            return Ok(incidencia);
        }

        //  Crear nueva incidencia
        [HttpPost("Crear nueva incidencia")]
        public async Task<IActionResult> CrearAsync([FromBody] incidencias_software nuevaIncidencia)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _incidenciasSoftwareServicio.IncidenciasSoftwareAddAsync(nuevaIncidencia);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevaIncidencia.id_incidencia }, nuevaIncidencia);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la incidencia: {ex.Message}");
                return StatusCode(500, "Error interno al crear la incidencia");
            }
        }

        // Actualizar incidencia
        [HttpPut("Actualizar Incidencia")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] incidencias_software incidenciaActualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _incidenciasSoftwareServicio.IncidenciasSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe la incidencia con ID {id}" });

            try
            {
                incidenciaActualizada.id_incidencia = id;
                await _incidenciasSoftwareServicio.IncidenciasSoftwareUpdateAsync(incidenciaActualizada);
                return Ok(new { mensaje = "Incidencia actualizada correctamente", datos = incidenciaActualizada });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la incidencia: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar la incidencia");
            }
        }

        //  Eliminar incidencia
        [HttpDelete("Eliminar Incidencia")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _incidenciasSoftwareServicio.IncidenciasSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe la incidencia con ID {id}" });

            try
            {
                await _incidenciasSoftwareServicio.IncidenciasSoftwareDeleteAsync(id);
                return Ok(new { mensaje = "Incidencia eliminada correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la incidencia: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar la incidencia");
            }
        }
    }
}