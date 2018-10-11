using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
namespace ConoceAColombia.Test
{
    [TestClass]
    public class clsPrueba
    {
        [TestMethod]
        public void verificar_suma()
        {
            //Arrange instancias de objetos
            logica.BL.clsSuma obclsSuma = new logica.BL.clsSuma();
            //Act
            int result = obclsSuma.getSuma(5,9);
            //Assert lo que espero que se cumpla
            Assert.AreEqual(14,result);
        }
        [TestMethod]
        public void verficar_TipodeArquitectura()
        {
            //Arrange 
            logica.BL.clsTipodeArquitectura obclsTipodeArquitectura = new logica.BL.clsTipodeArquitectura();
            logica.Models.clsTipodeArquitectura obclsTipodeArquitecturaModels = new logica.Models.clsTipodeArquitectura {
                lgCodigo = 5,
                stDescripcion = "Leonardo "
            
            };
            //Act 
            string mensaje = obclsTipodeArquitectura.setAdministrarTiposdeArquitectura(obclsTipodeArquitecturaModels,1);
            //Assert 
            Assert.AreEqual("Se realizo proceso con exito",mensaje);
        }
        [TestMethod]
        public void verificar_Arquitectura()
        {
            //Arrange
            logica.BL.clsArquitectura obclsArquitectura = new logica.BL.clsArquitectura();
            logica.Models.clsArquitectura obclsArquitecturaModels = new logica.Models.clsArquitectura
            {
                lgCodigo = 20,
                stNombre = "Prueba",
                stCiudad = "Cali",
                stLatitud = "121212",
                stLongitud = "1121212",
                clsDepartamentos = new logica.Models.clsDepartamentos { inCodigo=1},
                clsTipodeArquitectura = new logica.Models.clsTipodeArquitectura { lgCodigo=1}
            };
            //act
            string mensaje = obclsArquitectura.setAdministrarArquitectura(obclsArquitecturaModels, 1);
            //Assert
            Assert.AreEqual("Se realizo proceso con exito", mensaje);
        }


        [TestMethod]
        public void insertFloraTest()
        {
            //ARRANGE
            ws.Servicios.wsFlora obwsFlora = new ws.Servicios.wsFlora();

            //ACT
            logica.Models.clsFlora clsFlora = new logica.Models.clsFlora
            {
                lgCodigo = 2,
                stNombre = "Rosas",
                stNombreCientifico = "No se Cual es",
                stDescripcion = "Es una flor",
                stAbundancia = "En cada esquina",
                stLatitud = "ICKKCK",
                stLongitud = "ICKKCK",
                stPeriodoFloracion = "No se",
                obclsDepartamentos = new logica.Models.clsDepartamentos
                {
                    inCodigo = 1
                }
            };

            
            string json = JsonConvert.SerializeObject(clsFlora);
            //ASSERT
            obwsFlora.InsertFlora(json);
        }



        [TestMethod]
        public void insertTipoFaunaTest()
        {
            //ARRANGE
            ws.Servicios.wsTipoFauna obwsTipoFauna = new ws.Servicios.wsTipoFauna();

            //ACT
            logica.Models.clsTipoFauna clsTipoFauna = new logica.Models.clsTipoFauna
            {
                lgCodigo = 2,
                stDescripcion = "Mamifero"
                
            };
            string json = JsonConvert.SerializeObject(clsTipoFauna);
            //ASSERT
            obwsTipoFauna.InsertTipoFauna(json);
        }
    }
}
