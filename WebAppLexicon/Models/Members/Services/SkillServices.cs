using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class SkillServices : ISkillServices
    {
        private readonly ISkillsRepo _skillsRepo;

        public SkillServices(ISkillsRepo skillsRepo)
        {
            _skillsRepo = skillsRepo;
        }
        public Skills Create(CreateSkillsViewModel skill)
        {
            List<Skills> getAllSkills = new List<Skills>();
            getAllSkills = GetAll();
            int assignId = 0;
            if (getAllSkills.Count==0)
            {
                assignId = 1;
            }
            else
            {
                assignId = getAllSkills[getAllSkills.Count - 1].SkillId;
            }
            return _skillsRepo.Create(skill, assignId);
        }

        public Skills Edit(int id, Skills editskill)
        {
            throw new NotImplementedException();
        }

        public Skills FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skills> GetAll()
        {
            return _skillsRepo.GetAll();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
