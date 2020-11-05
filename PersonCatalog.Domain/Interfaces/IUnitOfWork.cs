using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}
