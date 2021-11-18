using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.Controllers
{
    /// <summary>
    /// 1.4 - Book controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //private readonly IPersonRepository _humanRepository;
        //private readonly IBookRepository _bookRepository;
        //private readonly IMapper _mapper;

        //public BookController(IPersonRepository humanRepository, IBookRepository bookRepository, IMapper mapper)
        //{
        //    _bookRepository = bookRepository;
        //    _humanRepository = humanRepository;
        //    _mapper = mapper;
        //}

        ///// <summary>
        ///// 1.3.1 - Returns a list of all book
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult GetAllBook([FromQuery] BookParameters bookParameters)
        //{
        //    var items = _bookRepository.FindAll();

        //    // 1.3.1.2 - filtering by AuthorId
        //    if (bookParameters.FilteringById!=null)
        //    {
        //        items = items.Where(o=>o.AuthorId == bookParameters.FilteringById);
        //    }

        //    // 2.2.2 - ordering by book attributes
        //    if (bookParameters.OrderingBy != null)
        //    {
        //        switch (bookParameters.OrderingBy)
        //        {
        //            case "Author":
        //                items = items.OrderBy(o => o.Author);
        //                break;
        //            case "Genre":
        //                items = items.OrderBy(o => o.Genre);
        //                break;
        //            case "Title":
        //                items = items.OrderBy(o => o.Title);
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    if (items == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        // 1.3.1.1
        //        return Ok(items);
        //    }
        //}

        ///// <summary>
        ///// Get book by id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("{id}", Name = "BookById")]
        //public IActionResult GetBook(int id)
        //{
        //    var book = _bookRepository.FindByCondition(o => o.Id == id)
        //        .FirstOrDefault();

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(book);
        //    }
        //}

        ///// <summary>
        ///// 1.3.2 - Creates new book in book list
        ///// </summary>
        ///// <param name="book">Book object</param>
        //[HttpPost]
        //public IActionResult CreateBook([FromBody] BookDto book)
        //{
        //    if (book == null)
        //    {
        //        return BadRequest("BookDTO object is null");
        //    }

        //    var bookEntity = _mapper.Map<Book>(book);
        //    bookEntity.Id = _bookRepository.FindAll().Max(o => o.Id) + 1; //Guid.NewGuid();
        //    _bookRepository.Create(bookEntity);

        //    return CreatedAtRoute("HumanById", new { id = bookEntity.Id }, bookEntity);
        //}

        ///// <summary>
        ///// 1.3.3 - Deletes an exist book from book list
        ///// </summary>
        ///// <param name="id">Book id</param>
        //[HttpDelete("{id}")]
        //public IActionResult DeleteBook(int id)
        //{
        //    var book = _bookRepository.FindByCondition(o => o.Id == id).FirstOrDefault();

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _bookRepository.Delete(book);

        //    return NoContent();
        //}
    }
}
