using BookLibrary.Contracts;
using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// 1.2.3 - Dummy objects representings humans
        /// </summary>
        private readonly List<Book> _bookList;

        public BookRepository()
        {
            _bookList = DummyData.bookList.ToList();
        }

        public void Create(Book entity)
        {
            _bookList.Add(entity);
        }

        public void Delete(Book entity)
        {
            _bookList.Remove(entity);
        }

        public IEnumerable<Book> FindAll()
        {
            return _bookList;
        }

        public IQueryable<Book> FindByCondition(Expression<Func<Book, bool>> expression)
        {
            return _bookList.Where(expression.Compile()).AsQueryable();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
