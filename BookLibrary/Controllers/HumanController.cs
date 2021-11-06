using AutoMapper;
using BookLibrary.Contracts;
using BookLibrary.Entites.DTO;
using BookLibrary.Entites.Models;
using BookLibrary.RequestOptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookLibrary.Controllers
{
    /// <summary>
    /// 1.3 - The controller that is responsible for the person
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanRepository _humanRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public HumanController(IHumanRepository humanRepository,IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _humanRepository = humanRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 1.3.1 - Returns a list of all people
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllHumans([FromQuery] HumanParametrs humanParametrs)
        {
            var items = _humanRepository.FindAll();

            // 1.3.1.3
            if (humanParametrs.SearchInName!=null)
            {
                items = items.Where(o=>
                o.Name.Contains(humanParametrs.SearchInName) ||
                o.Patronymic.Contains(humanParametrs.SearchInName) ||
                o.Surname.Contains(humanParametrs.SearchInName));
            }

            // 1.3.1.2
            if(humanParametrs.ShowWriters)
            {
                items = items.Where(o => _bookRepository
                .FindAll()
                .Any(x =>
                x.Author.Contains(o.Name) &&
                x.Author.Contains(o.Patronymic) &&
                x.Author.Contains(o.Surname)));
            }

            if (items == null)
            {
                return NotFound();
            }
            else
            {
                // 1.3.1.1
                return Ok(items);
            }
        }

        /// <summary>
        /// Get human by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "HumanById")]
        public IActionResult GetHuman(int id)
        {
            var human = _humanRepository.FindByCondition(o => o.Id == id).FirstOrDefault();
            if (human == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(human);
            }
        }

        /// <summary>
        /// 1.3.2 - Creates new human
        /// </summary>
        /// <param name="human">Human object</param>
        [HttpPost]
        public IActionResult CreateHuman([FromBody] HumanDto human)
        {
            if (human == null)
            {
                return BadRequest("HumanDTO object is null");
            }

            var humanEntity = _mapper.Map<Human>(human);
            humanEntity.Id = _humanRepository.FindAll().Max(o=>o.Id) + 1; //Guid.NewGuid();
            _humanRepository.Create(humanEntity);

            return CreatedAtRoute("HumanById", new { id = humanEntity.Id }, humanEntity);
        }

        /// <summary>
        /// 1.3.3 - Deletes an existing human from human list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public IActionResult DeleteHuman(int id)
        {
            var human = _humanRepository.FindByCondition(o=>o.Id==id).FirstOrDefault();

            if (human == null)
            {
                return NotFound();
            }

            _humanRepository.Delete(human);

            return NoContent();
        }
    }
}
