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
    public class TownshipRepository : BaseRepository<Township>, ITownshipRepository
    {
        private readonly GeographicalApiContext _apiContext;

        public TownshipRepository(GeographicalApiContext apiContext) : base(apiContext)
        {
            _apiContext = apiContext;
        }

        public List<Township> GetTownshipsByStateId(int stateId)
        {
            return _apiContext.Townships.Where(t => t.StateCode == stateId).ToList();
        }
    }
}
