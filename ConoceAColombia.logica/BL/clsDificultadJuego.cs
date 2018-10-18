using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsDificultadJuego
    {
        public string addDificultadJuego(Models.clsDicultadJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDificultadJuego obtbDificultadJuego= new Entidades.tbDificultadJuego
                    {
                        dijuCodigo = ob.lgCodigo,
                        dijuDescripcion = ob.stDescripcion
                    };
                    obbdConoceAColombiaEntities.tbDificultadJuego.Add(obtbDificultadJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string updateDificultadJuego(Models.clsDicultadJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDificultadJuego obtbDificultadJuego = (from q in obbdConoceAColombiaEntities.tbDificultadJuego
                                                         where q.dijuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obtbDificultadJuego.dijuDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteDificultadJuego(Models.clsDicultadJuego ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbDificultadJuego obtbDificultadJuego = (from q in obbdConoceAColombiaEntities.tbDificultadJuego
                                                         where q.dijuCodigo == ob.lgCodigo
                                                         select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbDificultadJuego.Remove(obtbDificultadJuego);
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Models.clsDicultadJuego> getDificultadJuego()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsDicultadJuego> lstclsDificultadJuego
                        = (from q in obbdConoceAColombiaEntities.tbDificultadJuego
                           select new Models.clsDicultadJuego
                           {
                               lgCodigo = q.dijuCodigo,
                               stDescripcion = q.dijuDescripcion
                           }).ToList();

                    return lstclsDificultadJuego;
                }

            }
            catch (Exception ex) { throw ex; }
        }
    }
}
