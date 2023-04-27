using FormProject.Application.Models.DTOs;
using FormProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormProject.Presentation.Controllers
{
    [Authorize]

    public class AccountController : Controller
    {

        private readonly IAppUserService _userService;

        public AccountController(IAppUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Registor()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "form");
            }

            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Registor(RegistorDTO model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userService.Registor(model);
                if (result.Succeeded)
                    return RedirectToAction("Index", "form");

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }

                TempData["error"] = "Something goes wrong";

            }


            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = "/")
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "form");
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _userService.Login(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "form");
                }
                ModelState.AddModelError("", "Invalid login attempt");
            }
            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction("Login", "Account");
        }
       
    }
}
