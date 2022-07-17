using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface ICityRepo
    {
        City Create(City city);
        bool Delete(City city);
        City FindById(int id);
        public City GetCity(int id);
        List<City> GetAll();
        bool Update(City city);

        List<City> BindState(int stateId);
    }
}
