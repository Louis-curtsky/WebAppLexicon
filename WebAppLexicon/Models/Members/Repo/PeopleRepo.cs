using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class PeopleRepo : IPeopleRepo
    {
        private readonly MemberDbContext _memberDbContext;

        public PeopleRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }

        public List<Members> All()
        {
            return _memberDbContext.Members
                .ToList();
        }

        //public Person Create(Person person, List<PersonLanguage> personLang)
        public Members Create(Members member)
        {
           if (member.StateId<1 || member.CntyId<1 || member.CtyId<1)
           {
            return null;
            }
           else
           {
               _memberDbContext.Add(member);
               int add = _memberDbContext.SaveChanges();
//               int add = 1;
                if (add != 1)
                        return null;
                else
                    return member;
           }
        }


        public List<Members> Search(string firstName, string lastName, int CntyId, int cityId)
        {
            if (firstName == null)
                firstName = "";
            else if (lastName == null)
                lastName = "";
            else if (CntyId < 0)
                CntyId = 99999; // To be replace 
            else if (cityId < 0)
                cityId = 99999;

            List<Members> searchMember = new List<Members>();
            searchMember = _memberDbContext.Members
                .Include(member => member.CntyId)
//                .Include(person => person.languageSpoken)
                .Where(member => member.FirstName == firstName
                || member.LastName == lastName
                || member.CtyId == cityId
                || member.CntyId == CntyId
                )
                .ToList();
            return searchMember;
        }

        public Members FindByID(int id)
        {
            return _memberDbContext.Members
                //.Include(person => person.languageSpoken)
                .SingleOrDefault(member => member.MemberId == id);
        }

        public List<Members> FindLast()
        {
            List<Members> member = 
            _memberDbContext.Members
                .OrderByDescending(m => m.MemberId)
                .Take(1).ToList();
            return member;
        }

        public List<Members> FindWithPending()
        {
            return _memberDbContext.Members
           .Where(member => member.MemberApproval == "Pending").ToList();
        }

        public bool Update(Members member)
        {
            _memberDbContext
                .Update(member);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return true;
            } else
            {
                return false;
            };
        }
        public bool Delete(Members member)
        {
            _memberDbContext.Remove(member);
            int removed = _memberDbContext.SaveChanges();
            if (removed == 2)
                return true;
            else
                return false;
        }

        public Members Read(int id)
        {
            foreach (Members member in _memberDbContext.Members)
            {
                if (member.MemberId == id)
                {
                    return member;
                }
            }
            return null;
        }


    }
}
