using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace ConoceAColombia.logica.Mapping
{
    public class DepartamentosMap : ClassMap<Models.clsDepartamentos>
    {
        public DepartamentosMap()
        {
            Table("tbDepartamento");
            Id(x => x.inCodigo).Column("depaCodigo").GeneratedBy.Assigned();
            Map(x => x.stNombre).Column("depaNombre");
            Map(x => x.stCapital).Column("depaCapital");
            Map(x => x.stGobernador).Column("depaGobernador");
            Map(x => x.stMunicipios).Column("depaMunicipios");
            Map(x => x.stFundacion).Column("depaFundacion");
            Map(x => x.stGentilicio).Column("depaGentilicio");
            Map(x => x.stPoblacion).Column("depaPoblacion");
            Map(x => x.stLatitud).Column("depaLatitud");
            Map(x => x.stLongitud).Column("depaLongitud");
            Map(x => x.stDemografia).Column("depaDemografia");
            Map(x => x.stSuperficie).Column("depaSuperficie");
            
        }
    }
}
