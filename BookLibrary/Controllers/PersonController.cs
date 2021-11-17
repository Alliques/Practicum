using AutoMapper;
using BookLibrary.Contracts;
using BookLibrary.Entites;
using BookLibrary.Entites.DTO;
using BookLibrary.RequestOptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    /// <summary>
    /// 1.3 - The controller that is responsible for the person
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson([FromQuery] PersonParametrs personParametrs)
        {
            var items = await _repositoryManager.Person.FindAllPerson();

            if (personParametrs.SearchInName!=null)
            {
                items = items.Where(o=>
                o.FirstName.Contains(personParametrs.SearchInName) ||
                o.LastName.Contains(personParametrs.SearchInName) ||
                o.MiddleName.Contains(personParametrs.SearchInName));
            }

            if(personParametrs.ShowWriters)
            {
                var books = await _repositoryManager.Book.FindAllBook();
                items = items.Where(o => books.Any(x =>x.AuthorId == o.Id));
            }

            if (items == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }
        }

        /// <summary>
        /// Returns person by id
        /// </summary>
        [HttpGet("{id}", Name = "PersonById")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _repositoryManager.Person.FindPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        /// <summary>
        /// Creates new person
        /// </summary>
        /// <param name="person">person object</param>
        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonDto person)
        {
            if (person == null)
            {
                return BadRequest("PersonDTO object is null");
            }

            var personEntity = _mapper.Map<Person>(person);
            _repositoryManager.Person.CreatePerson(personEntity);

            return CreatedAtRoute("PersonById", new { id = personEntity.Id }, personEntity);
        }

        /// <summary>
        /// 1.3.3 - Deletes an existing person from person list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _repositoryManager.Person.FindPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            _repositoryManager.Person.DeletePerson(person);

            return NoContent();
        }
    }
}
