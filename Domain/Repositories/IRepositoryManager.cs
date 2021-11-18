using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IPersonRepository Person { get; }
        IBookRepository Book { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
