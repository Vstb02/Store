using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Store.WebAPI.Models.Products
{
    public record class ProductImageDto
    {
        [Display(Name = "Название")]
        [MaxLength(300, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string? Name { get; init; }
        [Display(Name = "Путь к изображению")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(255, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string ImageUri { get; init; }
    }
}
