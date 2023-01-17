using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Store.Application.Models.Filters
{
    public class FilterPagingDto
    {
        [Display(Name = "Номер страницы")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 100, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public int PageNumber { get; set; }
        [Display(Name = "Размер страницы")]
        [Required(ErrorMessage = "Поле «{0}» не заполнено")]
        [Range(0, 100, ErrorMessage = "Значение для {0} должно быть между {1} ​​и {2}.")]
        public int PageSize { get; set; }
    }
}
