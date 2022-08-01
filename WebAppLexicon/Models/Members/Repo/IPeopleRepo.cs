using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface IPeopleRepo
    {
        Members Read(int id);

        List<Members> All();
        //Person Create(Person person, List<PersonLanguage> personLang);
        Members Create(Members member);
        Members FindByID(int id);
        List<Members> FindLast();
        List<Members> FindWithPending();
        List<Members> Search(string firstName, string lastName, int countryId, int cityId);
        bool Update(Members member);

        //void UpdateLang(int pId, List<PersonLanguage> langPer);

        bool Delete(Members member);

        //List<PersonLanguage> GetLanguage(int id);
    }
}
