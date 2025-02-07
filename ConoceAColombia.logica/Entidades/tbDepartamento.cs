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
    
    public partial class tbDepartamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbDepartamento()
        {
            this.tbArquitectura = new HashSet<tbArquitectura>();
            this.tbArtistas = new HashSet<tbArtistas>();
            this.tbCiudadesPrincipales = new HashSet<tbCiudadesPrincipales>();
            this.tbCulturas = new HashSet<tbCulturas>();
            this.tbEquipos = new HashSet<tbEquipos>();
            this.tbPersonajeAprendizaje = new HashSet<tbPersonajeAprendizaje>();
            this.tbDeportista = new HashSet<tbDeportista>();
            this.tbEquipos1 = new HashSet<tbEquipos>();
            this.tbEstadios = new HashSet<tbEstadios>();
            this.tbFaunaxDepartamento = new HashSet<tbFaunaxDepartamento>();
            this.tbGastronomia = new HashSet<tbGastronomia>();
            this.tbHistoria = new HashSet<tbHistoria>();
            this.tbMusica = new HashSet<tbMusica>();
            this.tbFloraxDepartamento = new HashSet<tbFloraxDepartamento>();
            this.tbLugares = new HashSet<tbLugares>();
        }
    
        public long depaCodigo { get; set; }
        public string depaNombre { get; set; }
        public string depaCapital { get; set; }
        public string depaGobernador { get; set; }
        public string depaMunicipios { get; set; }
        public System.DateTime depaFundacion { get; set; }
        public string depaGentilicio { get; set; }
        public string depaPoblacion { get; set; }
        public string depaSuperficie { get; set; }
        public string depaDemografia { get; set; }
        public string depaLatitud { get; set; }
        public string depaLongitud { get; set; }
        public string depaImagen { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbArquitectura> tbArquitectura { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbArtistas> tbArtistas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCiudadesPrincipales> tbCiudadesPrincipales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCulturas> tbCulturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEquipos> tbEquipos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbPersonajeAprendizaje> tbPersonajeAprendizaje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDeportista> tbDeportista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEquipos> tbEquipos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEstadios> tbEstadios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbFaunaxDepartamento> tbFaunaxDepartamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbGastronomia> tbGastronomia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbHistoria> tbHistoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMusica> tbMusica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbFloraxDepartamento> tbFloraxDepartamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbLugares> tbLugares { get; set; }
    }
}
