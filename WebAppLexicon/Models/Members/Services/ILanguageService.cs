using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel language);
        List<Language> GetAll();
        Language FindById(int id);
        Language Edit(int id, CreateLanguageViewModel editlanguage);
        bool Remove(int id);
    }
}
