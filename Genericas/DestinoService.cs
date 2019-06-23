using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class DestinoService
    {
        private Context Context = new Context();

        public Ciudad BuscarCiudad(string nombreCiudad)
        {
            return Context.Ciudad.FirstOrDefault(c => c.Nombre == nombreCiudad);
        }

        public Ciudad BuscarCiudad(long IdCiudad)
        {
            return Context.Ciudad.FirstOrDefault(c => c.IdCiudad == IdCiudad);
        }

        public List<Pais> ListarPaises()
        {
            return Context.Pais.ToList();
        }
    }
}
