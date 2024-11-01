using Dominio.Entidades;

namespace Infraestructura.Data
{
    public class UserRepository
    {
        private readonly AplicacionDbContext _context;
        public UserRepository(AplicacionDbContext context)
        {
            _context = context;
        }
        public User? GetUserByUserName(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email.Equals(email));
        }
    }
}
