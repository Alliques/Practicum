using Domain.Repositories;
using Services.Abstractions;
using System;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPersonService> _lazyPersonService;
        private readonly Lazy<IBookService> _lazyBookService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyPersonService = new Lazy<IPersonService>(() => new PersonService(repositoryManager));
            _lazyBookService = new Lazy<IBookService>(() => new BookService(repositoryManager));
        }
        public IPersonService PersonService 
        { 
            get { return _lazyPersonService.Value; } 
        }

        public IBookService BookService
        {
            get { return _lazyBookService.Value; }
        }
    }
}
