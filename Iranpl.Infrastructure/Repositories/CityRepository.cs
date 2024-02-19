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
    public class CityRepository : BaseRepository<City> , ICityRepository
    {
        private readonly ApiContext _apiContext;

        public CityRepository(ApiContext apiContext) : base(apiContext)
        {
            _apiContext = apiContext;
        }

        public List<City> GetCitiesByPartId(int partId)
        {
            return _apiContext.Cities.Where(c => c.PartCode == partId).ToList();
        }
    }
}
