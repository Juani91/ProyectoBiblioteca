using static Contract.UserContract.UserDto;

namespace Aplicacion.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserRequest request);
        Task<UserResponse?> GetUserByIdAsync(int id);
        Task<List<UserResponse>> GetAllUsersAsync();
        Task EditUserAsync(int id, UserRequest request);
    
    }
}
