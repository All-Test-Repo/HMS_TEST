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
    public class LabTechnician
    {
        [Key]
        public int TechnicianID { get; set; }

        [Required(ErrorMessage = "Enter Technician Name")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string TechnicianName { get; set; } = default!;

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public TechnicianType TechnicianType { get; set; } = default!;

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

        public string Image { get; set; } = default!;

        [StringLength(200)]
        public string Education_Info { get; set; } = default!;

        [NotMapped]
        public virtual Department? Departments { get; set; } = default!;

        public virtual ICollection<LabTest> Labtest { get; set; } = new List<LabTest>();
    }
    public enum TechnicianType
    {
        [Display(Name = "Medical Technician")]
        Medical,

        [Display(Name = "Laboratory Technician")]
        Laboratory,

        [Display(Name = "Radiology Technician")]
        Radiology,

        [Display(Name = "Surgical Technician")]
        Surgical,

        [Display(Name = "Pharmacy Technician")]
        Pharmacy,

        [Display(Name = "Respiratory Technician")]
        Respiratory,

        Other
    }


}
