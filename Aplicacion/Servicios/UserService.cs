using Aplicacion.Interfaces;
using Contract.UserContract;
using Dominio.Entidades;
using Dominio.Interfaces;
using static Contract.UserContract.UserDto;

namespace Aplicacion.Servicios
{
    public class UserService  : IUserService
    {
        private readonly IRepositoryBase<User> _userRepository;

        public UserService(IRepositoryBase<User> userRepository)
        {
            _userRepository = userRepository;
        }

        // Crear un nuevo usuario
        public async Task AddUser(UserRequest request)
        {
            var user = new User
            {
                Email = request.Email,
                Password = request.Password

            };

            await _userRepository.AddAsync(user);
        }

        // Obtener usuario por ID
        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
            };
        }

        // Obtener todos los usuarios
        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.ListAsync();
            return users.Select(user => new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
            }).ToList();
        }

        // Editar un usuario existente
        public async Task EditUserAsync(int id, UserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception($"Usuario con ID {id} no encontrado.");


            user.Email = request.Email;

            await _userRepository.UpdateAsync(user);
        }

       
    }
}

