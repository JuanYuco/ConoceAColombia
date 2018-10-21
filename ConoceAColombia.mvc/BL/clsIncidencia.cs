using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConoceAColombia.mvc.BL
{
    public class clsIncidencia
    {

        public List<Models.Incidencia> getIncidencia()
        {
            try
            {
                using(var db = new DAL.bdConoceAColombiaEntities())
                {
                    var result = (from q in db.incidencia
                                  join tbEi in db.tbEstadoIncidente on q.estado_incidente equals tbEi.ID
                                  join tbTi in db.Tipo_Incidencia on q.tipo_incidencia_id equals tbTi.id
                                  select new Models.Incidencia
                                  {
                                      Id = q.id,
                                      Identificacion =(long)q.identificacion,
                                      PrimerNombre = q.primer_nombre,
                                      SegundoNombre = q.segundo_nombre,
                                      PrimerApellido = q.primer_apellido,
                                      SegundoApellido = q.segundo_apellido,
                                      Direccion = q.direccion,
                                      Telefono = q.telefono,
                                      Correo = q.correo,
                                      estadoIncidencia = new Models.EstadoIncidencia
                                      {
                                          inId = (int)q.estado_incidente,
                                          stDescripcion = tbEi.descripcion
                                      },
                                      TipoIncidencia = new Models.TipoIncidencia
                                      {
                                          inId = (int)q.tipo_incidencia_id,
                                          stDescripcion = tbTi.descripcion
                                      }
                                  }).ToList();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public List<Models.Incidencia> getIncidencia(int id)
        {
            try
            {
                using (var db = new DAL.bdConoceAColombiaEntities())
                {
                    var result = (from q in db.incidencia
                                  join tbEi in db.tbEstadoIncidente on q.estado_incidente equals tbEi.ID
                                  join tbTi in db.Tipo_Incidencia on q.tipo_incidencia_id equals tbTi.id
                                  where q.id == id
                                  select new Models.Incidencia
                                  {
                                      Id = q.id,
                                      Identificacion = (long)q.identificacion,
                                      PrimerNombre = q.primer_nombre,
                                      SegundoNombre = q.segundo_nombre,
                                      PrimerApellido = q.primer_apellido,
                                      SegundoApellido = q.segundo_apellido,
                                      Direccion = q.direccion,
                                      Telefono = q.telefono,
                                      Correo = q.correo,
                                      estadoIncidencia = new Models.EstadoIncidencia
                                      {
                                          inId = (int)q.estado_incidente,
                                          stDescripcion = tbEi.descripcion
                                      },
                                      TipoIncidencia = new Models.TipoIncidencia
                                      {
                                          inId = (int)q.tipo_incidencia_id,
                                          stDescripcion = tbTi.descripcion
                                      }
                                  }).ToList();
                    return result;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public void CreateIncidencia(Models.Incidencia incidencia)
        {
            try
            {
                using (var db = new DAL.bdConoceAColombiaEntities())
                {
                    db.incidencia.Add(new DAL.incidencia
                    {
                        identificacion = incidencia.Identificacion,
                        primer_nombre = incidencia.PrimerNombre,
                        segundo_nombre = incidencia.SegundoNombre,
                        primer_apellido = incidencia.PrimerApellido,
                        segundo_apellido = incidencia.SegundoApellido,
                        direccion = incidencia.Direccion,
                        telefono = incidencia.Telefono,
                        correo = incidencia.Correo,
                        estado_incidente = incidencia.estadoIncidencia.inId,
                        tipo_incidencia_id = incidencia.TipoIncidencia.inId
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}