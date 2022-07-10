using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public interface IStateServices
    {
        State Create(CreateStateViewModel createState);
        State Update(int id, CreateStateViewModel editState);
        State FindById(int id);
        public State GetState(int id);
        List<State> GetAll();

        bool Remove(State state);
    }
}
