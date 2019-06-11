using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class ViajeService
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

        public List<Viaje> Listar()
        {
            return Context.Viaje.ToList();
        }

        public List<Viaje> BuscarDestino(params string[] keywords)
        {
            var predicate = PredicateBuilder.False<Viaje>();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(v =>
                                            v.Ciudad.Nombre.Contains(temp) ||
                                            v.Ciudad.Provincia.Nombre.Contains(temp) ||
                                            v.Ciudad.Provincia.Pais.Nombre.Contains(temp)
                                        );
            }

            return Context.Viaje.AsExpandable().Where(predicate).ToList();
        }
    }
}
