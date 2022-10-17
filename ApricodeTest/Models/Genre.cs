using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApricodeTest.Models;

public class Genre
{
    [Key]
    public int GenreId { get; set; }
    [DisplayName("Жанр игры")]
    public string GenreName { get; set; }
}