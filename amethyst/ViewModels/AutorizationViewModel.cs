using amethyst.Data.DataBase;
using System.ComponentModel.DataAnnotations;

namespace amethyst.ViewModels
{
    public class AutorizationViewModel
    {
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string login { get; set; }
        [Required(ErrorMessage = "Данные не может быть пустым")]
        public string password { get; set; }
    }
}
