using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string contrasenia { get; set; }
    }
}