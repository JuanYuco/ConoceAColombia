using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTematicasJuego
    {
        public string addTematicas(Models.clsTematicasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTematicaJuego obtbTematicaJuego = new Entidades.tbTematicaJuego
                    {
                        tejuCodigo = ob.lgCodigo,
                        tejuDescripcion = ob.stDescripcion 
                    };
                    obbdConoceAColombiaEntities.tbTematicaJuego.Add(obtbTematicaJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateTematica(Models.clsTematicasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTematicaJuego obtbTematicaJuego = (from q in obbdConoceAColombiaEntities.tbTematicaJuego
                                                         where q.tejuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obtbTematicaJuego.tejuDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTematica(Models.clsTematicasJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTematicaJuego obtbTematicaJuego = (from q in obbdConoceAColombiaEntities.tbTematicaJuego
                                                         where q.tejuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTematicaJuego.Remove(obtbTematicaJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTematicasJuego> getTematica()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTematicasJuego> lstclsTematicaJuego
                        = (from q in obbdConoceAColombiaEntities.tbTematicaJuego
                           select new Models.clsTematicasJuego
                           {
                               lgCodigo = q.tejuCodigo,
                               stDescripcion = q.tejuDescripcion
                           }).ToList();

                    return lstclsTematicaJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }
    }
}