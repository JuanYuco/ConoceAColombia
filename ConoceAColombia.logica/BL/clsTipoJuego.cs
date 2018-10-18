using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoJuego
    {
        public string addTipoJuego(Models.clsTipoJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoJuego obtbTipoJuego = new Entidades.tbTipoJuego
                    {
                        tijuCodigo = ob.lgCodigo,
                        tijuDescripcion = ob.stDescripcion
                    };
                    obbdConoceAColombiaEntities.tbTipoJuego.Add(obtbTipoJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateTipoJuego(Models.clsTipoJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoJuego obtbTipoJuego = (from q in obbdConoceAColombiaEntities.tbTipoJuego
                                                         where q.tijuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obtbTipoJuego.tijuDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoJuego(Models.clsTipoJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoJuego obtbTipoJuego = (from q in obbdConoceAColombiaEntities.tbTipoJuego
                                                         where q.tijuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoJuego.Remove(obtbTipoJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsTipoJuego> getTipoJuego()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoJuego> lstclsTipoJuego
                        = (from q in obbdConoceAColombiaEntities.tbTipoJuego
                           select new Models.clsTipoJuego
                           {
                               lgCodigo = q.tijuCodigo,
                               stDescripcion = q.tijuDescripcion
                           }).ToList();

                    return lstclsTipoJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }
    }
}