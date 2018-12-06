using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyTree.Controllers
{
    public class ProfileController : Controller
    {

		Models.UserDbContext userDbContext;

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