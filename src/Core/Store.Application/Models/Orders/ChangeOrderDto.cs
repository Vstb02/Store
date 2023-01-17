using Store.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Orders
{
    public record class ChangeOrderDto
    {
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 1, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public OrderStatus OrderStatus { get; init; } 
    }
}
