using Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllAsync(BookParameters bookParameters, CancellationToken cancellationToken = default);

        Task<BookDto> GetByIdAsync(int bookId, CancellationToken cancellationToken = default);

        Task<BookDto> CreateAsync(BookForCreationDto bookForCreationDto, CancellationToken cancellationToken = default);

        Task<BookDto> UpdateAsync(int bookId, BookForUpdateDto bookForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int bookId, CancellationToken cancellationToken = default);
    }
}
