using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ConoceAColombia.web.Controllers
{
    public class ArtistasControllers
    {
        public DataSet getConsultarArtistasController()
        {
            try
            {
                logica.BL.clsArtistas obclsArtistas = new logica.BL.clsArtistas();
                return obclsArtistas.getConsultarArtistas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public String setAdministarArtistasController(logica.Models.clsArtistas obclsArtistasModels, int inOpcion)
        {
            try
            {
                logica.BL.clsArtistas obclsArtistas = new logica.BL.clsArtistas();
                return obclsArtistas.setAdministrarArtista(obclsArtistasModels, inOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}