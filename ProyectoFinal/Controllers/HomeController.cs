﻿using Genericas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using API;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioService srvUsuario = new UsuarioService();

        private ViajeService srvViaje = new ViajeService();

        public ActionResult Logout()
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;

            List<Usuario> usus = new List<Usuario>();
            usus = srvUsuario.ListarAgencias();

            ViewBag.Guias = srvUsuario.ListarGuias();
            // usus = srvUsuario.Listar();
            return View(usus);


        }

        public ActionResult Login()
        {
            if (Request.Cookies.AllKeys.Contains("usuarioSesion") && Request.Cookies["usuarioSesion"].Values.Count > 0)
            {
                var cookie = Request.Cookies["usuarioSesion"].Value;
                if (cookie != null && !string.IsNullOrWhiteSpace(cookie))
                {
                    byte[] decryted = Convert.FromBase64String(string.IsNullOrWhiteSpace(cookie) ? string.Empty : cookie);
                    var result = Int32.Parse(System.Text.Encoding.Unicode.GetString(decryted));

                    var usuario = srvUsuario.GetById(result);
                    if (usuario != null)
                    {
                        Session["Usuario"] = usuario;
                        return RedirectToAction("Buscador", "Home");
                    }
                    else
                    {
                        return View();
                    }
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario u)
        {
            var user = srvUsuario.VerificarExistenciaUsuario(u);
            if (user != null)
            {
                Session["Usuario"] = user;

                if (Session["RedireccionLogin"] != null)
                {
                    String accionSesion = (String)Session["RedireccionLogin"];
                    String pattern = "/";
                    String[] accion = Regex.Split(accionSesion, pattern);
                    Session.Remove("RedireccionLogin");
                    return RedirectToAction(accion[1], accion[0]);
                }
                //redirecciona segun rol
                switch (user.IdRol)
                {
                    case 1:
                        return RedirectToAction("IndexAdmin", "Usuario");
                       
                    case 2:
                        return RedirectToAction("IndexAgencia", "Usuario");
                       
                    case 3:
                        return RedirectToAction("IndexViajero", "Usuario");
                    case 4:
                        return RedirectToAction("IndexGuia", "Usuario");

                }
                return RedirectToAction("Error", "Usuario");

            }

            else 
            {
                ViewBag.ErrorLogin = "Usuario y/o Contraseña Invalidos";
                return View();
            }
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
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

        [HttpGet]
        public ActionResult RegistroViajero()
        {          
                ViewBag.ListaPaises = srvViaje.ObtenerPaises();
                Usuario usu = new Usuario();
                usu.IdRol = 3;
                return View(usu);
           
        }
        [HttpPost]
        public ActionResult RegistroViajero(Usuario u)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                //TODO: Agregar validacion para confirmar que el archivo es una imagen
                //creo un nombre significativo en este caso apellidonombre pero solo un caracter del nombre, ejemplo BatistutaG
                string nombreSignificativo = u.Email;
                //Guardar Imagen
                string pathRelativoImagen = ImagenesUtility.Guardar(Request.Files[0], nombreSignificativo);
                u.UrlFotoPerfil = pathRelativoImagen;
            }

            srvUsuario.Agregar(u);
            return RedirectToAction("Login", u);
        }

        public ActionResult Eliminar(long id)
        {
            var sj = new UsuarioService();
            sj.Eliminar(id);
            return RedirectToAction("IndexAdmin", "Usuario");

        }

        public ActionResult Buscador()
        {
            ViewBag.Rol = Session["Usuario"] as Usuario;
            return View();
        }
    }
}