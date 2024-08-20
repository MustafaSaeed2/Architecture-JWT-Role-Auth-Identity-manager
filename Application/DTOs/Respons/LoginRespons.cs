using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Respons
{
   public record LoginRespons(bool flag= false,string message= null!,string token =null!,string Refreshtoken =null!);
   
}
