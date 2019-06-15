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
        private DestinoService DestinoService = new DestinoService();

        public bool registrarViaje(ViajeModel RequestModel, long IdUsuario)
        {

            Viaje NuevoViaje = new Viaje();

            NuevoViaje.IdUsuario = IdUsuario;
            NuevoViaje.Aerolinea = RequestModel.Aerolinea;
            NuevoViaje.NumeroVuelo = RequestModel.NumeroVuelo;
            NuevoViaje.Alojamiento = RequestModel.Alojamiento;
            NuevoViaje.FechaDesde = RequestModel.FechaDesde;
            NuevoViaje.FechaHasta = RequestModel.FechaHasta;

            NuevoViaje.InteresActividades = RequestModel.InteresActividades;
            NuevoViaje.InteresAlojamiento = RequestModel.InteresAlojamiento;
            NuevoViaje.InteresAmistades = RequestModel.InteresAmistades;
            NuevoViaje.InteresExcursiones = RequestModel.InteresExcursiones;
            NuevoViaje.InteresOtros = RequestModel.InteresOtros;
            NuevoViaje.InteresTraslados = RequestModel.InteresTraslados;

            Ciudad CiudadOrigen = DestinoService.BuscarCiudad(RequestModel.Origen);
            Ciudad CiudadDestino = DestinoService.BuscarCiudad(RequestModel.Destino);

            NuevoViaje.IdOrigen = CiudadOrigen.IdCiudad;
            NuevoViaje.IdDestino = CiudadDestino.IdCiudad;

            try
            {
                Context.Viaje.Add(NuevoViaje);
                Context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExisteViaje(long Id)
        {
            return (Context.Viaje.Find(Id) != null) ? true : false;
        }

        public bool ModificarViaje(ViajeModel RequestModel)
        {
            Viaje Viaje = Context.Viaje.Find(RequestModel.IdViaje);

            try
            {
                Viaje.IdViaje = RequestModel.IdViaje;
                Viaje.FechaDesde = RequestModel.FechaDesde;
                Viaje.FechaHasta = RequestModel.FechaHasta;
                Viaje.Aerolinea = RequestModel.Aerolinea;
                Viaje.NumeroVuelo = RequestModel.NumeroVuelo;
                Viaje.Alojamiento = RequestModel.Alojamiento;
                Viaje.InteresActividades = RequestModel.InteresActividades;
                Viaje.InteresAlojamiento = RequestModel.InteresAlojamiento;
                Viaje.InteresAmistades = RequestModel.InteresAmistades;
                Viaje.InteresExcursiones = RequestModel.InteresExcursiones;
                Viaje.InteresOtros = RequestModel.InteresOtros;
                Viaje.InteresTraslados = RequestModel.InteresTraslados;

                Ciudad CiudadOrigen = DestinoService.BuscarCiudad(RequestModel.Origen);
                Ciudad CiudadDestino = DestinoService.BuscarCiudad(RequestModel.Destino);

                Viaje.IdOrigen = CiudadOrigen.IdCiudad;
                Viaje.IdDestino = CiudadDestino.IdCiudad;

                Context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public bool EliminarViaje(long IdViaje, long IdUsuario)
        {
            try
            {
                Viaje Viaje = Context.Viaje.Find(IdViaje);

                if (Viaje == null || Viaje.IdUsuario != IdUsuario)
                    throw new Exception();
                else
                {
                    Context.Viaje.Remove(Viaje);
                    Context.SaveChanges();

                    return true;
                }
                
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private ViajeModel TransformarDatos(Viaje Viaje)
        {
            ViajeModel Model = new ViajeModel();

            Model.IdViaje = Viaje.IdViaje;
            Model.FechaDesde = Viaje.FechaDesde;
            Model.FechaHasta = Viaje.FechaHasta;
            Model.Aerolinea = Viaje.Aerolinea;
            Model.NumeroVuelo = Viaje.NumeroVuelo;
            Model.Alojamiento = Viaje.Alojamiento;

            Model.Origen = DestinoService.BuscarCiudad(Viaje.IdOrigen).Nombre;
            Model.Destino = DestinoService.BuscarCiudad(Viaje.IdDestino).Nombre;

            Model.InteresActividades = Viaje.InteresActividades;
            Model.InteresAlojamiento = Viaje.InteresAlojamiento;
            Model.InteresAmistades = Viaje.InteresAmistades;
            Model.InteresExcursiones = Viaje.InteresExcursiones;
            Model.InteresOtros = Viaje.InteresOtros;
            Model.InteresTraslados = Viaje.InteresTraslados;

            return Model;
        }

        public List<ViajeModel> Listar(long IdUsuario)
        {
            List<Viaje> Viajes = Context.Viaje.Where(v => v.IdUsuario == IdUsuario).ToList();
            List<ViajeModel> ViajesTransformados = new List<ViajeModel>();

            foreach(Viaje Viaje in Viajes)
            {
                ViajesTransformados.Add(TransformarDatos(Viaje));
            }

            return ViajesTransformados;
        }
        
        public ViajeModel Buscar(long IdViaje)
        {
            Viaje Viaje = Context.Viaje.Find(IdViaje);

            return (Viaje == null)? null : TransformarDatos(Viaje);
        }
    }
}
