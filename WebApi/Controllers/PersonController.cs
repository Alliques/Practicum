using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
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
        /// Creates new person
        /// </summary>
        /// <param name="person">person object</param>
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonForCreationDto person)
        {
            var personDto = await _serviceManager.PersonService.CreateAsync(person);

            return CreatedAtRoute("PersonById", new { id = personDto.Id }, personDto);
        }

        /// <summary>
        /// 1.3.3 - Deletes an existing person from person list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            await _serviceManager.PersonService.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
