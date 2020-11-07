using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;

namespace PersonCatalog.Repository.Repositories
{
    public class PhoneRepository : RepositoryBase<PhoneNumber>, IPhoneRepository
    {
        public PhoneRepository(IUnitOfWork context) : base(context)
        {

        }
    }
}
