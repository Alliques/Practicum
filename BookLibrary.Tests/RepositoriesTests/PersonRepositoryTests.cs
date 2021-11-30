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
    public class PersonRepositoryTests
    {
        private readonly TestData data = TestData.GetInstance();

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
            Person createdPerson = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository bookRepository = new PersonRepository(context);
                createdPerson = bookRepository.Create(personCreation);
            }

            // Assert
            Assert.NotNull(createdPerson);
        }

        [Fact]
        public async Task DeletePerson_Test()
        {
            // Arrange
            EntityEntry<Person> person = null;
            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personeRepository = new PersonRepository(context);
                person = personeRepository.Delete(await personeRepository.FindByIdAsync(2, CancellationToken.None));
            }

            // Assert
            Assert.Equal(EntityState.Deleted, person.State);
        }

        [Fact]
        public async Task GetPersons_ShouldReturnAllPerson_WithoutFilters()
        {
            // Arrange
            int itemCount = 0;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personRepository = new PersonRepository(context);
                var books = await personRepository.FindAllAsync(new PersonParametrs(), CancellationToken.None);
                itemCount = books.ToList().Count;
            }

            // Assert
            Assert.True(itemCount > 0);
        }

        [Fact]
        public async Task GetPersons_ShouldReturnAllPerson_ShowWriters()
        {
            // Arrange
            int itemCount = 0;
            var personParametrs = new PersonParametrs() 
            { 
                ShowWriters = true 
            };

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personRepository = new PersonRepository(context);
                var books = await personRepository.FindAllAsync(personParametrs, CancellationToken.None);
                itemCount = books.ToList().Count;
            }

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
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personRepository = new PersonRepository(context);
                people = await personRepository.FindAllAsync(personParametrs, CancellationToken.None);
                var t = people.ToList();
                itemCount = people.ToList().Count;
            }

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
            Person person = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personRepository = new PersonRepository(context);
                person = await personRepository.FindByIdAsync(1, CancellationToken.None);
            }

            // Assert
            Assert.NotNull(person);
            Assert.Equal(1, person.Id);
        }

        [Fact]
        public async Task FindTakenBooks_Test()
        {
            // Arrange
            IEnumerable<Book> books = null;

            // Act
            using (var context = new RepositoryContext(data.options))
            {
                IPersonRepository personRepository = new PersonRepository(context);
                books = await personRepository.FindTakenBooks(1, CancellationToken.None);
            }

            // Assert
            Assert.Equal(2, books.Count());
        }
    }
}
