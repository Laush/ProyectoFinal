using Genericas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class PublicacionController : Controller
    {
        private UsuarioService srvUsuario = new UsuarioService();
        private ViajeService srvViaje = new ViajeService();
  // lista de publicaciones de una agencia
        public ActionResult Listar(long id)
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            ViewBag.ListaPublicaciones = srvUsuario.ObtenerPublicacionesByUsuario(id);
            return View();         
        }

        [HttpGet]
        public ActionResult AgregarPublicacion()
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            if (usuarioLogueado != null)
            {       
                Publicacion usu = new Publicacion();
                return View(usu);
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult AgregarPublicacion(Publicacion p)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            srvViaje.AgregarPublicacion(p, usuarioLogueado);
            return RedirectToAction("IndexAgencia","Usuario", p);
        }

        public ActionResult Eliminar(long id)
        {
            var sj = new ViajeService();
            sj.EliminarPublicacion(id);
            return RedirectToAction("IndexAgencia", "Usuario");

        }
    }
}