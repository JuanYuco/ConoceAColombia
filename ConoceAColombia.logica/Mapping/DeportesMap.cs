using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ConoceAColombia.logica.Mapping
{
    public class DeportesMap : ClassMap<Models.clsDeportes>
    {
     public DeportesMap()
        {
            Table("tbDeportes");
            Id(x => x.lgCodigo).Column("depoCodigo").GeneratedBy.Assigned();
            Map(x => x.stNombre).Column("depoNombre");
        }   
    }
}
