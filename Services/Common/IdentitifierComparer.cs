using Domain.Entites;
using System.Collections.Generic;

namespace Services.Common
{
    public class IdentitifierComparer : IEqualityComparer<Author>
    {
        public bool Equals(Author x, Author y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Author obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
