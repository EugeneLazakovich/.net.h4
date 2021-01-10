using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();
        IEnumerable<Country> GetCountry(int id);
        IEnumerable<District> GetDistrict(int id);
    }
}
