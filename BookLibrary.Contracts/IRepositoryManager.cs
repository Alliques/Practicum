using System.Threading.Tasks;

namespace BookLibrary.Contracts
{
    public interface IRepositoryManager
    {
        IPersonRepository Person { get; }
        IBookRepository Book { get; }
        Task<int> Save();
    }
}
