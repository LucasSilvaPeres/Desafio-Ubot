using Microsoft.EntityFrameworkCore;
using MovieApi.DB.Entities;

namespace MovieApi.Infra.Context;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
    }
    public DbSet<Filme> Filmes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
