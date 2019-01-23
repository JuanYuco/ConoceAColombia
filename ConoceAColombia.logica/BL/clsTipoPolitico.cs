using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoPolitico
    {
        public List<Models.clsTipoPolitico> getTipoPolitico()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoPolitico> lstclsTipoPolitico = (from q in obDatos.tbTipoPolitico
                                                                           select new Models.clsTipoPolitico
                                                                           {
                                                                               lgCodigo = q.tipoCodigo,
                                                                               stDescripcion = q.tipoDescripcion
                                                                           }).ToList();
                    return lstclsTipoPolitico;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public string InsertTipoPolitico(Models.clsTipoPolitico obclsTipoPolitico)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoPolitico.Add(new Entidades.tbTipoPolitico
                    {
                        tipoCodigo = obclsTipoPolitico.lgCodigo,
                        tipoDescripcion = obclsTipoPolitico.stDescripcion
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


        public string updateTipoPolitico(Models.clsTipoPolitico ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoPolitico obtbTipoPolitico = (from q in obbdConoceAColombiaEntities.tbTipoPolitico
                                                                     where q.tipoCodigo == ob.lgCodigo
                                                                     select q).FirstOrDefault();
                    obtbTipoPolitico.tipoDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoPolitico(Models.clsTipoPolitico ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoPolitico obtbTipoPolitico = (from q in obbdConoceAColombiaEntities.tbTipoPolitico
                                                                     where q.tipoCodigo == ob.lgCodigo
                                                                     select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoPolitico.Remove(obtbTipoPolitico);
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
