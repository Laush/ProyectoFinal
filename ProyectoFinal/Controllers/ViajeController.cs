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
        //genero el contexto

        private ViajeService srvViaje = new ViajeService();

        // GET: Viaje
        public ActionResult Index()
        {
            return RedirectToAction("Home", "BusquedaPorDestino");
        }

        //GET: Busqueda Destino
        [HttpGet]
        public ActionResult BusquedaDestino()
        {
            return View();
        }

        //POST: Busqueda Destino
        [HttpPost]
        public ActionResult BusquedaDestino(params string[] buscarDestino)
        {
            TempData["ResultadoBusqueda"] = srvViaje.BuscarDestino(buscarDestino);

            return RedirectToAction("ResultadoBusqueda");
        }

        //GET: Busqueda Vuelo
        [HttpGet]
        public ActionResult BusquedaVuelo()
        {
            return View();
        }

        //POST: Busqueda Vuelo
        [HttpPost]
        public ActionResult BusquedaVuelo(params string[] buscarVuelo)
        {
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