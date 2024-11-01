using Aplicacion.Interfaces;
using Contract.UserContract;
using Microsoft.AspNetCore.Mvc;
using static Contract.UserContract.UserDto;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest request)
        {
            await _userService.AddUser(request);
            return Ok("Usuario creado exitosamente.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound($"Usuario con ID {id} no encontrado.");
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserRequest request)
        {
            try
            {
                await _userService.EditUserAsync(id, request);
                return Ok("Usuario actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

     
    }
}
