using BuyTheBookStore.Application.Dtos.UserAPIDtos;
using BuyTheBookStore.BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.Application.UserService.Services
{
    public interface IUserService
    {
        Task<object> CreateUser(RegisterDto user);
        Task<object> UpdateUser(Guid id, CustomerUpdateDto user);
        Task<object> UpdateAdmin(Guid id, UserDto customer);
        Task<bool> DeleteUser(Guid id);
        Task<object> GetUserById(Guid id);
        Task<object> GetUserByEmail(string email);
        Task<object> GetUsers();
    }
}
