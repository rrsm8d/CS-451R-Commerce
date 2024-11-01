using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email")]
        public string? Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public string? Password { get; set; }
    }
}
