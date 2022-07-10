using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppLexicon.Models.Members.Repo
{
    public interface IStateRepo
    {
        State Create(State state);
        List<State> GetAll();
        State FindById(int id);
        State GetState(int id);

        State Update(State state);
        bool Delete(State state);
    }
}
