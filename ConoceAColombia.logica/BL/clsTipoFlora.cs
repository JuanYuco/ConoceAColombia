using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoFlora
    {
        public List<Models.clsTipoFlora> getTipoFlora()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoFlora> lstclsTipoFlora = (from q in obDatos.tbTipoFlora
                                                                 select new Models.clsTipoFlora
                                                                 {
                                                                     lgCodigo = q.tiflCodigo,
                                                                     stDescripcion = q.tiflDescripcion
                                                                 }).ToList();
                    return lstclsTipoFlora;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertTipoFlora(Models.clsTipoFlora obclsTipoFlora)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoFlora.Add(new Entidades.tbTipoFlora
                    {
                        tiflCodigo = obclsTipoFlora.lgCodigo,
                        tiflDescripcion = obclsTipoFlora.stDescripcion
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


        public string updateTipoFlora(Models.clsTipoFlora ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoFlora obtbTipoFlora = (from q in obbdConoceAColombiaEntities.tbTipoFlora
                                                           where q.tiflCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obtbTipoFlora.tiflDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoFlora(Models.clsTipoFlora ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoFlora obtbTipoFlora = (from q in obbdConoceAColombiaEntities.tbTipoFlora
                                                           where q.tiflCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoFlora.Remove(obtbTipoFlora);
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
