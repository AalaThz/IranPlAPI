using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Geographical
{
    public interface ITownshipRepository : IBaseRepository<Township>
    {
        List<Township> GetTownshipsByStateId(int stateId);
    }
}
