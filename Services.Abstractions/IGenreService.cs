using Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IGenreService
    {
        Task<IEnumerable<GenrePresentationDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<GenrePresentationDto> CreateAsync(GenrePresentationDto genreDto, 
            CancellationToken cancellationToken = default);
        Task<IEnumerable<GenreStatisticDto>> GetGenresStatistic(CancellationToken cancellationToken = default);
    }
}
