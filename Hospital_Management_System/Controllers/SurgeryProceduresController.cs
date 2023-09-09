using HMS.DAL.Data;
using HMS.Models.SurgeryWard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurgeryProceduresController : ControllerBase
    {
        private readonly HospitalDbContext _context;
        public SurgeryProceduresController(HospitalDbContext context)
        {
            _context = context;
        }
        // Get all Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurgeryProcedure>>> GetSurgeryProcedure()
        {
            return await _context.SurgeryProcedures.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SurgeryProcedure>> GetSurgeryProcedureById(int id)
        {
            if (_context.SurgeryProcedures == null)
            {
                return NotFound();
            }
            var surgeryProcedure = await _context.SurgeryProcedures.FindAsync(id);
            if (surgeryProcedure == null)
            {
                return NotFound();
            }
            return surgeryProcedure;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurgeryProcedure(int id, SurgeryProcedure surgeryProcedure)
        {
            if (id != surgeryProcedure.SurgeryID)
            {
                return BadRequest();
            }
            _context.Entry(surgeryProcedure).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!SurgeryProcedureExists(id))
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
        public async Task<ActionResult<SurgeryProcedure>> PostSurgeryProcedure(SurgeryProcedure surgeryProcedure)
        {
            if (_context.SurgeryProcedures == null)
            {
                return Problem("Entity set 'Surgery' is null");
            }
            _context.SurgeryProcedures.Add(surgeryProcedure);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSurgeryProcedure", new { id = surgeryProcedure.SurgeryID });
        }

        private bool SurgeryProcedureExists(int id)
        {
            return (_context.SurgeryProcedures?.Any(e => e.SurgeryID == id)).GetValueOrDefault();
        }
    }
}
