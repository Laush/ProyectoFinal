using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class UsuarioService
    {
        Context Context = new Context();

        public bool registrarViajero(Usuario Viajero)
        {
            try
            {
                Context.Usuario.Add(Viajero);
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool existeUsuario(Usuario Usuario) // verifica la existencia de un usuario, ya sea por nombre de usuario o por e-mail
        {
            Usuario UsuarioExistente = Context.Usuario.FirstOrDefault(u => u.NombreUsuario == Usuario.NombreUsuario || u.Email == Usuario.Email);

            return (UsuarioExistente == null) ? false : true;
        }

        public Usuario login(LoginRequestModel loginRequest)
        {
            return Context.Usuario.FirstOrDefault(u => (u.NombreUsuario == loginRequest.usuario || u.Email == loginRequest.usuario) && u.Password == loginRequest.contrasenia);
        }
    }
}
