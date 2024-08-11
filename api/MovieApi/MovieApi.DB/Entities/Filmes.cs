namespace MovieApi.DB.Entities;

public class Filme
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public DateOnly Data_Lancamento { get; set; }
    public string Sinopse { get; set; }
    public int Duracao { get; set; }
    public string Categorias { get; set; }
    public bool Avaliado { get; set; } = false;
    public string? Avaliacao { get; set; }
    public int? Nota { get; set; }

}
