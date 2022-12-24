using System.ComponentModel.DataAnnotations;

namespace Store.WebAPI.Models.Identity
{
    public record class LoginUserRequestDto
    {
        [Required(ErrorMessage = "Поле «Login» не заполнено")]
        public string UserName { get; init; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле «Paasword» не заполнено")]
        public string Password { get; init; }
        public bool RemeberMe { get; init; }
    }
}
