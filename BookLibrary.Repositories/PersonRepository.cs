using BookLibrary.Contracts;
using BookLibrary.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibrary.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public PersonRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void CreatePerson(Person entity)
        {
            Create(entity);
        }

        public void DeletePerson(Person entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<Person>> FindAllPerson()
        {
            return await _repositoryContext.Person.ToListAsync();
        }

        public async Task<Person> FindPersonById(int id)
        {
            return await FindByCondition(o => o.Id.Equals(id), false).SingleOrDefaultAsync();
        }

        public void UpdatePerson(Person entity)
        {
            Update(entity);
        }
    }
}
