using Genericas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioService srvUsuario = new UsuarioService();

        // GET: Usuario Admin
        [HttpGet]
        public ActionResult IndexAdmin()
        {
            if (Session["Usuario"] != null)
            {
                //listas
                ViewBag.UsuarioAdmin = Session["Usuario"] as Usuario;

                List<Usuario> usus = new List<Usuario>();
                usus = srvUsuario.Listar();

                return View(usus);
            }

            return RedirectToAction("Login", "Home");
        }

        // GET: Usuario Viajero
        [HttpGet]
        public ActionResult IndexViajero()
        {
            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                //aca deje armado un viewbag con los viajes del viajero/usuario logeado, probarla y armar la lista en la vista
                //se puede recorrer igual que una lista
                ViewBag.ViajesUsuario = srvUsuario.ObtenerViajesUsuario(usuarioLogueado.IdUsuario);

                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/IndexViajero";
            return RedirectToAction("Login", "Home");

        }
        
        // GET: Usuario Entidad
        [HttpGet]
        public ActionResult IndexAgencia()
        {
            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/IndexViajero";
            return RedirectToAction("Login", "Home");
        }
    }
}