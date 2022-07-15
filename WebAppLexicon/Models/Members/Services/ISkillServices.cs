using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface ISkillServices
    {
        Skills Create(Skills skill);
        List<Skills> GetMySkill(int memberId);
        List<Skills> GetAll();
        Skills FindById(int id);

        Skills Edit(int id, Skills editskill);
        bool Remove(int id);
    }
}
