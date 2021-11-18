using System.Threading;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;

        public UnitOfWork(RepositoryContext dbContext)
        {
            _repositoryContext = dbContext;
        }

        public  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _repositoryContext.SaveChangesAsync(cancellationToken);
        }
    }
}