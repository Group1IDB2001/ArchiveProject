using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Countries
{
    public class CountryManager:ICountryManager
    {
        private readonly ArchiveContext _context;
        public CountryManager(ArchiveContext context)
        {
            _context = context;
        }
        public async Task AddCountry(string name)
        {
            var country_1 = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
            if (country_1 == null)
            {
                var country = new Country { Name = name };
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("There is Country with the same name");
            }
        }

        public async Task<IList<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                throw new Exception("Error,I can't found,There is not country");
            }
            return country;
        }

        public async Task<Country> GetCountryByName(string name)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == name);
            if (country == null)
            {
                throw new Exception("Error,I can't found,There is not country");
            }
            return country;
        }

        public async Task DeleteCountry(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                throw new Exception("Error,I can't delete,There is not country");
            }
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }
        public async Task EditCountryName(int id, string name)
        {
            var country = _context.Countries.FirstOrDefault(g => g.Id == id);
            if (country == null)
            {
                throw new Exception("Error,I can't found,There is not country");
            }
            country.Name = name;
            await _context.SaveChangesAsync();
        }
    }
}
