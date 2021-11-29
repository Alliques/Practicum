using Contracts;
using Domain.RequestOptions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDto>> GetAllAsync(PersonParametrs personParametrs, CancellationToken cancellationToken = default);

        Task<PersonDto> GetByIdAsync(int personId, CancellationToken cancellationToken = default);

        Task<PersonDto> CreateAsync(PersonForCreationDto personForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(int personId, PersonForUpdateDto personForUpdateDto,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(int personId, CancellationToken cancellationToken = default);

        Task DeleteByFullNameAsync(string fullName, CancellationToken cancellationToken = default);

        Task<IEnumerable<BookDto>> GetTakenBooks(int id, CancellationToken cancellationToken = default);

        Task<PersonTakenBooksDto> TakeBooks(int personId, IEnumerable<BookDto> books, 
            CancellationToken cancellationToken = default);

        Task<PersonTakenBooksDto> ReturnTakenBooks(int personId, IEnumerable<BookDto> books,
            CancellationToken cancellationToken = default);
    }
}
