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

        public bool registrarGuia(Usuario Guia)
        {
            try
            {
                if (contexto.Usuario.First(u => u.MatriculaGuia == Guia.MatriculaGuia) == null)
                    return false;

                contexto.Usuario.Add(Guia);
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
        public List<Usuario> ListarAgencias()
        {
            var query = from a in contexto.Usuario
                        where a.IdRol == 2
                        select a;

            return query.ToList();
        }
        public List<Usuario> ListarGuias()
        {
            var query = from a in contexto.Usuario
                        where a.IdRol == 4
                        select a;

            return query.ToList();
        }

        public Usuario GetById(long id)
        {
            return contexto.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }

        public Usuario GetById(long? id)
        {
            return contexto.Usuario.FirstOrDefault(x => x.IdUsuario == id);
        }

        public Usuario GetUsuario(Usuario u)
        {
            return contexto.Usuario.FirstOrDefault(x => x.IdUsuario.Equals(u));
        }
        // FIN - Estos metodos los traigo de Servicios/UsuarioServicio.cs que estaban en ProyectoFinal (web)

        public List<Viaje> ObtenerViajesUsuario(long id)
        {

            return contexto.Viaje.Where(v => v.IdUsuario == id).ToList();
        }

        //listar publicaciones de una agencia
        public List<Publicacion> ObtenerPublicacionesByUsuario(long idAgencia)
        {
            return contexto.Publicacion.Where(x => x.IdUsuario == idAgencia).ToList();   
        }
        //obtener info de una publicacion
        public Publicacion ObtenerDetallePublicacion(long idPublicacion)
        {
            return contexto.Publicacion.FirstOrDefault(x => x.IdPublicacion == idPublicacion);
        }


        //abm usuario viajero
        public void Agregar(Usuario u)
        {
            Usuario nuevoUsuario = u;
            nuevoUsuario.IdRol = 3;
            contexto.Usuario.Add(nuevoUsuario);
            contexto.SaveChanges();

        }

        public void Editar(Usuario v)
        {
            Usuario p = contexto.Usuario.Find(v.IdUsuario);
            p.Nombre = v.Nombre;
            p.NombreUsuario = v.NombreUsuario;
            p.Apellido = v.Apellido;
            p.Nacionalidad = v.Nacionalidad;
            p.Edad = v.Edad;
            p.Email = v.Email;
            p.UrlFotoPerfil = v.UrlFotoPerfil;
            p.Password = v.Password;
            p.MatriculaGuia = v.MatriculaGuia;
            p.UrlFotoPerfil = v.UrlFotoPerfil;
            p.Descripcion = v.Descripcion;
            contexto.SaveChanges();
        }
        public void EditarCalificacion(Usuario v)
        {
            Usuario p = contexto.Usuario.Find(v.IdUsuario);
            p.Nombre = v.Nombre;
            p.NombreUsuario = v.NombreUsuario;
            p.Apellido = v.Apellido;
            p.Nacionalidad = v.Nacionalidad;
            p.Edad = v.Edad;
            p.Email = v.Email;
            p.UrlFotoPerfil = v.UrlFotoPerfil;
            p.Password = v.Password;
            p.MatriculaGuia = v.MatriculaGuia;
            p.UrlFotoPerfil = v.UrlFotoPerfil;
            p.Descripcion = v.Descripcion;
            if (p.Calificacion == null)
            {
                p.Calificacion = v.Calificacion;
            }
            else
            {
                p.Calificacion = p.Calificacion + v.Calificacion;
            }
            contexto.SaveChanges();
        }
        public void Eliminar(long id)
        {
            Usuario usuarioEliminar = contexto.Usuario.FirstOrDefault(u => u.IdUsuario == id);
            contexto.Usuario.Remove(usuarioEliminar);
            contexto.SaveChanges();
        }
        //fin abm usuario

            // Verificar si tiene uso
        public AmistadUsuario EstadoSeguimiento(long IdResponsable, long IdSeguido)
        {
            var Amistad = contexto.AmistadUsuario.Where(a => a.IdResponsable == IdResponsable && a.IdSeguido == IdSeguido);

            return (Amistad.Count() == 0)? null : Amistad.First();
        }

        public Pais ObtenerNacionalidad(long IdPais)
        {
            return contexto.Pais.Find(IdPais);
        }
    }
}
