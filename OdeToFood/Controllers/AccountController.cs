using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new User {UserName = viewModel.UserName};
            var createResult = await _userManager.CreateAsync(user, viewModel.Password);

            if (createResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var loginResult = await _signInManager
                .PasswordSignInAsync(
                viewModel.UserName,
                viewModel.Password,
                viewModel.RememberMe,
                false);
            if (!loginResult.Succeeded)
            {
                ModelState.AddModelError("", "Could not login");
                return View(viewModel);
            }

            if (Url.IsLocalUrl(viewModel.ReturnUrl))
            {
                return Redirect(viewModel.ReturnUrl);
            }          
                return RedirectToAction("Index", "Home");
            
        }

    }
}
