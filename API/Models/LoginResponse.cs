using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class LoginResponse
    {
        public string Usuario { get; set; }
        public long IdUsuario { get; set; }
        public string Token { get; set; }
    }
}