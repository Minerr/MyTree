using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyTree.Models;
using MyTree.Models.Account;

namespace MyTree.Controllers
{
	[Authorize]
    public class UserController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;

		public UserController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Settings()
		{
			return View();
		}
	}
}