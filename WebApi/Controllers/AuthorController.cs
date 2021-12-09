using Contracts;
using Domain.RequestOptions;
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
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        ///// <summary>
        ///// 2.7.3.1 - Можно получить список всех авторов
        ///// </summary>
        ///// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors(CancellationToken cancellationToken)
        {
            var books = await _authorService.GetAllAsync(cancellationToken);

            return Ok(books);
        }

        /// <summary>
        /// 2.7.4.2 - Создать новый метод контроллера,  который будет выводить список всех авторов, у которых есть хотя бы одна книга
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("bycriteria")]
        public async Task<IActionResult> GetAllAuthors([FromQuery] AuthorParameters parameters, CancellationToken cancellationToken)
        {
            var books = await _authorService.GetAllByCriteriaAsync(parameters, cancellationToken);

            return Ok(books);
        }

        ///// <summary>
        ///// 2.7.3.2 - Можно получить список книг автора 
        ///// </summary>
        ///// <returns></returns>
        [HttpGet("books", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorBooks(int authorId, CancellationToken cancellationToken)
        {
            var books = await _authorService.GetAuthorBooksAsync(authorId, cancellationToken);

            return Ok(books);
        }

        /// <summary>
        /// 2.7.2.3 - Добавить автора (с книгами или без) 
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto authorForCreationDto)
        {
            var authorDto = await _authorService.CreateAsync(authorForCreationDto);

            return CreatedAtRoute("AuthorById", new { id = authorDto.Id }, authorDto);
        }

        /// <summary>
        /// 2.7.2.3 - Удалить автора 
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAsync(id);

            return Ok();
        }

        ///// <summary>
        ///// 2.7.4.3 - создать новый метод, который будет выводить всех авторов, у которых название книги СОДЕРЖИТ 
        ////  указанную в параметрах подстроку 
        ///// </summary>
        ///// <returns></returns>
        [HttpGet("{substring}")]
        public async Task<IActionResult> GetAllAuthors(string substring, CancellationToken cancellationToken)
        {
            var books = await _authorService.GetAuthorBookBySubstringAsync(substring, cancellationToken);

            return Ok(books);
        }
    }
}
