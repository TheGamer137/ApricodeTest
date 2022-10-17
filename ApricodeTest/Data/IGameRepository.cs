using ApricodeTest.Models;

namespace ApricodeTest._Data;

public interface IGameRepository
{
    IEnumerable<Game> GetAllGames();
    List<Game> GetGamesByGenre(int id);
    Task<Game> AddNewGame(Game game);
    bool DeleteGame(int id);
    Task<Game> UpdateGame(Game game);
}