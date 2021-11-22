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
    public class BookService : IBookService
    {
        private readonly IRepositoryManager _repositoryManager;
        public BookService(IRepositoryManager repositoryManager)
        {
            _repositoryManager  = repositoryManager;
        }

        public async Task<BookDto> CreateAsync(BookForCreationDto bookForCreationDto,
            CancellationToken cancellationToken = default)
        {
            var bookEntity = bookForCreationDto.Adapt<Book>();
            var genres = bookEntity.Genres.Select(
                o => _repositoryManager.Genre.FindById(o.Id)).ToList();

            var author = await _repositoryManager.Author.FindByIdAsync(bookEntity.AuthorId, cancellationToken);

            bookEntity.Genres = genres;
            bookEntity.Author = author;
            bookEntity.ChangingDate = System.DateTimeOffset.Now;
            bookEntity.CreationDate = System.DateTimeOffset.Now;

            _repositoryManager.Book.Create(bookEntity);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return bookEntity.Adapt<BookDto>();
        }

        public async Task DeleteAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.Book.FindByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

           var bookWithHolders = await _repositoryManager.Book.GetBookWithHolders(book.Id, cancellationToken);

            if(bookWithHolders.Persons.Any())
            {
                throw new DeletingException($"Can't delete book with id: {book.Id} because there are holders.");
            }

            _repositoryManager.Book.Delete(book);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(BookParameters bookParameters, CancellationToken cancellationToken = default)
        {
            var books = await _repositoryManager.Book.FindAllAsync(cancellationToken);

            if (bookParameters.FilteringById != null)
            {
                books = books.Where(o => o.AuthorId == bookParameters.FilteringById);
            }

            // 2.7.1.4 - Можно получить список всех книг с фильтром по автору 
            if (!string.IsNullOrEmpty(bookParameters.AuthName))
            {
                books = books.Where(o => o.Author.FirstName == bookParameters.AuthName);
            }

            if (!string.IsNullOrEmpty(bookParameters.AuthSurname))
            {
                books = books.Where(o => o.Author.LastName == bookParameters.AuthSurname);
            }

            if (!string.IsNullOrEmpty(bookParameters.AuthPatronymic))
            {
                books = books.Where(o => o.Author.MiddleName == bookParameters.AuthPatronymic);
            }

            //2.7.1.5 - Можно получить список книг по жанру
            if (!string.IsNullOrEmpty(bookParameters.Genre))
            {
                books = books.Where(o => o.Genres.Any(o=>o.GenreName==bookParameters.Genre));
            }

            var booksDto = books.Adapt<IEnumerable<BookDto>>();

            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.Book.FindByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            var ownerDto = book.Adapt<BookDto>();

            return ownerDto;
        }

        public async Task<BookDto> UpdateAsync(int bookId, BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.Book.FindByIdAsync(bookId, cancellationToken);

            var genres = bookForUpdateDto.GenreIds.Distinct()
                .Select(o => _repositoryManager.Genre.FindById(o));
            
            var author = await _repositoryManager.Author.FindByIdAsync(bookForUpdateDto.AuthorId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            book.ChangingDate = System.DateTimeOffset.Now;
            book.Version += 1;
            book.AuthorId = author.Id;
            book.Genres = genres.ToList();
            book.Title = bookForUpdateDto.Title;
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return book.Adapt<BookDto>();
        }
    }
}
