using System.ComponentModel.DataAnnotations;

namespace AuthBasic.Models
{
    public class UserLogInModel{

        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}