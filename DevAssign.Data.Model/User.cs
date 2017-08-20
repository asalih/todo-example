using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevAssign.Data.Model
{
    public class User : EntityBase
    {
        [DisplayName("Full name"), Required]
        public string FullName { get; set; }
        [DisplayName("Email")]

        [Required, EmailAddress, Index(IsUnique =true), StringLength(150)]
        public string Email { get; set; }
        [DisplayName("Password"), Required, DataType(DataType.Password), MinLength(5, ErrorMessage="Too short.")]
        public string Password { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
