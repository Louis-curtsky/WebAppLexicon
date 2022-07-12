using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface ISkillCatsServices
    {
        SkillCats Create(CreateSkillCatsViewModel skillCats);
        List<SkillCats> GetAll();
        SkillCats FindById(int id);
        SkillCats Edit(int id, SkillCats skillCats);
        bool Remove(int id);
    }
}
