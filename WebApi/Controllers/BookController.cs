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
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        ///// <summary>
        ///// 1.3.1 - Returns a list of all book
        ///// </summary>
        ///// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBook([FromQuery] BookParameters bookParameters, CancellationToken cancellationToken)
        {
            var books = await _bookService.GetAllAsync(bookParameters, cancellationToken);

            return Ok(books);
        }

        /// <summary>
        /// Returns person by id
        /// </summary>
        [HttpGet("{id}", Name = "BookById")]
        public async Task<IActionResult> GetBookById(int id, CancellationToken cancellationToken)
        {
            var book = await _bookService.GetByIdAsync(id, cancellationToken);

            return Ok(book);
        }

        /// <summary>
        /// 2.7.2.1 - Книга может быть добавлена (POST) (вместе с автором и жанром) 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto book)
        {
            var bookDto = await _bookService.CreateAsync(book);

            return CreatedAtRoute("BookById", new { id = bookDto.Id }, bookDto);
        }

        /// <summary>
        /// 2.7.2.2 - Книга может быть удалена из списка библиотеки 
        /// </summary>
        /// <param name="id">Book id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);

            return NoContent();
        }

        /// <summary>
        /// 2.7.1.2 - Книге можно присвоить новый жанр, или удалить один из имеющихся 
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookForUpdateDto bookForUpdateDto,
            CancellationToken cancellationToken)
        {
            var book = await _bookService.UpdateAsync(id, bookForUpdateDto, cancellationToken);

            return CreatedAtRoute("BookById", new { id = id }, book);
        }
    }
}
