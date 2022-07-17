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
        public Skills Create(Skills skills)
        {

            _memberDbContext
                .Add(skills);
            _memberDbContext.SaveChanges();
            return skills;
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

        public List<Skills> GetMySkill(int memberId)
        {
            if (memberId != 0)
            {
                var noTrackSkill = _memberDbContext.Skills
                    .AsNoTracking()
                    .Where(x => memberId == x.MemberId)
                    .ToList();
                List<Skills> returnSkills = new List<Skills>();
                for (int i=0; i<noTrackSkill.Count; i++)
                {
                    returnSkills.Add(new Skills
                    {
                        SkillId = noTrackSkill[i].SkillId,
                        SkillDesc = noTrackSkill[i].SkillDesc,
                        MemberId = memberId,
                        SkillLevel = noTrackSkill[i].SkillLevel,
                        SkillYears = noTrackSkill[i].SkillYears,
                        Charges = noTrackSkill[i].Charges,
                        ChargeUnit = noTrackSkill[i].ChargeUnit,
                        MinUnit = noTrackSkill[i].MinUnit
                    });
                }
                return (returnSkills);
            }
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
