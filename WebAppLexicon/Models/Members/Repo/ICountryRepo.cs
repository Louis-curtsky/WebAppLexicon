﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface ICountryRepo
    {
        Country Create(Country country);
        List<Country> GetAll();
        Country FindById(int id);
        Country GetCountry(int id);

        Country Update(Country country);
        bool Delete(Country country);
    }
}
