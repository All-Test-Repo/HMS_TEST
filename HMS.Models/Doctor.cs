using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HMS.Models.DbModels;

namespace HMS.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Enter Doctor Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string DoctorName { get; set; } = default!;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [StringLength(20, ErrorMessage = "Enter Doctor Speciality Only (Ex: Heart, Kidney)")]
        public string Specialization { get; set; } = default!;

        public doctortype Doctortype { get; set; } = default!;

        [Column(TypeName = "date")]
        [Display(Name = "Join Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Resign Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ResignDate { get; set; }

        [EnumDataType(typeof(EmployeeStatus))]
        public EmployeeStatus employeeStatus { get; set; }

        [StringLength(200)]
        public string Education_Info { get; set; } = default!;

        public string Image { get; set; } = default!;

        [NotMapped]
        public virtual Department? Department { get; set; } = default!;

        [NotMapped]
        public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();

        [NotMapped]
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        [NotMapped]
        public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
    }
    public enum doctortype
    {
        [Display(Name = "General Practitioner")]
        generalpractitioner,

        [Display(Name = "Specialist")]
        specialist,

        [Display(Name = "Surgeon")]
        surgeon,

        [Display(Name = "Anesthesiologist")]
        anesthesiologist
    }

}
