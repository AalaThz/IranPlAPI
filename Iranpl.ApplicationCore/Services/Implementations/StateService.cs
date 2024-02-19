using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations
{
    public class StateService 
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public List<State> GetAllState()
        {
            return _stateRepository.GetAll();
        }

        public State GetStateById(int id)
        {
            return _stateRepository.GetById(id);
        }
    }
}
