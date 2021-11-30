using Domain.Repositories;
using Moq;
using Services;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Tests.ServicesTests
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorRepository> _authorRepo = new Mock<IAuthorRepository>();
        private readonly Mock<IGenreRepository> _genreRepo = new Mock<IGenreRepository>();
        private readonly Mock<IUnitOfWork> _uowRepo = new Mock<IUnitOfWork>();
        public AuthorServiceTests()
        {
            _authorService = new AuthorService(_authorRepo.Object, _genreRepo.Object,_uowRepo.Object);
        }


    }
}
