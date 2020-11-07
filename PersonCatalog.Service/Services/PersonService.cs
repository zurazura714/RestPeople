using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Helpers;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.Interfaces.IServices;
using PersonCatalog.Domain.ResourceParameters;
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

        public PagedList<Person> SearchForPeople(PeopleResourceParameters resourceParameters)
        {
            if (resourceParameters == null)
            {
                throw new ArgumentNullException(nameof(PeopleResourceParameters));
            }

            var searchName = resourceParameters.SearchName;
            var result = Set().AsQueryable();
            if (searchName != null)
            {
                searchName = searchName.Trim();

                result = result.Where(a =>
                        searchName == null ||
                        a.Name.Contains(searchName) ||
                        a.Surname.Contains(searchName) ||
                        a.PersonalNumber.Contains(searchName) ||
                        a.Phones.Any(a => a.Number.Contains(searchName))
                        //||
                        //a.RelativeTo.Any(a => a.PersonTo.Name.Contains(parameters.SearchName))
                        );
            }

            return PagedList<Person>.Create(result,
                resourceParameters.PageNumber,
                resourceParameters.PageSize);
        }
    }
}
