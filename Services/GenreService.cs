using Contracts;
using Domain.Entites;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class GenreService: IGenreService
    {
        private readonly IRepositoryManager _repositoryManager;
        public GenreService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GenrePresentationDto> CreateAsync(GenrePresentationDto genreDto, 
            CancellationToken cancellationToken = default)
        {
            var genre = genreDto.Adapt<Genre>();
            _repositoryManager.Genre.Create(genre);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return genre.Adapt<GenrePresentationDto>();
        }

        public async Task<IEnumerable<GenrePresentationDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await _repositoryManager.Genre.FindAllAsync(cancellationToken);
            var booksDto = books.Adapt<IEnumerable<GenrePresentationDto>>();

            return booksDto;
        }

        public async Task<IEnumerable<GenreStatisticDto>> GetGenresStatistic(CancellationToken cancellationToken = default)
        {
            var genres = await _repositoryManager.Genre.FindAllAsync(cancellationToken, true);
            var statistic = genres.Select(o => new GenreStatisticDto 
            { 
                GenreName = o.GenreName,
                BookCount = o.Books.Count() 
            });

            return statistic;
        }
    }
}
