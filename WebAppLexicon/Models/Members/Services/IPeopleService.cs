using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface IPeopleService
    {
        List<Members> All();
        Members Add(CreateMemberViewModel memberViewModel);
        Members FindById(int id);
        List<Members> FindLast();
        void Edit(int id, MemberViewModel memberViewModel);
        bool Remove(int id);
        List<Members> Search(string firstName, string lastName, int countryId, int cityId);
    }
}
