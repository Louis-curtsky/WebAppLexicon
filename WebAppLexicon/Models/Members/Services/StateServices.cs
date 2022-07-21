using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members.Repo;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Models.Members.Services
{
    public class StateServices : IStateServices
    {
        private readonly IStateRepo _stateRepo;

        public StateServices(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }
        public State Create(CreateStateViewModel createState)
        {
            if (string.IsNullOrWhiteSpace(createState.StateName))
            {
                throw new ArgumentException("State Name with backspace(s)/whitespace(s) is not permited!!!");
            }
            State state = new State()
            {
                StateName = createState.StateName,
                CntyId = createState.CntyId
            };
            return _stateRepo.Create(state);
        }

        public State Update(int id, CreateStateViewModel editState)
        {
            State editedState = new State() { 
                StateId = id, 
                StateName = editState.StateName,
                CntyId = editState.CntyId,
                Countries = editState.Country
            };
            return _stateRepo.Update(editedState);
        }

        public State FindById(int id)
        {
            return _stateRepo.FindById(id);
        }

        public State GetState(int id)
        {
            return _stateRepo.GetState(id);
        }
        public List<State> GetAll()
        {
            return _stateRepo.GetAll();
        }

        public bool Remove(int id)
        {
            if (_stateRepo.FindById(id) != null)
            {
                State state = _stateRepo.GetState(id);
                return _stateRepo.Delete(state);
            }
            else
                return false;
        }

        public List<State> BindCountry(int countryId)
        {
            return _stateRepo.BindCountry(countryId);
        }
    }
}
