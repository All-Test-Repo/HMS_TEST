using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class DbModels
    {
        
        public class LabEquipment
        {
            [Key]
            public int EquipmentID { get; set; }
            public string EquipmentName { get; set; } = default!;
            public string EquipmentDetails { get; set; } = default!;
            public int StockQuantity { get; set; }
            //public decimal PurchasePrice { get; set; }
            public int DepartmentID { get; set; }
            public Department Departments { get; set; } = default!;

        }
        
        
        public class Morgue
        {
            [Key]
            public int MorgueID { get; set; }
            public string DeceasedName { get; set; } = default!;
            public bool IsPatient { get; set; }
            public int PatientID { get; set; }
            public DateTime DateOfDeath { get; set; }
            public string CauseOfDeath { get; set; } = default!;
        }
        public class Ambulance
        {
            [Key]
            public int AmbulanceID { get; set; }
            public string AmbulanceNumber { get; set; } = default!;
            //Driver Phone Number{Required}
            [Required(ErrorMessage = "Please enter phone number")]
            [Display(Name = "Phone")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; } = default!;
            public string DrivingLiense { get; set; } = default!;
            public string DriverName { get; set; } = default!;
            public string LastLocation { get; set; } = default!;
            public bool Availability { get; set; }
        }
        public class WasteManagement
        {
            [Key]
            public int WasteID { get; set; }
            public string WasteType { get; set; } = default!;
            public DateTime DisposalDate { get; set; }
            public string DisposalMethod { get; set; } = default!;
            public int Quantity { get; set; }
            public DateTime NextScheduleDate { get; set; }
            public string ContactNumber { get; set; } = default!;
        }
        
        public class WardCabin
        {
            [Key]
            public int WardID { get; set; }
            public string WardName { get; set; } = default!;
            public int BedCabinNumber { get; set; }
            [ForeignKey("Departments")]
            public int DepartmentID { get; set; }
            //[ForeignKey("Doctor")]
            //public int DoctorID { get; set; }
            //[ForeignKey("Nurse")]
            //public int NurseID { get; set; }
            //nev
            //public Doctor Doctor { get; set; }
            //public Nurse Nurse { get; set; }
            public Department Departments { get; set; }
            public virtual ICollection<PatientRegister> PatientRegisters { get; set; } = new HashSet<PatientRegister>();
        }
        public class Appointment
        {
            [Key]
            public int AppointmentID { get; set; }
            public string PatientName { get; set; }
            public string PhoneNumber { get; set; }
            [ForeignKey("Doctor")]
            public int DoctorID { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string AppointmentType { get; set; }
            public string TicketNumber { get; set; }
            public bool AppointmentStatus { get; set; }

            [NotMapped]
            public virtual Doctor Doctor { get; set; }
        }
        public class Outdoor
        {
            [Key]
            public int OutdoorID { get; set; }
            [ForeignKey("PatientRegister")]
            public int PatientID { get; set; }
            public string TreatmentType { get; set; }
            public DateTime TreatmentDate { get; set; }
            public string TicketNumber { get; set; }
            public int InvoiceID { get; set; }// ?
            public int DoctorID { get; set; }
            public string Remarks { get; set; }
            public bool IsAdmissionRequired { get; set; } //prescription jabe na?
            public virtual PatientRegister PatientRegister { get; set; }
            public virtual Invoice Invoice { get; set; }
        }
        public class PatientRegister
        {
            [Key]
            public int PatientID { get; set; }
            public string PatientName { get; set; } = default!;
            public string Gender { get; set; } = default!;
            public DateTime DateOfBirth { get; set; }
            public string Address { get; set; } = default!;
            public string PhoneNumber { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string EmergencyContact { get; set; } = default!;
            public DateTime AdmissionDate { get; set; }
            public string BloodType { get; set; } = default!;
            public bool IsTransferred { get; set; }
            [ForeignKey("WardCabin")]
            public int WardID { get; set; }
            // add navigation properties
            public virtual WardCabin WardCabin { get; set; } = default!;
            public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
            public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();
            public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
            public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
            public virtual ICollection<DischargeTransfer> DischargeTransfers { get; set; } = new List<DischargeTransfer>();
        }
        public class Prescriptions
        {
            [Key]
            public int PrescriptionID { get; set; }
            [ForeignKey("PatientRegister")]
            public int PatientID { get; set; }
            [ForeignKey("Medicine")]
            public int MedicinID { get; set; }
            public DateTime PrescriptionDate { get; set; }
            public string Dosage { get; set; } = default!;
            public string Advice { get; set; } = default!;
            public string ProgressNotes { get; set; } = default!;
            public DateTime? NextVisit { get; set; } = default!; // Nullable
            public bool AdmissionSuggested { get; set; } = default!;
            //public string PrescribedBy { get; set; } //doctor name comes via DoctorID
            [ForeignKey("Doctor")]
            public int DoctorID { get; set; }
            [ForeignKey("LabTest")]
            public int TestID { get; set; }
            public DateTime DiagnosisDate { get; set; }//work as prescription date
            public string Symptoms { get; set; } = default!;
            public DateTime SymptomStartDate { get; set; }
            public int Severity { get; set; }
            public string Duration { get; set; } = default!;
            public string DiagonesNotes { get; set; } = default!;
            public string FollowUpInstructions { get; set; } = default!;

            [NotMapped]
            public virtual Medicine Medicine { get; set; } = default!;
            public virtual PatientRegister PatientRegister { get; set; } = default!;
            public virtual Doctor Doctor { get; set; } = default!;
            public virtual LabTest LabTest { get; set; } = default!;
            public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
            public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
        }
        public class LabTest
        {
            [Key]
            public int TestID { get; set; }
            public string TestName { get; set; } = default!;
            public decimal Price { get; set; }
            //[ForeignKey("Departments")]
            //public int DepartmentID { get; set; }
            //[ForeignKey("Doctor")]
            //public int DoctorID { get; set; }
            [ForeignKey("PatientRegister")]
            public int PatientID { get; set; }
            public string Result { get; set; } = default!;
            [ForeignKey("LabTechnician")]
            public int TechnicianID { get; set; }
            //nev
            [NotMapped]
            public virtual LabTechnician LabTechnician { get; set; } = default!;
            public virtual PatientRegister PatientRegister { get; set; } = default!;
            //public virtual Department Departments { get; set; } = default!;
            public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();
            public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();
            public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
        }
        public class MedicalRecords
        {
            [Key]
            public int MedicalRecordsID { get; set; }
            public bool PatientType { get; set; } //indore/outdoor -- enum?
            public DateTime RecordDate { get; set; }
            public string MedicalHistory { get; set; } = default!; //prescription history + other history
            [ForeignKey("Patient")]
            public int PatientID { get; set; }//for patient basic info
            public PatientRegister Patient { get; set; } = default!;

            //add prescription id

        }
        public class SurgeryProcedure
        {
            [Key]
            public int SurgeryID { get; set; }
            [ForeignKey("PatientRegister")]
            public int PatientID { get; set; }
            public string ProcedureType { get; set; } = default!;
            public DateTime SurgeryDate { get; set; }
            [ForeignKey("Doctor")]
            public int DoctorID { get; set; }
            public string Observations { get; set; } = default!;
            public string Preoperative_Diagnosis { get; set; } = default!;
            public string Postoperative_Diagnosis { get; set; } = default!;
            [ForeignKey("LabTest")]
            public int TestID { get; set; }
            [ForeignKey("Prescription")]
            public int PrescriptionID { get; set; }
            //nev
            public virtual PatientRegister PatientRegister { get; set; } = default!;
            public virtual Doctor Doctor { get; set; } = default!;
            public virtual LabTest LabTest { get; set; } = default!;
            public virtual Prescriptions Prescription { get; set; } = default!;
        }
        public class DischargeTransfer
        {
            [Key]
            public int DT_ID { get; set; }
            [ForeignKey("Patient")]
            public int PatientID { get; set; }
            public DateTime DischargeDate { get; set; }
            public string DischargeSummary { get; set; } = default!;

            public PatientRegister Patient { get; set; } = default!;
        }
        public class Invoice
        {
            [Key]
            public int InvoiceID { get; set; }
            [ForeignKey("PatientRegisters")]
            public int PatientID { get; set; }
            public string Transaction_Info { get; set; } = default!;
            public decimal Bill_Amount { get; set; }
            public decimal Discount { get; set; }
            public decimal PaidAmount { get; set; }
            public decimal Due { get; set; }
            public string PaymentMethod { get; set; } = default!;
            public string PaymentStatus { get; set; } = default!;
            public DateTime InvoiceDate { get; set; }
            public string BillingAddress { get; set; } = default!;
            public string BillingNotes { get; set; } = default!;
            public string PreparedBy { get; set; } = default!;

            public PatientRegister PatientRegisters { get; set; } = default!;
            public virtual ICollection<Outdoor> Outdoors { get; set; } = new List<Outdoor>();
        }
    }
}
