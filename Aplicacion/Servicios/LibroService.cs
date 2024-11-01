using Aplicacion.Interfaces;
using Contract.Interfaces;
using Contract.LibroContract;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacion.Servicios
{
    public class LibroService 
    {
        private readonly IRepositoryBase<Libro> _libroRepositoryBase;
        private readonly ILibroRepository _libroRepository;
        private readonly ILibroMapping _mapping;

        public LibroService(IRepositoryBase<Libro> libroRepositoryBase, ILibroRepository libroRepository, ILibroMapping mapping)
        {
            _libroRepositoryBase = libroRepositoryBase;
            _libroRepository = libroRepository;
            _mapping = mapping;
        }



        // Método para agregar un libro
        public async Task AddLibro(LibroRequest request)
        {
            var entity = _mapping.FromDtoToEntity(request);
            await _libroRepositoryBase.AddAsync(entity);
        }
        // Método para obtener todos los libros
        public async Task<List<LibroResponse>> GetAllLibrosAsync()
        {
            var libros = await _libroRepositoryBase.ListAsync();
            return libros.Select(_mapping.FromEntityToResponse).ToList();
        }

        // Método para obtener libros por nombre
        public async Task<List<LibroResponse>> GetLibroByNombreAsync(string nombre)
        {
            var libros = await _libroRepository.GetByNombreAsync(nombre);
            return libros.Select(_mapping.FromEntityToResponse).ToList();
        }
        // Método para obtener un libro por ID
        public async Task<LibroResponse?> GetLibroByIdAsync(int id)
        {
            var libro = await _libroRepositoryBase.GetByIdAsync(id);
            if (libro == null) return null;
            return _mapping.FromEntityToResponse(libro);
        }

        // Método para editar un libro
        public async Task EditLibroAsync(int id, LibroRequest request)
        {
            var existingLibro = await _libroRepositoryBase.GetByIdAsync(id);
            if (existingLibro == null)
                throw new Exception($"El libro con ID {id} no existe.");

            // Actualizar las propiedades del libro
            existingLibro.Titulo = request.Titulo;
            existingLibro.FechaPublicacion = request.FechaPublicacion;

            await _libroRepositoryBase.UpdateAsync(existingLibro);
        }

        // Método para eliminar un libro
        public async Task DeleteLibroAsync(int id)
        {
            var libro = await _libroRepositoryBase.GetByIdAsync(id);
            if (libro == null)
                throw new Exception($"El libro con ID {id} no existe.");

            await _libroRepositoryBase.DeleteAsync(libro);
        }
    }
}
