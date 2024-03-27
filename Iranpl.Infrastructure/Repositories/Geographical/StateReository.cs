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
    public class StateReository : BaseRepository<State>, IStateRepository
    {
        public StateReository(GeographicalApiContext apiContext) : base(apiContext)
        {
        }
    }
}
