using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevAssign.Model
{
    public class UserModel : DevAssign.Data.Model.User
    {
        [Required, EmailAddress, StringLength(150)]
        [System.Web.Mvc.Remote("CheckExistingEmail", "Common", HttpMethod ="POST", ErrorMessage = "Email already exists")]
        public new string Email { get; set; }

    }
}