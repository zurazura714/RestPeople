using PersonCatalog.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IRepositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
    }
}
