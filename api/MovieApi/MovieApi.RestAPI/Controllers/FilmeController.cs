using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieApi.Core.Services;
using MovieApi.Core.ViewModel.Filme;
using MovieApi.DB.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.RestAPI.Controllers;

[ApiController]
[Route ("api/[controller]")]
public class FilmeController : Controller
{
    private readonly FilmeService _filmeService;

    public FilmeController(FilmeService filmeService)
    {
        _filmeService = filmeService;
    }

    /// <summary>
    /// Retorna uma lista de filmes.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var filmes = await _filmeService.GetFilmes();
        return Ok(filmes);
    }

    /// <summary>
    /// Cria um novo filme.
    /// </summary>
    /// <param name="model">Os dados do novo filme.</param>
    [HttpPost]
    public async Task<IActionResult> Create(CreateFilmeVM model)
    {
        var createdFilme = await _filmeService.CreateFilme(model);
        return Ok(createdFilme);
    }

    /// <summary>
    /// Atualiza os dados de um filme.
    /// </summary>
    /// <param name="model">Os dados atualizados do filme.</param>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateFilmeVM model)
    {
        var updatedFilme = await _filmeService.UpdateFilme(model);
        return Ok(updatedFilme);
    }
    /// <summary>
    /// Avalia um filme.
    /// </summary>
    /// <param name="model">Os dados para atualizar a avaliação do filme.</param>
    [HttpPost("Avaliar")]
    public async Task<IActionResult> AvaliarFilme(AvaliarFilmeVM model)
    {
        var updatedFilme = await _filmeService.AvaliarFilme(model);
        return Ok(updatedFilme);
    }

    /// <summary>
    /// Exclui um filme.
    /// </summary>
    /// <param name="Id">O identificador do filme.</param>
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid Id)
    {
        await _filmeService.DeleteFilme(Id);
        return Ok();
    }

    /// <summary>
    /// Retorna uma lista de sugestões de filmes.
    /// </summary>
    [HttpGet("sugestao")]
    public IActionResult Sugestao()
    {
        var sugestao = _filmeService.SugestaoFilme();
        return Ok(sugestao);
    }
}
