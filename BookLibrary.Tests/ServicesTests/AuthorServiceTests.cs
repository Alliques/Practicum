using AutoFixture;
using Contracts;
using Domain.Entites;
using Domain.Repositories;
using Moq;
using Mapster;
using Services;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using BookLibrary.Tests.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Domain.RequestOptions;

namespace BookLibrary.Tests.ServicesTests
{
    public class AuthorServiceTests : TestBase
    {
        private readonly AuthorService _authorService;
        private readonly IAuthorRepository _authorRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly IUnitOfWork _uowRepo;
        
        public AuthorServiceTests()
        {
            _authorRepo = new AuthorRepository(Context);
            _genreRepo = new GenreRepository(Context);
            _uowRepo = new UnitOfWork(Context);
            _authorService = new AuthorService(_authorRepo,_genreRepo,_uowRepo);
        }

        [Fact]
        public async Task CreateAuthor_Test()
        {
            // Arrange
            var countBeforeCreation = Context.Authors.ToList().Count;
            var authorDto = new AuthorForCreationDto
            {
                Books=new List<AuthorBookForCreationDto>(),
                FirstName="test",
                LastName="test"
            };

            // Act
            var createdEntity = await _authorService.CreateAsync(authorDto);
            var countAfterCreation = Context.Authors.ToList().Count;

            // Assert
            Assert.NotNull(createdEntity);
            Assert.Equal(countBeforeCreation+1, countAfterCreation);
        }

        [Fact]
        public async Task DeleteAuthor_Test()
        {
            // Arrange
            var id = 6;

            // Act
            var deletedEntity = await _authorService.DeleteAsync(id);

            // Assert
            Assert.Equal(1, deletedEntity);
        }

        [Fact]
        public async Task GetAllAuthors_Test()
        {
            // Arrange

            // Act
            var authors = await _authorService.GetAllAsync();

            // Assert
            Assert.Equal(6, authors.Count());
        }

        [Fact]
        public async Task GetAuthorWithBookById_Test()
        {
            // Arrange
            int authorId = 1;

            // Act
            var author = await _authorService.GetAuthorBooksAsync(authorId);

            // Assert
            Assert.Equal(3, author.Books.Count());
            Assert.NotNull(author.Books);
        }

        [Fact]
        public async Task GetAllByCriteria_Test()
        {
            // Arrange
            var authorOptions = new AuthorParameters
            {
                IsAsc = true,
                OrderbyAlph = true,
                WriteYear = "1992"
            };

            // Act
            var author = await _authorService.GetAllByCriteriaAsync(authorOptions);
           
            // Assert
            Assert.NotNull(author);
            Assert.Equal(2, author.Count());
        }

        [Fact]
        public async Task GetAuthorBookBySubstring_Test()
        {
            // Arrange
            var substringOrTitle = "тишь";

            // Act
            var author = await _authorService.GetAuthorBookBySubstringAsync(substringOrTitle);

            // Assert
            Assert.NotNull(author);
        }
    }
}
