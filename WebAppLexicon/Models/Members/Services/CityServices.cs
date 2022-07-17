using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class CityServices : ICityServices
    {
        private readonly ICityRepo _cityRepo;

        public CityServices(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }
        public City Create(CreateCityViewModel createCity)
        {
            if (string.IsNullOrWhiteSpace(createCity.CName))
            {
                throw new ArgumentException("City Name with backspace(s)/whitespace(s) is not permited!!!");
            }
            City city = new City()
            {
                CityName = createCity.CName,
                StateId = createCity.StateId
            };
            return _cityRepo.Create(city);
        }

        public bool Edit(City city)
        {
            if (_cityRepo.Update(city))
                return true;
            else
                return false;
        }

        public City FindById(int id)
        {
            return _cityRepo.FindById(id);
        }

        public City GetCity(int id)
        {
            return _cityRepo.GetCity(id);
        }
        public List<City> GetAll()
        {
            return _cityRepo.GetAll();
        }

        public bool Remove(City city)
        {
            if (_cityRepo.Delete(city))
                return true;
            else
                return false;
        }

        public List<City> BindState(int stateId)
        {
            return _cityRepo.BindState(stateId);
        }
    }
}
