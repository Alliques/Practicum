using Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.RequestOptions;
using Mapster;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork, IBookRepository bookRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _bookRepository = bookRepository;
        }

        public async Task<PersonDto> CreateAsync(PersonForCreationDto personForCreationDto, 
            CancellationToken cancellationToken = default)
        {
            var personEntity = personForCreationDto.Adapt<Person>();
            personEntity.CreationDate = System.DateTimeOffset.Now;
            personEntity.ChangingDate = System.DateTimeOffset.Now;

            _personRepository.Create(personEntity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return personEntity.Adapt<PersonDto>();
        }

        public async Task DeleteAsync(int personId, CancellationToken cancellationToken = default)
        {
            var owner = await _personRepository.FindByIdAsync(personId, cancellationToken);

            if (owner is null)
            {
                throw new PersonNotFoundException(personId);
            }

            _personRepository.Delete(owner);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteByFullNameAsync(string fullName, CancellationToken cancellationToken = default)
        {
            var personsToDelete = await _personRepository.FindByCondition(o=> (fullName.Contains(o.FirstName) &&
            fullName.Contains(o.LastName) && (o.MiddleName != null && fullName.Contains(o.MiddleName))),
            cancellationToken);

            if (!personsToDelete.Any())
            {
                return;
            }

            foreach (var person in personsToDelete)
            {
                _personRepository.Delete(person);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PersonDto>> GetAllAsync(PersonParametrs personParametrs, 
            CancellationToken cancellationToken = default)
        {
            var persons = await _personRepository.FindAllAsync(personParametrs, cancellationToken);


            var personsDto = persons.Adapt<IEnumerable<PersonDto>>();

            return personsDto;
        }

        public async Task<PersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default)
        {
            var person = await _personRepository.FindByIdAsync(personId, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            var ownerDto = person.Adapt<PersonDto>();

            return ownerDto;
        }

        public async Task<IEnumerable<BookDto>> GetTakenBooks(int id, CancellationToken cancellationToken = default)
        {
            var list = await _personRepository.FindTakenBooks(id, cancellationToken);

            return list.Adapt<IEnumerable<BookDto>>();
        }

        public async Task<PersonTakenBooksDto> ReturnTakenBooks(int personId, IEnumerable<BookDto> books, 
            CancellationToken cancellationToken = default)
        {
            var person = await _personRepository.FindByIdAsync(personId, cancellationToken, true);
            person.Books.RemoveAll(o => books.Any(x => x.Id == o.Id));
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return person.Adapt<PersonTakenBooksDto>();
        }

        public async Task<PersonTakenBooksDto> TakeBooks(int personId, IEnumerable<BookDto> books,
            CancellationToken cancellationToken = default)
        {
            var person = await _personRepository.FindByIdAsync(personId, cancellationToken, true);
            List<Book> takenBooks = new List<Book>();

            foreach (var book in books)
            {
                takenBooks.Add(await _bookRepository.FindByIdAsync(book.Id, cancellationToken));
            }

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            person.Books.AddRange(takenBooks);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return person.Adapt<PersonTakenBooksDto>();
        }

        public async Task UpdateAsync(int personId, PersonForUpdateDto personForUpdateDto,
            CancellationToken cancellationToken = default)
        {
            var person = await _personRepository.FindByIdAsync(personId, cancellationToken);

            if (person is null)
            {
                throw new PersonNotFoundException(personId);
            }

            person.FirstName = personForUpdateDto.FirstName;
            person.LastName = personForUpdateDto.LastName;
            person.MiddleName = personForUpdateDto.MiddleName;
            //person.ChangingDate = System.DateTimeOffset.Now;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
