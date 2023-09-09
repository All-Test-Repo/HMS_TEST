using HMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static HMS.Models.DbModels;
using LabTechnician = HMS.Models.LabTechnician;

namespace HMS.DAL.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<Morgue> Morgues { get; set; }
        public DbSet<Ambulance> Ambulances { get; set; }
        public DbSet<WasteManagement> WasteManagements { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientRegister> PatientRegisters { get; set; }
        public DbSet<OtherEmployee> OtherEmployees { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<LabTechnician> LabTechnicians { get; set; }
        public DbSet<LabEquipment> LabEquipments { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Prescriptions> Prescriptions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Outdoor> Outdoors { get; set; }
        //public DbSet<Diagnoses> Diagnoses { get; set; }
        public DbSet<MedicalRecords> MedicalRecords { get; set; }
        public DbSet<SurgeryProcedure> SurgeryProcedures { get; set; }
        public DbSet<DischargeTransfer> DischargeTransfers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<WardCabin> WardCabins { get; set; }

        

        //from mama to avoid exception
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(i => i.Bill_Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Discount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.PaidAmount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Due)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<LabTest>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Medicine>()
                .Property(m => m.SellPrice)
                .HasColumnType("decimal(18, 2)");

            



        }

    }
}
