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

        [HttpPost]
        [Route("api/Amistad/Invitar/{IdResponsable}/{IdSeguido}")]
        public HttpResponseMessage Seguir(long IdResponsable, long IdSeguido)
        {
            if (usuarioService.GetById(IdSeguido) == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Usuario a seguir no encontrado");

            if (amistadService.SeguirUsuario(IdResponsable, IdSeguido) == true)
            {
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
            amistadService.actualizarInvitacion(IdResponsable, IdInvitado, EsAceptado);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/Amistad/ExisteAmistad/{IdResponsable}/{IdInvitado}")]
        public HttpResponseMessage ExisteAmistad(long IdResponsable, long IdInvitado)
        {
            AmistadUsuario Amistad = amistadService.BuscarAmistad(IdResponsable, IdInvitado);

            InvitacionResponse Response = new InvitacionResponse();

            Response.IdResponsable = Amistad.IdResponsable;
            Response.Estado = Amistad.Estado;
            Response.FechaCoincidencia = Amistad.FechaCoincidencia;
            Response.Descripcion = Amistad.Usuario1.Descripcion;
            Response.NombreUsuario = Amistad.Usuario1.NombreUsuario;
            Response.MatriculaGuia = Amistad.Usuario1.MatriculaGuia;
            Response.UrlFotoPerfil = Amistad.Usuario1.UrlFotoPerfil;

            return Request.CreateResponse(HttpStatusCode.OK, Response);
        }
    }
}
