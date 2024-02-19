using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations
{
    public class TownshipService 
    {
        private readonly ITownshipRepository _townshipRepository;

        public TownshipService(ITownshipRepository townshipRepository)
        {
            _townshipRepository = townshipRepository;
        }

        public List<Township> GetAllTownship()
        {
            return _townshipRepository.GetAll();
        }

        public Township GetTownshipById(int id)
        {
            return _townshipRepository.GetById(id);
        }

        public List<Township> GetTownshipsByStateId(int stateId)
        {
            return _townshipRepository.GetTownshipsByStateId(stateId);
        }
    }
}
