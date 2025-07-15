using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/informes-software")]
    public class InformesSoftwareController : ControllerBase
    {
        private readonly IInformesSoftwareServicio _informesSoftwareServicio;

        public InformesSoftwareController(IInformesSoftwareServicio informesSoftwareServicio)
        {
            _informesSoftwareServicio = informesSoftwareServicio;
        }

        // Obtener todos los informes
        [HttpGet("Listar todos los Informes")]
        public async Task<ActionResult<IEnumerable<informes_software>>> GetAllAsync()
        {
            var lista = await _informesSoftwareServicio.InformesSoftwareGetAllAsync();
            return Ok(lista);
        }

        // Obtener informe por ID
        [HttpGet("Buscar Informe por ID")]
        public async Task<ActionResult<informes_software>> GetByIdAsync(int id)
        {
            var informe = await _informesSoftwareServicio.InformesSoftwareGetByIdAsync(id);
            if (informe == null)
                return NotFound(new { mensaje = $"No se encontró el informe con ID {id}" });

            return Ok(informe);
        }

        // Crear nuevo informe
        [HttpPost("Crear Informe")]
        public async Task<IActionResult> CrearAsync([FromBody] informes_software nuevoInforme)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _informesSoftwareServicio.InformesSoftwareAddAsync(nuevoInforme);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoInforme.id_informe }, nuevoInforme);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el informe: {ex.Message}");
                return StatusCode(500, "Error interno al crear el informe");
            }
        }

        //  Actualizar informe
        [HttpPut("Actualizar Informe")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] informes_software informeActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _informesSoftwareServicio.InformesSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el informe con ID {id}" });

            try
            {
                informeActualizado.id_informe = id;
                await _informesSoftwareServicio.InformesSoftwareUpdateAsync(informeActualizado);
                return Ok(new { mensaje = "Informe actualizado correctamente", datos = informeActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el informe: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el informe");
            }
        }

        // Eliminar informe
        [HttpDelete("Eliminar Informe por ID")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _informesSoftwareServicio.InformesSoftwareGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el informe con ID {id}" });

            try
            {
                await _informesSoftwareServicio.InformesSoftwareDeleteAsync(id);
                return Ok(new { mensaje = "Informe eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el informe: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el informe");
            }
        }
    }
}