using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Contracts
{
    /// <summary>
    /// Interface for represents functionality humans entity
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHumanRepository
    {
        /// <summary>
        /// Find all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        IEnumerable<Human> FindAll();

        /// <summary>
        /// The method of searching for objects by any criteria 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<Human> FindByCondition(Expression<Func<Human, bool>> expression);

        /// <summary>
        /// Method for creating a new oobject
        /// </summary>
        /// <param name="entity">The object being created</param>
        void Create(Human entity);

        /// <summary>
        /// Method for updating an object
        /// </summary>
        /// <param name="entity">The object being updated</param>
        void Update(Human entity);

        /// <summary>
        /// Method for deleting object
        /// </summary>
        /// <param name="entity">The object being deleting</param>
        void Delete(Human entity);
    }
}
