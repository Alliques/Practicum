using Contracts;
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

        Task UpdateAsync(int personId, PersonForUpdateDto personForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(int personId, CancellationToken cancellationToken = default);
    }
}
