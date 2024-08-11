using System.ComponentModel.DataAnnotations;

namespace MovieApi.Core.ViewModel.Filme
{
    public class UpdateFilmeVM : CreateFilmeVM
    {
        [Display(Name = "Id do filme")]
        public Guid Id { get; set; }
    }
}