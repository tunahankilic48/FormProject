﻿using FormProject.Application.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FormProject.Application.Services
{
    public interface IAppUserService
    {
        Task<IdentityResult> Registor(RegistorDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task Logout();
        Task UpdateUser(UpdateProfileDTO model);
        Task<UpdateProfileDTO> GetByUserName(string userName);

    }
}
