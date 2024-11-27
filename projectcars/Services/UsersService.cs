using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using projectcars.DTO;
using projectcars.Interfaces.Auth;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Services
{
    public class UsersService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IPasswordHasher passwordHasher, IUsersRepository usersRepository, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _usersRepository = usersRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string name, string surname, string phoneNumber, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(), name, surname, phoneNumber, hashedPassword);

            await _usersRepository.Add(user);
        }

        public async Task<LoginDTO> Login(string phoneNumber, string password)
        {
            var user = await _usersRepository.GetByPhoneNumber(phoneNumber);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login!");
            }

            var token = _jwtProvider.GenerateToken(user);

            var loginDto = new LoginDTO
            {
                Name = user.Name,
                Surname = user.SurName,
                PhoneNumber = phoneNumber,
                Token = token
            };

            return loginDto;
        }

        public async Task<User> GetUserDataById(Guid userId) 
        {
            return await _usersRepository.GetUserDataById(userId);
        }
    }
}
