//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConoceAColombia.logica.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbPeriodoHistoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbPeriodoHistoria()
        {
            this.tbHistoria = new HashSet<tbHistoria>();
        }
    
        public long pehiCodigo { get; set; }
        public string pehiDescripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoria> tbHistoria { get; set; }
    }
}
