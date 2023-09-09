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
    public class AmbulancesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public AmbulancesController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ambulance>>> GetAmbulances()
        {
            return await _context.Ambulances.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ambulance>> GetAmbulance(int id)
        {
            var ambulance = await _context.Ambulances.FindAsync(id);

            if (ambulance == null)
            {
                return NotFound();
            }

            return ambulance;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAmbulance(int id, Ambulance ambulance)
        {
            if (id != ambulance.AmbulanceID)
            {
                return BadRequest();
            }

            _context.Entry(ambulance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmbulanceExists(id))
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
        public async Task<ActionResult<Ambulance>> CreateAmbulance(Ambulance ambulance)
        {
            //driver Phone Nubmer and Ambulance Number
            _context.Ambulances.Add(ambulance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAmbulance), new { id = ambulance.AmbulanceID }, ambulance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmbulance(int id)
        {
            var ambulance = await _context.Ambulances.FindAsync(id);
            if (ambulance == null)
            {
                return NotFound();
            }

            _context.Ambulances.Remove(ambulance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AmbulanceExists(int id)
        {
            return _context.Ambulances.Any(a => a.AmbulanceID == id);
        }
    }
}