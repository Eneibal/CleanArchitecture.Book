using Microsoft.EntityFrameworkCore;
using Server.Domain.Models.Entities;

namespace Server.Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Publisher> Publisher { get; set; }
    public DbSet<CountBooks> CountBooks { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
