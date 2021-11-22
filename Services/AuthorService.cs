﻿using Contracts;
using Domain.Repositories;
using Services.Abstractions;
using Mapster;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entites;
using Domain.Exceptions;
using Contracts.RequestOptions;

namespace Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AuthorService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<AuthorBookDto> CreateAsync(AuthorForCreationDto authorForCreationDto, 
            CancellationToken cancellationToken = default)
        {

            var author = authorForCreationDto.Adapt<Author>();
            author.CreationDate = System.DateTimeOffset.Now;
            author.ChangingDate = System.DateTimeOffset.Now;

            if (author.Books.Select(o => o.Genres).Any())
            {
                for (int i = 0; i < author.Books.Count; i++)
                {
                    //если добавят дубликаты жанров в книгу, то удаляем
                    author.Books[i].Genres = author.Books[i].Genres.GroupBy(o => o.Id)
                        .Select(g => g.First())
                        .ToList();

                    for (int j = 0; j < author.Books[i].Genres.Count; j++)
                    {
                        author.Books[i].Genres[j] = await _repositoryManager.Genre
                            .FindByIdAsync(author.Books[i].Genres[j].Id, cancellationToken);
                    }
                }
            }
            _repositoryManager.Author.Create(author);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return author.Adapt<AuthorBookDto>();
        }

        public async Task DeleteAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.Author.FindByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new BookNotFoundException(authorId);
            }

            if(author.Books.Any())
            {
                throw new DeletingException($"The author with {authorId}-id has books.");
            }

            _repositoryManager.Author.Delete(author);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.Author.FindAllAsync(cancellationToken);
            var authorDto = author.Adapt<IEnumerable<AuthorDto>>();

            return authorDto;
        }

        public async Task<AuthorBookDto> GetAuthorBooksAsync(int authorId, CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.Author.FindByIdAsync(authorId, cancellationToken);

            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }

            var authorBookDto = author.Adapt<AuthorBookDto>();

            return authorBookDto;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllByCriteriaAsync(AuthorParameters authorOptions,
            CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.Author.FindAllAsync(cancellationToken, true);

            if(!string.IsNullOrEmpty(authorOptions.WriteYear))
            {
                author = author.Where(o => o.Books
                .Any(b => b.WriteDate.Year.ToString() == authorOptions.WriteYear));
            }

            if(authorOptions.OrderBy== "Ascending" || authorOptions.OrderbyAlph)
            {
                author = author.OrderBy(o => o.LastName);
            }

            if (authorOptions.OrderBy == "Descending")
            {
                author = author.OrderByDescending(o => o.LastName);
            }
            var authorDto = author.Adapt<IEnumerable<AuthorDto>>();

            return authorDto;
        }

        public async Task<IEnumerable<AuthorDto>> GetAuthorBookSubstringAsync(string substring,
            CancellationToken cancellationToken = default)
        {
            var author = await _repositoryManager.Author.FindAllAsync(cancellationToken, true);
            author = author.Where(a => a.Books.Any(t => t.Title.Contains(substring)));
            
            var authorDto = author.Adapt<IEnumerable<AuthorDto>>();

            return authorDto;
        }
    }
}
