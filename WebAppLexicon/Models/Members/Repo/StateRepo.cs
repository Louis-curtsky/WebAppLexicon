using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Data;

namespace WebAppLexicon.Models.Members.Repo
{
    public class StateRepo : IStateRepo
    {
        readonly MemberDbContext _memberDbContext;

        public StateRepo(MemberDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }
        public State Create(State state)
        {
            _memberDbContext.States.Add(state);
            _memberDbContext.SaveChanges();
            return state;
        }

        public bool Delete(State state)
        {
            _memberDbContext.States.Remove(state);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public State FindById(int id)
        {
            State stateFound = _memberDbContext.States.Find(id);
            return stateFound;
        }

        public State GetState(int id)
        {
            return _memberDbContext.States.Find(id);
        }
        public List<State> GetAll()
        {
            return (_memberDbContext.States.Include(state => state.Cities).ToList());
        }


        public State Update(State state)
        {
            _memberDbContext.States.Update(state);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return state;
            }
            return null;
        }

        public List<State> BindCountry(int countryId)
        {
            List<State> lstStates = new List<State>();
            lstStates = _memberDbContext.States.Where(x => x.CntyId == countryId).ToList();
            return lstStates;
        }
    }
}
