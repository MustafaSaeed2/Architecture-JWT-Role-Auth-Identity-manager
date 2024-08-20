using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requst.Account
{
     public class LoginDTO
    {
        [EmailAddress, Required]
        [RegularExpression("[^@ \\t\\n]+@[^@\\t\\r\\n]+\\.[^@ \\t\\r\\n]+",
            ErrorMessage = "your Email is not valid email such as   .. ")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }=string.Empty;
        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",
            ErrorMessage = "you password must be a mix of aphanunic and special chracters")]
        public string Password { get; set; }= string.Empty;     
    }
}
