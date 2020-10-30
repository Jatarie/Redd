
using System.ComponentModel.DataAnnotations;

namespace AuthBasic.Models
{
    public class UserRegistrationModel{

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "hey")]
        public string PasswordConfirmation { get; set; }
    }
}