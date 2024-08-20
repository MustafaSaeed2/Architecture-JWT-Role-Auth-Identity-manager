using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Respons
{
    public record GeneralRespons(bool flag, string message = null!);
    
}
