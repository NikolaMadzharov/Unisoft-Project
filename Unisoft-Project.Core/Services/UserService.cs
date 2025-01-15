
using Microsoft.EntityFrameworkCore;
using Unisoft_Project.Core.Contracts;
using Unisoft_Project.Core.Models;
using Unisoft_Project.Infrastructure.Data;
using Unisoft_Project.Infrastructure.Data.Entities;

namespace Unisoft_Project.Core.Services
{
    public class UserService :IUserService
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITokenService _tokenService;

        public UserService(AppDbContext appDbContext, ITokenService tokenService)
        {
            _appDbContext = appDbContext;
            _tokenService = tokenService;
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            if (user == null)
            {
                throw new ArgumentException("This user cannot be found!");
            }

            return user;
        }


        public async Task<string> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == loginUserDTO.Email);

            if (user == null)
            {
                throw new ArgumentException("Wrong email address!");
            }

            bool verifyPassword = BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.HashPassword);

            if (!verifyPassword)
            {
                throw new ArgumentException("Wrong password!");
            }


            var token = await _tokenService.GenerateToken(user);


            return token;
        }


        public async Task<string> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == registerUserDTO.Email);

            if (user != null)
            {
                throw new ArgumentException("User with this email already exists!");
            }

            var userDb = new User()
            {
                Id = Guid.NewGuid(),
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = registerUserDTO.Password,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password),
                Avatar = registerUserDTO.Avatar,
                WebsiteUrl = registerUserDTO.WebsiteUrl
            };


            await _appDbContext.AddAsync(userDb);
            await _appDbContext.SaveChangesAsync();

            Console.WriteLine($"---> USER ID = {userDb.Id.ToString()}");

            var token = await _tokenService.GenerateToken(userDb);


            return token;
        }


        public async Task<User> UpdateUserProfileAsync(string userId, EditUserDTO editUserDto)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

            if (user == null)
            {
                throw new ArgumentException("User ID mismatch.");
            }

            user.Name = editUserDto.Name;
            user.Email = editUserDto.Email;
            user.Avatar = editUserDto.Avatar;
            user.WebsiteUrl = editUserDto.WebsiteUrl;

            await _appDbContext.SaveChangesAsync();

            return user;
        }
    }
}
