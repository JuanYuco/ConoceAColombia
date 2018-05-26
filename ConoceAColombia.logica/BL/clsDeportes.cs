using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsDeportes
    {
        public string addDeportes(Models.clsDeportes ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities()) {
                    Entidades.tbDeportes obtbDeportes = new Entidades.tbDeportes {
                        depoCodigo = ob.lgCodigo,
                        depoNombre = ob.stNombre
                    };
                    obbdConoceAColombiaEntities.tbDeportes.Add(obtbDeportes);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateDeportes(Models.clsDeportes ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDeportes obtbDeportes = (from q in obbdConoceAColombiaEntities.tbDeportes
                                                         where q.depoCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obtbDeportes.depoNombre = ob.stNombre;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteDeportes(Models.clsDeportes ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDeportes obtbDeportes = (from q in obbdConoceAColombiaEntities.tbDeportes
                                                         where q.depoCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbDeportes.Remove(obtbDeportes);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsDeportes> getDeportes()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDeportes> lstclsDeportes
                        = (from q in obbdConoceAColombiaEntities.tbDeportes
                           select new Models.clsDeportes
                           {
                               lgCodigo = q.depoCodigo,
                               stNombre = q.depoNombre
                           }).ToList();

                    return lstclsDeportes;
                }
                    
            }
            catch(Exception ex) { throw ex; }
        }
    }
}
