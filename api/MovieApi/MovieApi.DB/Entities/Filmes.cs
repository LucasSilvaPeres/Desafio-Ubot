namespace MovieApi.DB.Entities;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime DataLancamento { get; set; }
    public string Sinopse { get; set; }
    public int Duracao { get; set; }
    public List<string> Categorias { get; set; }
    public byte[] Poster { get; set; }
    public bool Avaliado { get; set; }
    public string Avaliacao { get; set; }
    public int Nota { get; set; }

}
