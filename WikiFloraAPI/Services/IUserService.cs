using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public interface IUserService
    {
        public Task<User> addUser(User user);
        public Task<bool> updateUser(UserDto user);
        public Task<List<User>> getAllUser();
        public Task<User>getUser(string userId);
        public Task<bool>isUserExist(string userId);
        public Task<bool> deductContributionPoint(string id);
        public Task<bool> addContributionPoint(string id);
        public Task<List<User>> getTopContributers();
    }
}
