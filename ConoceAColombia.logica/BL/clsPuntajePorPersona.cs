using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsPuntajePorPersona
    {
        public string addPuntajePorPersona(Models.clsPuntajePorPersona ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbPuntajePorPersona obtbPuntajePorPersona = new Entidades.tbPuntajePorPersona
                    {
                        pupeCodigo = obbdConoceAColombiaEntities.tbPuntajePorPersona.Select(q => q.pupeCodigo).Max() + 1,
                        pupeNombreCompleto = ob.stNombreCompleto,
                        pupePuntaje = ob.inPuntaje,
                        pupeTipoJuego = ob.stTipoJuego,
                        pupeDificultad = ob.stDificultad
                    };
                    obbdConoceAColombiaEntities.tbPuntajePorPersona.Add(obtbPuntajePorPersona);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<Models.clsPuntajePorPersona> getPuntajePorPersona()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsPuntajePorPersona> lstclsPuntajePorPersona
                        = (from q in obbdConoceAColombiaEntities.tbPuntajePorPersona
                           orderby q.pupePuntaje descending
                           select new Models.clsPuntajePorPersona
                           {
                               lgCodigo = q.pupeCodigo,
                               stNombreCompleto = q.pupeNombreCompleto,
                               inPuntaje =(int) q.pupePuntaje,
                               stTipoJuego = q.pupeTipoJuego,
                               stDificultad = q.pupeDificultad
                           }).ToList();

                    return lstclsPuntajePorPersona;
                }

            }
            catch (Exception ex) { throw ex; }
        }



    }
}
