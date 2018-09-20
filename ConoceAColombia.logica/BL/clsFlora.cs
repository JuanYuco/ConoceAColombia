using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConoceAColombia.logica.BL
{
    public class clsFlora
    {
        public List<Models.clsFlora>getFlora()
        {
            try
            {
                using(Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFlora> lstclFlora = (from q in obDatos.tbFlora
                                                        join tbDep in obDatos.tbDepartamento on q.depaCodigo equals tbDep.depaCodigo
                                                        select new Models.clsFlora
                                                        {
                                                            lgCodigo = q.florCodigo,
                                                            stNombre = q.florNomComun,
                                                            stNombreCientifico = q.florNomCientifico,
                                                            stAbundancia = q.florAbundancia,
                                                            stDescripcion = q.florDescripcion,
                                                            stPeriodoFloracion = q.florPeriodoFloracion,
                                                            stLatitud = q.florLatitud,
                                                            stLongitud = q.florLongitud,
                                                            obclsDepartamentos = new Models.clsDepartamentos
                                                            {
                                                                inCodigo = q.depaCodigo,
                                                                stNombre = tbDep.depaNombre
                                                                
                                                            }
                                                        }).ToList();
                    return lstclFlora;
                                                        
                }
            }catch(Exception ew)
            {
                throw ew;
            }
        }




        public void InsertFlora(Models.clsFlora obclsFlora)
        {
            try
            {
                using(Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    obDatos.tbFlora.Add(new Entidades.tbFlora
                    {
                        florCodigo = obclsFlora.lgCodigo,
                        florNomComun = obclsFlora.stNombre,
                        florNomCientifico = obclsFlora.stNombreCientifico,
                        florDescripcion = obclsFlora.stDescripcion,
                        florAbundancia = obclsFlora.stAbundancia,
                        florPeriodoFloracion = obclsFlora.stPeriodoFloracion,
                        florLatitud = obclsFlora.stLatitud,
                        florLongitud = obclsFlora.stLongitud,
                        depaCodigo = obclsFlora.obclsDepartamentos.inCodigo
                    });
                    obDatos.SaveChanges();
                }
            }catch(Exception ew)
            {
                throw ew;
            }
        }


        public List<Models.clsFlora> getFloraNuevo(string stNombreCompleto)
        {
            try
            {
                using (Entidades.bdConoceAColombiaEntities obDatos = new Entidades.bdConoceAColombiaEntities())
                {
                    List<Models.clsFlora> lstclFlora = (from q in obDatos.tbFlora
                                                        where (q.florNomComun + " " + q.florNomCientifico).ToLower().Contains(stNombreCompleto.ToLower())
                                                        select new Models.clsFlora
                                                        {
                                                            lgCodigo = q.florCodigo,
                                                            stNombre = q.florNomComun,
                                                            stNombreCientifico = q.florNomCientifico
                                                        } ).ToList();
                    return lstclFlora;

                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}
