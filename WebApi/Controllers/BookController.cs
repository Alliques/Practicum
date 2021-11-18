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

        /// <summary>
        /// Returns person by id
        /// </summary>
        [HttpGet("{id}", Name = "BookById")]
        public async Task<IActionResult> GetBookById(int id, CancellationToken cancellationToken)
        {
            var book = await _serviceManager.BookService.GetByIdAsync(id, cancellationToken);

            return Ok(book);
        }

        /// <summary>
        /// 1.3.2 - Creates new book in book list
        /// </summary>
        /// <param name="book">Book object</param>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
        {
            var bookDto = await _serviceManager.BookService.CreateAsync(book);

            return CreatedAtRoute("BookById", new { id = bookDto.Id }, bookDto);
        }

        /// <summary>
        /// 1.3.3 - Deletes an exist book from book list
        /// </summary>
        /// <param name="id">Book id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _serviceManager.BookService.DeleteAsync(id);

            return NoContent();
        }
    }
}
