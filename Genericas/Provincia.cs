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
    
    public partial class Provincia
    {
        public Provincia()
        {
            this.Ciudad = new HashSet<Ciudad>();
        }
    
        public long IdProvincia { get; set; }
        public string Nombre { get; set; }
        public long IdPais { get; set; }
    
        public virtual ICollection<Ciudad> Ciudad { get; set; }
        public virtual Pais Pais { get; set; }
    }
}