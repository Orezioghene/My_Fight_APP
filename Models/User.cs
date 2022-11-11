using Microsoft.AspNetCore.Identity;

namespace My_Fight_APP.Models
{
    public class User:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        public string Password { get; set; }
    }
}
