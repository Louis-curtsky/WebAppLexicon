using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface ISkillsRepo
    {
        Skills Create(CreateSkillsViewModel skills, int id);
        List<Skills> GetAll();
        Skills FindById(int id);

        Skills Update(Skills skills);
        bool Delete(Skills skills);
    }
}
