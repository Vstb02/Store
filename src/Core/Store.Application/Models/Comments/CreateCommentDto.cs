using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Comments
{
    public record class CreateCommentDto
    {
        [Display(Name = "Содержание")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [MaxLength(500, ErrorMessage = "Поле «{0}» превысило максимально допустимое значение в «{1}» символов")]
        public string Content { get; init; }
    }
}
