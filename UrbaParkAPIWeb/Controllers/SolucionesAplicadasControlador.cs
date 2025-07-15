using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/soluciones-aplicadas")]
    public class SolucionesAplicadasController : ControllerBase
    {
        private readonly ISolucionesAplicadasServicio _solucionesAplicadasServicio;

        public SolucionesAplicadasController(ISolucionesAplicadasServicio solucionesAplicadasServicio)
        {
            _solucionesAplicadasServicio = solucionesAplicadasServicio;
        }

        // Obtener todas las soluciones aplicadas
        [HttpGet("Listar Soluciones Aplicadas")]
        public async Task<ActionResult<IEnumerable<soluciones_aplicadas>>> GetAllAsync()
        {
            var lista = await _solucionesAplicadasServicio.SolucionesAplicadasGetAllAsync();
            return Ok(lista);
        }

        //  Obtener solución por ID
        [HttpGet("Buscar Solucion Aplicada por ID")]
        public async Task<ActionResult<soluciones_aplicadas>> GetByIdAsync(int id)
        {
            var solucion = await _solucionesAplicadasServicio.SolucionesAplicadasGetByIdAsync(id);
            if (solucion == null)
                return NotFound(new { mensaje = $"No se encontró la solución aplicada con ID {id}" });

            return Ok(solucion);
        }

        // Crear nueva solución
        [HttpPost("Ingresar Solucion Aplicada")]
        public async Task<IActionResult> CrearAsync([FromBody] soluciones_aplicadas nuevaSolucion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _solucionesAplicadasServicio.SolucionesAplicadasAddAsync(nuevaSolucion);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevaSolucion.id_solucion }, nuevaSolucion);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la solución: {ex.Message}");
                return StatusCode(500, "Error interno al crear la solución aplicada");
            }
        }

        // Actualizar solución aplicada
        [HttpPut("Modificar Solución Aplicada")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] soluciones_aplicadas solucionActualizada)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _solucionesAplicadasServicio.SolucionesAplicadasGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe la solución aplicada con ID {id}" });

            try
            {
                solucionActualizada.id_solucion = id;
                await _solucionesAplicadasServicio.SolucionesAplicadasUpdateAsync(solucionActualizada);
                return Ok(new { mensaje = "Solución actualizada correctamente", datos = solucionActualizada });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la solución: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar la solución aplicada");
            }
        }

        //  Eliminar solución aplicada
        [HttpDelete("Eliminar Soluciuon Aplicada")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _solucionesAplicadasServicio.SolucionesAplicadasGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe la solución aplicada con ID {id}" });

            try
            {
                await _solucionesAplicadasServicio.SolucionesAplicadasDeleteAsync(id);
                return Ok(new { mensaje = "Solución aplicada eliminada correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la solución: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar la solución aplicada");
            }
        }
    }
}