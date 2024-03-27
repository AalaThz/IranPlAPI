using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Geographical
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
    }
}
