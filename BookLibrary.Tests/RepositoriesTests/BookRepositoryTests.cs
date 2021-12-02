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
    public class BookRepositoryTests : TestBase
    {
        [Fact]
        public void CreateBook_Test_ShouldBeReturnCreatedInstance()
        {
            // Arrange
            var bookCreation = new Book
            {
                AuthorId = 1,
                Title = "Test_Title",
                Genres = null
            };
            
            // Act
            IBookRepository bookRepository = new BookRepository(Context);
            var createdBook = bookRepository.Create(bookCreation);

            // Assert
            Assert.NotNull(createdBook);
        }

        [Fact]
        public async Task DeleteBook_Test()
        {
            // Arrange
            IBookRepository bookRepository = new BookRepository(Context);
            
            // Act
            var bookState = bookRepository.Delete(await bookRepository.FindByIdAsync(2, CancellationToken.None));
            
            // Assert
            Assert.Equal(EntityState.Deleted, bookState);
        }

        [Fact]
        public async Task GetBooks_ShouldReturnAllrBooks()
        {
            // Arrange
            IBookRepository bookRepository = new BookRepository(Context);

            // Act
            var books = await bookRepository.FindAllAsync(CancellationToken.None);
            var itemCount = books.Count();

            // Assert
            Assert.True(itemCount>0);
        }

        [Fact]
        public async Task GetBookById_test()
        {
            // Arrange
            IBookRepository bookRepository = new BookRepository(Context);

            // Act
            var book = await bookRepository.FindByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
        }

        /// <summary>
        /// The book should be returned with the persons who hold this book
        /// </summary>
        [Fact]
        public async Task GetBookWithHolders_Test()
        {
            // Arrange
            IBookRepository bookRepository = new BookRepository(Context);

            // Act
            var book = await bookRepository.GetBookWithHolders(1, CancellationToken.None);

            // Assert
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
            Assert.NotNull(book.Persons);
        }
    }
}
