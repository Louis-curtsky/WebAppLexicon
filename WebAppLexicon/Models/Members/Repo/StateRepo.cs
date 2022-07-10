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
            _memberDbContext.State.Add(state);
            _memberDbContext.SaveChanges();
            return state;
        }

        public bool Delete(State state)
        {
            _memberDbContext.State.Remove(state);
            int returnValue = _memberDbContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public State FindById(int id)
        {
            State stateFound = _memberDbContext.State.Find(id);
            return stateFound;
        }

        public State GetState(int id)
        {
            return _memberDbContext.State.Find(id);
        }
        public List<State> GetAll()
        {
            return (_memberDbContext.State.Include(state => state.StateId).ToList());
        }


        public State Update(State state)
        {
            _memberDbContext.State.Update(state);
            if (_memberDbContext.SaveChanges() > 0)
            {
                return state;
            }
            return null;
        }
    }
}
