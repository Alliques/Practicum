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
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork)
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<GenrePresentationDto> CreateAsync(GenrePresentationDto genreDto, 
            CancellationToken cancellationToken = default)
        {
            var genre = genreDto.Adapt<Genre>();
            genre.CreationDate = System.DateTimeOffset.Now;
            genre.ChangingDate = System.DateTimeOffset.Now;
            _genreRepository.Create(genre);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return genre.Adapt<GenrePresentationDto>();
        }

        public async Task<IEnumerable<GenrePresentationDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var books = await _genreRepository.FindAllAsync(cancellationToken);
            var booksDto = books.Adapt<IEnumerable<GenrePresentationDto>>();

            return booksDto;
        }

        public async Task<IEnumerable<GenreStatisticDto>> GetGenresStatistic(CancellationToken cancellationToken = default)
        {
            var genres = await _genreRepository.FindAllAsync(cancellationToken, true);
            var statistic = genres.Select(o => new GenreStatisticDto 
            { 
                GenreName = o.GenreName,
                BookCount = o.Books.Count() 
            });

            return statistic;
        }
    }
}
