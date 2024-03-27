using Iranpl.ApplicationCore.Services.Intefaces.Geographical;
using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations.Geographical
{
    public class VillageService
    {
        private readonly IVillageRepository _villageRepository;

        public VillageService(IVillageRepository villageRepository)
        {
            _villageRepository = villageRepository;
        }

        public List<Village> GetAllVillage()
        {
            return _villageRepository.GetAll();
        }

        public Village GetVillageById(int id)
        {
            return _villageRepository.GetById(id);
        }

        public List<Village> GetVillageByPartId(int partId)
        {
            return _villageRepository.GetVillagesByPartId(partId);
        }
    }
}
