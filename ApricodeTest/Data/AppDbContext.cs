using ApricodeTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApricodeTest._Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Game> Games { get; set; }
    public DbSet<DeveloperStudio> DeveloperStudios { get; set; }
    public DbSet<Genre> Genres { get; set; }

}