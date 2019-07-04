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
        // lista de publicaciones de una agencia
        public ActionResult Listar(long id)
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            ViewBag.ListaPublicaciones = srvUsuario.ObtenerPublicacionesByUsuario(id);
            return View();         
        }
    }
}