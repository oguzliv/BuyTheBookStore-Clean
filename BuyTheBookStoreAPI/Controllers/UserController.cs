using AppDbContext.Models.Dtos;
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
        private ResponseDto _response;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
            _response = new ResponseDto();
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
            return await _userService.GetUsers();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<object> Get([FromRoute] Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound($"{id} user not found");
            else
                return Ok(user);
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut("{id}")]
        public async Task<object> Update([FromRoute] Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                _response.Result = await _userService.UpdateAdmin(id, userDto);
                if (_response.Result == null)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    return Ok(_response);
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _response.Result = await _userService.UpdateUser(id, customerDto);
                if (_response.Result == null)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage.Add(ex.Message);
            }
            return _response;
        }


        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public async Task<object> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var isDeleted = await _userService.DeleteUser(id);
                if (isDeleted == false)
                {
                    return NotFound($"{id} user not exist!");
                }
                else
                {
                    _response.Result = true;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage.Add(ex.Message);
            }
            return _response;
        }
    }
}
