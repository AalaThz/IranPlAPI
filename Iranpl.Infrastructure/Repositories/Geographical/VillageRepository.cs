using Iranpl.ApplicationCore.Services.Intefaces.Geographical;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories.Geographical
{
    public class VillageRepository : BaseRepository<Village>, IVillageRepository
    {
        private readonly GeographicalApiContext _apiContext;

        public VillageRepository(GeographicalApiContext apiContext) : base(apiContext)
        {
            _apiContext = apiContext;
        }

        public List<Village> GetVillagesByPartId(int partId)
        {
            return _apiContext.Villages.Where(v => v.PartCode == partId).ToList();
        }

    }
}
