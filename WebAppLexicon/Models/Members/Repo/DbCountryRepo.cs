using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class DbCountryRepo : ICountryRepo
    {
        readonly MemberDbContext _personDBContext;

        public DbCountryRepo(MemberDbContext personDBContext)
        {
            _personDBContext = personDBContext;
        }
        public Country Create(Country country)
        {
            _personDBContext.Countries.Add(country);
            _personDBContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            _personDBContext.Countries.Remove(country);
            int returnValue = _personDBContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Country FindById(int id)
        {
            Country countryFound = _personDBContext.Countries.Find(id);
            return countryFound;
        }

        public Country GetCountry(int id)
        {
            return _personDBContext.Countries.Find(id);
        }
        public List<Country> GetAll()
        {
            return (_personDBContext.Countries.Include(country => country.States).ToList());
        }


        public Country Update(Country country)
        {
            _personDBContext.Countries.Update(country);
            if (_personDBContext.SaveChanges() > 0)
            {
                return country;
            }
            return null;
        }
    }
}
