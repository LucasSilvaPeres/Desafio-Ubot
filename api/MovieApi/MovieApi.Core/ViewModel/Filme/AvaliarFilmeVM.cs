using System.ComponentModel.DataAnnotations;

namespace MovieApi.Core.ViewModel.Filme
{
    public class AvaliarFilmeVM
    {

        [Display(Name = "Id do filme")]
        public Guid Id { get; set; }

        [Display(Name = "Avaliação")]
        public string Avaliacao { get; set; }

        [Display(Name = "Nota de 1 a 10")]
        public int Nota { get; set; }

    }
}