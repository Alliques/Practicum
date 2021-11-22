using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface ILibraryCardRepository
    {
        /// <summary>
        /// Сreating a new entry in the library card
        /// </summary>
        /// <param name="entity">The object being created</param>
        void Create(LibraryCard entity);
    }
}
