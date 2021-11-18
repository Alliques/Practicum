using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    /// <summary>
    /// 2.1.2 Library card controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCardController : ControllerBase
    {
        //private readonly IPersonRepository _humanRepository;
        //private readonly ICardLibraryRepository _cardLibraryRepository;
        //private readonly IMapper _mapper;

        //public LibraryCardController(IPersonRepository humanRepository, 
        //    ICardLibraryRepository cardLibraryRepository, IMapper mapper)
        //{
        //    _cardLibraryRepository = cardLibraryRepository;
        //    _humanRepository = humanRepository;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public IActionResult GetAllHumans()
        //{
        //    var items = _cardLibraryRepository.FindAll();

        //    if (items == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(items);
        //    }
        //}

        ///// <summary>
        ///// 2.1.4 - Creates new library card
        ///// </summary>
        ///// <param name="human">Library card object</param>
        //[HttpPost]
        //public IActionResult CreateLibraryCard([FromBody] LibraryCardDto libraryCardDto)
        //{
        //    if (libraryCardDto == null)
        //    {
        //        return BadRequest("LibraryCardDTO object is null");
        //    }

        //    var human = _humanRepository.FindByCondition(o => o.Id == libraryCardDto.HumanId).FirstOrDefault();

        //    if (human == null)
        //    {
        //        return BadRequest("The person with the specified id does not exist.");
        //    }

        //    var libraryCardEntity = _mapper.Map<LibraryCard>(libraryCardDto);
        //    libraryCardEntity.HumanId = human.Id;
        //    libraryCardEntity.Human = human;
        //    libraryCardEntity.Date = libraryCardDto.Date; //2.1.5 - сохраняет в нужном виде
        //    libraryCardEntity.Id = _humanRepository.FindAll().Max(o => o.Id) + 1; //Guid.NewGuid();
        //    _cardLibraryRepository.Create(libraryCardEntity);

        //    return CreatedAtRoute("LibraryCardById", new { id = libraryCardEntity.Id }, libraryCardEntity);
        //}

        ///// <summary>
        ///// Get library card by id
        ///// </summary>
        //[HttpGet("{id}", Name = "LibraryCardById")]
        //public IActionResult GetLibraryCard(int id)
        //{
        //    var libraryCard = _cardLibraryRepository.FindByCondition(o => o.Id == id).FirstOrDefault();
        //    if (libraryCard == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(libraryCard);
        //    }
        //}
    }
}
