using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTree.Models;
using MyTree.Models.Profile;

namespace MyTree.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
	[ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly MyTreeDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

		public PeopleController(MyTreeDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
			_userManager = userManager;

		}

        // GET: api/People
        [HttpGet]
        public IEnumerable<Person> GetPeopleInFamily()
        {
			int familyId = GetFamily().Id;

			return _context.People.Where(p => p.FamilyId == familyId);
		}

		// GET: api/People/GetAllPeople
		[AllowAnonymous]
		[HttpGet("GetAllPeople")]
        public IEnumerable<Person> GetAllPeople()
        {
			return _context.People;
        }

		// GET: api/People/5
		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetPerson(int id)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var person = await _context.People.FindAsync(id);
			if(person == null)
			{
				return NotFound();
			}

			return Ok(person);
		}

		// POST: api/People
		[HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonViewModel viewModel)
        {

			if(!ModelState.IsValid)
			{
                return BadRequest(ModelState);
			}

			Person person = new Person()
			{
				FamilyId = GetFamily().Id,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				Gender = (Gender)viewModel.Gender
			};

			GetFamily().People.Add(person);

			// Context saves the person to the database, because it is added into the list 
			// of people of the family object. _contect.People.Add(person) would work aswell.
			await _context.SaveChangesAsync(); 

            return CreatedAtAction("AddPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }


		/// <summary>
		/// Retrieves the family based on the current user logged in. If there is no family, create one.
		/// </summary>
		/// <returns></returns>
		private Family GetFamily()
		{
			string userId = _userManager.GetUserId(this.User);
			Family family = _context.Families.Where(f => f.CreatorId == _userManager.GetUserId(this.User)).FirstOrDefault();

			if(family == null)
			{
				family = new Family() { CreatorId = userId, People = new List<Person>() };
				_context.Families.Add(family);
				_context.SaveChanges();
			}

			return family;
		}
	}
}