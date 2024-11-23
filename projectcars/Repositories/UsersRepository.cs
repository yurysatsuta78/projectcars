using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class UsersRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(User user) 
        {
            var newUser = new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            var userEntity = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

            return _mapper.Map<User>(userEntity);
        }
    }
}
