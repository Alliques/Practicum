using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// 1.4 - Book controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public BookController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        ///// <summary>
        ///// 1.3.1 - Returns a list of all book
        ///// </summary>
        ///// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBook([FromQuery] BookParameters bookParameters, CancellationToken cancellationToken)
        {
            var books = await _serviceManager.BookService.GetAllAsync(bookParameters, cancellationToken);

            return Ok(books);
        }

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
