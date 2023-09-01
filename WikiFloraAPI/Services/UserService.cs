using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> addUser(User user)
        {
            bool isUserExist = _context.Users.Any(u => u.UserId == user.UserId);
            if (isUserExist) return user;
            _context.Users.Add(user);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<List<User>> getAllUser()
        {
            return await _context.Users.ToListAsync<User>();
        }

        public async Task<User?> getUser(string userId)
        {
            User? user = await _context.Users.FirstOrDefaultAsync( u => u.UserId == userId);
            return user;
        }

        public async Task<bool> isUserExist(string userId)
        {
            bool x = await _context.Users.AnyAsync(u => u.UserId == userId);
            return x;
        }

        public Task<UserDto> updateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
