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

            //devuelvo la lista con los datos de busqueda
            if (TempData["ResultadoBusqueda"] != null)
            {
                var viajes = TempData["ResultadoBusqueda"];

                return View(viajes);
            }
            //devuelvo una lista vacia si no ingresa a la condicion
            return View(ds);
        }
    }
}