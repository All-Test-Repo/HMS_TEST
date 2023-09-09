using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HMS.Models.DbModels;

namespace HMS.Models.SurgeryWard
{
    public class WardCabin
    {
        [Key]
        public int WardID { get; set; }

        [Required(ErrorMessage = "Please enter medical ward name")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string WardName { get; set; } = default!;

        [Required(ErrorMessage = "Please enter Bed Or Cabin number"), Range(0, 100)]
        [Display(Name = "Bed Number")]
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
        //nev
        [NotMapped]
        public virtual Department Departments { get; set; } = default!;
        public virtual ICollection<PatientRegister> PatientRegisters { get; set; } = new HashSet<PatientRegister>();
    }
}
