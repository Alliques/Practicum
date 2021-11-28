using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class PersonRepository :  IPersonRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PersonRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Person Create(Person entity)
        {
            _repositoryContext.Persons.Add(entity);

            return entity;
        }

        public void Delete(Person entity)
        {
            _repositoryContext.Persons.Remove(entity);
        }

        public async Task<IEnumerable<Person>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _repositoryContext.Persons.ToListAsync(cancellationToken);
        }

        public async Task<Person> FindByIdAsync(int id, CancellationToken cancellationToken, 
            bool withTakenBooks = false)
        {
            if (withTakenBooks)
            {
                return await _repositoryContext.Persons.Include(b=>b.Books)
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
            else
            {
                return await _repositoryContext.Persons.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            }
        }

        public async Task<IEnumerable<Person>> FindByCondition(Expression<Func<Person, bool>> expression,
            CancellationToken cancellationToken)
        {
            return await _repositoryContext.Persons.Where(expression).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Book>> FindTakenBooks(int personId, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Persons
                .Where(p=>p.Id == personId)
                .SelectMany(p => p.Books, (b, g) => 
                new Book {
                    Id=g.Id, 
                    Title = g.Title, 
                    Genres = g.Genres,
                    Author=g.Author 
                }).ToListAsync();
        }
    }
}
