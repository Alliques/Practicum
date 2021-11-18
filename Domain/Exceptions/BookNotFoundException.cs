using System;

namespace Domain.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int bookId)
            : base($"The book with the identifier {bookId} was not found.")
        {
        }
    }
}
