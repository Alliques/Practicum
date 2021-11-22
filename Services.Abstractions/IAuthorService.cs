using Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<AuthorBookDto> GetAuthorBooksAsync(int authorId, CancellationToken cancellationToken = default);

        Task<AuthorBookDto> CreateAsync(AuthorForCreationDto authorForCreationDto, 
            CancellationToken cancellationToken = default);

        Task DeleteAsync(int authorId, CancellationToken cancellationToken = default);
    }
}
