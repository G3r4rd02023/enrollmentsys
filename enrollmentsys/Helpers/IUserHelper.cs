﻿using enrollmentsys.Data.Entities;
using enrollmentsys.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<User> AddUser(AddUserViewModel view, string role, string path);
        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<bool> DeleteUserAsync(string email);
    }
}
