using System.ComponentModel.DataAnnotations;

namespace Web.Models.RegisterViewModel
{
    public class RegisterViewModel
    {

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Usernameis required")]
        public string Username { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

    }
}
