namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IGenreService GenreService { get; }
        IAuthorService AuthorService { get; }
        IPersonService PersonService { get; }
        IBookService BookService { get; }
    }
}
