using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Contract.LibroContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // Crear libro
        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] LibroRequest request)
        {
            await _libroService.AddLibro(request);
            return Ok("Libro creado exitosamente.");
        }

        // Obtener libro por ID
        [HttpGet("id/{id}")]
        public async Task<ActionResult<LibroResponse>> GetBookById(int id)
        {
            var libro = await _libroService.GetLibroByIdAsync(id);
            if (libro == null) return NotFound($"El libro con ID {id} no fue encontrado.");
            return Ok(libro);
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<LibroResponse>>> GetAllLibros()
        {
            var libros = await _libroService.GetAllLibrosAsync();
            return Ok(libros);
        }

        [HttpGet("nombre/{nombre}")]
        public async Task<ActionResult<List<LibroResponse>>> GetLibroByNombre([FromRoute] string nombre)
        {
            var libros = await _libroService.GetLibroByNombreAsync(nombre);
            return Ok(libros);
        }
        // Editar libro
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] LibroRequest request)
        {
            try
            {
                await _libroService.EditLibroAsync(id, request);
                return Ok("Libro actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Eliminar libro
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                await _libroService.DeleteLibroAsync(id);
                return Ok("Libro eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
