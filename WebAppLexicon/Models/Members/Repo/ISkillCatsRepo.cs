using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface ISkillCatsRepo
    {
        SkillCats Create(CreateSkillCatsViewModel skillCats, int id);
        List<SkillCats> GetAll();
        SkillCats FindById(int id);
        SkillCats Update(SkillCats skillCats);
        bool Delete(SkillCats skillCats);
    }
}
