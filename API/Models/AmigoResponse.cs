using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class AmigoResponse
    {
        public long IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> Edad { get; set; }
        public string Email { get; set; }
        public string MatriculaGuia { get; set; }
        public string Descripcion { get; set; }
        public string Nacionalidad { get; set; }
        public string UrlFotoPerfil { get; set; }
        public Nullable<long> Calificacion { get; set; }
    }
}