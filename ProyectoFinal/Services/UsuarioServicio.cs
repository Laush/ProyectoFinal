using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Services
{
    public class UsuarioServicio
    {

        private FriendsTrip_Entities MiBD = new FriendsTrip_Entities();

        public List<Usuario> Listar()
        {
            return MiBD.Usuario.ToList();

        }

        public Usuario VerificarExistenciaUsuario(Usuario u)
        {
            var user = MiBD.Usuario.Where(us => us.Email.Equals(u.Email) && us.Password.Equals(u.Password)).FirstOrDefault();

            return user;
        }


        public Usuario GetById(int id)
        {
            return MiBD.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }

        //prueba
        public Usuario GetUsuario(Usuario u)
        {
            return MiBD.Usuario.FirstOrDefault(x => x.IdUsuario.Equals(u));
        }

    }
}