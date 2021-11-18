using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public BookRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(Book entity)
        {
            _repositoryContext.Books.Add(entity);
        }

        public void Delete(Book entity)
        {
            _repositoryContext.Books.Remove(entity);
        }

        public async Task<IEnumerable<Book>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _repositoryContext.Books.ToListAsync(cancellationToken);
        }

        public async Task<Book> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Books.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
