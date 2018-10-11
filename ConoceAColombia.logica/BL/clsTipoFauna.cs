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

        public void InsertTipoFauna(Models.clsTipoFauna obclsTipoFauna)
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
                }
            }
            catch (Exception ew)
            {
                throw ew;
            }
        }
    }
}
