using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        List<City> GetCitiesByPartId(int partId);
    }
}
