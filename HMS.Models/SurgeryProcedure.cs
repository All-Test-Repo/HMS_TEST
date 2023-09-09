
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
    public enum Preoperative_Diagnosis
    {
        Done = 1, Not_Done
    }
    public enum SurgeryType
    {
        Appendectomy = 1, Cholecystectomy, Hysterectomy, Mastectomy
    }
    public class SurgeryProcedure
    {
        [Key]
        public int SurgeryID { get; set; }

        [ForeignKey("PatientRegister")]
        public int PatientID { get; set; }

        [EnumDataType(typeof(SurgeryType))]
        public SurgeryType SurgeryType { get; set; } = default!; //enum

        [Column(TypeName = "date"),
         Display(Name = "Date"),
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
         ApplyFormatInEditMode = true)]
        public DateTime SurgeryDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Please enter medical Observations")]
        [StringLength(150, ErrorMessage = "Please do not enter values over 150 characters")]
        public string Observations { get; set; } = default!;

        [EnumDataType(typeof(Preoperative_Diagnosis))]
        public Preoperative_Diagnosis Preoperative_Diagnosis { get; set; } = default!;

        [Required(ErrorMessage = "Please enter medical Postoperative_Diagnosis")]
        [StringLength(150, ErrorMessage = "Please do not enter values over 150 characters")]
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
}
