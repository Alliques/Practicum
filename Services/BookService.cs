using Contracts;
using Domain.Entites;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.RequestOptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepository bookRepository, IGenreRepository genreRepository,
            IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BookDto> CreateAsync(BookForCreationDto bookForCreationDto,
            CancellationToken cancellationToken = default)
        {
            var bookEntity = bookForCreationDto.Adapt<Book>();
            var genres = bookEntity.Genres.Select(
                o => _genreRepository.FindById(o.Id)).ToList();

            var author = await _authorRepository.FindByIdAsync(bookEntity.AuthorId, cancellationToken);

            bookEntity.Genres = genres;
            bookEntity.Author = author;
            _bookRepository.Create(bookEntity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return bookEntity.Adapt<BookDto>();
        }

        public async Task<EntityState> DeleteAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _bookRepository.FindByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

           var bookWithHolders = await _bookRepository.GetBookWithHolders(book.Id, cancellationToken);

            if(bookWithHolders.Persons.Any())
            {
                throw new DeletingException($"Can't delete book with id: {book.Id} because there are holders.");
            }

            var state = _bookRepository.Delete(book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return state;
        }

        public async Task<IEnumerable<BookDto>> GetAllAsync(BookParameters bookParameters, CancellationToken cancellationToken = default)
        {
            var books = await _bookRepository.FindAllAsync(cancellationToken);

            if (bookParameters.FilteringById != null)
            {
                books = books.Where(o => o.AuthorId == bookParameters.FilteringById);
            }

            // 2.7.1.4 - Можно получить список всех книг с фильтром по автору 
            if (!string.IsNullOrEmpty(bookParameters.AuthName))
            {
                books = books.Where(o => o.Author.FirstName.ToLower() == bookParameters.AuthName.ToLower());
            }

            if (!string.IsNullOrEmpty(bookParameters.AuthSurname))
            {
                books = books.Where(o => o.Author.LastName.ToLower() == bookParameters.AuthSurname.ToLower());
            }

            //2.7.1.5 - Можно получить список книг по жанру
            if (!string.IsNullOrEmpty(bookParameters.Genre))
            {
                books = books.Where(o => o.Genres.Any(o=>o.GenreName.ToLower() == bookParameters.Genre.ToLower()));
            }

            var booksDto = books.Adapt<IEnumerable<BookDto>>();

            return booksDto;
        }

        public async Task<BookDto> GetByIdAsync(int bookId, CancellationToken cancellationToken = default)
        {
            var book = await _bookRepository.FindByIdAsync(bookId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            var ownerDto = book.Adapt<BookDto>();

            return ownerDto;
        }

        public async Task<BookDto> UpdateAsync(int bookId, BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default)
        {
            var book = await _bookRepository.FindByIdAsync(bookId, cancellationToken);

            var genres = bookForUpdateDto.GenreIds.Distinct()
                .Select(o => _genreRepository.FindById(o));
            
            var author = await _authorRepository.FindByIdAsync(bookForUpdateDto.AuthorId, cancellationToken);

            if (book is null)
            {
                throw new BookNotFoundException(bookId);
            }

            book.ChangingDate = System.DateTimeOffset.Now;
            book.AuthorId = author.Id;
            book.Genres = genres.ToList();
            book.Title = bookForUpdateDto.Title;
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return book.Adapt<BookDto>();
        }
    }
}
