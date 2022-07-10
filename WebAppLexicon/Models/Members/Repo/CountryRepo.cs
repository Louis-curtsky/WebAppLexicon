using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class CountryRepo : ICountryRepo
    {
        private readonly MemberDbContext _memberDbContext;

        public CountryRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }

        
        public Country Create(Country country)
        {
            _memberDbContext.Countries.Add(country);
            _memberDbContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            _memberDbContext.Countries.Remove(country);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Country FindById(int id)
        {
            Country countryFound = _memberDbContext.Countries.Find(id);
            return countryFound;
        }

        public Country GetCountry(int id)
        {
            return _memberDbContext.Countries.Find(id);
        }
        public List<Country> GetAll()
        {
            return (_memberDbContext.Countries.Include(country => country.States).ToList());
        }


        public Country Update(Country country)
        {
            _memberDbContext.Countries.Update(country);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return country;
            }
            return null;
        }
    }
}
