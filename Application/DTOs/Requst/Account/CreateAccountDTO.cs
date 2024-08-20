using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Requst.Account
{
    public class CreateAccountDTO:LoginDTO
    {
        [Required]
        public string Name { get; set; }=string.Empty;
        [Required, Compare(nameof(Password))]
        public string confirmPassword { get; set; }= string . Empty;
        public string Role { get; set; }    = string . Empty;       
    }
}
