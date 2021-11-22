using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ChangingDate { get; set; }
        public int Version { get; set; } = 1;
    }
}
