using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Contacts
{
    public record class CreateContactDto
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Name { get; init; }
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Surname { get; init; }
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(50, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Patronymic { get; init; }
        [Display(Name = "Номер телефона")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(20, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        [RegularExpression("([0-9])\\w+", ErrorMessage = "Поле «{0}» может состоять только из цифр")]

        public string PhoneNumber { get; init; }
    }
}
