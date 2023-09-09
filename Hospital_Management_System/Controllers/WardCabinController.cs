using HMS.DAL.Data;
using HMS.Models;
using HMS.Models.SurgeryWard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardCabinController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public WardCabinController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WardCabin>>> GetWardCabins()
        {
            if (_context.WardCabins == null)
            {
                return NotFound();
            }
            return await _context.WardCabins.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<WardCabin>> GetWardCabinById(int id)
        {
            if (_context.WardCabins == null)
            {
                return NotFound();
            }
            var bloodBank = await _context.WardCabins.FindAsync(id);

            if (bloodBank == null)
            {
                return NotFound();
            }

            return bloodBank;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutWardCabin(int id, WardCabin wardCabin)
        {
            if (id != wardCabin.WardID)
            {
                return BadRequest();
            }

            _context.Entry(wardCabin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardCabinExists(id))
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


        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<WardCabin>> PostWardCabin(WardCabin wardCabin)
        {
            if (_context.WardCabins == null)
            {
                return Problem("Entity set 'HospitalDbContext.WardCabin'  is null.");
            }
            _context.WardCabins.Add(wardCabin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBloodBank", new { id = wardCabin.WardID }, wardCabin);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBloodBank(int id)
        {
            if (_context.WardCabins == null)
            {
                return NotFound();
            }
            var wardCabin = await _context.WardCabins.FindAsync(id);
            if (wardCabin == null)
            {
                return NotFound();
            }

            _context.WardCabins.Remove(wardCabin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WardCabinExists(int id)
        {
            return (_context.WardCabins?.Any(e => e.WardID == id)).GetValueOrDefault();
        }
    }
}
