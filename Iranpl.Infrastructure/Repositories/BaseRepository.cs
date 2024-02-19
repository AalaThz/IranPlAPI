using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Infrastructure.Data.IranPlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : class, new()
    {
        private readonly ApiContext _apiContext;

        public BaseRepository(ApiContext apiContext)
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
