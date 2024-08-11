using System.ComponentModel.DataAnnotations;

namespace MovieApi.Core.ViewModel.Filme
{
    public class CreateFilmeVM
    {
        [Display(Name = "Nome do filme")]
        public string Titulo { get; set; }

        [Display(Name = "Data de lancamento(ano-mes-dia)")]
        public DateOnly Data_Lancamento { get; set; }

        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Display(Name = "Duracao em minutos")]
        public int Duracao { get; set; }

        [Display(Name = "Categorias")]
        public string Categorias { get; set; }

    }
}