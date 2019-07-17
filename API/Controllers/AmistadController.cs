using API.Models;
using Genericas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class AmistadController : ApiController
    {
        private UsuarioService usuarioService = new UsuarioService();
        private DestinoService destinoService = new DestinoService();
        private AmistadService amistadService = new AmistadService();
        private EmailService emailService = new EmailService();

        [HttpPost]
        [Route("api/Amistad/Invitar/{IdResponsable}/{IdSeguido}")]
        public HttpResponseMessage Seguir(long IdResponsable, long IdSeguido)
        {
            Usuario UsuarioResponsable = usuarioService.GetById(IdResponsable);
            Usuario UsuarioInvitado = usuarioService.GetById(IdSeguido);

            // parametros para el mail
            string asunto = UsuarioResponsable.NombreUsuario + " te ha enviado una invitación";
            string cuerpoMensaje = "Hola " + UsuarioInvitado.NombreUsuario + ", " + asunto + " para conectar. Puedes aceptar la misma entrando en la aplicación.";

            if (UsuarioInvitado == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Usuario a seguir no encontrado");

            if (amistadService.SeguirUsuario(IdResponsable, IdSeguido) == true)
            {
                emailService.enviarMensaje(UsuarioInvitado.Email, UsuarioInvitado.NombreUsuario, asunto, cuerpoMensaje);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "No se ha podido seguir al usuario");
            }
        }

        [HttpGet]
        [Route("api/Amistad/BuscarInvitaciones/{IdUsuarioInvitado}")]
        public HttpResponseMessage BuscarInvitaciones(long IdUsuarioInvitado)
        {
            List<AmistadUsuario> Invitaciones = amistadService.BuscarInvitaciones(IdUsuarioInvitado);
            // en las amistades --> Usuario hace referencia al usuario invitado y Usuario1 al usuario que invita

            List<InvitacionResponse> InvitacionesRetornadas = new List<InvitacionResponse>();

            foreach(AmistadUsuario Invitacion in Invitaciones)
            {   
                //Usuario UsuarioResponsable = usuarioService.GetById(Invitacion.IdResponsable);

                InvitacionResponse InvitacionRetornada = new InvitacionResponse();

                InvitacionRetornada.IdResponsable = Invitacion.IdResponsable;
                InvitacionRetornada.Estado = Invitacion.Estado;
                InvitacionRetornada.FechaCoincidencia = Invitacion.FechaCoincidencia;
                InvitacionRetornada.Descripcion = Invitacion.Usuario1.Descripcion;
                InvitacionRetornada.MatriculaGuia = Invitacion.Usuario1.MatriculaGuia;
                InvitacionRetornada.NombreUsuario = Invitacion.Usuario1.NombreUsuario;
                InvitacionRetornada.UrlFotoPerfil = Invitacion.Usuario1.UrlFotoPerfil;

                InvitacionesRetornadas.Add(InvitacionRetornada);
            }

            return Request.CreateResponse(HttpStatusCode.OK, InvitacionesRetornadas);
        }

        [HttpPut]
        [Route("api/Amistad/AceptarInvitacion/{IdResponsable}/{IdInvitado}/{EsAceptado}")]
        public HttpResponseMessage AceptarInvitacion(long IdResponsable, long IdInvitado, char EsAceptado)
        {
            // EsAceptado = Y|N

            if(EsAceptado == 'Y')
            {
                Usuario UsuarioResponsable = usuarioService.GetById(IdResponsable);
                Usuario UsuarioInvitado = usuarioService.GetById(IdInvitado);

                // parametros para el mail
                string asunto = UsuarioInvitado.NombreUsuario + " ha aceptado tu invitación";
                string cuerpoMensaje = "Hola " + UsuarioResponsable.NombreUsuario + ", te informamos que el usuario " + asunto + " para conectar. Puedes ver su perfil para podder ponerte en contacto con el.";

                emailService.enviarMensaje(UsuarioResponsable.Email, UsuarioResponsable.NombreUsuario, asunto, cuerpoMensaje);
            }

            amistadService.actualizarInvitacion(IdResponsable, IdInvitado, EsAceptado);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Amistad/ExisteAmistad/{IdResponsable}/{IdInvitado}")]
        public HttpResponseMessage ExisteAmistad(long IdResponsable, long IdInvitado)
        {
            AmistadUsuario Amistad = amistadService.BuscarAmistad(IdResponsable, IdInvitado);

            InvitacionResponse Response = new InvitacionResponse();

            if (Amistad != null)
            {
                Response.IdResponsable = Amistad.IdResponsable;
                Response.Estado = Amistad.Estado;
                Response.FechaCoincidencia = Amistad.FechaCoincidencia;
                Response.Descripcion = Amistad.Usuario1.Descripcion;
                Response.NombreUsuario = Amistad.Usuario1.NombreUsuario;
                Response.MatriculaGuia = Amistad.Usuario1.MatriculaGuia;
                Response.UrlFotoPerfil = Amistad.Usuario1.UrlFotoPerfil;
            }

            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }

        [HttpGet]
        [Route("api/Amistad/BuscarAmigos/{IdUsuario}")]
        public HttpResponseMessage BuscarAmigos(long IdUsuario)
        {
            List<AmistadUsuario> Amistades = amistadService.ListarAmistades(IdUsuario);

            List<AmigoResponse> Amigos = new List<AmigoResponse>();

            foreach(AmistadUsuario Amistad in Amistades)
            {
                AmigoResponse Amigo = new AmigoResponse();

                if(Amistad.Usuario.IdUsuario == IdUsuario)
                {
                    Amigo.IdUsuario = Amistad.Usuario1.IdUsuario;
                    Amigo.NombreUsuario = Amistad.Usuario1.NombreUsuario;
                    Amigo.Nombre = Amistad.Usuario1.Nombre;
                    Amigo.Apellido = Amistad.Usuario1.Apellido;
                    Amigo.Edad = Amistad.Usuario1.Edad;
                    Amigo.Email = Amistad.Usuario1.Email;
                    Amigo.MatriculaGuia= Amistad.Usuario1.MatriculaGuia;
                    Amigo.Descripcion = Amistad.Usuario1.Descripcion;
                    Amigo.UrlFotoPerfil = Amistad.Usuario1.UrlFotoPerfil;
                    Amigo.Nacionalidad = usuarioService.ObtenerNacionalidad(Amistad.Usuario1.Nacionalidad).Nombre;
                    Amigo.Calificacion = Amistad.Usuario1.Calificacion;

                    Amigos.Add(Amigo);
                }
                else if(Amistad.Usuario1.IdUsuario == IdUsuario)
                {
                    Amigo.IdUsuario = Amistad.Usuario.IdUsuario;
                    Amigo.NombreUsuario = Amistad.Usuario.NombreUsuario;
                    Amigo.Nombre = Amistad.Usuario.Nombre;
                    Amigo.Apellido = Amistad.Usuario.Apellido;
                    Amigo.Edad = Amistad.Usuario.Edad;
                    Amigo.Email = Amistad.Usuario.Email;
                    Amigo.MatriculaGuia = Amistad.Usuario.MatriculaGuia;
                    Amigo.Descripcion = Amistad.Usuario.Descripcion;
                    Amigo.UrlFotoPerfil = Amistad.Usuario.UrlFotoPerfil;
                    Amigo.Nacionalidad = usuarioService.ObtenerNacionalidad(Amistad.Usuario.Nacionalidad).Nombre;
                    Amigo.Calificacion = Amistad.Usuario.Calificacion;

                    Amigos.Add(Amigo);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, Amigos);
        }
    }
}
