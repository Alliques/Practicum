using BookLibrary.Tests.Common;
using Contracts;
using Domain.Repositories;
using Domain.RequestOptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.Tests.ServicesTests
{
    public class BookServicesTests : TestBase
    {
        private readonly BookService _bookService;
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;
        private readonly IGenreRepository _genreRepo;
        private readonly IUnitOfWork _uowRepo;

        public BookServicesTests()
        {
            _bookRepo = new BookRepository(Context);
            _authorRepo = new AuthorRepository(Context);
            _genreRepo = new GenreRepository(Context);
            _uowRepo = new UnitOfWork(Context);
            _bookService = new BookService(_bookRepo, _genreRepo, _authorRepo, _uowRepo);
        }

        [Fact]
        public async Task CreateAuthor_Test()
        {
            // Arrange
            var countBeforeCreation = Context.Books.ToList().Count;
            var bookDto = new BookForCreationDto
            {
                AuthorId=1,
                Genres=new List<GenreDto>
                {
                    new GenreDto{Id=1},
                    new GenreDto{Id=2}
                },
                Title="Test_Title",
                WriteDate=DateTime.Now
            };

            // Act
            var createdEntity = await _bookService.CreateAsync(bookDto);
            var countAfterCreation = Context.Books.ToList().Count;

            // Assert
            Assert.NotNull(createdEntity);
            Assert.Equal(countBeforeCreation + 1, countAfterCreation);
        }

        [Fact]
        public async Task DeleteAuthor_Test()
        {
            // Arrange

            // Act
            EntityState state = await _bookService.DeleteAsync(7);

            // Assert
            Assert.Equal(EntityState.Deleted, state);
        }

        [Fact]
        public async Task GetBookById_Test()
        {
            // Arrange
            int id = 1;

            // Act
            var authors = await _bookService.GetByIdAsync(id);
            
            // Assert
            Assert.NotNull(authors);
            Assert.IsType<BookDto>(authors);
        }

        [Fact]
        public async Task UpdateBook_byId_Test()
        {
            // Arrange
            int id = 7;
            var book = new BookForUpdateDto{
                AuthorId = 3,
                GenreIds=new List<int> { 2,4},
                Title = "Updated book",
                WriteDate = DateTime.Now
            };

            // Act
            var updatedbook = await _bookService.UpdateAsync(id, book);

            // Assert
            Assert.NotNull(updatedbook);
            Assert.IsType<BookDto>(updatedbook);
            Assert.Equal(book.Title, updatedbook.Title);
            Assert.Equal(book.AuthorId, updatedbook.Author.Id);
        }


    }
}
