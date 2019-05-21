using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {   
        //Landing Page
        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Registracion()
        {
            return View();
        }
        public ActionResult RegistroGuia()
        {
            return View();
        }
        public ActionResult RegistroEntidad()
        {
            return View();
        }
        public ActionResult RegistroViajero()
        {
            return View();
        }
        public ActionResult BusquedaPorDestino()
        {
            return View();
        }
        public ActionResult BusquedaPorVuelo()
        {
            return View();
        }
    }
}