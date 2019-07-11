using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genericas
{
    public class AmistadService
    {
        private Context contexto = new Context();

        public bool SeguirUsuario(long IdResponsable, long IdSeguido)
        {
            AmistadUsuario Amistad = new AmistadUsuario();

            //DateTime Fecha = DateTime.Now;
            try
            {   //verifico de que no exista una amistad inversa
                AmistadUsuario AmistadInversa = BuscarAmistad(IdResponsable, IdSeguido);
                if (AmistadInversa == null)
                {

                    Amistad.IdResponsable = IdResponsable;
                    Amistad.IdSeguido = IdSeguido;
                    Amistad.Estado = "PENDIENTE";
                    Amistad.FechaCoincidencia = DateTime.Now;

                    contexto.AmistadUsuario.Add(Amistad);
                    contexto.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AmistadUsuario> BuscarInvitaciones(long idUsuarioInvitado)
        {
            return contexto.AmistadUsuario.Where(a => a.IdSeguido == idUsuarioInvitado && a.Estado != "ACEPTADO").ToList();
        }

        public void actualizarInvitacion(long IdResponsable, long IdInvitado, char EsAceptado)
        {
            AmistadUsuario Amistad = contexto.AmistadUsuario.Where(a => a.IdResponsable == IdResponsable && a.IdSeguido == IdInvitado).First();

            if(EsAceptado == 'N')
            {
                contexto.AmistadUsuario.Remove(Amistad);
                contexto.SaveChanges();
            }
            else if(EsAceptado == 'Y')
            {
                Amistad.Estado = "ACEPTADO";
                contexto.SaveChanges();
            }
        }

        public AmistadUsuario BuscarAmistad(long IdResponsable, long IdInvitado)
        {
            return contexto.AmistadUsuario.Where(a => (a.IdResponsable == IdResponsable && a.IdSeguido == IdInvitado) || (a.IdResponsable == IdInvitado && a.IdSeguido == IdResponsable)).FirstOrDefault();
        }

        public List<AmistadUsuario> ListarAmistades(long IdUsuario)
        {
            return contexto.AmistadUsuario.Where(a => (a.IdSeguido == IdUsuario || a.IdResponsable == IdUsuario) && a.Estado == "ACEPTADO").ToList();
        }
    }
}
