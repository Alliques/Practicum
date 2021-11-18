namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IPersonRepository Person { get; }
        IGenreRepository Genre { get; }
        IBookRepository Book { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
