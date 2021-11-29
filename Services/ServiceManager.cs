//using Domain.Repositories;
//using Services.Abstractions;
//using System;

//namespace Services
//{
//    public class ServiceManager : IServiceManager
//    {
//        private readonly Lazy<IGenreService> _lazyGenreService;
//        private readonly Lazy<IPersonService> _lazyPersonService;
//        private readonly Lazy<IBookService> _lazyBookService;
//        private readonly Lazy<IAuthorService> _lazyAuthorService;
//        public ServiceManager(IRepositoryManager repositoryManager)
//        {
//            _lazyGenreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager));
//            _lazyAuthorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
//            _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager));
//            _lazyBookService = new Lazy<IBookService>(() => new BookService(repositoryManager));
//        }

//        public IGenreService GenreService
//        {
//            get { return _lazyGenreService.Value; }
//        }

//        public IAuthorService AuthorService
//        {
//            get { return _lazyAuthorService.Value; }
//        }

//        public IPersonService PersonService 
//        { 
//            get { return _lazyPersonService.Value; } 
//        }

//        public IBookService BookService
//        {
//            get { return _lazyBookService.Value; }
//        }
//    }
//}
