using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public AuthorRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Author Create(Author entity)
        {
            _repositoryContext.Authors.Add(entity);

            return entity;
        }

        public void Delete(Author entity)
        {
            _repositoryContext.Authors.Remove(entity);
        }

        public async Task<IQueryable<Author>> FindAllAsync(CancellationToken cancellationToken)
        {
            var list = await _repositoryContext.Authors.Include(b => b.Books).ToListAsync(cancellationToken);

            return list.AsQueryable();
        }

        public async Task<Author> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Authors.Include(b=>b.Books).ThenInclude(g=>g.Genres)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
