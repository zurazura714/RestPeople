using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;
using PersonCatalog.Domain.Interfaces.IServices;

namespace PersonCatalog.Service.Services
{
    public class RelationService : ServiceBase<Relation, IRelationRepository>, IRelationService
    {
        public RelationService(IUnitOfWork context, IRelationRepository relationRepository) : base(context, relationRepository)
        {
        }
    }
}
