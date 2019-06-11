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
            TempData["ResultadoBusquedaDestino"] = srvViaje.BuscarDestino(buscarDestino);

            return RedirectToAction("ResultadoBusquedaPorDestino");
        }

        // GET: Resultado Busqueda por Destino
        [HttpGet]
        public ActionResult ResultadoBusquedaPorDestino()
        {
            List<Viaje> ds = new List<Viaje>();

            //devuelvo la lista con los datos de busqueda
            if (TempData["ResultadoBusquedaDestino"] != null)
            {
                var destinos = TempData["ResultadoBusquedaDestino"];

                return View(destinos);
            }
            //devuelvo una lista vacia si no ingresa a la condicion
            return View(ds);
        }
    }
}