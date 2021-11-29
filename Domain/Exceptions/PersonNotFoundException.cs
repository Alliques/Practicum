using System;

namespace Domain.Exceptions
{
    public sealed class PersonNotFoundException : NotFoundException
    {
        public PersonNotFoundException(int accountId)
            : base($"The person with the identifier {accountId} was not found.")    
        {
        }
    }
}
