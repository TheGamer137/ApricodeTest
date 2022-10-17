using ApricodeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest._Data;

public class GameRepository:IGameRepository
{
    private readonly AppDbContext _dbContext;

    public GameRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        if (!_dbContext.Games.Any())
        {
            _dbContext.Add(new Game() { GameName = "The Withcer 3", Genre = new HashSet<Genre>() { new Genre() { GenreName = "RPG" }, new Genre() { GenreName = "Action" } }, DeveloperStudio = new DeveloperStudio() {DeveloperStudioName = "CD Projekt RED"}});
            _dbContext.Add(new Game() { GameName = "Guild Wars 2", Genre = new HashSet<Genre>() { new Genre() { GenreName = "MMORPG" } }, DeveloperStudio = new DeveloperStudio() {DeveloperStudioName = "ArenaNet"}});
            _dbContext.Add(new Game() { GameName = "Skyrim", Genre = new HashSet<Genre>() { new Genre() { GenreName = "RPG" }, new Genre() { GenreName = "Fantasy" } }, DeveloperStudio = new DeveloperStudio() {DeveloperStudioName = "Bethesda Game Studios"}});
            _dbContext.Add(new Game() { GameName = "Pathfinder: Wrath of the Righteous", Genre = new HashSet<Genre>() { new Genre() { GenreName = "Strategy" }, new Genre() { GenreName = "Isometric RPG" } }, DeveloperStudio = new DeveloperStudio() {DeveloperStudioName = "Owlcat Games"}});
            _dbContext.SaveChanges();
        }
    }
    public IEnumerable<Game> GetAllGames()=>_dbContext.Games.ToList();

    public List<Game> GetGamesByGenre(int id) => _dbContext.Games.Where(g => g.Genre.Any(gg => gg.GenreId == id)).ToList();

    public async Task<Game> AddNewGame(Game game)
    {
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
        return game;
    }

    public bool DeleteGame(int id)
    {
        bool result = false;
        var department = _dbContext.Games.Find(id);
        if (department != null) {
            _dbContext.Entry(department).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            result = true;
        } else {
            result = false;
        }
        return result;
    }

    public async Task<Game> UpdateGame(Game game)
    {
        _dbContext.Entry(game).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return game;
    }
}