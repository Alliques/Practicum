using Domain.Entites;
using Domain.Repositories;
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
    public class BookRepositoryTests
    {
        private readonly TestData data = TestData.GetInstance();

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
            Book createdBook = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IBookRepository bookRepository = new BookRepository(context);
                createdBook = bookRepository.Create(bookCreation);
                context.SaveChanges();
            }

            // Assert
            Assert.NotNull(createdBook);
        }

        [Fact]
        public async Task DeleteBook_Test()
        {
            // Arrange
            Book book = null;
            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IBookRepository bookRepository = new BookRepository(context);
                bookRepository.Delete(await bookRepository.FindByIdAsync(2, CancellationToken.None));
                context.SaveChanges();
                book = await bookRepository.FindByIdAsync(2, CancellationToken.None);
            }

            // Assert
            Assert.Null(book);
        }

        [Fact]
        public async Task GetBooks_ShouldReturnAllrBooks()
        {
            // Arrange
            int itemCount = 0;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IBookRepository bookRepository = new BookRepository(context);
                var books = await bookRepository.FindAllAsync(CancellationToken.None);
                itemCount = books.Count();
            }

            // Assert
            Assert.True(itemCount>0);
        }

        [Fact]
        public async Task GetBookById_test()
        {
            // Arrange
            Book book = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IBookRepository bookRepository = new BookRepository(context);
                book = await bookRepository.FindByIdAsync(1, CancellationToken.None);
            }

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
            Book book = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IBookRepository bookRepository = new BookRepository(context);
                book = await bookRepository.GetBookWithHolders(1, CancellationToken.None);
            }

            // Assert
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
            Assert.NotNull(book.Persons);
        }
    }
}
