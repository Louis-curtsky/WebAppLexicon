using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface ICountryServices
    {
        Country Create(CreateCountryViewModel country);
        List<Country> GetAll();
        Country FindById(int id);

        Country Edit(int id, CreateCountryViewModel editountry);
        bool Remove(int id);
    }
}
