using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.mvc.BL
{
    public class clsTipoIncidencia
    {
        public List<Models.TipoIncidencia> GetTipoIncidencia()
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    List<Models.TipoIncidencia> tipo_incidencia = new List<Models.TipoIncidencia>();
                    tipo_incidencia = (from q in obDatos.Tipo_Incidencia
                                       select new Models.TipoIncidencia
                                       {
                                           inId = q.id,
                                           stDescripcion = q.descripcion
                                       }).ToList();

                    return tipo_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}