using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public interface IManRepository
    {
        IEnumerable<Human> GetAllHumans();
        IEnumerable<Human> GetHuman(int id);
        void CreateHuman();
        void ModifyHuman(int id);
        void DeleteHuman(int id);
    }
}
