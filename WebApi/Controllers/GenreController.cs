﻿using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        ///// <summary>
        ///// 2.7.4.1 - Просмотр всех жанров
        ///// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var books = await _genreService.GetAllAsync();

            return Ok(books);
        }

        ///// <summary>
        ///// 2.7.4.2 - Добавление нового жанра
        ///// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateGenre(GenrePresentationDto genreDto, CancellationToken cancellationToken)
        {
            var books = await _genreService.CreateAsync(genreDto);

            return Ok(books);
        }

        ///// <summary>
        ///// 2.7.4.3 - Вывод статистики Жанр - количество книг
        ///// </summary>
        [HttpGet("statistic")]
        public async Task<IActionResult> GetGenreStatistic()
        {
            var statistics = await _genreService.GetGenresStatistic();

            return Ok(statistics);
        }
    }
}
