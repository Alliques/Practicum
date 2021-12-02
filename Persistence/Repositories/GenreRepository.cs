using Domain.Entites;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public Genre Create(Genre entity)
        {
            _repositoryContext.Genres.Add(entity);

            return entity;
        }

        public EntityState Delete(Genre entity)
        {
            return _repositoryContext.Genres.Remove(entity).State;
        }

        public async Task<List<Genre>> FindAllAsync(CancellationToken cancellationToken,
            bool loadGenreBooks = false)
        {
            if (loadGenreBooks)
            {
                return await _repositoryContext.Genres.Include(b => b.Books)
                .ToListAsync(cancellationToken);
            }
            else
            {
                return await _repositoryContext.Genres
                    .ToListAsync(cancellationToken);
            }
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
