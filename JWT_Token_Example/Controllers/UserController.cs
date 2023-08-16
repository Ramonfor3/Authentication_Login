using Authentication_Login.Dtos.Users;
using Authentication_Login.Response;
using Authentication_Login.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Login.Controllers
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

        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public async Task<ApiResponse<GetUserDto>> GetData() => await _userService.GetAll();


        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ApiResponse<GetUserDto>> GetById(int id) => await _userService.GetById(id);
        
        [Authorize]
        [HttpGet("{name}")]
        public async Task<ApiResponse<GetUserDto>> GetByUserName(string name) => await _userService.GetByUserName(name);

        [Authorize]
        [HttpPost]
        public async Task<UserDto> Post(CreateUserDto users) => await _userService.AddUser(users);
    }
}
