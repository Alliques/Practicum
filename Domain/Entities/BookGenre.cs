

namespace Domain.Entites
{
    public partial class BookGenre
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public int GenresId { get; set; }
    }
}
