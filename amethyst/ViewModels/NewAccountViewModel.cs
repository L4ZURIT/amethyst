using System.ComponentModel.DataAnnotations;
namespace amethyst.ViewModels
{
    public class NewAccountViewModel
    {
        [Required(ErrorMessage = "Данные не может быть пустым")]
        public string UIE { get; set; }
        [Required(ErrorMessage = "Данные не может быть пустым")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Данные не может быть пустым")]
        public string Password { get; set; }
    }
}
