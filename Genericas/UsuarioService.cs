using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class UsuarioService
    {
        Context contexto = new Context();

        public string HashPassword(string Password)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] Bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(Password));

            return Encoding.UTF8.GetString(Bytes);
        }

        public bool registrarViajero(Usuario Viajero)
        {
            try
            {
                contexto.Usuario.Add(Viajero);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool existeUsuario(Usuario Usuario) // verifica la existencia de un usuario, ya sea por nombre de usuario o por e-mail
        {
            Usuario UsuarioExistente = contexto.Usuario.FirstOrDefault(u => u.NombreUsuario == Usuario.NombreUsuario || u.Email == Usuario.Email);

            return (UsuarioExistente == null) ? false : true;
        }

        public Usuario login(LoginRequestModel loginRequest)
        {
            string hashedPassword = HashPassword(loginRequest.contrasenia);

            return contexto.Usuario.FirstOrDefault(u => (u.NombreUsuario == loginRequest.usuario || u.Email == loginRequest.usuario) && u.Password == hashedPassword);
        }

        // INICIO - Estos metodos los traigo de Servicios/UsuarioServicio.cs que estaban en ProyectoFinal (web)
        public List<Usuario> Listar()
        {
            return contexto.Usuario.ToList();
        }
        public Usuario VerificarExistenciaUsuario(Usuario u)
        {
            var user = contexto.Usuario.Where(us => us.Email.Equals(u.Email) && us.Password.Equals(u.Password)).FirstOrDefault();

            return user;
        }


        public Usuario GetById(int id)
        {
            return contexto.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }

        //prueba
        public Usuario GetUsuario(Usuario u)
        {
            return contexto.Usuario.FirstOrDefault(x => x.IdUsuario.Equals(u));
        }
        // FIN - Estos metodos los traigo de Servicios/UsuarioServicio.cs que estaban en ProyectoFinal (web)

        public List<Viaje> ObtenerViajesUsuario(long id)
        {
            return contexto.Viaje.Where(v => v.Usuario.FirstOrDefault().IdUsuario == id).ToList();
        }
    }
}
