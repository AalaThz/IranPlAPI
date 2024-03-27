using Iranpl.ApplicationCore.Services.Intefaces.Geographical;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories.Geographical
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly GeographicalApiContext _apiContext;

        public BaseRepository(GeographicalApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public List<TEntity> GetAll()
        {
            return _apiContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _apiContext.Set<TEntity>().Find(id);
        }
    }
}
