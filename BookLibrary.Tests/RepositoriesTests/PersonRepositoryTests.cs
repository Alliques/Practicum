using BookLibrary.Tests.Common;
using Domain.Entites;
using Domain.Repositories;
using Domain.RequestOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookLibrary.Tests.RepositoriesTests
{
    public class PersonRepositoryTests : TestBase
    {

        [Fact]
        public void CreatePersonk_Test_ShouldBeReturnCreatedInstance()
        {
            // Arrange
            var personCreation = new Person
            {
               BirthDate = DateTime.Now,
               MiddleName = "MiddleName_Test",
               FirstName = "FirstName_Test",
               LastName = "LastName_Test"
            };
            IPersonRepository bookRepository = new PersonRepository(Context);

            // Act
            var createdPerson = bookRepository.Create(personCreation);

            // Assert
            Assert.NotNull(createdPerson);
        }

        [Fact]
        public async Task DeletePerson_Test()
        {
            // Arrange
            IPersonRepository personeRepository = new PersonRepository(Context);

            // Act
            var person = personeRepository.Delete(await personeRepository.FindByIdAsync(2, CancellationToken.None));

            // Assert
            Assert.Equal(EntityState.Deleted, person.State);
        }

        [Fact]
        public async Task GetPersons_ShouldReturnAllPerson_WithoutFilters()
        {
            // Arrange
            IPersonRepository personRepository = new PersonRepository(Context);

            // Act
            var books = await personRepository.FindAllAsync(new PersonParametrs(), CancellationToken.None);
            var itemCount = books.ToList().Count;

            // Assert
            Assert.True(itemCount > 0);
        }

        [Fact]
        public async Task GetPersons_ShouldReturnAllPerson_ShowWriters()
        {
            // Arrange
            var personParametrs = new PersonParametrs() 
            { 
                ShowWriters = true 
            };
            IPersonRepository personRepository = new PersonRepository(Context);

            // Act
            var books = await personRepository.FindAllAsync(personParametrs, CancellationToken.None);
            var itemCount = books.ToList().Count;

            // Assert
            Assert.Equal(3,itemCount);
        }

        [Fact]
        public async Task GetPersons_ShouldReturnAllPerson_SearchByName()
        {
            // Arrange
            int itemCount = 0;
            IQueryable<Person> people;
            var personParametrs = new PersonParametrs()
            {
                SearchInName = "ич"
            };

            // Act
            IPersonRepository personRepository = new PersonRepository(Context);
            people = await personRepository.FindAllAsync(personParametrs, CancellationToken.None);
            itemCount = people.ToList().Count;

            // Assert
            Assert.Equal(2, itemCount);
            Assert.True(people.All(o => o.MiddleName
            .Contains(personParametrs.SearchInName)
            || o.LastName.Contains(personParametrs.SearchInName)
            || o.FirstName.Contains(personParametrs.SearchInName)));
        }

        [Fact]
        public async Task GetPersonById_test()
        {
            // Arrange
            IPersonRepository personRepository = new PersonRepository(Context);

            // Act
            var person = await personRepository.FindByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(person);
            Assert.Equal(1, person.Id);
        }

        [Fact]
        public async Task FindTakenBooks_Test()
        {
            // Arrange
            IPersonRepository personRepository = new PersonRepository(Context);

            // Act
            var books = await personRepository.FindTakenBooks(1, CancellationToken.None);

            // Assert
            Assert.Equal(2, books.Count());
        }

    }
}
