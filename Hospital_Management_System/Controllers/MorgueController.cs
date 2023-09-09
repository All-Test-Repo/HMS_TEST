using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using HMS.DAL.Data;
using static HMS.Models.DbModels;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorgueController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MorgueController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMorgueEntries()
        {
            var morgueEntries = await _context.Morgues.ToListAsync();
            return Ok(morgueEntries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMorgueEntry(int id)
        {
            var morgueEntry = await _context.Morgues.FindAsync(id);
            if (morgueEntry == null)
            {
                return NotFound();
            }
            return Ok(morgueEntry);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMorgueEntry(Morgue morgueEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Morgues.Add(morgueEntry);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetMorgueEntry), new { id = morgueEntry.MorgueID }, morgueEntry);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMorgueEntry(int id, Morgue updatedMorgueEntry)
        {
            if (id != updatedMorgueEntry.MorgueID)
            {
                return BadRequest();
            }

            _context.Entry(updatedMorgueEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MorgueEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMorgueEntry(int id)
        {
            var morgueEntry = await _context.Morgues.FindAsync(id);
            if (morgueEntry == null)
            {
                return NotFound();
            }

            _context.Morgues.Remove(morgueEntry);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool MorgueEntryExists(int id)
        {
            return _context.Morgues.Any(e => e.MorgueID == id);
        }
    }
}
