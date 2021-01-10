using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public class ManRepository : IManRepository
    {
        private InfesDbContext _context { get; }
        public ManRepository(InfesDbContext context)
        {
            _context = context;
        }
        public void CreateHuman()
        {
            throw new NotImplementedException();
        }

        public void DeleteHuman(int id)
        {
            var human = _context.Humans.Where(c => c.Id == id).FirstOrDefault();
            _context.Humans.Remove(human);
            _context.SaveChanges();
        }

        public IEnumerable<Human> GetAllHumans()
        {
            return _context.Humans.ToList();
        }

        public IEnumerable<Human> GetHuman(int id)
        {
            return _context.Humans.Where(c => c.Id == id);
        }

        public void ModifyHuman(int id)
        {
            var human = _context.Humans.Where(c => c.Id == id).FirstOrDefault();
            _context.SaveChanges();
        }
    }
}
