using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MyTree.Models;
using MyTree.Models.Account;

namespace MyTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
		private readonly UserManager<IdentityUser> _userManager;

		public UserController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IEnumerable<IdentityUser> GetAllUsers()
		{
			return _userManager.Users.AsEnumerable();
		}

		[HttpGet("{email}")]
		public async Task<ActionResult<IdentityUser>> GetUserByEmail(string email)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var user = await _userManager.FindByEmailAsync(email);

			if(user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}
	
	}
}