using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApricodeTest.Models;

public class DeveloperStudio
{
    [Key]
    public int DeveloperId { get; set; }
    [Required]
    [DisplayName("Студия разработчик")]
    public string DeveloperStudioName { get; set; }
}