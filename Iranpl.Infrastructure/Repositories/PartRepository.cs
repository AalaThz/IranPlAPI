using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Models.ApiModels;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories
{
    public class PartRepository : BaseRepository<Part> , IPartRepository
    {
        private readonly ApiContext _apiContext;

        public PartRepository(ApiContext apiContext) : base(apiContext)
        {
            _apiContext = apiContext;
        }

        public List<Part> GetPartsByTownshipId(int townshipId)
        {
            return _apiContext.Parts.Where(p => p.TownshipCode == townshipId).ToList();
        }
    }
}
