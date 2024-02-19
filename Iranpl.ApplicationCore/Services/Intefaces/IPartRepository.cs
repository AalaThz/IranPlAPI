using Iranpl.Domain.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces
{
    public interface IPartRepository : IBaseRepository<Part>
    { 
        List<Part> GetPartsByTownshipId(int townshipId);
    }
}
