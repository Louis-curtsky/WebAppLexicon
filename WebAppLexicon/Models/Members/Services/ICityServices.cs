using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface ICityServices
    {
        City Create(CreateCityViewModel createCity);
        bool Edit(City city);
        City FindById(int id);
        public City GetCity(int id);
        List<City> GetAll();

        bool Remove(City city);
    }
}
