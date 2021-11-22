using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public void Create(Author entity)
        {
            _repositoryContext.Authors.Add(entity);
        }

        public void Delete(Author entity)
        {
            _repositoryContext.Authors.Remove(entity);
        }

        public async Task<IEnumerable<Author>> FindAllAsync(CancellationToken cancellationToken, bool loadBooks = false)
        {
            if (loadBooks)
            {
                return await _repositoryContext.Authors.Include(b=>b.Books).ToListAsync(cancellationToken);
            }
            else
            {
                return await _repositoryContext.Authors.ToListAsync(cancellationToken);
            }
        }

        public async Task<Author> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Authors.Include(b=>b.Books).ThenInclude(g=>g.Genres)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
