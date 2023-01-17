using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Addresses
{
    public record class CreateAddressDto
    {
        [Display(Name = "Страна")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Country { get; init; }
        [Display(Name = "Область/регион")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Region { get; init; }
        [Display(Name = "Город")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string City { get; init; }
        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(100, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Place { get; init; }
        [Display(Name = "Почтовый индекс")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(6, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Index { get; init; }
    }
}
