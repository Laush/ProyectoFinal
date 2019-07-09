using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class BusquedaResponseModel
    {
        public string Destino { get; set; }
        public string Origen { get; set; }
        public string Aerolinea { get; set; }
        public string NumeroVuelo { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string Alojamiento { get; set; }
        public bool? InteresActividades { get; set; }
        public bool? InteresExcursiones { get; set; }
        public bool? InteresTraslados { get; set; }
        public bool? InteresAmistades { get; set; }
        public bool? InteresAlojamiento { get; set; }
        public bool? InteresOtros { get; set; }

        // datos de usuario
        public long IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string UrlFotoPerfil { get; set; }
    }
}