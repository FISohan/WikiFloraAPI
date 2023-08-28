﻿using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public interface IUserService
    {
        public Task<User> addUser(User user);
        public Task<UserDto> updateUser(UserDto user);
        public Task<List<User>> getAllUser();
    }
}
