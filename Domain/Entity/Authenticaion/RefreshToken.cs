﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Authenticaion
{
     public class RefreshToken 
    {
        public int Id { get; set; }
        public string? UsreID { get; set; }
        public string? Token {  get; set; }  

    }
}
