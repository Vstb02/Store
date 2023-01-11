using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Products
{
    public record class CreateProductDto
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(200, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Name { get; init; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(2000, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Description { get; init; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле {0}» не заполнено")]
        [Range(10, 1000000, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public decimal Price { get; init; }

        [Display(Name = "Главное изображение")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(200, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string MainImageUri { get; init; }

        public IEnumerable<ProductImageDto> ProductImages { get; init; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 10000, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public int Quantity { get; init; }

        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 1, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public ProductStatus Status { get; init; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        public Guid CategoryId { get; init; }

        [Display(Name = "Компания")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        public Guid BrandId { get; set; }

        public CreateProductDto()
        {
            ProductImages = new List<ProductImageDto>();
        }
    }
}
