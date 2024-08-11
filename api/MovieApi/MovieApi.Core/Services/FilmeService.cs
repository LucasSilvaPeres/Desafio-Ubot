using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using MovieApi.Core.ViewModel.Filme;
using MovieApi.DB;
using MovieApi.DB.Entities;
using MovieApi.Infra.Context;

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
        public async Task<Filme> GetFilme(Guid Id){
            return await _context.Filmes
                .FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<Filme> CreateFilme(CreateFilmeVM model)
        {
            var tempFilme = new Filme
            {
                Titulo = model.Titulo,
                Data_Lancamento = model.Data_Lancamento,
                Sinopse = model.Sinopse,
                Duracao = model.Duracao,
                Categorias = model.Categorias,
                Avaliado = false
            };
            _context.Filmes.Add(tempFilme);
            await _context.SaveChangesAsync();
            return tempFilme;
        }

        public async Task<Filme> UpdateFilme(UpdateFilmeVM model) 
        {
            var tempFilme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == model.Id);
            tempFilme.Titulo = model.Titulo;
            tempFilme.Data_Lancamento = model.Data_Lancamento;
            tempFilme.Sinopse = model.Sinopse;
            tempFilme.Duracao = model.Duracao;
            tempFilme.Categorias = model.Categorias;

            _context.Filmes.Update(tempFilme);
            await _context.SaveChangesAsync();
            return tempFilme;
        }

        public async Task DeleteFilme(Guid Id) 
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == Id);
            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
        }

        public async Task<Filme> AvaliarFilme(AvaliarFilmeVM model)
        {
            var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (model.Nota > 0 && model.Nota < 11)
            {
                filme.Nota = model.Nota;
            }
            if (model.Avaliacao != null)
            {
                filme.Avaliacao = model.Avaliacao;
            }
            filme.Avaliado = true;
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public List<Filme> SugestaoFilme()
        {
            Random rand = new Random();
            return _context.Filmes
                .Where(x => x.Avaliado == false)
                .AsEnumerable()
                .OrderBy(x => rand.Next())
                .Take(5)
                .ToList();
                
        }
        
    }
}