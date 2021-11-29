using Domain.Entites;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public LibraryCardRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public LibraryCard Create(LibraryCard entity)
        {
            _repositoryContext.LibraryCards.Add(entity);

            return entity;
        }
    }
}
