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
    public class ProfileController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;

		public ProfileController(UserManager<IdentityUser> userManager)
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

		public IActionResult FamilyTree()
		{
			return View();
		}

		public IActionResult Statistics()
		{
			return View();
		}

		public IActionResult GiveAccess()
		{
			return View();
		}

		public IActionResult FamilyTreeGame()
		{
			return View();
		}
	}
}