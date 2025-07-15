using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/tecnicos-software")]
    public class TecnicosSoftwareController : ControllerBase
    {
        private readonly ITecnicosSoftwareServicio _tecnicosSoftwareServicio;

        public TecnicosSoftwareController(ITecnicosSoftwareServicio tecnicosSoftwareServicio)
        {
            _tecnicosSoftwareServicio = tecnicosSoftwareServicio;
        }

        // ✅ Obtener todos los técnicos
        [HttpGet("Listar Tecnicos")]
        public async Task<ActionResult<IEnumerable<tecnicos_software>>> GetAllAsync()
        {
            var lista = await _tecnicosSoftwareServicio.TecnicosSoftwareGetAllAsync();
            return Ok(lista);
        }

        // ✅ Obtener técnico por ID
        [HttpGet("Buscar Técnico por ID")]
        public async Task<ActionResult<tecnicos_software>> GetByIdAsync(int id)
        {
            var tecnico = await _tecnicosSoftwareServicio.TecnicosSoftwareGetByIdAsync(id);
            if (tecnico == null)
                return NotFound(new { mensaje = $"No se encontró el técnico con ID {id}" });

            return Ok(tecnico);
        }

        //  Crear nuevo técnico
        [HttpPost("Ingresar Nuevo Técnico")]
        public async Task<IActionResult> CrearAsync([FromBody] tecnicos_software nuevoTecnico)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _tecnicosSoftwareServicio.TecnicosSoftwareAddAsync(nuevoTecnico);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoTecnico.id_tecnico }, nuevoTecnico);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el técnico: {ex.Message}");
                return StatusCode(500, "Error interno al crear el técnico");
            }
        }

        // Actualizar técnico
        [HttpPut("Actualizar Técnico")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] tecnicos_software tecnicoActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _tecnicosSoftwareServicio.TecnicosSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el técnico con ID {id}" });

            try
            {
                tecnicoActualizado.id_tecnico = id;
                await _tecnicosSoftwareServicio.TecnicosSoftwareUpdateAsync(tecnicoActualizado);
                return Ok(new { mensaje = "Técnico actualizado correctamente", datos = tecnicoActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el técnico: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el técnico");
            }
        }

        // Eliminar técnico
        [HttpDelete("Eliminar Técnico")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _tecnicosSoftwareServicio.TecnicosSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el técnico con ID {id}" });

            try
            {
                await _tecnicosSoftwareServicio.TecnicosSoftwareDeleteAsync(id);
                return Ok(new { mensaje = "Técnico eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el técnico: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el técnico");
            }
        }
    }
}