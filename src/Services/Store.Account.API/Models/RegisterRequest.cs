using Nest;
using System.ComponentModel.DataAnnotations;

namespace Store.Account.API.Models
{
    public class RegisterRequest
    {
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string UserName { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        [MinLength(5, ErrorMessage = "Поле «{0}» должно содержать не менее «{1}» символов")]
        public string Password { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Surname { get; set; }
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Email { get; set; }
    }
}
