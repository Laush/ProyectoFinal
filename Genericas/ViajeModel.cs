using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    // Esta clase se usa para requests y responses del usuario
    public class ViajeModel
    {
        public long IdViaje { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public string Aerolinea { get; set; }
        public string NumeroVuelo { get; set; }
        public string Alojamiento { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public bool? InteresActividades { get; set; }
        public bool? InteresExcursiones { get; set; }
        public bool? InteresTraslados { get; set; }
        public bool? InteresAmistades { get; set; }
        public bool? InteresAlojamiento { get; set; }
        public bool? InteresOtros { get; set; }
    }
}
