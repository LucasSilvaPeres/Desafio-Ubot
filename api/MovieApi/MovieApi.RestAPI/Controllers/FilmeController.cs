using Microsoft.AspNetCore.Mvc;
using MovieApi.Core.Services;
using MovieApi.DB.Entities;

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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var filmes = await _filmeService.GetFilmes();
        return Ok(filmes);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]Filme filme)
    {
        var createdFilme = await _filmeService.CreateFilme(filme);
        return Ok(createdFilme);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody]Filme filme)
    {
        var updatedFilme = await _filmeService.UpdateFilme(filme);
        return Ok(updatedFilme);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody]Filme filme)
    {
        var deletedFilme = await _filmeService.DeleteFilme(filme);
        return Ok(deletedFilme);
    }

    [HttpGet("sugestao")]
    public IActionResult Sugestao()
    {
        var sugestao = _filmeService.SugestaoFilme();
        return Ok(sugestao);
    }
}
