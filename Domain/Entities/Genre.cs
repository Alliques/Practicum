using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Entites
{
    public partial class Genre: BaseEntity
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
