using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.mvc.BL
{
    public class clsEstadoIncidencia
    {
        public List<Models.EstadoIncidencia> getEstadoIncidencia()
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    List<Models.EstadoIncidencia> estado_incidencia = new List<Models.EstadoIncidencia>();
                    estado_incidencia = (from q in obDatos.tbEstadoIncidente
                                         select new Models.EstadoIncidencia
                                         {
                                             inId = q.ID,
                                             stDescripcion = q.descripcion
                                         }).ToList();

                    return estado_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public List<Models.EstadoIncidencia> getEstadoIncidencia(Models.EstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    List<Models.EstadoIncidencia> estado_incidencia = new List<Models.EstadoIncidencia>();
                    estado_incidencia = (from q in obDatos.tbEstadoIncidente
                                         where q.ID == obEstadoIncidencia.inId
                                         select new Models.EstadoIncidencia
                                         {
                                             inId = q.ID,
                                             stDescripcion = q.descripcion
                                         }).ToList();

                    return estado_incidencia;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void createEstadoIncidencia(Models.EstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    obDatos.tbEstadoIncidente.Add(new DAL.tbEstadoIncidente
                    {
                        descripcion = obEstadoIncidencia.stDescripcion
                    });
                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void updateEstadoIncidencia(Models.EstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    DAL.tbEstadoIncidente estado_incidencia = new DAL.tbEstadoIncidente();
                    estado_incidencia = (from q in obDatos.tbEstadoIncidente
                                         where q.ID == obEstadoIncidencia.inId
                                         select q).FirstOrDefault();

                    estado_incidencia.descripcion = obEstadoIncidencia.stDescripcion;
                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void deleteEstadoIncidencia(Models.EstadoIncidencia obEstadoIncidencia)
        {
            try
            {
                using (DAL.bdConoceAColombiaEntities obDatos = new DAL.bdConoceAColombiaEntities())
                {
                    DAL.tbEstadoIncidente estado_incidencia = new DAL.tbEstadoIncidente();
                    estado_incidencia = (from q in obDatos.tbEstadoIncidente
                                         where q.ID == obEstadoIncidencia.inId
                                         select q).FirstOrDefault();

                    obDatos.tbEstadoIncidente.Remove(estado_incidencia);
                    obDatos.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}