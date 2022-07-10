using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class CityRepo : ICityRepo
    {
        private readonly MemberDbContext _memberDBContext;

        public CityRepo(MemberDbContext memberDBContext)
        {
            _memberDBContext = memberDBContext;
        }
        public City Create(City city)
        {
            _memberDBContext.Cities.Add(city);
            _memberDBContext.SaveChanges();
            return city;
        }

        public bool Delete(City city)
        {
            _memberDBContext.Cities.Remove(city);

            if (_memberDBContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public City FindById(int id)
        {
            City cityFound = new City();
            if (id != 0)
                cityFound = _memberDBContext.Cities.Find(id);

            return cityFound;

        }

        public City GetCity(int id)
        {
            return _memberDBContext.Cities.Find(id);
        }

        public List<City> GetAll()
        {
            List<City> cityList = _memberDBContext.Cities.Include(city => city.States).ToList();
            return cityList;
        }

        public bool Update(City city)
        {
            _memberDBContext.Cities.Update(city);
            if (_memberDBContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
