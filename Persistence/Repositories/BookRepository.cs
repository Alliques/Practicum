using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
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
            return await _repositoryContext.Books
                .Include(o=>o.Genres)
                .Include(g=>g.Author)
                .ToListAsync(cancellationToken);
        }

        public async Task<Book> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Books
                .Include(o => o.Genres)
                .Include(g => g.Author)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Book> GetBookWithHolders(int bookId, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Books.Where(o => o.Id == bookId)
                .Include(p => p.Persons).FirstOrDefaultAsync();
        }
    }
}
