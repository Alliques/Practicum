using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IQueryable<Author>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// The method of searching for Authors objects by id
        /// </summary>
        Task<Author> FindByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Method for creating a new Authors oobject
        /// </summary>
        /// <param name="entity">The Authors object being created</param>
        Author Create(Author entity);

        /// <summary>
        /// Method for deleting Authors object
        /// </summary>
        /// <param name="entity">The Authors object being deleting</param>
        EntityState Delete(Author entity);
    }
}
