using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Respons.Account
{
   public record userClaimsDTO
        (string Fullname=null!,string UserName= null!,string Email = null!,string Role = null!);
    
}
