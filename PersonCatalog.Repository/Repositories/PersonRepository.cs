using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Repository.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork context) : base(context)
        {

        }
    }
}
