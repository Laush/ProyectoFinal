//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vuelo
    {
        public int IdVuelo { get; set; }
        public string Aerolinea { get; set; }
        public int NumeroVuelo { get; set; }
        public int FechaVuelo { get; set; }
        public int IdViaje { get; set; }
    }
}
