using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTree.Models.Account;

namespace MyTree.Controllers
{
    public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if(ModelState.IsValid)
			{
				IdentityUser user = new IdentityUser()
				{
					Email = model.Email,
					UserName = model.Email
				};

				var result = await _userManager.CreateAsync(user, model.Password);

				if(result.Succeeded)
				{
					return RedirectToAction("Index", "User");
				}
				else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(
					model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

				if(result.Succeeded)
				{
					// Redirect to user page
					return RedirectToAction("Index", "User");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Invalid sign in information");
				}
			}

			return View(model);
		}


		[HttpPost]
		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Index", "Home");
		}
		
		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}