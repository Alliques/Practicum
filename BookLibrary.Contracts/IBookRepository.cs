using BookLibrary.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IBookRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<IEnumerable<Book>> FindAllBook();

        /// <summary>
        /// The method of searching for Book objects by id
        /// </summary>
        Task<Book> FindBookById(int id);

        /// <summary>
        /// Method for creating a new Book oobject
        /// </summary>
        /// <param name="entity">The Book object being created</param>
        void CreateBook(Book entity);

        /// <summary>
        /// Method for updating an object
        /// </summary>
        /// <param name="entity">The Book object being updated</param>
        void UpdateBook(Book entity);

        /// <summary>
        /// Method for deleting Book object
        /// </summary>
        /// <param name="entity">The Book object being deleting</param>
        void DeleteBook(Book entity);
    }
}
