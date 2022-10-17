using ApricodeTest._Data;
using ApricodeTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGameRepository _gameRepository;

    public GamesController(IGameRepository gameRepository)=>_gameRepository = gameRepository;
    
    [HttpGet]
    public IActionResult GetAllGames()
    {
        return Ok(_gameRepository.GetAllGames());
    }

    [HttpPost]
    public async Task<IActionResult> AddNewGame(Game game)
    {
        var result = await _gameRepository.AddNewGame(game);
        if (result.Id == 0) {
            return StatusCode(StatusCodes.Status500InternalServerError, "Что-то пошло не так");
        }
        return Ok("Игра добавилась успешно!");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGame(Game game)
    {
        await _gameRepository.UpdateGame(game);
        return Ok("Игра обновлена");
    }

    [HttpDelete]
    public JsonResult Delete(int id)
    {
        _gameRepository.DeleteGame(id);
        return new JsonResult("Игра успешно удалена");
    }

    [HttpGet("{genre}")]
    public IActionResult GetGameByGenre(int id)
    {
        return Ok(_gameRepository.GetGamesByGenre(id));
    }
}