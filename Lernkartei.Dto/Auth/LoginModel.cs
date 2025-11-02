using System.ComponentModel.DataAnnotations;

namespace Lernkartei.Dto.Auth
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool? RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
