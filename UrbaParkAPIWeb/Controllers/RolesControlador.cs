using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesServicio _rolesServicio;

        public RolesController(IRolesServicio rolesServicio)
        {
            _rolesServicio = rolesServicio;
        }

        //Obtener todos los roles
        [HttpGet("Listar todos los Roles")]
        public async Task<ActionResult<IEnumerable<roles>>> GetAllAsync()
        {
            var lista = await _rolesServicio.RolesGetAllAsync();
            return Ok(lista);
        }

        // Obtener rol por ID
        [HttpGet("Buscar Rol por ID")]
        public async Task<ActionResult<roles>> GetByIdAsync(int id)
        {
            var rol = await _rolesServicio.RolesGetByIdAsync(id);
            if (rol == null)
                return NotFound(new { mensaje = $"No se encontró el rol con ID {id}" });

            return Ok(rol);
        }

        //  Crear nuevo rol
        [HttpPost("Crear Rol")]
        public async Task<IActionResult> CrearAsync([FromBody] roles nuevoRol)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _rolesServicio.RolesAddAsync(nuevoRol);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoRol.id_rol }, nuevoRol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el rol: {ex.Message}");
                return StatusCode(500, "Error interno al crear el rol");
            }
        }

        // Actualizar rol
        [HttpPut("Actualizar Rol")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] roles rolActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _rolesServicio.RolesGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el rol con ID {id}" });

            try
            {
                rolActualizado.id_rol = id;
                await _rolesServicio.RolesUpdateAsync(rolActualizado);
                return Ok(new { mensaje = "Rol actualizado correctamente", datos = rolActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el rol: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el rol");
            }
        }

        // Eliminar rol
        [HttpDelete("Eliminar Rol")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _rolesServicio.RolesGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el rol con ID {id}" });

            try
            {
                await _rolesServicio.RolesDeleteAsync(id);
                return Ok(new { mensaje = "Rol eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el rol");
            }
        }
    }
}