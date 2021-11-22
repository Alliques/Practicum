using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// 1.3 - The controller that is responsible for the person
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PersonController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson([FromQuery] PersonParametrs personParametrs, CancellationToken cancellationToken)
        {
            var persons = await _serviceManager.PersonService.GetAllAsync(personParametrs, cancellationToken);

            return Ok(persons);
        }

        /// <summary>
        /// Returns person by id
        /// </summary>
        [HttpGet("{id}", Name = "PersonById")]
        public async Task<IActionResult> GetPersonById(int id, CancellationToken cancellationToken)
        {
            var person = await _serviceManager.PersonService.GetByIdAsync(id, cancellationToken);
            
            return Ok(person);
        }

        /// <summary>
        /// 2.7.1.1 -  создание пользователя
        /// </summary>
        /// <param name="person">person object</param>
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonForCreationDto person)
        {
            var personDto = await _serviceManager.PersonService.CreateAsync(person);

            return CreatedAtRoute("PersonById", new { id = personDto.Id }, personDto);
        }

        /// <summary>
        /// 2.7.1.3 - удаление по id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.PersonService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }

        /// <summary>
        /// 2.7.1.4 - удаление по ФИО
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeletePersonByName([FromQuery] string fullName, CancellationToken cancellationToken)
        {
            await _serviceManager.PersonService.DeleteByFullNameAsync(fullName, cancellationToken);

            return Ok();
        }

        /// <summary>
        /// 2.7.1.2 - обновление информации о пользователе
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonForUpdateDto personForUpdateDto, 
            CancellationToken cancellationToken)
        {
            await _serviceManager.PersonService.UpdateAsync(id, personForUpdateDto, cancellationToken);

            return CreatedAtRoute("PersonById", new { id = id }, personForUpdateDto);
        }

        /// <summary>
        /// 2.7.1.5 - список всех взятых пользователем книг 
        /// </summary>
        [HttpGet("personbooks/{id}")]
        public async Task<IActionResult> GetTakenBooks(int id, CancellationToken cancellationToken)
        {
            var person = await _serviceManager.PersonService.GetTakenBooks(id);

            return Ok(person);
        }

        /// <summary>
        /// 2.7.1.6 - Пользователь может взять книгу  
        /// </summary>
        [HttpPost("personbooks/{id}")]
        public async Task<IActionResult> GetTakenBooks(int id,[FromBody]List<BookDto> books, 
            CancellationToken cancellationToken)
        {
            var person = await _serviceManager.PersonService.TakeBooks(id,books,cancellationToken);

            return Ok(person);
        }

        /// <summary>
        /// 2.7.1.7 - вернуть книги
        /// </summary>
        [HttpDelete("personbooks/{id}")]
        public async Task<IActionResult> ReturnBooks(int id, [FromBody] List<BookDto> books,
            CancellationToken cancellationToken)
        {
            await _serviceManager.PersonService.ReturnTakenBooks(id, books, cancellationToken);

            return Ok();
        }
    }
}
