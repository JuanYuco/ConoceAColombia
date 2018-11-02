using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoFauna
    {
        public List<Models.clsTipoFauna> getTipoFauna()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoFauna> lstclsTipoFauna = (from q in obDatos.tbTipoFauna
                                                        select new Models.clsTipoFauna
                                                        {
                                                            lgCodigo = q.tifaCodigo,
                                                            stDescripcion = q.tifaDescripcion
                                                        }).ToList();
                    return lstclsTipoFauna;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertTipoFauna(Models.clsTipoFauna obclsTipoFauna)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoFauna.Add(new Entidades.tbTipoFauna
                    {
                        tifaCodigo =  obclsTipoFauna.lgCodigo,
                        tifaDescripcion = obclsTipoFauna.stDescripcion
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


        public string updateTipoFauna(Models.clsTipoFauna ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoFauna obtbTipoFauna = (from q in obbdConoceAColombiaEntities.tbTipoFauna
                                                           where q.tifaCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obtbTipoFauna.tifaDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoFauna(Models.clsTipoFauna ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoFauna obtbTipoFauna = (from q in obbdConoceAColombiaEntities.tbTipoFauna
                                                           where q.tifaCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoFauna.Remove(obtbTipoFauna);
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
