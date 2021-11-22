using Domain.Entites;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<Book>> FindAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// The method of searching for Book objects by id
        /// </summary>
        Task<Book> FindByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Method for creating a new Book oobject
        /// </summary>
        /// <param name="entity">The Book object being created</param>
        void Create(Book entity);

        /// <summary>
        /// Method for deleting Book object
        /// </summary>
        /// <param name="entity">The Book object being deleting</param>
        void Delete(Book entity);

        /// <summary>
        /// Сhecking the availability of the book from users
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Book> GetBookWithHolders(int bookId, CancellationToken cancellationToken);
    }
}
