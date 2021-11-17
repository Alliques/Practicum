using BookLibrary.Contracts;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IPersonRepository _person;
        private IBookRepository _book;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IPersonRepository Person
        {
            get
            {
                if (_person == null)
                {
                    _person = new PersonRepository(_repositoryContext);
                }
                return _person;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_repositoryContext);
                }
                return _book;
            }
        }
        public async Task<int> Save()
        {
            return await _repositoryContext.SaveChangesAsync();
        }
    }
}
