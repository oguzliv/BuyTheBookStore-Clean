using AutoMapper;
using BuyTheBookStore.Application.Dtos.UserAPIDtos;
using BuyTheBookStore.Application.UserService.Services;
using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using BuyTheBookStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<object> CreateUser(RegisterDto user)
        {
            var _user = await _userRepository.GetByEmail(user.Email);

            if (_user == null)
            {
                _user = _mapper.Map<User>(user);
                _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _user.Role = (bool)user.IsAdmin ? User.ROLE.ADMIN : User.ROLE.CUSTOMER;
                _user.Id = Guid.NewGuid();

                await _userRepository.Create(_user);

                return _mapper.Map<UserResultDto>(_user);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            User user = await _userRepository.GetById(id);
            if (user == null)
            {
                return false;
            }
            else
            {
                var removed = await _userRepository.Delete(user);
                return true;
            }
        }

        public async Task<object> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            return user;
        }

        public async Task<object> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserResultDto>(user);
        }

        public async Task<object> GetUsers()
        {
            return await _userRepository.Get();
        }

        public async Task<object> UpdateAdmin(Guid id, UserDto user)
        {
            var _user = await _userRepository.GetById(id);
            if (_user == null)
                return null;

            var newUser = _mapper.Map<User>(user);
            newUser.Id = id;
            newUser.Role = user.IsAdmin ? User.ROLE.ADMIN : User.ROLE.CUSTOMER;
            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _userRepository.Update(newUser);

            return _mapper.Map<UserResultDto>(newUser);
        }

        public async Task<object> UpdateUser(Guid id, CustomerUpdateDto user)
        {
            var _user = await _userRepository.GetById(id);
            if (_user == null)
                return null;

            _user.Name = user.Name;
            _user.Email = user.Email;
            _user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _userRepository.Update(_user);
            return _mapper.Map<UserResultDto>(_user);
        }
    }
}
