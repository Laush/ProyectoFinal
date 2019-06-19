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
        private Context contexto = new Context();

        public bool registrarViaje(Viaje ViajeNuevo)
        {
            try
            {
                contexto.Viaje.Add(ViajeNuevo);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Viaje> Listar()
        {
            return contexto.Viaje.ToList();
        }

        //Metodo para buscar por destinos, devuelve una lista de viajes
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

            return contexto.Viaje.AsExpandable().Where(predicate).ToList();
        }

        //Metodo para buscar por vuelos, devuelve una lista de viajes
        public List<Viaje> BuscarVuelo(params string[] keywords)
        {
            var predicate = PredicateBuilder.False<Viaje>();

            foreach (string keyword in keywords)
            {
                string temp = keyword;
                predicate = predicate.Or(v =>
                                            v.NumeroVuelo.Contains(temp) ||
                                            v.Aerolinea.Contains(temp)
                                        );
            }

            return contexto.Viaje.AsExpandable().Where(predicate).ToList();
        }

        //Metodo para cargar el texto que muestro en la busqueda sin usuario logeado
        public string CargarResultadoSinLogin(int numero, string tipo)
        {
            string rtdo =   "Encontraste " + numero + " resultados en el " + tipo + " indicado. ¡Segui buscando y ";

            if (numero == 1)
            {
                rtdo = "Encontraste " + numero + " resultado en el " + tipo + " indicado. ¡Para conocerlo ";
            }

            if (numero > 1)
            {
                rtdo = "Se encontraron " + numero + " resultados en el " + tipo + " indicado. ¡Para conocerlos ";
            }

            return rtdo;
        }
    }
}
