
//using Domain.Repositories;
//using Persistence;
//using Persistence.Repositories;
//using System;
//using System.Threading.Tasks;

//namespace Persistence.Repositories
//{
//    public class RepositoryManager : IRepositoryManager
//    {
//        private readonly Lazy<IPersonRepository> _lazyPersonRepository;
//        private readonly Lazy<IBookRepository> _lazyBookRepository;
//        private readonly Lazy<IGenreRepository> _lazyGenreRepository;
//        private readonly Lazy<ILibraryCardRepository> _lazyLibraryCardRepository;
//        private readonly Lazy<IAuthorRepository> _lazyAuthorRepository;
//        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

//        public RepositoryManager(RepositoryContext repositoryContext)
//        {
//            _lazyAuthorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(repositoryContext));
//            _lazyLibraryCardRepository = new Lazy<ILibraryCardRepository>(() => new LibraryCardRepository(repositoryContext));
//            _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(repositoryContext));
//            _lazyBookRepository = new Lazy<IBookRepository>(() => new BookRepository(repositoryContext));
//            _lazyGenreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(repositoryContext));
//            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryContext));
//        }

//        public IAuthorRepository Author
//        {
//            get
//            {
//                return _lazyAuthorRepository.Value;
//            }
//        }

//        public ILibraryCardRepository LibraryCard
//        {
//            get
//            {
//                return _lazyLibraryCardRepository.Value;
//            }
//        }
//        public IGenreRepository Genre
//        {
//            get
//            {
//                return _lazyGenreRepository.Value;
//            }
//        }
//        public IPersonRepository Person
//        {
//            get
//            {
//                return _lazyPersonRepository.Value;
//            }
//        }
//        public IBookRepository Book
//        {
//            get
//            {
//                return _lazyBookRepository.Value;
//            }
//        }
//        public IUnitOfWork UnitOfWork 
//        {
//            get
//            {
//               return _lazyUnitOfWork.Value;
//            }
//        }
//    }
//}
