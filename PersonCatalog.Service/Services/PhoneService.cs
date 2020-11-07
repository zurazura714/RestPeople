using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.Interfaces.IServices;

namespace PersonCatalog.Service.Services
{
    public class PhoneService : ServiceBase<PhoneNumber, IPhoneRepository>, IPhoneService
    {
        public PhoneService(IUnitOfWork context, IPhoneRepository phoneRepository) : base(context, phoneRepository)
        {
        }
    }
}
