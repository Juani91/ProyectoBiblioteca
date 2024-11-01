using Dominio.Entidades;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class LibroRepository : RepositoryBase<Libro>, ILibroRepository
    {
        private readonly AplicacionDbContext _dbContext;

        public LibroRepository(AplicacionDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // Método personalizado para buscar libros por nombre
        public async Task<List<Libro>> GetByNombreAsync(string nombre)
        {
            return await _dbContext.Set<Libro>()
                .Where(l => EF.Functions.Like(l.Titulo, $"%{nombre}%"))
                .ToListAsync();
        }
    }
}
