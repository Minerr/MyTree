using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTree.Models;
using MyTree.Models.Account;

namespace MyTree.Controllers
{
    public class AccountController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly MyTreeDbContext _context;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, MyTreeDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_context = context;
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
					return RedirectToAction("Index", "Profile");
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
		public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = null)
		{
			ViewData["ReturnURL"] = returnUrl;
			if(ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(
					model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

				if(result.Succeeded)
				{
					// Redirect to profile page
					if(Url.IsLocalUrl(returnUrl))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Profile");
					}
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