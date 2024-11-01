using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
