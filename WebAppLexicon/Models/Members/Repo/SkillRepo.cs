using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Repo
{
    public class SkillRepo : ISkillsRepo
    {
        private readonly MemberDbContext _memberDbContext;

        public SkillRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }
        public Skills Create(CreateSkillsViewModel skills, int id)
        {
            Skills storeSkill = new Skills();
            storeSkill.SkillId = id;
            storeSkill.SkillDesc = skills.SkillDesc;
            storeSkill.SkillLevel = skills.SkillLevel;
            storeSkill.SkillYears = skills.SkillYears;
            _memberDbContext.Skills.Add(storeSkill);
            _memberDbContext.SaveChanges();
            return storeSkill;
        }

        public bool Delete(Skills skills)
        {
            _memberDbContext.Skills.Remove(skills);

            if (_memberDbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public Skills FindById(int id)
        {
            Skills skillFound = new Skills();
            if (id != 0)
                skillFound = _memberDbContext.Skills.Find(id);

            return skillFound;
        }

        public List<Skills> GetMySkill(int memberId, int skillId)
        {
            if (memberId != 0)
                return (_memberDbContext.Skills.Where(x =>
                skillId == x.SkillId &&
                memberId == x.MemberId
                ).ToList());
            else
            return null;     
        }
        public List<Skills> GetAll()
        {
            return _memberDbContext.Skills.ToList();
        }


        public Skills Update(Skills skills)
        {
            _memberDbContext.Skills.Update(skills);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return skills;
            }
            return null;
        }
    }
}
