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
            _humanList = new List<Human>
            {
                new Human
                {
                    Id = 3, //new Guid("cc66e001-80b8-4623-ae52-4929decfbed0"),
                    Name ="Ярослав",
                    Surname ="Лопатин",
                    Patronymic ="Дмитриевич"
                },
                new Human
                {
                    Id = 1, //new Guid("31a46390-12b6-4f78-b505-52a8b2ed4865"),
                    Name ="Наталья",
                    Surname ="Шпак",
                    Patronymic ="Алексеевна"
                },
                new Human
                {
                    Id = 2, //new Guid("81830a02-2b6f-49d9-9402-01a1efcd3e20"),
                    Name ="Кирилл",
                    Surname ="Иванов",
                    Patronymic ="Борисович"
                }
            };
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
