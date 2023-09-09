using HMS.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static HMS.Models.DbModels;

namespace Hospital_Management_System.Helpers
{
    public class NurseHelper
    {
        public NurseHelper()
        {

        }

        public NurseHelper(Nurse nurse)
        {
            this.NurseID = nurse.NurseID;
            this.DepartmentID = nurse.DepartmentID;
            this.NurseName = nurse.NurseName;
            this.NurseLevel = nurse.NurseLevel;
            this.NurseType = nurse.NurseType;
            this.JoinDate = nurse.JoinDate;
            this.ResignDate = nurse.ResignDate;
            this.employeeStatus = nurse.employeeStatus;
            //this.Image = ConvertByteToFile(nurse.Image);
            this.Education_Info = nurse.Education_Info;
            this.Department = nurse.Department;
            //this.WardCabins = nurse.WardCabins.ToList();
        }

        public int NurseID { get; set; }
        public int DepartmentID { get; set; }
        public string NurseName { get; set; }
        public NurseLevel NurseLevel { get; set; }
        public NurseType NurseType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public EmployeeStatus employeeStatus { get; set; }
        public IFormFile Image { get; set; }
        public string Education_Info { get; set; }
        public Department Department { get; set; }
        //public List<WardCabin> WardCabins { get; set; }

        public Nurse GetNurse()
        {
            Nurse nurse = new Nurse();
            nurse.NurseID = this.NurseID;
            nurse.DepartmentID = this.DepartmentID;
            nurse.NurseName = this.NurseName;
            nurse.NurseLevel = this.NurseLevel;
            nurse.NurseType = this.NurseType;
            nurse.JoinDate = this.JoinDate;
            nurse.ResignDate = this.ResignDate;
            nurse.employeeStatus = this.employeeStatus;
            //nurse.Image = ConvertFileToByte(this.Image);
            nurse.Education_Info = this.Education_Info;
            nurse.Department = this.Department;
            //nurse.WardCabins = this.WardCabins;
            return nurse;
        }

        // Helper method to save images
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadPath = Path.Combine("wwwroot", "Images"); // Modify the path as needed
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                return Path.Combine("Images", fileName); // Return the relative path
            }

            return null;
        }

        
    }
}
