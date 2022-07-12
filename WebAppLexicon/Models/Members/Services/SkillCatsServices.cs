using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class SkillCatsServices : ISkillCatsServices
    {
        private readonly ISkillCatsRepo _skillCatsRepo;

        public SkillCatsServices(ISkillCatsRepo skillCatsRepo)
        {
            _skillCatsRepo = skillCatsRepo;
        }
        public SkillCats Create(CreateSkillCatsViewModel skillCats)
        {
            List<SkillCats> getAllSkills = new List<SkillCats>();
            getAllSkills = GetAll();
            int assignId = 0;
            if (getAllSkills.Count == 0)
            {
                assignId = 1;
            }
            else
            {
                assignId = getAllSkills[getAllSkills.Count - 1].SkillId;
            }
            return _skillCatsRepo.Create(skillCats, assignId);
        }

        public SkillCats Edit(int id, SkillCats skillCats)
        {
            throw new NotImplementedException();
        }

        public SkillCats FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SkillCats> GetAll()
        {
            return _skillCatsRepo.GetAll();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
