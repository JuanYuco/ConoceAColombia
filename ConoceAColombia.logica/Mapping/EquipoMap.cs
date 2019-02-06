using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ConoceAColombia.logica.Mapping
{
    public class EquipoMap : ClassMap<Models.clsEquipo>
    {
        public EquipoMap() 
        {
            Table("tbEquipos");
            Id(x => x.lgCodigo).Column("equiCodigo").GeneratedBy.Assigned();
            Map(x => x.stNombre).Column("equiNombre");
            Map(x => x.stDescripcion).Column("equiDescripcion");
            Map(x => x.stPresidente).Column("equiPresidente");
            Map(x => x.stFundacion).Column("equiFundacion");
            Map(x => x.stCiudad).Column("equiCiudad");
            Map(x => x.stImagen).Column("equiImagen");
            Map(x => x.stLatitud).Column("equiLatitud");
            Map(x => x.stLongitud).Column("equiLongitud");
            References(x => x.obclsDeportes).Column("equiDeporte").ForeignKey("depoCodigo");
            References(x => x.obclsDepartamentos).Column("equiDepartamento").ForeignKey("depaCodigo");


        }
    }
}
