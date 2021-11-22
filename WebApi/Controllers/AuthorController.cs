using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public AuthorController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        ///// <summary>
        ///// 2.7.3.1 - Можно получить список всех авторов
        ///// </summary>
        ///// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
        {
            var books = await _serviceManager.AuthorService.GetAllAsync(cancellationToken);

            return Ok(books);
        }

        ///// <summary>
        ///// 2.7.3.2 - Можно получить список книг автора 
        ///// </summary>
        ///// <returns></returns>
        [HttpGet("books", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorBooks(int authorId, CancellationToken cancellationToken)
        {
            var books = await _serviceManager.AuthorService.GetAuthorBooksAsync(authorId, cancellationToken);

            return Ok(books);
        }

        /// <summary>
        /// 2.7.2.3 - Добавить автора (с книгами или без) 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto authorForCreationDto)
        {
            var authorDto = await _serviceManager.AuthorService.CreateAsync(authorForCreationDto);

            return CreatedAtRoute("AuthorById", new { id = authorDto.Id }, authorDto);
        }

        /// <summary>
        /// 2.7.2.3 - Удалить автора 
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _serviceManager.AuthorService.DeleteAsync(id);

            return Ok();
        }
    }
}
