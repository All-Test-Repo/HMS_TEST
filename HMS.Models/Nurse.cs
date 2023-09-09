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
    public class Nurse
    {
        [Key]
        public int NurseID { get; set; }

        [Required(ErrorMessage = "Enter Nurse Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string NurseName { get; set; } = default!;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public NurseLevel NurseLevel { get; set; } = default!;

        public NurseType NurseType { get; set; } = default!;

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

        public virtual ICollection<Prescriptions> Prescriptions { get; set; } = new List<Prescriptions>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<SurgeryProcedure> SurgeryProcedures { get; set; } = new List<SurgeryProcedure>();
    }
    public enum NurseType
    {
        [Display(Name = "General Nurse")]
        General,

        [Display(Name = "Ward Duty Nurse")]
        WordDuty,

        [Display(Name = "Certified Midwife")]
        Midwife,

        [Display(Name = "Pediatric Nurse")]
        Pediatric,

        [Display(Name = "OT Nurse")]
        OT,

        [Display(Name = "High Dependency Unit")]
        HDU
    }

    public enum NurseLevel
    {
        Intern,
        Junior,
        Intermediate,
        Senior,

        [Display(Name = "Head Nurse")]
        HeadNurse,

        Other
    }

}
