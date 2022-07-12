using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public class SkillCatsRepo : ISkillCatsRepo
    {
        private readonly MemberDbContext _memberDbContext;

        public SkillCatsRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }
        public SkillCats Create(CreateSkillCatsViewModel skillCats, int id)
        {
            SkillCats storeSkill = new SkillCats();
            storeSkill.SkillId = id;
            storeSkill.Categories = skillCats.Categories;
            _memberDbContext.SkillCats.Add(storeSkill);
            _memberDbContext.SaveChanges();
            return storeSkill;
        }

        public bool Delete(SkillCats skillCats)
        {
            _memberDbContext.SkillCats.Remove(skillCats);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public SkillCats FindById(int id)
        {
            SkillCats skillCatsFound = _memberDbContext.SkillCats.Find(id);
            return skillCatsFound;
        }

        public List<SkillCats> GetAll()
        {
            return (_memberDbContext.SkillCats).ToList();
        }

        public SkillCats Update(SkillCats skillCats)
        {
            _memberDbContext.SkillCats.Update(skillCats);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return skillCats;
            }
            return null;
        }
    }
}
