using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevAssign.Model
{
    public class LoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [DisplayName("Password"), Required, DataType(DataType.Password), MinLength(5, ErrorMessage = "Too short.")]
        public string Password { get; set; }
    }
}