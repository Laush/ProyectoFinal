using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Genericas
{
    public class LoginRequestModel
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string contrasenia { get; set; }
    }
}
