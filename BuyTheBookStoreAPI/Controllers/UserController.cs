using BuyTheBookStore.Application.Dtos.UserAPIDtos;
using BuyTheBookStore.Application.Helpers;
using BuyTheBookStore.Application.UserService.Services;
using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyTheBookStoreAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost("register")]
        [ValidateModel]
        public async Task<object> Register([FromBody] RegisterDto user)
        {
            try
            {

                var newUser = await _userService.CreateUser(user);
                return Ok(newUser);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginDto user)
        {
            try
            {

                User userInDb = (User)await _userService.GetUserByEmail(user.Email);
                if (userInDb == null || !BCrypt.Net.BCrypt.Verify(user.Password, userInDb.PasswordHash)){
                    return NotFound("Invalid username or password");
                }
                else
                {
                    return Ok(JWTTokenCreator.TokenCreator(userInDb, _configuration));
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var users = await _userService.GetUsers();
                if(users == null)
                {
                    return BadRequest();
                }
                else
                {
                    return users;
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<object> Get([FromRoute] Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                    return NotFound($"{id} user not found");
                else
                    return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<object> Update([FromRoute] Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                var user = await _userService.UpdateAdmin(id, userDto);
                if (user == null)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<object> UpdateUser([FromRoute] Guid id, [FromBody] CustomerUpdateDto customerDto)
        {
            try
            {
                var user = await _userService.UpdateUser(id, customerDto);
                if (user == null)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<object> Delete(Guid id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUser(id);
                if (isDeleted == false)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
