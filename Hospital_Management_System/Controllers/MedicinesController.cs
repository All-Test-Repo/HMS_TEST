using HMS.DAL.Data;
using HMS.Models;
using HMS.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static HMS.Models.DbModels;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public MedicinesController(HospitalDbContext _context)
        {
            this._context = _context;
        }
    
        [HttpGet]
        [Route("GetMedicine")]
        public async Task<ActionResult<IEnumerable<MedicineVM>>> GetMedicineVMs()
        {
            var medicineVMs = await _context.Medicines
                .Include(m => m.MedicineGeneric)
                .Include(m => m.Manufacturer)
                .Select(m => new MedicineVM
                {
                    MedicineID = m.MedicineID,
                    MedicineName = m.MedicineName,
                    ExpireDate = m.ExpireDate,
                    Quantity = m.Quantity,
                    SellPrice = m.SellPrice,
                    Discount = m.Discount,
                    Manufacturer = m.Manufacturer,
                    MedicineGeneric = m.MedicineGeneric
                })
                .ToListAsync();

            return medicineVMs;
        }
        [HttpPost]
        [Route("PostMedicine")]
        public async Task<ActionResult<MedicineVM>> PostMedicineVM(MedicineVM medicineVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var medicine = new Medicine
            {
                MedicineName = medicineVM.MedicineName,
                ExpireDate = medicineVM.ExpireDate,
                Quantity = medicineVM.Quantity,
                SellPrice = medicineVM.SellPrice,
                Discount = medicineVM.Discount,
                MedicineGeneric = medicineVM.MedicineGeneric,
                Manufacturer = medicineVM.Manufacturer,
            };

            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMedicineVMs", new { id = medicine.MedicineID }, medicineVM);
        }
        private bool MedicineExists(int id)
        {
            return _context.Medicines.Any(e => e.MedicineID == id);
        }
        [Route("UpdateMedicine/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutMedicineVM(int id, MedicineVM medicineVM)
        {
            if (id != medicineVM.MedicineID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingMedicine = await _context.Medicines.FindAsync(id);
            if (existingMedicine == null)
            {
                return NotFound();
            }
            existingMedicine.MedicineName = medicineVM.MedicineName;
            existingMedicine.ExpireDate = medicineVM.ExpireDate;
            existingMedicine.Quantity = medicineVM.Quantity;
            existingMedicine.SellPrice = medicineVM.SellPrice;
            existingMedicine.Discount = medicineVM.Discount;
            existingMedicine.MedicineGeneric = medicineVM.MedicineGeneric;
            existingMedicine.Manufacturer = medicineVM.Manufacturer;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
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
        [Route("DeleteMedicine/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMedicine(int id)
        {

            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
