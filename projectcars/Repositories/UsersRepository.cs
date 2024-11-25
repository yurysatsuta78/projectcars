using AutoMapper;
using Microsoft.EntityFrameworkCore;
using projectcars.Entities;
using projectcars.Interfaces.Repositories;
using projectcars.Models;

namespace projectcars.Repositories
{
    public class UsersRepository : IUsersRepository
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
            var userRole = new UserRoleEntity()
            {
                UserId = user.Id,
                RoleId = 2
            };

            await _context.Users.AddAsync(newUser);
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByPhoneNumber(string phoneNumber)
        {
            var userEntity = await _context.Users.AsNoTracking()
                .Include(p => p.Roles)
                .FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);

            if (userEntity == null) 
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<User>(userEntity);
        }
    }
}
