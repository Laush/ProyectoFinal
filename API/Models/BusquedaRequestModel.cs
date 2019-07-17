using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class BusquedaRequestModel
    {
        public string Destino { get; set; }
        public string Vuelo { get; set; }
        public long IdUsuario { get; set; }
    }
}