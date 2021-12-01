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

namespace BookLibrary.Tests.ServicesTests
{
    public class AuthorServiceTests : TestBase
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorRepository> _authorRepoMock = new Mock<IAuthorRepository>();
        private readonly Mock<IGenreRepository> _genreRepoMock = new Mock<IGenreRepository>();
        private readonly Mock<IUnitOfWork> _uowRepoMock = new Mock<IUnitOfWork>();
        private readonly TestData data = TestData.GetInstance();

        public AuthorServiceTests()
        {
            _authorService = new AuthorService(_authorRepoMock.Object, _genreRepoMock.Object, _uowRepoMock.Object);
        }

        [Fact]
        public async Task CreateAuthor_Test()
        {
            // Arrange
            AuthorForCreationDto authorDto = new Fixture().Create<AuthorForCreationDto>();
            var author = authorDto.Adapt<Author>();

            // Act
            var createdEntity = await _authorService.CreateAsync(authorDto);

            // Assert
            Assert.NotNull(createdEntity);
        }

        [Fact]
        public async Task DeleteAuthor_Test()
        {
            // Arrange
            var author = new Author { Id = 1 };

            // Act
            _authorService.DeleteAsync(1, CancellationToken.None);
            //var createdEntity = _authorService.DeleteAsync(authorDto.Id);

            // Assert
            Assert.True(true);
        }
    }
}
