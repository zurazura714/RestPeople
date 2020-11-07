using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Helpers;
using PersonCatalog.Domain.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonCatalog.Domain.Interfaces.IServices
{
    public interface IPersonService : IServiceBase<Person>
    {
        PagedList<Person> SearchForPeople(PeopleResourceParameters resourceParameters);
    }
}
