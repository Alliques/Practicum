using Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System.Collections;
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

        public async Task<BookDto> CreateAsync(BookForCreationDto bookForCreationDto, CancellationToken cancellationToken = default)
        {
            var bookEntity = bookForCreationDto.Adapt<Book>();
            var genres = bookEntity.Genres.Select(
                o => _repositoryManager.Genre.FindById(o.Id)).ToList();

            bookEntity.Genres = genres;

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

        public async Task UpdateAsync(int bookId, BookForCreationDto bookForCreationDto, CancellationToken cancellationToken = default)
        {
            var book = await _repositoryManager.Book.FindByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            book.AuthorId = bookForCreationDto.AuthorId;
            book.Title = bookForCreationDto.Title;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
