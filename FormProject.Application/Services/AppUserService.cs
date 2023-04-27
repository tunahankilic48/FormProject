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
       
        /// <summary>
        /// Kullanıcının giriş bilgilerini kontrol ederek giriş yapabilmesini sağlar.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<SignInResult> Login(LoginDTO model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }
        /// <summary>
        /// Kullanıcının sistemden çıkış yapmasını sağlar
        /// </summary>
        /// <returns></returns>
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
        /// <summary>
        /// Kullanıcının sisteme kayıt olabilmesini sağlar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Giriş yapmış kullanıcının name propertysini kullanarak Id bulanmasını sağlar
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<int> UserId(string name)
        {
            AppUser user = await _userManager.FindByNameAsync(name);
            return user.Id;
        }
    }
}
