namespace Services.Abstractions
{
    public interface IServiceManager
    {
        IPersonService PersonService { get; }
        IBookService BookService { get; }
    }
}
