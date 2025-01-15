using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unisoft_Project.Core.Models;
using Unisoft_Project.Infrastructure.Data.Entities;

namespace Unisoft_Project.Core.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(string userId);
        Task<User> UpdateUserProfileAsync(string id, EditUserDTO editUserDto);
        Task<string> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<string> LoginUserAsync(LoginUserDTO loginUserDTO);
    }
}
