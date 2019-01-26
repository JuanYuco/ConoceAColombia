using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoCulturas
    {
        public List<Models.clsTipoCulturas> getTipoCulturas()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoCulturas> lstclsTipoCulturas = (from q in obDatos.tbTipoCultura
                                                                 select new Models.clsTipoCulturas
                                                                 {
                                                                     lgCodigo = q.ticuCodigo,
                                                                     stDescripcion = q.ticuDescripcion
                                                                 }).ToList();
                    return lstclsTipoCulturas;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }

        public string InsertTipoCulturas(Models.clsTipoCulturas obclsTipoCulturas)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoCultura.Add(new Entidades.tbTipoCultura
                    {
                        ticuCodigo = obclsTipoCulturas.lgCodigo,
                        ticuDescripcion = obclsTipoCulturas.stDescripcion
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


        public string updateTipoCulturas(Models.clsTipoCulturas ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoCultura obtbTipoCulturas = (from q in obbdConoceAColombiaEntities.tbTipoCultura
                                                           where q.ticuCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obtbTipoCulturas.ticuDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoCulturas(Models.clsTipoCulturas ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoCultura obtbTipoCulturas = (from q in obbdConoceAColombiaEntities.tbTipoCultura
                                                           where q.ticuCodigo == ob.lgCodigo
                                                           select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoCultura.Remove(obtbTipoCulturas);
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
