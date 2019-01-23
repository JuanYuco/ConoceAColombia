using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoDeportista
    {
        public List<Models.clsTipoDeportista> getTipoDeportista()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoDeportista> lstclsTipoDeportista = (from q in obDatos.tbTipoDeportista
                                                                 select new Models.clsTipoDeportista
                                                                 {
                                                                     lgCodigo = q.tideCodigo,
                                                                     stDescripcion = q.tideDescripcion
                                                                 }).ToList();
                    return lstclsTipoDeportista;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public string InsertTipoDeportista(Models.clsTipoDeportista obclsTipoDeportista)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoDeportista.Add(new Entidades.tbTipoDeportista
                    {
                        tideCodigo = obclsTipoDeportista.lgCodigo,
                        tideDescripcion = obclsTipoDeportista.stDescripcion
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


        public string updateTipoDeportista(Models.clsTipoDeportista ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoDeportista obtbTipoDeportista = (from q in obbdConoceAColombiaEntities.tbTipoDeportista
                                                           where q.tideCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obtbTipoDeportista.tideDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoDeportista(Models.clsTipoDeportista ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoDeportista obtbTipoDeportista = (from q in obbdConoceAColombiaEntities.tbTipoDeportista
                                                           where q.tideCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoDeportista.Remove(obtbTipoDeportista);
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
