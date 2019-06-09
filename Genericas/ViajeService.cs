using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    class ViajeService
    {
        private Context Context = new Context();

        public bool registrarViaje(Viaje ViajeNuevo)
        {
            try
            {
                Context.Viaje.Add(ViajeNuevo);
                Context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
