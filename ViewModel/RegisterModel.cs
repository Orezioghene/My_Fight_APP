using System.ComponentModel.DataAnnotations;

namespace My_Fight_APP.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

    }
}
