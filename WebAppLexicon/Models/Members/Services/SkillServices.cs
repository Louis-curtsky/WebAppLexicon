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
        public Skills Create(Skills skill)
        {
            return _skillsRepo.Create(skill);
        }

        public List<Skills> GetMySkill(int memberId)
        {
            return _skillsRepo.GetMySkill(memberId);
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
