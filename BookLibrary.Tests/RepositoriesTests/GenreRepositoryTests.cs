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
    public class GenreRepositoryTests
    {
        private readonly TestData data = TestData.GetInstance();

        [Fact]
        public void CreateGenre_Test_ShouldBeReturnCreatedInstance()
        {
            // Arrange
            var genreCreation = new Genre
            {
                GenreName = "Test_Genre"
            };
            Genre createdGenre = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IGenreRepository bookRepository = new GenreRepository(context);
                createdGenre = bookRepository.Create(genreCreation);
            }

            // Assert
            Assert.NotNull(createdGenre);
        }

        [Fact]
        public async Task DeleteGenre_Test()
        {
            // Arrange
            EntityEntry<Genre> genre = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IGenreRepository genreRepository = new GenreRepository(context);
                genre = genreRepository.Delete(await genreRepository.FindByIdAsync(2, CancellationToken.None));
            }

            // Assert
            Assert.Equal(EntityState.Deleted, genre.State);
        }

        [Fact]
        public async Task GetGenres_ShouldReturnAllGenre()
        {
            // Arrange
            int itemCount = 0;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IGenreRepository genreRepository = new GenreRepository(context);
                var genre = await genreRepository.FindAllAsync(CancellationToken.None);
                itemCount = genre.Count;
            }

            // Assert
            Assert.True(itemCount > 0);
        }

        [Fact]
        public async Task GetGenreById_test()
        {
            // Arrange
            Genre genre = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IGenreRepository genreRepository = new GenreRepository(context);
                genre = await genreRepository.FindByIdAsync(1, CancellationToken.None);
            }

            // Assert
            Assert.NotNull(genre);
            Assert.Equal(1, genre.Id);
        }
    }
}
