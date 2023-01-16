using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Ratings
{
    public record class CreateRatingDto
    {
        [Display(Name = "Рейтинг")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 5, ErrorMessage = "Значение для «{0}»  должно быть между {1} ​​и {2}.")]
        public int Value { get; init; }
    }
}
