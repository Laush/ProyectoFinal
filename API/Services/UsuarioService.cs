using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models;

namespace API.Services
{
    public class UsuarioService
    {
        Context context = new Context();

        public bool registrarViajero(Usuario Viajero)
        {
            try
            {
                context.Usuario.Add(Viajero);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool existeUsuario(Usuario Usuario) // verifica la existencia de un usuario, ya sea por nombre de usuario o por e-mail
        {
            Usuario UsuarioExistente = context.Usuario.FirstOrDefault(u => u.NombreUsuario == Usuario.NombreUsuario || u.Email == Usuario.Email);

            return (UsuarioExistente == null) ? false : true;
        }

        public Usuario login(LoginRequestModel loginRequest)
        {
            return context.Usuario.FirstOrDefault(u => (u.NombreUsuario == loginRequest.usuario || u.Email == loginRequest.usuario) && u.Password == loginRequest.contrasenia);
        }

    }
}