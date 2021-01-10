using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public class CountryRepository : ICountryRepository
    {
        private InfesDbContext _context { get; }
        public CountryRepository(InfesDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public IEnumerable<Country> GetCountry(int id)
        {
            return _context.Countries.Where(c => c.Id == id);
        }

        public IEnumerable<District> GetDistrict(int id)
        {
            return _context.Districts.Where(c => c.Id == id);
        }
    }
}
