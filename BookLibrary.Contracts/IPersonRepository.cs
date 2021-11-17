using BookLibrary.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
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
        Task<IEnumerable<Person>> FindAllPerson();

        /// <summary>
        /// The method of searching for Person objects by id
        /// </summary>
        Task<Person> FindPersonById(int id);

        /// <summary>
        /// Method for creating a new Person object
        /// </summary>
        /// <param name="entity">The object being created</param>
        void CreatePerson(Person entity);

        /// <summary>
        /// Method for updating an Person object
        /// </summary>
        /// <param name="entity">The Person object being updated</param>
        void UpdatePerson(Person entity);

        /// <summary>
        /// Method for deleting Person object
        /// </summary>
        /// <param name="entity">The Person object being deleting</param>
        void DeletePerson(Person entity);
    }
}
