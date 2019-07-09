using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class InvitacionResponse
    {
        public long IdResponsable { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaCoincidencia { get; set; }
        public string NombreUsuario { get; set; }
        public string MatriculaGuia { get; set; }
        public string Descripcion { get; set; }
        public string UrlFotoPerfil { get; set; }
    }
}