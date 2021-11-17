using System;

namespace BookLibrary.Entites
{
    public partial class LibraryCard
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PersonId { get; set; }
        public DateTime ReceiptDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Person Person { get; set; }
    }
}
