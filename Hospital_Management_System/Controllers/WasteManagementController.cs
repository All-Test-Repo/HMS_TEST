using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models; 
using HMS.DAL.Data;
using static HMS.Models.DbModels;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteManagementController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public WasteManagementController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetWasteEntries()
        {
            var wasteEntries = await _context.WasteManagements.ToListAsync();
            return Ok(wasteEntries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWasteEntry(int id)
        {
            var wasteEntry = await _context.WasteManagements.FindAsync(id);
            if (wasteEntry == null)
            {
                return NotFound();
            }
            return Ok(wasteEntry);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWasteEntry(WasteManagement wasteEntry)
        {
            if (ModelState.IsValid)
            {
                //schedule date
                //validation
                _context.WasteManagements.Add(wasteEntry);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetWasteEntry), new { id = wasteEntry.WasteID }, wasteEntry);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWasteEntry(int id, WasteManagement updatedWasteEntry)
        {
            if (id != updatedWasteEntry.WasteID)
            {
                return BadRequest();
            }

            _context.Entry(updatedWasteEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteEntryExists(id))
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
        public async Task<ActionResult> DeleteWasteEntry(int id)
        {
            var wasteEntry = await _context.WasteManagements.FindAsync(id);
            if (wasteEntry == null)
            {
                return NotFound();
            }

            _context.WasteManagements.Remove(wasteEntry);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool WasteEntryExists(int id)
        {
            return _context.WasteManagements.Any(e => e.WasteID == id);
        }
    }
}
