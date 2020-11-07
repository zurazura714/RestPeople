using PersonCatalog.Domain.Domains;
using PersonCatalog.Domain.Interfaces;
using PersonCatalog.Domain.Interfaces.IRepositories;

namespace PersonCatalog.Repository.Repositories
{
    public class RelationRepository : RepositoryBase<Relation>, IRelationRepository
    {
        public RelationRepository(IUnitOfWork context) : base(context)
        {

        }
    }
}
