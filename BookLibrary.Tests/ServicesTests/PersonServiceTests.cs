using BookLibrary.Tests.Common;
using Contracts;
using Domain.Repositories;
using Domain.RequestOptions;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.Tests.ServicesTests
{
    public class PersonServiceTests : TestBase
    {
        private readonly PersonService _personService;
        private readonly IPersonRepository _personRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IUnitOfWork _uowRepo;

        public PersonServiceTests()
        {
            _bookRepo = new BookRepository(Context);
            _personRepo = new PersonRepository(Context);
            _uowRepo = new UnitOfWork(Context);
            _personService = new PersonService(_personRepo, _uowRepo, _bookRepo);
        }

        [Fact]
        public async Task CreatePerson_Test()
        {
            // Arrange
            var countBeforeCreation = Context.Persons.ToList().Count;
            var personDto = new PersonForCreationDto
            {
                BirthDate=System.DateTime.Now,
                FirstName="Test_name",
                LastName = "last name test"
            };

            // Act
            var createdEntity = await _personService.CreateAsync(personDto);
            var countAfterCreation = Context.Persons.ToList().Count;

            // Assert
            Assert.NotNull(createdEntity);
            Assert.Equal(countBeforeCreation + 1, countAfterCreation);
        }

        [Fact]
        public async Task DeleteAuthor_Test()
        {
            // Arrange
            var id = 16;

            // Act
            EntityState state = await _personService.DeleteAsync(id);

            // Assert
            Assert.Equal(EntityState.Deleted, state);
        }

        [Fact]
        public async Task DeleteByFullNameAsync_Test()
        {
            // Arrange
            string fullName = "FN_NotWriter MN_NotWriter LN_NotWrite";

            // Act
            EntityState state = await _personService.DeleteByFullNameAsync(fullName);

            // Assert
            Assert.Equal(EntityState.Deleted, state);
        }

        [Fact]
        public async Task GetAllPersons_Test()
        {
            // Arrange
            var personParametrs = new PersonParametrs
            {
                SearchInName= "кИрИлл",
                ShowWriters = true
            };

            // Act
            var persons = await _personService.GetAllAsync(personParametrs);

            // Assert
            Assert.True(persons.Count()==1);
        }

        [Fact]
        public async Task GetPersonById_Test()
        {
            // Arrange
            int id = 1;
            string firstName = "Виктория";

            // Act
            var persons = await _personService.GetByIdAsync(id);

            // Assert
            Assert.Equal(persons.FirstName, firstName);
        }

        [Fact]
        public async Task ReturnTakenBooks_Test()
        {
            // Arrange
            int id = 3;
            var books = new List<BookDto>
            {
                new BookDto { Id=5 },
                new BookDto { Id=6 }
            };

            // Act
            var persons = await _personService.ReturnTakenBooks(id, books);

            // Assert
            Assert.True(persons.Books.Count==2);
        }

        [Fact]
        public async Task TakeBooks_Test()
        {
            // Arrange
            int id = 3;
            var books = new List<BookDto>
            {
                new BookDto { Id=2 },
                new BookDto { Id=3 }
            };

            // Act
            var persons = await _personService.TakeBooks(id, books);

            // Assert
            Assert.True(persons.Books.Count == 6);
        }

        [Fact]
        public async Task UpdateBooks_Test()
        {
            // Arrange
            int id = 3;
            var bookDto = new PersonForUpdateDto
            {
                BirthDate = System.DateTime.Now,
                FirstName = "updated name",
                LastName = "updated LN",
                MiddleName = null
            };

            // Act
            var flag = await _personService.UpdateAsync(id, bookDto);

            // Assert
            Assert.True(flag == 1);
        }
    }
}
