﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Services;
using Genericas;

namespace API.Controllers
{
    [Authorize]
    public class ViajeController : ApiController
    {
        private TokenManager TokenManager = new TokenManager();
        private ViajeService ViajeService = new ViajeService();
        //private UsuarioService UsuarioService = new UsuarioService();
        private DestinoService DestinoService = new DestinoService();

        [HttpPost]
        public HttpResponseMessage Registrar(ViajeModel RequestModel)
        {
            Viaje NuevoViaje = new Viaje();
            string JwtToken = Request.Headers.First(h => h.Key == "Authorization").Value.First();
            long IdUsuario = TokenManager.GetUserId(JwtToken);

            if (ViajeService.registrarViaje(RequestModel, IdUsuario))
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Se ha producido un error en el servidor. Intente nuevamente más tarde");
        }

        [HttpPut]
        public HttpResponseMessage Modificar(ViajeModel ViajeModificado)
        {
            if (ViajeService.ModificarViaje(ViajeModificado))
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpDelete]
        public HttpResponseMessage Eliminar(long id)
        {
            string JwtToken = Request.Headers.First(h => h.Key == "Authorization").Value.First();
            long IdUsuario = TokenManager.GetUserId(JwtToken);

            if (!ViajeService.ExisteViaje(id))
                return Request.CreateResponse(HttpStatusCode.NotFound, "el viaje no existe");

            if (ViajeService.EliminarViaje(id, IdUsuario))
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error al intentar eliminar el viaje. Inténtelo más tarde");
        }
        
        [HttpGet]
        public HttpResponseMessage Listar()
        {
            string JwtToken = Request.Headers.First(h => h.Key == "Authorization").Value.First();
            long IdUsuario = TokenManager.GetUserId(JwtToken);

            return Request.CreateResponse(HttpStatusCode.OK, ViajeService.Listar(IdUsuario));
        }
        
        [HttpGet]
        [Route("api/Viaje/Buscar/{IdViaje}")]
        public HttpResponseMessage Buscar(long IdViaje)
        {
            ViajeModel Viaje = ViajeService.Buscar(IdViaje);

            if(Viaje == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Viaje no encontrado");
            else
            return Request.CreateResponse(HttpStatusCode.OK, Viaje);
        }
    }
}
