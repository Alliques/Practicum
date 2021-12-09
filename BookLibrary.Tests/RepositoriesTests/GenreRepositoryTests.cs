using BookLibrary.Tests.Common;
using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.Tests.RepositoriesTests
{
    public class GenreRepositoryTests : TestBase
    {
        [Fact]
        public void CreateGenre_Test_ShouldBeReturnCreatedInstance()
        {
            // Arrange
            var genreCreation = new Genre
            {
                GenreName = "Test_Genre"
            };
            IGenreRepository bookRepository = new GenreRepository(Context);

            // Act
            var createdGenre = bookRepository.Create(genreCreation);

            // Assert
            Assert.NotNull(createdGenre);
        }

        [Fact]
        public async Task DeleteGenre_Test()
        {
            // Arrange
            IGenreRepository genreRepository = new GenreRepository(Context);

            // Act
            var genreState = genreRepository.Delete(await genreRepository.FindByIdAsync(2, CancellationToken.None));

            // Assert
            Assert.Equal(EntityState.Deleted, genreState);
        }

        [Fact]
        public async Task GetGenres_ShouldReturnAllGenre()
        {
            // Arrange
            IGenreRepository genreRepository = new GenreRepository(Context);

            // Act
            var genre = await genreRepository.FindAllAsync(CancellationToken.None);
            var itemCount = genre.Count;

            // Assert
            Assert.True(itemCount > 0);
        }

        [Fact]
        public async Task GetGenreById_test()
        {
            // Arrange
            IGenreRepository genreRepository = new GenreRepository(Context);

            // Act
            var genre = await genreRepository.FindByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(genre);
            Assert.Equal(1, genre.Id);
        }
    }
}
