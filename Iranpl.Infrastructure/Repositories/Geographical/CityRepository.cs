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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        private readonly GeographicalApiContext _apiContext;

        public CityRepository(GeographicalApiContext apiContext) : base(apiContext)
        {
            _apiContext = apiContext;
        }

        public List<City> GetCitiesByPartId(int partId)
        {
            return _apiContext.Cities.Where(c => c.PartCode == partId).ToList();
        }
    }
}
