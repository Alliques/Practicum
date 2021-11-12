using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Contracts
{
    public interface IBookRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        IEnumerable<Book> FindAll();

        /// <summary>
        /// The method of searching for objects by any criteria 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression);

        /// <summary>
        /// Method for creating a new oobject
        /// </summary>
        /// <param name="entity">The object being created</param>
        void Create(Book entity);

        /// <summary>
        /// Method for updating an object
        /// </summary>
        /// <param name="entity">The object being updated</param>
        void Update(Book entity);

        /// <summary>
        /// Method for deleting object
        /// </summary>
        /// <param name="entity">The object being deleting</param>
        void Delete(Book entity);
    }
}
