namespace Domain.Exceptions
{
    public class AuthorNotFoundExeption : NotFoundException
    {
        public AuthorNotFoundExeption(int authorId)
            : base($"The author with the identifier {authorId} was not found.")
        {
        }
    }
}
