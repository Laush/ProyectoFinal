﻿using API.Models;
using API.Services;
using Genericas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace API.Controllers
{

    public class UsuarioController : ApiController
    {
        private UsuarioService usuarioService = new UsuarioService();
        private DestinoService destinoService = new DestinoService();

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage registroViajero(Usuario Viajero)
        {
            Viajero.IdRol = 3;
            Viajero.Descripcion = ""; 
            Viajero.Password = usuarioService.HashPassword(Viajero.Password);

            if(!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            if(usuarioService.existeUsuario(Viajero))
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "El nombre de usuario o el e-mail ya están registrados.");

            if (usuarioService.registrarViajero(Viajero))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Ha ocurrido un error en el servidor. Por favor intente más tarde.");
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage registroGuia(Usuario Guia)
        {
            Guia.IdRol = 4;
            Guia.Descripcion = "";
            Guia.Password = usuarioService.HashPassword(Guia.Password);

            if (!ModelState.IsValid)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            if (usuarioService.existeUsuario(Guia))
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "El nombre de usuario o el e-mail ya están registrados.");

            if (usuarioService.registrarViajero(Guia))
                return new HttpResponseMessage(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ha ocurrido un error en el servidor. Por favor intente más tarde.");
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage login(LoginRequestModel LoginRequest)
        {
            LoginResponse LoginResponse = new LoginResponse();
            Usuario UsuarioEncontrado = usuarioService.login(LoginRequest);

            if (UsuarioEncontrado == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            LoginResponse.IdUsuario = UsuarioEncontrado.IdUsuario;
            LoginResponse.Usuario = UsuarioEncontrado.NombreUsuario;
            LoginResponse.Token = TokenManager.GenerateTokenJwt(UsuarioEncontrado);

            return Request.CreateResponse(HttpStatusCode.OK, LoginResponse);
        }

        [HttpGet]
        public HttpResponseMessage Nacionalidades()
        {
            List<Pais> Paises = destinoService.ListarPaises();

            List<NacionalidadModel> Nacionalidades = new List<NacionalidadModel>();

            foreach(Pais Pais in Paises)
            {
                NacionalidadModel Nacionalidad = new NacionalidadModel();

                Nacionalidad.Id = Pais.IdPais;
                Nacionalidad.Pais = Pais.Nombre;

                Nacionalidades.Add(Nacionalidad);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Nacionalidades);
        }

        [HttpPut]
        [Route("api/Usuario/Calificar/{IdUsuario}/{Calificacion}")]
        public HttpResponseMessage CalificarUsuario(long IdUsuario, long Calificacion)
        {
            Usuario UsuarioCalificado = usuarioService.GetById(IdUsuario);

            if (UsuarioCalificado == null)
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Usuario no encontrado");

            usuarioService.CalificarUsuario(UsuarioCalificado,Calificacion);

            return Request.CreateResponse(HttpStatusCode.OK,"El usuario ha sido calificado");
        }
    }
}
