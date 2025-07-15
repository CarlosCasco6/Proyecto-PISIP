using Microsoft.AspNetCore.Mvc;
using UrbaPark.Aplicacion.Servicio;
using UrbaPark.Infraestructura.AccesoDatos;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServicio _usuariosServicio;

        public UsuariosController(IUsuariosServicio usuariosServicio)
        {
            _usuariosServicio = usuariosServicio;
        }

        // Obtener todos los usuarios
        [HttpGet("Listar Usuarios")]
        public async Task<ActionResult<IEnumerable<usuarios>>> GetAllAsync()
        {
            var lista = await _usuariosServicio.UsuariosGetAllAsync();
            return Ok(lista);
        }

        // ✅ Obtener usuario por ID
        [HttpGet("Buscar Usuario por ID")]
        public async Task<ActionResult<usuarios>> GetByIdAsync(int id)
        {
            var usuario = await _usuariosServicio.UsuariosGetByIdAsync(id);
            if (usuario == null)
                return NotFound(new { mensaje = $"No se encontró el usuario con ID {id}" });

            return Ok(usuario);
        }

        // ✅ Crear nuevo usuario
        [HttpPost("Crear Nuevo Usuario")]
        public async Task<IActionResult> CrearAsync([FromBody] usuarios nuevoUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _usuariosServicio.UsuariosAddAsync(nuevoUsuario);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = nuevoUsuario.id_usuario }, nuevoUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el usuario: {ex.Message}");
                return StatusCode(500, "Error interno al crear el usuario");
            }
        }

        //  Actualizar usuario existente
        [HttpPut("Actualizar Usuario")]
        public async Task<IActionResult> ActualizarAsync(int id, [FromBody] usuarios usuarioActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existente = await _usuariosServicio.UsuariosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el usuario con ID {id}" });

            try
            {
                usuarioActualizado.id_usuario = id;
                await _usuariosServicio.UsuariosUpdateAsync(usuarioActualizado);
                return Ok(new { mensaje = "Usuario actualizado correctamente", datos = usuarioActualizado });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                return StatusCode(500, "Error interno al actualizar el usuario");
            }
        }

        // Eliminar usuario
        [HttpDelete("Eliminar Usuario por ID")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            var existente = await _usuariosServicio.UsuariosGetByIdAsync(id);
            if (existente == null)
                return NotFound(new { mensaje = $"No existe el usuario con ID {id}" });

            try
            {
                await _usuariosServicio.UsuariosDeleteAsync(id);
                return Ok(new { mensaje = "Usuario eliminado correctamente" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return StatusCode(500, "Error interno al eliminar el usuario");
            }
        }
    }
}