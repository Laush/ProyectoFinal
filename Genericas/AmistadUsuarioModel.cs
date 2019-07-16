using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class AmistadUsuarioModel
    {
        public string Result { get; set; }
        public long IdResponsable { get; set; }
        public long IdSeguido { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCoincidencia { get; set; }
    }
}
