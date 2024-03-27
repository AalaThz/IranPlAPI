using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Geographical
{
    public interface IVillageRepository : IBaseRepository<Village>
    {
        List<Village> GetVillagesByPartId(int partId);
    }
}
