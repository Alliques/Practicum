using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public GenreRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(Genre entity)
        {
            _repositoryContext.Genres.Add(entity);
        }

        public void Delete(Genre entity)
        {
            _repositoryContext.Genres.Remove(entity);
        }

        public async Task<IEnumerable<Genre>> FindAllAsync(CancellationToken cancellationToken)
        {
            return await _repositoryContext.Genres
                .ToListAsync(cancellationToken);
        }

        public Genre FindById(int id)
        {
            return _repositoryContext.Genres.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Genre> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Genres.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
