using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogic.Authors
{
    public interface ICountryManager
    {
        Task AddCountry(string name);
        Task<IList<Country>> GetAllCountries();
        Task<Country> GetCountryById (int id);
        Task<Country> GetCountryByName (string name);
        Task DeleteCountry (int id);
        
    }
}
