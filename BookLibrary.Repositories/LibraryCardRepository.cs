using BookLibrary.Contracts;
using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public class LibraryCardRepository : ICardLibraryRepository
    {
        private readonly List<LibraryCard> _libraryCards;

        public LibraryCardRepository()
        {
            _libraryCards = DummyData.libraryCards.ToList();
        }

        public IEnumerable<LibraryCard> FindAll()
        {
            return _libraryCards;
        }

        public void Create(LibraryCard entity)
        {
            _libraryCards.Add(entity);
        }

        public IQueryable<LibraryCard> FindByCondition(Expression<Func<LibraryCard, bool>> expression)
        {
            return _libraryCards.Where(expression.Compile()).AsQueryable();
        }
    }
}
