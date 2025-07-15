using Microsoft.AspNetCore.Mvc;

namespace UrbaParkAPIWeb.Controllers
{
    [ApiController]
    [Route("api/urbapark/[Controller]")]
    public class DemoControlador: ControllerBase
    {
        [HttpGet]
        public string Mensaje()
        {
            return "Este es el sistema de UrbaPark para registrar informes";
        }


        [HttpGet("saludo")] //Saludo con nombre
        public IActionResult ObtenerSaludo([FromQuery] string nombre)
        {
            var mensaje = $"Hola {nombre}, bienvenido al sistema UrbaPark";
            return Ok(new { saludo = mensaje });
        }


        public class InformeDTO  //POST..... Crear informe
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
        }

        [HttpPost("crear-informe")]
        public IActionResult CrearInforme([FromBody] InformeDTO informe)
        {
            // Aquí podrías guardar el informe en la base de datos
            return Created("", new { mensaje = "Informe creado exitosamente", datos = informe });
        }


        [HttpPut("actualizar-informe/{id}")] //PUT.....Actualizar Informe
        public IActionResult ActualizarInforme(int id, [FromBody] InformeDTO informeActualizado)
        {
            // Simulación de actualización
            return Ok(new { mensaje = $"Informe {id} actualizado", datos = informeActualizado });
        }


        [HttpDelete("eliminar-informe/{id}")]  // DELETE....Eliminar Informe
        public IActionResult EliminarInforme(int id)
        {
            // Simulación de eliminación
            return Ok(new { mensaje = $"Informe con ID {id} ha sido eliminado" });
        }


        [HttpGet("obtener-informe/{id}")] // GET...... Obtener informe por ID
        public IActionResult ObtenerInformePorId(int id)
        {
            // Simulación de búsqueda
            var informe = new { Id = id, Titulo = "Informe de prueba", Descripcion = "Descripción de muestra" };
            return Ok(informe);
        }
    }
}
