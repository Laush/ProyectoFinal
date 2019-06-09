using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class ViajeRequestModel
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Aerolinea { get; set; }
        public string NumeroVuelo { get; set; }
        public string Alojamiento { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public bool InteresActividades { get; set; }
        public bool InteresExcursiones { get; set; }
        public bool InteresTraslados { get; set; }
        public bool InteresAmistades { get; set; }
        public bool InteresAlojamiento { get; set; }
        public bool InteresOtros { get; set; }
    }
}
