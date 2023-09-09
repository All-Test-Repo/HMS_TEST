using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.ViewModels
{
    public class MedicineVM
    {
        [Key]
        public int MedicineID { get; set; }
        public string MedicineName { get; set; } = default!;
        public DateTime ExpireDate { get; set; }
        public int Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public decimal Discount { get; set; }
        public virtual MedicineGeneric MedicineGeneric { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
    }
}
