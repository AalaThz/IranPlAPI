using Iranpl.ApplicationCore.Services.Intefaces.Geographical;
using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations.Geographical
{
    public class PartService
    {
        private readonly IPartRepository _partRepository;

        public PartService(IPartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        public List<Part> GetAllParts()
        {
            return _partRepository.GetAll();
        }

        public Part GetPartById(int id)
        {
            return _partRepository.GetById(id);
        }

        public List<Part> GetPartsByTownshipId(int townshipId)
        {
            return _partRepository.GetPartsByTownshipId(townshipId);
        }
    }
}
