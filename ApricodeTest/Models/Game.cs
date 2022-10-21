using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApricodeTest.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Название игры")]
    public string GameName { get; set; }
    [Required]
    [DisplayName("Студия разработчик")]
    public DeveloperStudio DeveloperStudio { get; set; }
    [Required]
    [DisplayName("Жанры игры")]
    public ICollection<GameGenre> GameGenres { get; set; }
}