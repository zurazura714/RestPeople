using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonCatalog.Service.Services
{
    public class PersonService : ServiceBase<Person, IPersonRepository>, IPersonService
    {
        public PersonService(IUnitOfWork context, IPersonRepository personRepository) : base(context, personRepository)
        {
        }

        public IEnumerable<Person> GetPeopleByName(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return Set();
            }
            searchName = searchName.Trim();
            return Set().Where(a => a.Name == searchName);
        }
    }
}
