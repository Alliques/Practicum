using BookLibrary.Contracts;
using BookLibrary.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookLibrary.Repositories
{
    public class HumanRepository :  IHumanRepository
    {
        /// <summary>
        /// 1.2.3 - Dummy objects representings humans
        /// </summary>
        private readonly List<Human> _humanList;

        public HumanRepository()
        {
            _humanList = DummyData.humanList.ToList();
        }

        public void Create(Human entity)
        {
            _humanList.Add(entity);
        }

        public void Delete(Human entity)
        {
            _humanList.Remove(entity);
        }

        public IEnumerable<Human> FindAll()
        {
            return _humanList;
        }

        //refactoring
        public IQueryable<Human> FindByCondition(Expression<Func<Human, bool>> expression)
        {
            return _humanList.Where(expression.Compile()).AsQueryable();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Human entity)
        {
            throw new NotImplementedException();
        }
    }
}
