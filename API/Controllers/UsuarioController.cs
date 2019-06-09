using API.Models;
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
        

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage registroViajero(Usuario Viajero)
        {
            Viajero.IdRol = 1;
            Viajero.Descripcion = ""; // el rol se setea en blanco porque el campo es obligatorio
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

        

        //falta el metodo para eliminar perfil, que requiere la anotaacion [Authorize]
    }
}
