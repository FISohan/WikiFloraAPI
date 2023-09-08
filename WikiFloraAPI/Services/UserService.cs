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
        public async Task<bool> addContributionPoint(string id)
        {
            User? user = await getUser(id);
            if(user == null) return false;
            user.ContributionPoints += 1;
            _context.Entry(user).State = EntityState.Modified;
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> deductContributionPoint(string id)
        {
            User? user = await getUser(id);
            if (user == null) return false;
            user.ContributionPoints -= 1;
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
        public async Task<User?> getUser(string userId)
        {
            User? user = await _context.Users.FirstOrDefaultAsync( u => u.UserId == userId || u.Name == userId);
            return user;
        }

        public async Task<bool> isUserExist(string userId)
        {
            bool x = await _context.Users.AnyAsync(u => u.UserId == userId);
            return x;
        }
        public async Task<List<User>> getTopContributers()
        {
            List<User> users = await _context.Users.OrderBy(u => u.ContributionPoints).ToListAsync();
            return users;
        }
        public Task<UserDto> updateUser(UserDto user)
        {
            throw new NotImplementedException();
        }
        
    }
}
