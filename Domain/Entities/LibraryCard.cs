using System;

namespace Domain.Entites
{
    public partial class LibraryCard
    {
        public int Id { get; set; }
        public int BooksId { get; set; }
        public int PersonsId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public Book Books { get; set; }
        public Person Persons { get; set; }
    }
}
