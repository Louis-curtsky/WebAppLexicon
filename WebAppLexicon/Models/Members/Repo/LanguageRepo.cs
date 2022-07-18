using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        readonly MemberDbContext _memberDbContext;

        public LanguageRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }

        public Language Create(Language language)
        {
            _memberDbContext.Add(language);
            _memberDbContext.SaveChanges();
            return language;
        }

        public bool Delete(Language language)
        {
            _memberDbContext.Language.Remove(language);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Language FindById(int id)
        {
            return _memberDbContext.Language.Find(id);
        }

        public List<Language> GetAll()
        {
            return _memberDbContext.Language.ToList();
        }

        public string GetLangName(int id)
        {
            Language lang = new Language();
            lang = _memberDbContext.Language.Find(id);
            return (lang.LangName);
        }

        public Language Update(Language language)
        {
            _memberDbContext.Language.Update(language);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }
    }
}
