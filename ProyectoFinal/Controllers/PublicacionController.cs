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

        public ActionResult Listar(long id)
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            ViewBag.ListaPublicaciones = srvUsuario.ObtenerPublicacionesByUsuario(id);
            ViewBag.Agencia = srvUsuario.GetById(id);

            return View();         
        }

        [HttpGet]
        public ActionResult AgregarPublicacion()
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
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
        public ActionResult EditarPublicacion(int id)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            Publicacion pu = srvViaje.ObtenerPublicacionPorId(id);
            return View(pu);
        }

        [HttpPost]
        public ActionResult EditarPublicacion(Publicacion publ)
        {
            if (ModelState.IsValid)
            {
                srvViaje.EditarPublicacion(publ);
                return RedirectToAction("IndexAgencia", "Usuario");
            }
            else
            {
                return View(publ);
            }
        }

        public ActionResult Detalle(int id)
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;

            return View(srvUsuario.ObtenerDetallePublicacion(id));
           

        }
    }
}