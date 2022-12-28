using Store.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.WebAPI.Models.Categories
{
    public record class CreateCategoryDto
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(200, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Name { get; init; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(500, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Description { get; init; }
    }
}
