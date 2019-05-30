using ProyectoFinal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServicio srvUsuario = new UsuarioServicio();
        // GET: Usuario
        public ActionResult IndexAdmin()
        {
            //listas
            List<Usuario> usus = new List<Usuario>();
            usus = srvUsuario.Listar();       
                return View(usus);
          
        }
        public ActionResult IndexViajero()
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            if (usuarioLogueado != null)
            {
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/IndexViajero";
            return RedirectToAction("Login", "Home");

        }
        public ActionResult IndexAgencia()
        {
            return View();
        }
    }
}