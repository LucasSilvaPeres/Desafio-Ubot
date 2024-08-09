using Microsoft.EntityFrameworkCore;
using MovieApi.DB;
using MovieApi.DB.Entities;

namespace MovieApi.Core.Services
{
    public class FilmeService
    {
        private readonly MovieDbContext _context;

        public FilmeService(MovieDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Filme>> GetFilmes()
        {
            return await _context.Filmes.ToListAsync();
        }
        public async Task<Filme> CreateFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<Filme> UpdateFilme(Filme filme) 
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<Filme> DeleteFilme(Filme filme) 
        {
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public IQueryable<Filme> SugestaoFilme()
        {
            return _context.Filmes
                .Where(x => x.Avaliado == false)
                .OrderBy(x => Guid.NewGuid())
                .Take(5);
        }
        
    }
}