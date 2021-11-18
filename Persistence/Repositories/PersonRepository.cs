
using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class PersonRepository :  IPersonRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PersonRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(Person entity)
        {
            _repositoryContext.Person.Add(entity);
        }

        public void Delete(Person entity)
        {
            _repositoryContext.Person.Remove(entity);
        }

        public async Task<IEnumerable<Person>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _repositoryContext.Person.ToListAsync(cancellationToken);
        }

        public async Task<Person> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Person.FirstOrDefaultAsync(x=>x.Id==id, cancellationToken);
        }
    }
}
