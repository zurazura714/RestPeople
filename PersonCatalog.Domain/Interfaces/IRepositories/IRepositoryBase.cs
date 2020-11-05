using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IRepositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IUnitOfWork Context { get; }

        void Add(TEntity entity);

        TEntity Fetch(int id);

        IEnumerable<TEntity> Set();

        void Save(TEntity entity);

        void Delete(int id);

        void Delete(TEntity entity);
    }
}
