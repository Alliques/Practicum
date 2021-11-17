using BookLibrary.Contracts;
using BookLibrary.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void CreateBook(Book entity)
        {
            Create(entity);
        }

        public void DeleteBook(Book entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<Book>> FindAllBook()
        {
            return await _repositoryContext.Books.ToListAsync();
        }

        public async Task<Book> FindBookById(int id)
        {
            return await FindByCondition(o=>o.Id.Equals(id),false).SingleOrDefaultAsync();
        }

        public void UpdateBook(Book entity)
        {
            Update(entity);
        }
    }
}
