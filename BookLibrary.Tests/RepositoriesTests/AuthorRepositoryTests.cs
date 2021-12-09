using BookLibrary.Tests.Common;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Persistence;
using Persistence.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.Tests.RepositoriesTests
{
    public class AuthorRepositoryTests :TestBase
    {

        [Fact]
        public async Task GetAuthorBooks_ShouldReturnAuthorInstance_ByAuthorId()
        {
            // Arrange
            int itemCount = 0;

            // Act
            AuthorRepository authorRepository = new AuthorRepository(Context);
            var authorBooks = await authorRepository.FindAllAsync(CancellationToken.None);
            itemCount = authorBooks.Count();

            // Assert
            Assert.Equal(6, itemCount);
        }

        [Fact]
        public async Task GetAuthorById_test()
        {
            // Arrange
            Author author = null;

            // Act
            AuthorRepository authorRepository = new AuthorRepository(Context);
            author = await authorRepository.FindByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(author);
        }

        [Fact]
        public void CreateAuthor_Test_ShouldReturnCreatedAuthorInstance()
        {
            // Arrange
            var authorCreation = new Author 
            { 
                FirstName="FN_Test",
                LastName="LN_Test",
                MiddleName = "MN_Test",
            };
            Author createdAuthor = null;

            // Act
            AuthorRepository authorRepository = new AuthorRepository(Context);
            createdAuthor = authorRepository.Create(authorCreation);

            // Assert
            Assert.NotNull(createdAuthor);
        }


        [Fact]
        public async Task DeleteAuthor_Test()
        {
            // Arrange

            // Act
            AuthorRepository authorRepository = new AuthorRepository(Context);
            var a = Context.Authors.ToList();
            var authorState = authorRepository.Delete(await authorRepository.FindByIdAsync(1, CancellationToken.None));
            
            // Assert
            Assert.Equal(EntityState.Deleted, authorState);
        }
    }
}