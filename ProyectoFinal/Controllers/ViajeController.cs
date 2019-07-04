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

            TempData["ResultadoBusqueda"] = srvViaje.BuscarDestino(buscarDestino);

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

            TempData["ResultadoBusqueda"] = srvViaje.BuscarVuelo(buscarVuelo);

            return RedirectToAction("ResultadoBusqueda");
        }

        // GET: Resultado Busqueda por Vuelo
        [HttpGet]
        public ActionResult ResultadoBusqueda()
        {
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
                 Viaje v = new Viaje();
                 return View(v);
                 }

            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult AgregarViaje(Viaje v)
        {

            var usuarioLogueado = Session["Usuario"] as Usuario;
            srvViaje.AgregarViaje(v, usuarioLogueado);

            return RedirectToAction("IndexViajero", "Usuario", v);
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

    }
}