using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTree.Models;

namespace MyTree.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly MyTreeDbContext _context;

        public FamilyMembersController(MyTreeDbContext context)
        {
            _context = context;
        }

        // GET: api/FamilyMembers
        [HttpGet]
        public IEnumerable<FamilyMember> GetFamilyMembers()
        {
            return _context.FamilyMembers;
        }

        // GET: api/FamilyMembers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilyMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var familyMember = await _context.FamilyMembers.FindAsync(id);

            if (familyMember == null)
            {
                return NotFound();
            }

            return Ok(familyMember);
        }

        // POST: api/FamilyMembers
        [HttpPost]
        public async Task<IActionResult> PostFamilyMember([FromBody] FamilyMember familyMember)
        {
            if (!ModelState.IsValid || familyMember.Person == null)
            {
                return BadRequest(ModelState);
            }

            _context.FamilyMembers.Add(familyMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFamilyMember", new { id = familyMember.Id }, familyMember);
        }

        // DELETE: api/FamilyMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMember([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var familyMember = await _context.FamilyMembers.FindAsync(id);
            if (familyMember == null)
            {
                return NotFound();
            }

            _context.FamilyMembers.Remove(familyMember);
            await _context.SaveChangesAsync();

            return Ok(familyMember);
        }
    }
}