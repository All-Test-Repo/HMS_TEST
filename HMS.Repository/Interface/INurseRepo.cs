using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HMS.Models.DbModels;

namespace HMS.Repository.Interface
{
    public interface INurseRepo
    {
        IEnumerable<Nurse> GetNurses();
        Nurse GetNurseById(int id);
        void SaveNurse(Nurse nurse);
        void DeleteNurse(int id);
    }
}
