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
        private AmistadService srvAmistad = new AmistadService();

        // GET: Usuario Admin
        [HttpGet]
        public ActionResult IndexAdmin()
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            if (usuarioLogueado != null && usuarioLogueado.IdRol==1)
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
                ViewBag.ListaPublicaciones = srvUsuario.ObtenerPublicacionesByUsuario(usuarioLogueado.IdUsuario);
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/IndexAgencia";
            return RedirectToAction("Login", "Home");
        }

        public ActionResult IndexPerfil(long id)
        {

            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                ViewBag.CheckeaAmistad = srvAmistad.BuscarAmistad(usuarioLogueado.IdUsuario, id);
            }
            ViewBag.Rol = Session["Usuario"] as Usuario;         
            Usuario usuario = srvUsuario.GetById(id);
            return View(usuario);

        }

        //lo usa admin
        public ActionResult EditarUsuario(int id)
        {
            var usuarioLogueado = Session["Usuario"] as Usuario;
            Usuario usu = srvUsuario.GetById(id);
            return View(usu);
        }

        [HttpGet]
        public ActionResult IndexGuia()
        {
            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                ViewBag.ListaPublicaciones = srvUsuario.ObtenerPublicacionesByUsuario(usuarioLogueado.IdUsuario);
           
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/IndexGuia";
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario u)
        {
            if (ModelState.IsValid)
            {
                srvUsuario.Editar(u);
                 return RedirectToAction("IndexAdmin", "Usuario");
            }
            else
            {
                return View(u);
            }
        }

        public ActionResult Notificaciones()
        {
            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                ViewBag.ListaNotificaciones = srvAmistad.BuscarInvitaciones(usuarioLogueado.IdUsuario);
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/Notificaciones";
            return RedirectToAction("Login", "Home");
        }


        public ActionResult ListaAmigos()
        {
            if (Session["Usuario"] is Usuario usuarioLogueado)
            {
                ViewBag.Usu = Session["Usuario"] as Usuario;
                
                ViewBag.ListaAmigos = srvAmistad.ListarAmistades(usuarioLogueado.IdUsuario);
                
                return View(usuarioLogueado);
            }

            Session["RedireccionLogin"] = "Usuario/ListaAmigos";
            return RedirectToAction("Login", "Home");
        }
    }
}