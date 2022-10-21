using ApricodeTest.Models;
using ApricodeTest.Models.ViewModels;

namespace ApricodeTest._Data;

public interface IGameRepository
{
    ICollection<Game> GetAllGames();
    List<Game> GetGamesByGenre(string genreName);
    Task<Game> AddNewGame(GameViewModel gameViewModel);
    bool DeleteGame(int id);
    Task<Game> UpdateGame(GameViewModel gameViewModel);
}