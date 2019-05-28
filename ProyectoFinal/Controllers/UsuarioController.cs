using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult IndexViajero()
        {
            //List<Usuario> usus = new List<Usuario>();
            //usus = srvUsuario.Listar();
            // return View(usus);
            return View();
        }
        public ActionResult IndexAgencia()
        {
            return View();
        }
    }
}