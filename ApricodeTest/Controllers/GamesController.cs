using ApricodeTest._Data;
using ApricodeTest.Models;
using ApricodeTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllGames()
    {
        return Ok(_gameRepository.GetAllGames());
    }

    [HttpPost]
    public async Task<IActionResult> AddNewGame(GameViewModel gameViewModel)
    {
        if(ModelState.IsValid)
        {
            await _gameRepository.AddNewGame(gameViewModel);
        }
        else
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Что-то пошло не так");
        }
        return Ok("Игра добавилась успешно!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGame(GameViewModel gameViewModel)
    {
        if (ModelState.IsValid)
        {
            await _gameRepository.UpdateGame(gameViewModel);
        }
        return Ok("Игра обновлена");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        _gameRepository.DeleteGame(id);
        return new JsonResult("Игра успешно удалена");
    }

    [HttpGet("{genre}")]
    public IActionResult GetGameByGenre(string genre)
    {
        return Ok(_gameRepository.GetGamesByGenre(genre));
    }
}