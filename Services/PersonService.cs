using Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryManager _repositoryManager;
        public PersonService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PersonDto> CreateAsync(PersonForCreationDto personForCreationDto, 
            CancellationToken cancellationToken = default)
        {
            var personEntity = personForCreationDto.Adapt<Person>();

            _repositoryManager.Person.Create(personEntity);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return personEntity.Adapt<PersonDto>();
        }

        public async Task DeleteAsync(int personId, CancellationToken cancellationToken = default)
        {
            var owner = await _repositoryManager.Person.FindByIdAsync(personId, cancellationToken);

            if (owner is null)
            {
                throw new PersonNotFoundException(personId);
            }

            _repositoryManager.Person.Delete(owner);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteByFullNameAsync(string fullName, CancellationToken cancellationToken = default)
        {
            var personsToDelete = await _repositoryManager.Person.FindByCondition(o=> (fullName.Contains(o.FirstName) &&
            fullName.Contains(o.LastName) && (o.MiddleName != null && fullName.Contains(o.MiddleName))),
            cancellationToken);

            if (!personsToDelete.Any())
            {
                return;
            }

            foreach (var person in personsToDelete)
            {
                _repositoryManager.Person.Delete(person);
            }

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(PersonParametrs personParametrs, 
            CancellationToken cancellationToken = default)
        {
            var persons = await _repositoryManager.Person.FindAllAsync(cancellationToken);

            if (personParametrs.SearchInName != null)
            {
                persons = persons.Where(o =>
                o.FirstName.Contains(personParametrs.SearchInName) ||
                o.LastName.Contains(personParametrs.SearchInName) ||
                o.MiddleName.Contains(personParametrs.SearchInName));
            }

            if (personParametrs.ShowWriters)
            {
                var books = await _repositoryManager.Book.FindAllAsync(cancellationToken);
                persons = persons.Where(o => books.Any(x => x.AuthorId == o.Id));
            }

            var personsDto = persons.Adapt<IEnumerable<PersonDto>>();

            return personsDto;
        }

        public async Task<PersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.Person.FindByIdAsync(personId, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            var ownerDto = person.Adapt<PersonDto>();

            return ownerDto;
        }

        public async Task<IEnumerable<BookDto>> GetTakenBooks(int id, CancellationToken cancellationToken = default)
        {
            var list = await _repositoryManager.Person.FindTakenBooks(id, cancellationToken);

            return list.Adapt<IEnumerable<BookDto>>();
        }

        public async Task<PersonTakenBooksDto> ReturnTakenBooks(int personId, IEnumerable<BookDto> books, 
            CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.Person.FindByIdAsync(personId, cancellationToken, true);
            person.Books.RemoveAll(o => books.Any(x => x.Id == o.Id));
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return person.Adapt<PersonTakenBooksDto>();
        }

        public async Task<PersonTakenBooksDto> TakeBooks(int personId, IEnumerable<BookDto> books,
            CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.Person.FindByIdAsync(personId, cancellationToken, true);
            List<Book> takenBooks = new List<Book>();

            foreach (var book in books)
            {
                takenBooks.Add(await _repositoryManager.Book.FindByIdAsync(book.Id, cancellationToken));
            }

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            person.Books.AddRange(takenBooks);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            
            return person.Adapt<PersonTakenBooksDto>();
        }

        public async Task UpdateAsync(int personId, PersonForUpdateDto personForUpdateDto,
            CancellationToken cancellationToken = default)
        {
            var person = await _repositoryManager.Person.FindByIdAsync(personId, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            person.FirstName = personForUpdateDto.FirstName;
            person.LastName = personForUpdateDto.LastName;
            person.MiddleName = personForUpdateDto.MiddleName;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
