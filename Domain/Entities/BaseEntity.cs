using System;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ChangingDate { get; set; }
    }
}
