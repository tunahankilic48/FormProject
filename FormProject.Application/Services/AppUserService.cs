using AutoMapper;
using FormProject.Application.Models.DTOs;
using FormProject.Domain.Entities;
using FormProject.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FormProject.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _repository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepository repository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UpdateProfileDTO> GetByUserName(string userName)
        {
            UpdateProfileDTO result = await _repository.GetFilteredFirstOrDefault(
                select: x => new UpdateProfileDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.PasswordHash,
                    Email = x.Email
                },
                where: x => x.UserName == userName
                );

            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Registor(RegistorDTO model)
        {
            AppUser user = _mapper.Map<AppUser>(model);


            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            AppUser user = await _repository.GetDefault(x => x.Id == model.Id);


            if (model.Password != null)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }
            }

            if (model.Email != null)
            {
                AppUser isEmailExist = await _repository.GetDefault(x => x.Email == model.Email);

                if (isEmailExist == null)
                {
                    await _userManager.SetEmailAsync(user, model.Email);
                }
            }

            if (model.UserName != null)
            {
                var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);
                if (isUserNameExist == null)
                {
                    await _userManager.SetUserNameAsync(user, model.UserName);
                }
            }

        }

        public async Task<int> UserId(string name)
        {
            AppUser user = await _userManager.FindByNameAsync(name);
            return user.Id;
        }
    }
}
