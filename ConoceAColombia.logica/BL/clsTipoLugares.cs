using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoLugares
    {
        public List<Models.clsTipoLugares> getTipoLugares()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoLugares> lstclsTipoLugares = (from q in obDatos.tbTipoLugares
                                                                           select new Models.clsTipoLugares
                                                                           {
                                                                               lgCodigo = q.tiluCodigo,
                                                                               stDescripcion = q.tiluDescripcion
                                                                           }).ToList();
                    return lstclsTipoLugares;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public string InsertTipoLugares(Models.clsTipoLugares obclsTipoLugares)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoLugares.Add(new Entidades.tbTipoLugares
                    {
                        tiluCodigo = obclsTipoLugares.lgCodigo,
                        tiluDescripcion = obclsTipoLugares.stDescripcion
                    });
                    obDatos.SaveChanges();
                    return "Se realizo con exito";
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }


        public string updateTipoLugares(Models.clsTipoLugares ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoLugares obtbTipoLugares = (from q in obbdConoceAColombiaEntities.tbTipoLugares
                                                                     where q.tiluCodigo == ob.lgCodigo
                                                                     select q).FirstOrDefault();
                    obtbTipoLugares.tiluDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoLugares(Models.clsTipoLugares ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoLugares obtbTipoLugares = (from q in obbdConoceAColombiaEntities.tbTipoLugares
                                                                     where q.tiluCodigo == ob.lgCodigo
                                                                     select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoLugares.Remove(obtbTipoLugares);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
