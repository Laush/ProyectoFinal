//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Genericas
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudad
    {
        public Ciudad()
        {
            this.Usuario = new HashSet<Usuario>();
            this.Viaje = new HashSet<Viaje>();
            this.Viaje1 = new HashSet<Viaje>();
        }
    
        public long IdCiudad { get; set; }
        public string Nombre { get; set; }
        public long IdProvincia { get; set; }
    
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Viaje> Viaje { get; set; }
        public virtual ICollection<Viaje> Viaje1 { get; set; }
    }
}