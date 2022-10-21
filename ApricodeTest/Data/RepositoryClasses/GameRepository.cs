using ApricodeTest._Data;
using ApricodeTest.Models;
using ApricodeTest.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest.Data.RepositoryClasses;

public class GameRepository:IGameRepository
{
    private readonly AppDbContext _dbContext;

    public GameRepository(AppDbContext dbContext)
    {
         _dbContext = dbContext;
    }

    public ICollection<Game> GetAllGames()=>_dbContext.Games.AsNoTracking()
        .Include(g => g.DeveloperStudio)
        .Include(g => g.GameGenres).ThenInclude(gg=>gg.Genre)
        .ToList();

    public List<Game> GetGamesByGenre(string genreName) => _dbContext.Games.Where(g => g.GameGenres.Any(gg => gg.Genre.GenreName == genreName)).ToList();

    public async Task<Game> AddNewGame(GameViewModel gameViewModel)
    {
        var game = new Game();
        {
            game.GameName = gameViewModel.GameName;
            game.DeveloperStudio = new DeveloperStudio();
            game.DeveloperStudio.DeveloperStudioName = gameViewModel.DeveloperStudioName;
            game.GameGenres = new List<GameGenre>();
            foreach (var gameGenre in game.GameGenres)
            {
                foreach (var genre in gameViewModel.Genres)
                {
                    gameGenre.Genre.GenreName = genre;
                }
            }
        }
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
        return game;
    }

    public  bool DeleteGame(int id)
    {
        bool result = false;
        var game = _dbContext.Games.FirstOrDefault(g => g.Id == id);
        if (game != null)
        {
            _dbContext.Remove(game);
            _dbContext.SaveChanges();
            result = true;
        } 
        else 
        {
            result = false;
        }
        return result;
    }

    public async Task<Game> UpdateGame(GameViewModel gameViewModel)
    {
        var game = new Game();
        {
            game.Id = gameViewModel.Id;
            game.GameName = gameViewModel.GameName;
            game.DeveloperStudio = new DeveloperStudio();
            game.DeveloperStudio.DeveloperStudioName = gameViewModel.DeveloperStudioName;
            game.GameGenres = new List<GameGenre>();
            foreach (var gameGenre in game.GameGenres)
            {
                foreach (var genre in gameViewModel.Genres)
                {
                    gameGenre.Genre.GenreName = genre;
                }
            }
        }
        _dbContext.Entry(game).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return game;
    }
}