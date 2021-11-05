using BookLibrary.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    /// <summary>
    /// 1.3 - Humans controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IHumanRepository _humanRepository;
        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }

        [HttpGet]
        public IActionResult GetAllAnimals()
        {
            var items = _humanRepository.FindAll();

            if (items == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(items);
            }
        }
    }
}
