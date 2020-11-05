using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IServices
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Fetch(int id);
        IEnumerable<TEntity> Set();
        void Save(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
    }
}
