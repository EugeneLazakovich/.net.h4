using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public class HumanRepository : IHumanRepository
    {
        private InfesDbContext _context { get; }
        public HumanRepository(InfesDbContext context)
        {
            _context = context;
        }
        public void DeleteHuman(int humanId)
        {
            _context.Humans.Remove(_context.Humans.First(Human => Human.Id == humanId));
            _context.SaveChanges();
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans;
        }

        public IEnumerable<Human> ShowHumansByCountry(string nameCountry)
        {
            int idCountry = _context.Countries.Where(c => c.Name == nameCountry).Select(c => c.Id).FirstOrDefault();
            return _context.Humans.Where(c => c.CountryId == idCountry).ToList();
        }

        public IEnumerable<Human> GetHuman(int id)
        {
            return _context.Humans.Where(c => c.Id == id).ToList();
        }
    }
}
