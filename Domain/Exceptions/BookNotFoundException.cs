using System;

namespace Domain.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(Guid ownerId)
            : base($"The book with the identifier {ownerId} was not found.")
        {
        }
    }
}
