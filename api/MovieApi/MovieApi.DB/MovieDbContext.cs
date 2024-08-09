using Microsoft.EntityFrameworkCore;
using MovieApi.DB.Entities;

namespace MovieApi.DB;

public class MovieDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
}
