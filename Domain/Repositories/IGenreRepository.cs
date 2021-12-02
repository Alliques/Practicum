using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IGenreRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<List<Genre>> FindAllAsync(CancellationToken cancellationToken, bool loadGenreBooks = false);

        /// <summary>
        /// The asynchronus method of searching for Genre objects by id
        /// </summary>
        Task<Genre> FindByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// The method of searching for Genre objects by id
        /// </summary>
        Genre FindById(int id);

        /// <summary>
        /// Method for creating a new Genre oobject
        /// </summary>
        /// <param name="entity">The Genre object being created</param>
        Genre Create(Genre entity);

        /// <summary>
        /// Method for deleting Genre object
        /// </summary>
        /// <param name="entity">The Genre object being deleting</param>
        EntityState Delete(Genre entity);
    }
}
