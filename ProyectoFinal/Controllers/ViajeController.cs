using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Genericas;

namespace ProyectoFinal.Controllers
{
    public class ViajeController : Controller
    {
        //Servicios
        private ViajeService srvViaje = new ViajeService();
        private AmistadService srvAmistad = new AmistadService();
        private UsuarioService srvUsuario = new UsuarioService();
        private EmailService srvEmail = new EmailService();
        
        //GET: Busqueda Destino
        [HttpGet]
        public ActionResult BusquedaDestino()
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            ViewBag.ListaCiudades = srvViaje.ObtenerCiudades();
            if (Session["Usuario"] == null && TempData["ResultadoBusqueda"] != null)
            {
                int.TryParse(TempData["ResultadoBusqueda"].ToString(), out int num);

                ViewBag.ResultadoCantidad = srvViaje.CargarResultadoSinLogin(num, "Destino");                             
            }

            return View();
        }

        //POST: Busqueda Destino
        [HttpPost]
        public ActionResult BusquedaDestino(params string[] buscarDestino)
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;

            if (Session["Usuario"] == null)
            {
                TempData["ResultadoBusqueda"] = srvViaje.BuscarDestino(buscarDestino).Count();
                return RedirectToAction("BusquedaDestino", "Viaje");
            }

            var UsuarioResponsable = Session["Usuario"] as Usuario;

            TempData["ResultadoBusqueda"] = srvViaje.BuscarDestino(buscarDestino, UsuarioResponsable.IdUsuario);

            return RedirectToAction("ResultadoBusqueda");
        }

        //GET: Busqueda Vuelo
        [HttpGet]
        public ActionResult BusquedaVuelo()
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            if (Session["Usuario"] == null && TempData["ResultadoBusqueda"] != null)
            {
                int.TryParse(TempData["ResultadoBusqueda"].ToString(), out int num);

                ViewBag.ResultadoCantidad = srvViaje.CargarResultadoSinLogin(num, "Vuelo");
            }

            return View();
        }

        //POST: Busqueda Vuelo
        [HttpPost]
        public ActionResult BusquedaVuelo(params string[] buscarVuelo)
        {
            if (Session["Usuario"] == null)
            {
                TempData["ResultadoBusqueda"] = srvViaje.BuscarVuelo(buscarVuelo).Count();
                return RedirectToAction("BusquedaVuelo", "Viaje");
            }

            var UsuarioResponsable = Session["Usuario"] as Usuario;

            TempData["ResultadoBusqueda"] = srvViaje.BuscarVuelo(buscarVuelo, UsuarioResponsable.IdUsuario);

            return RedirectToAction("ResultadoBusqueda");
        }

        // GET: Resultado Busqueda por Vuelo
        [HttpGet]
        public ActionResult ResultadoBusqueda()
        {
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            List<Viaje> ds = new List<Viaje>();
            ViewBag.Rol = Session["Usuario"] as Usuario;
            //devuelvo la lista con los datos de busqueda
            if (TempData["ResultadoBusqueda"] != null)
            {
                var viajes = TempData["ResultadoBusqueda"];

                return View(viajes);
            }
            //devuelvo una lista vacia si no ingresa a la condicion
            return View(ds);
        }

        // ABM viaje
        [HttpGet]
        public ActionResult AgregarViaje()
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            if (usuarioLogueado != null) {
                ViewBag.ListaPaises = srvViaje.ObtenerPaises();
                ViewBag.ListaCiudades = srvViaje.ObtenerCiudades();

                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult AgregarViaje(Viaje v)
        {
            var UsuarioResponsable = Session["Usuario"] as Usuario;

            srvViaje.AgregarViaje(v, UsuarioResponsable);

            var NumeroDeVuelo = v.NumeroVuelo;

            if (srvViaje.ExisteNumeroVuelo(NumeroDeVuelo))
            {
                // Busco los viajeros que tengan el mismo numero de vuelo, sacando al responsable y envio email
                List<Usuario> UsuariosConMismoNumeroVuelo = srvUsuario.ObtenerUsuariosPorNumeroVuelo(NumeroDeVuelo, UsuarioResponsable.IdUsuario);

                foreach (var usuario in UsuariosConMismoNumeroVuelo)
                {
                    // parametros para el mail
                    string asunto = UsuarioResponsable.NombreUsuario + " registro un Viaje con el mismo Numero de Vuelo.";
                    string cuerpoMensaje = "Hola " + usuario.NombreUsuario + ", " + asunto + " invitalo a conectarte. Entra en la aplicación, coincidi y conectate para disfrutar o compartir actividades.";

                    srvEmail.enviarMensaje(usuario.Email, usuario.Nombre + " " + usuario.Apellido, asunto, cuerpoMensaje);
                }
            }

            return RedirectToAction("IndexViajero", "Usuario");
        }

        public ActionResult Eliminar(long id)
        {
            var sj = new ViajeService();
            sj.Eliminar(id);
            return RedirectToAction("IndexViajero", "Usuario");

        }
       
        public ActionResult EditarViaje(int id)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            Viaje viaje = srvViaje.ObtenerPorId(id);
            return View(viaje);
        }

        [HttpPost]
        public ActionResult EditarViaje(Viaje viaje)
        {
            if (ModelState.IsValid)
            {
                srvViaje.EditarViaje(viaje);
                return RedirectToAction("IndexViajero", "Usuario");
            }
            else
            {
                return View(viaje);
            }
        }

        /// <summary>
        /// Recibe un parametro de tipo string que utiliza para ir autompletando en base a lo que haya encontrado
        /// en la tabla Ciudad, por ahora funciona en esa tabla, falta agregarle las tablas Provincia y Pais
        /// </summary>
        /// <param name="search"></param>
        /// <returns> Resultados del tipo Json </returns>
        public JsonResult AutocompleteCiudades(string search)
        {
            List<CiudadModel> result = srvViaje.CiudadCompleto()
                                        .Where(x => x.Nombre.ToLower().Contains(search.ToLower()))
                                        .Select(x => new CiudadModel
                                        {
                                            IdCiudad = x.IdCiudad,
                                            Nombre = x.Nombre
                                        }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///  Mediante Ajax y JsonResult cambio el estado de la tabla AmistadUsuario mediante la accion del viajero
        ///  de Invitar
        /// </summary>
        /// <param name="idSeguido"></param>
        /// <returns> Retorna un AmistadUsuarioModel con un mensaje para funcionamiento ok, error o viajero no encontrado </returns>
        public JsonResult InvitarViajero(long idSeguido)
        {
            var UsuarioResponsable = Session["Usuario"] as Usuario;
            Usuario UsuarioInvitado = srvUsuario.GetById(idSeguido);

            var invitacionViajero = srvAmistad.BuscarAmistad(UsuarioResponsable.IdUsuario, idSeguido);

            // parametros para el mail
            string asunto = UsuarioResponsable.NombreUsuario + " te ha enviado una invitación";
            string cuerpoMensaje = "Hola " + UsuarioInvitado.NombreUsuario + ", " + asunto + " para conectar. Puedes aceptar la misma entrando en la aplicación.";

            AmistadUsuarioModel amistadUsuarioModel = new AmistadUsuarioModel
            {
                IdResponsable = UsuarioResponsable.IdUsuario,
                IdSeguido = idSeguido,
                FechaCoincidencia = DateTime.Now,
                Estado = "PENDIENTE",
                Result = "OK"
            };

            if (srvUsuario.GetById(idSeguido) == null)
                amistadUsuarioModel.Result = "Viajero invitado no encontrado. Vuelve a intentarlo.";

            if (srvAmistad.SeguirUsuario(UsuarioResponsable.IdUsuario, idSeguido) == true)
            {
                amistadUsuarioModel.Result = "Viajero invitado correctamente. Tu proximo compañero de viaje esta muy cerca.";
                // Notifico al viajero invitado que tiene una invitacion a conectar
                srvEmail.enviarMensaje(UsuarioInvitado.Email, UsuarioInvitado.NombreUsuario, asunto, cuerpoMensaje);
            }
            else
            {
                amistadUsuarioModel.Result = "Ya invitaste al Viajero o hubo un error.";
            }

            return Json(amistadUsuarioModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CancelarInvitarViajero(long idSeguido)
        {
            var UsuarioInvitado = Session["Usuario"] as Usuario;
            Usuario UsuarioResponsable = srvUsuario.GetById(idSeguido);

            var result = "";

            if (UsuarioInvitado == null)
            {
                result = "Viajero invitado no encontrado";
            }

            else
            {
                srvAmistad.actualizarInvitacion(UsuarioResponsable.IdUsuario, UsuarioInvitado.IdUsuario, 'N');
                result = "Cancelaste la invitacion a conectarse con el Viajero " + UsuarioResponsable.Nombre + " " + UsuarioResponsable.Apellido;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AceptarInvitarViajero(long idSeguido)
        {
            var UsuarioInvitado = Session["Usuario"] as Usuario;
            Usuario UsuarioResponsable = srvUsuario.GetById(idSeguido);

            // parametros para el mail
            string asunto = UsuarioInvitado.NombreUsuario 
                            + " ha aceptado tu invitación";
            string cuerpoMensaje =  "Hola " 
                                    + UsuarioResponsable.NombreUsuario 
                                    + ", te informamos que el usuario " 
                                    + asunto 
                                    + " para conectar. Puedes ver su perfil para poder ponerte en contacto con el.";

            var result = "";

            if (UsuarioInvitado == null)
            {
                result = "Viajero no encontrado.";
            }

            else
            {
                // Acepto la invitacion del viajero responsable
                srvAmistad.actualizarInvitacion(UsuarioResponsable.IdUsuario, UsuarioInvitado.IdUsuario, 'Y');
                result = "Aceptaste la invitacion a conectarse con el Viajero "
                        + UsuarioResponsable.Nombre 
                        + " " 
                        + UsuarioResponsable.Apellido
                        + ". Ahora puedes Conectarte con el Visita su Perfil en tu lista de Amigos.";

                // Notifico al viajero responsable que su invitacion fue aceptada
                srvEmail.enviarMensaje(UsuarioResponsable.Email, UsuarioResponsable.NombreUsuario, asunto, cuerpoMensaje);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteDestinoCompleto(string search)
        {
            List<CiudadModel> destinos = srvViaje.CiudadProvinciaPaisCompleto()
                                        .Where(x => x.Nombre.ToLower().Contains(search.ToLower()))
                                        .Select(x => new CiudadModel
                                        {
                                            IdCiudad = x.IdCiudad,
                                            Nombre = x.Nombre
                                        }).ToList();

            return Json(destinos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutocompleteVuelos(string search)
        {
            List<VueloModel> vuelos = srvViaje.VuelosAerolineasCompleto()
                                        .Where(x => x.Nombre.ToLower().Contains(search.ToLower()))
                                        .Select(x => new VueloModel
                                        {
                                            IdVuelo = x.IdVuelo,
                                            Nombre = x.Nombre
                                        }).ToList();

            return Json(vuelos, JsonRequestBehavior.AllowGet);
        }
    }
}