using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Brands
{
    public record class UpdateBrandDto
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(100, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Name { get; init; }
    }
}
