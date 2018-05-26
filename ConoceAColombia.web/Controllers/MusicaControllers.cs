using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class MusicaControllers
    {

        public DataSet getConsultarMusicaController()
        {
            try
            {
                logica.BL.clsMusica obclsMusica = new logica.BL.clsMusica();
                return obclsMusica.getConsultarMusica();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public String setAdministarMusicaController(logica.Models.clsMusica obclsMusicaModels, int inOpcion)
        {
            try
            {
                logica.BL.clsMusica obclsMusica = new logica.BL.clsMusica();
                return obclsMusica.setAdministrarMusica(obclsMusicaModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}