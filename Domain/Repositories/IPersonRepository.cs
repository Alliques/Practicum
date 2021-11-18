using Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    /// <summary>
    /// Interface for represents functionality Person entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPersonRepository
    {
        /// <summary>
        /// Find all Person entities
        /// </summary>
        /// <returns>Collection of Person entities</returns>
        Task<IEnumerable<Person>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// The method of searching for Person objects by id
        /// </summary>
        Task<Person> FindByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Method for creating a new Person object
        /// </summary>
        /// <param name="entity">The object being created</param>
        void Create(Person entity);

        /// <summary>
        /// Method for deleting Person object
        /// </summary>
        /// <param name="entity">The Person object being deleting</param>
        void Delete(Person entity);
    }
}
