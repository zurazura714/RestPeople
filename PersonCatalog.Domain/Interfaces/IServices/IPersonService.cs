using PersonCatalog.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IServices
{
    public interface IPersonService : IServiceBase<Person>
    {
        IEnumerable<Person> GetPeopleByName(string searchName);
    }
}
