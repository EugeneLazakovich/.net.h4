using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public interface IHumanRepository
    {
        void DeleteHuman(int humanId);
        IEnumerable<Human> ShowHumansByCountry(string nameCountry);
        IEnumerable<Human> GetHuman(int id);
        IEnumerable<Human> GetAllHumans();
    }
}
