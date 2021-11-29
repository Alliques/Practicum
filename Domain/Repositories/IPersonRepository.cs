using Domain.Entites;
using Domain.RequestOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<IEnumerable<Person>> FindAllAsync(PersonParametrs personParametrs, CancellationToken cancellationToken);

        /// <summary>
        /// The method of searching for Person objects by id
        /// </summary>
        Task<Person> FindByIdAsync(int id, CancellationToken cancellationToken, bool withTakenBooks = false);

        /// <summary>
        /// Method for creating a new Person object
        /// </summary>
        /// <param name="entity">The object being created</param>
        Person Create(Person entity);

        /// <summary>
        /// Method for deleting Person object
        /// </summary>
        /// <param name="entity">The Person object being deleting</param>
        void Delete(Person entity);

        /// <summary>
        /// Find by some criteria
        /// </summary>
        Task<IEnumerable<Person>> FindByCondition(Expression<Func<Person, bool>> expression,
            CancellationToken cancellationToken);

        /// <summary>
        /// Find all the books taken by a person
        /// </summary>
        /// <param name="personId">Person id</param>
        /// <returns>Returns person book collection</returns>
        Task<IEnumerable<Book>> FindTakenBooks(int personId, CancellationToken cancellationToken); 
    }
}
