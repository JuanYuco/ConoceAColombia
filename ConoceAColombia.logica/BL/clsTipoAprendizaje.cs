using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsTipoAprendizaje
    {
        public List<Models.clsTipoAprendizaje> getTipoAprendizaje()
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsTipoAprendizaje> lstclsTipoAprendizaje = (from q in obDatos.tbTipoPersonajeAprendizaje
                                                                       select new Models.clsTipoAprendizaje
                                                                       {
                                                                           lgCodigo = q.tiapCodigo,
                                                                           stDescripcion = q.tiapDescripcion
                                                                       }).ToList();
                    return lstclsTipoAprendizaje;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }



        public string InsertTipoAprendizaje(Models.clsTipoAprendizaje obclsTipoAprendizaje)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbTipoPersonajeAprendizaje.Add(new Entidades.tbTipoPersonajeAprendizaje
                    {
                        tiapCodigo = obclsTipoAprendizaje.lgCodigo,
                        tiapDescripcion = obclsTipoAprendizaje.stDescripcion
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


        public string updateTipoAprendizaje(Models.clsTipoAprendizaje ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoPersonajeAprendizaje obtbTipoAprendizaje = (from q in obbdConoceAColombiaEntities.tbTipoPersonajeAprendizaje
                                                                 where q.tiapCodigo == ob.lgCodigo
                                                                 select q).FirstOrDefault();
                    obtbTipoAprendizaje.tiapDescripcion = ob.stDescripcion;
                    obbdConoceAColombiaEntities.SaveChanges();

                    return "Se realizo proceso con exito";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string deleteTipoAprendizaje(Models.clsTipoAprendizaje ob)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obbdConoceAColombiaEntities =
                    new Entidades.bdConoceAColombiaEntities())
                {
                    Entidades.tbTipoPersonajeAprendizaje obtbTipoAprendizaje = (from q in obbdConoceAColombiaEntities.tbTipoPersonajeAprendizaje
                                                                 where q.tiapCodigo == ob.lgCodigo
                                                                 select q).FirstOrDefault();
                    obbdConoceAColombiaEntities.tbTipoPersonajeAprendizaje.Remove(obtbTipoAprendizaje);
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
